using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChuKySo.BL;
using ChuKySo.BL.Enums;
using ChuKySo.BL.Model;
using ChuKySo.Tools.Models;
using Log;
using MyConfig;

namespace ChuKySo.Tools
{
    public partial class RunningForm : Form
    {
        #region Variables

        public delegate void SetLogCallback(object text);

        private Thread _scrapperThread;

        private List<CompanyDto> _companies;

        #endregion

        #region Constructor

        public RunningForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ScrapperInit();
            PreScrapperInit();
            CompanyInit();
        }

        private void CompanyInit()
        {
            var siteIds = GetValues<SiteId>();
            _companies = new List<CompanyDto>();
            foreach (var siteId in siteIds)
            {
                string title = string.Empty;
                string url = string.Empty;

                // Lấy tên của công ty
                MemberInfo memberInfo = typeof(SiteId).GetMember(siteId.ToString()).FirstOrDefault();
                if (memberInfo != null)
                {
                    var attribute = (DescriptionAttribute)
                                 memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                           .FirstOrDefault();
                    title = attribute == null ? title : attribute.Description;
                }

                foreach (SiteElement site in MyConfiguration.Sites)
                {
                    if (site.SiteId == (int)siteId)
                    {
                        url = site.SiteUrl;
                        _companies.Add(new CompanyDto
                        {
                            SiteId = (int)siteId,
                            Title = title,
                            Url = url
                        });
                    }
                }
            }

            // Sắp xếp công ty theo tên
            _companies = _companies.OrderBy(x => x.Title).ToList();
            _companies.Insert(0, new CompanyDto
                {
                    SiteId = 0,
                    Title = "--- Chọn trang web ---",
                });

            cboCompanies.DataSource = _companies;
            cboCompanies.DisplayMember = "Title";
        }

        /// <summary>
        /// Hàm lấy danh sách giá trị của Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        #endregion

        #region Events

        private void RunningForm_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ScrapperStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ScrapperInit();

            if (_scrapperThread.IsAlive)
            {
                _scrapperThread.Abort();
            }
        }

        private void cboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as ComboBox;
            if (cbo != null)
            {
                var company = cbo.SelectedValue as CompanyDto;
                if (company != null)
                {
                    if (company.SiteId != 0)
                    {
                        PreScrapperStart();
                    }
                    else
                    {
                        PreScrapperInit();
                    }
                }
            }
        }

        #endregion

        #region Lấy danh mục

        private void PreScrapperInit()
        {
            pnlMain.Enabled = false;
        }

        private void PreScrapperActive()
        {
            pnlMain.Enabled = true;
        }

        private void PreScrapperBindData(List<AreaModel> areas)
        {
            Invoke((MethodInvoker)delegate
            {
                lstArea.DataSource = areas;
                lstArea.DisplayMember = "Title";
            });
        }

        /// <summary>
        /// 
        /// </summary>
        private void PreScrapperStart()
        {
            if (_scrapperThread != null)
            {
                _scrapperThread.Abort();
            }
            _scrapperThread = new Thread(PreScrapperProcessing) { IsBackground = true };
            _scrapperThread.Start();
        }

        private void PreScrapperProcessing()
        {
            try
            {
                CompanyDto selectedSite = null;
                Invoke((MethodInvoker) delegate
                {
                    selectedSite = cboCompanies.SelectedValue as CompanyDto;
                });
                if (selectedSite == null)
                {
                    return;
                }

                var site = _companies.FirstOrDefault(x => x.SiteId == selectedSite.SiteId);

                if (site == null || string.IsNullOrEmpty(site.Url))
                {
                    SetLog("Không tìm thấy website");
                }
                else
                {
                    SetLog("Bắt đầu tìm danh mục");
                    var areas = BoFactory.Scrapper.GetArea(selectedSite.SiteId, site.Url);
                    SetLog(string.Format("Tìm thấy {0} khu vực", areas.Count));
                    PreScrapperBindData(areas);
                    SetLog("Kết thúc tìm danh mục");
                    Invoke((MethodInvoker)PreScrapperActive);
                }
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("PreScrapperProcessing", ex);
                Invoke((MethodInvoker)PreScrapperInit);
            }
        }

        #endregion

        #region Lấy danh sách

        private void ScrapperInit()
        {
            btnStart.Enabled = cboCompanies.Enabled = true;
            btnStop.Enabled = false;
        }

        private void ScrapperStart()
        {
            if (_scrapperThread != null)
            {
                _scrapperThread.Abort();
            }
            _scrapperThread = new Thread(ScrapperProcessing) { IsBackground = true };
            _scrapperThread.Start();

            btnStart.Enabled = cboCompanies.Enabled = false;
            btnStop.Enabled = true;
        }

        private void ScrapperProcessing()
        {
            try
            {
                SetLog("Bắt đầu tìm");

                CompanyDto selectedSite = null;
                var urls = new List<RequestCompanyModel>();
                Invoke((MethodInvoker)delegate
                {
                    selectedSite = cboCompanies.SelectedValue as CompanyDto;

                    urls.AddRange(lstArea.SelectedItems.OfType<AreaModel>()
                        .Select(area => new RequestCompanyModel
                        {
                            Url = area.Url
                        }));
                });
                if (selectedSite == null)
                {
                    return;
                }

                BoFactory.Scrapper.GetCompany(selectedSite.SiteId, urls, new SetLogCallback(SetLog));
                SetLog("Kết thúc tìm công ty");
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("ScrapperProcessing", ex);
            }

            Invoke((MethodInvoker)ScrapperInit);
        }

        #endregion

        #region Logging

        private void SetLog(object text)
        {
            if (text != null)
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (txtLog.InvokeRequired)
                {
                    var d = new SetLogCallback(SetLog);
                    Invoke(d, new[] { text });
                }
                else
                {
                    txtLog.Text += String.Format("{0:yyyy-MM-dd HH:mm:ss} | {1}", DateTime.Now, text) + Environment.NewLine;
                    txtLog.SelectionStart = txtLog.Text.Length;
                    txtLog.ScrollToCaret();
                }
            }
        }

        #endregion
    }
}
