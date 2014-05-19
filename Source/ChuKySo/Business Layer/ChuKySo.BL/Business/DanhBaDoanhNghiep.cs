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
    public class DanhBaDoanhNghiep : IDanhBaDoanhNghiep
    {
        public int SearchingCompany(string link)
        {
            int result = 0, page = 1, province, maxPage;

            // Get province Id
            var uri = new Uri(link);
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (!Int32.TryParse(query.Get("slt_province"), out province))
            {
                return result;
            }

            string requestUrl = link, referer = string.Empty, html, next,
                domain = uri.OriginalString.Replace(uri.PathAndQuery, ""),
                data = String.Format("slt_province={1}&btnsubmit=T%C3%ACm+ki%E1%BA%BFm&AbsolutePage={0}", page, province);

            if (NetworkCommon.SendPostRequest(requestUrl, new CookieContainer(), data, referer, out html, out next, true))
            {
                // Get number of company
                result = GetCompanyQuantity(html, out maxPage);

                while (page <= maxPage)
                {
                    data = String.Format("slt_province={1}&btnsubmit=T%C3%ACm+ki%E1%BA%BFm&AbsolutePage={0}",
                        page, province);
                    NetworkCommon.SendPostRequest(requestUrl, new CookieContainer(),
                        data, referer, out html, out next, true);
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

            // Get body content
            var info = htmlDocument.DocumentNode.Descendants("div")
                .FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("linfo"));

            if (info != null)
            {
                var spanNumber = info.InnerText.Split(' ');
                if (spanNumber.Any())
                {
                    Int32.TryParse(spanNumber[0], out result);
                    Int32.TryParse(spanNumber[spanNumber.Length - 1], out maxPage);
                }
            }
            return result;
        }

        private void GetCompanyList(string domain, string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get body content
            var table = htmlDocument.DocumentNode.Descendants("table")
                .FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("tbl-data"));
            var links = table.Descendants("tbody").FirstOrDefault().Descendants("tr")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("odd"));

            foreach (var htmlNode in links)
            {
                var objLink = htmlNode.Descendants("a")
                    .FirstOrDefault(x => x.Attributes.Contains("href") && x.Attributes["href"].Value.Contains("showdetail"));
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

                var infoBox = htmlDocument.DocumentNode.Descendants("dl")
                    .FirstOrDefault(d => d.Attributes.Contains("class")
                                         && d.Attributes["class"].Value.Contains("company-info"));
                var infos = infoBox.Descendants("dd").ToArray();

                company.Title = HttpUtility.HtmlDecode(infos[0].InnerText).Trim();
                if (string.IsNullOrEmpty(company.Title))
                {
                    company.Title = HttpUtility.HtmlDecode(infos[1].InnerText).Trim();
                }

                company.Address = HttpUtility.HtmlDecode(infos[4].InnerText).Trim();
                company.City = HttpUtility.HtmlDecode(infos[5].InnerText).Trim();
                company.CompanyType = HttpUtility.HtmlDecode(infos[6].InnerText).Trim();
                company.Phone = HttpUtility.HtmlDecode(infos[8].InnerText).Trim();
                company.Fax = HttpUtility.HtmlDecode(infos[9].InnerText).Trim();
                company.Email = HttpUtility.HtmlDecode(infos[10].InnerText).Trim();
                company.Website = HttpUtility.HtmlDecode(infos[11].InnerText).Trim();

                company.DescriptionMajor = HttpUtility.HtmlDecode(infos[7].InnerText).Trim();
                company.Description = HttpUtility.HtmlDecode(infos[12].InnerText).Trim();
                company.Directors = HttpUtility.HtmlDecode(infos[3].InnerText).Trim();

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
