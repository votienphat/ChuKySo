using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using ChuKySo.BL.Business;
using ChuKySo.BL.Model.Entity;
using Common;
using HtmlAgilityPack;
using Log;

namespace ChuKySo.BL.Business
{
    public class DuLieuCongTy : IDuLieuCongTy
    {
        /// <summary>
        /// Get company from site danhbadoanhnghiep.vn
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        /// <history>
        /// 18/09/2014 phat.vo: Create new
        /// </history>
        public int SearchingCompany(string link)
        {
            int result = 0, page = 1;

            // Get province Id
            var uri = new Uri(link);
            string domain = uri.OriginalString;
            string requestUrl = link, referer = string.Empty, html, next;

            if (NetworkCommon.SendGetRequest(requestUrl, new CookieContainer(), referer, out html, out next, true))
            {
                // Get number of company
                int maxPage;
                result = GetCompanyQuantity(html, out maxPage);

                while (page <= maxPage)
                {
                    requestUrl = string.Format("{0}/index?page={1}", link, page);
                    NetworkCommon.SendGetRequest(requestUrl, new CookieContainer(), referer, out html, out next, true);
                    page++;

                    GetCompanyList(domain, html);
                }
            }

            return result;
        }

        /// <summary>
        /// Get number of companies
        /// </summary>
        /// <param name="html"></param>
        /// <param name="maxPage"></param>
        /// <returns></returns>
        private int GetCompanyQuantity(string html, out int maxPage)
        {
            int result = 0;
            maxPage = 0;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var info = htmlDocument.DocumentNode.Descendants("ul")
                .FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("pagination"));

            if (info != null)
            {
                // Lấy đối tượng cuối cùng là trang lớn nhất
                var link = info.Descendants("a").LastOrDefault();

                if (link != null)
                {
                    var spanNumber = link.GetAttributeValue("href", string.Empty);
                    if (!string.IsNullOrEmpty(spanNumber))
                    {
                        var index = spanNumber.LastIndexOf("=");
                        if (index >= 0)
                        {
                            spanNumber = spanNumber.Substring(index + 1);
                            Int32.TryParse(spanNumber, out maxPage);
                        }
                    }
                }
            }
            return result;
        }

        private void GetCompanyList(string domain, string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get body content
            var links = htmlDocument.DocumentNode.Descendants("div")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("search-results"));

            foreach (var htmlNode in links)
            {
                var objLink = htmlNode.Descendants("a")
                    .FirstOrDefault(x => x.Attributes.Contains("href") && x.Attributes["href"].Value.Contains("company"));
                if (objLink != null)
                {
                    string requestUrl = String.Format("{0}/{1}", domain, objLink.Attributes["href"].Value),
                        referer = string.Empty, next;
                    if (NetworkCommon.SendGetRequest(requestUrl, new CookieContainer(), referer, out html, out next, true))
                    {
                        InsertCompany(html);
                    }
                }
            }
        }

        /// <summary>
        /// Get the insert company into database
        /// </summary>
        /// <param name="html"></param>
        private void InsertCompany(string html)
        {
            try
            {
                var company = new CKS_Company
                {
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var infoBox = htmlDocument.DocumentNode.Descendants("div")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                                         && d.Attributes["class"].Value.Equals("home", StringComparison.OrdinalIgnoreCase));
                if (infoBox == null)
                {
                    return;
                }

                var title = infoBox.Descendants("h4").FirstOrDefault();
                company.Title = title == null ? string.Empty : title.InnerText;

                var infos = infoBox.Descendants("li").ToArray();

                if (string.IsNullOrEmpty(company.Title))
                {
                    company.Title = HttpUtility.HtmlDecode(infos[0].InnerText).Trim();
                }
                company.TransTitle = HttpUtility.HtmlDecode(infos[0].InnerText).Replace("Tên giao dịch:", string.Empty).Trim();
                company.Address = HttpUtility.HtmlDecode(infos[1].InnerText).Replace("Địa chỉ:", string.Empty).Trim();
                company.Directors = HttpUtility.HtmlDecode(infos[2].InnerText).Replace("Giám đốc:", string.Empty).Trim();
                company.Phone = HttpUtility.HtmlDecode(infos[7].InnerText).Replace("Điện thoại:", string.Empty).Trim();
                company.DescriptionMajor = HttpUtility.HtmlDecode(infos[6].InnerText).Replace("Hoạt động chính:", string.Empty).Trim();
                company.CompanyCode = HttpUtility.HtmlDecode(infos[4].InnerText).Replace("Mã số thuế:", string.Empty).Trim();
                //company.Fax = HttpUtility.HtmlDecode(infos[9].InnerText).Trim();
                //company.Email = HttpUtility.HtmlDecode(infos[10].InnerText).Trim();
                //company.Website = HttpUtility.HtmlDecode(infos[11].InnerText).Trim();

                var tmpCompany = RepositoryFactory.Company.GetByTitle(company.Title);

                if (tmpCompany == null)
                {
                    RepositoryFactory.Company.Insert(company);
                }
            }
            catch (Exception ex)
            {
                SingletonLogger.Instance.Error("InsertCompany", ex);
            }
        }
    }
}
