using System;
using System.Threading;
using System.Windows.Forms;
using ChuKySo.BL;
using Log;

namespace ChuKySo.Tools
{
    public partial class frmMain : Form
    {
        #region Variable

        private Thread _scrapperThread;

        #endregion

        #region General

        public frmMain()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ScrapperInit();
        }

        /// <summary>
        /// Hiển thị Log lên textbox
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="text"></param>
        private void SetLog(TextBox txt, object text)
        {
            if (txt != null && text != null)
            {
                Invoke((MethodInvoker)delegate
                {
                    txt.Text += text + Environment.NewLine;
                    txt.SelectionStart = txt.Text.Length;
                    txt.ScrollToCaret();
                });
            }
        }

        #endregion

        #region Notify Area

        private void ScrapperInit()
        {
            btnStart.Enabled = txtLink.Enabled = true;
            btnStop.Enabled = false;
        }

        private void ScrapperStart()
        {
            if (_scrapperThread != null)
            {
                _scrapperThread.Abort();
            }
            _scrapperThread = new Thread(ScrapperProcessing) { IsBackground = true };

            btnStart.Enabled = txtLink.Enabled = false;
            btnStop.Enabled = true;
        }

        private void ScrapperProcessing()
        {
            try
            {
                SetLog(txtScrapperLog, String.Format("{0:yyyy-MM-dd HH:mm:ss} | Bắt đầu tìm", DateTime.Now));
                SetLog(txtScrapperLog,
                       String.Format("{0:yyyy-MM-dd HH:mm:ss} | Số công ty tìm được: {1}", DateTime.Now,
                                     BoFactory.Scrapper.SearchingCompany(txtLink.Text)));
                SetLog(txtScrapperLog, String.Format("{0:yyyy-MM-dd HH:mm:ss} | Kết thúc tìm công ty", DateTime.Now));
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("ScrapperProcessing", ex);
            }

            Invoke((MethodInvoker)ScrapperInit);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetLog(txtScrapperLog, String.Format("{0:yyyy-MM-dd HH:mm:ss} | Bắt đầu", DateTime.Now));
            ScrapperStart();
            _scrapperThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetLog(txtScrapperLog, String.Format("{0:yyyy-MM-dd HH:mm:ss} | Dừng", DateTime.Now));
            ScrapperInit();

            if (_scrapperThread.IsAlive)
            {
                _scrapperThread.Abort();
            }
        }

        #endregion
    }
}
