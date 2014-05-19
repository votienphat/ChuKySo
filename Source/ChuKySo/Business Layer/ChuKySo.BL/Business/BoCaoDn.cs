using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using ChuKySo.BL.Business;
using ChuKySo.BL.Model.Entity;
using Common;
using HtmlAgilityPack;
using Log;

namespace ChuKySo.BL.Business
{
    public class BoCaoDn : IBoCaoDn
    {
        public int SearchingCompany(string link)
        {
            int result = 0, start = 0;

            string requestUrl = link, referer = string.Empty, html, next;

            if (NetworkCommon.SendGetRequest(requestUrl, new CookieContainer(), referer, out html, out next, true))
            {
                // Get number of company
                result = GetCompanyQuantity(html);

                while (start < result)
                {
                    GetCompanyList(html);

                    start += 10;
                    NetworkCommon.SendGetRequest(requestUrl + "&limitstart=" + start,
                        new CookieContainer(), referer, out html, out next, true);
                }
            }

            return result;
        }

        /// <summary>
        /// Get number of companies
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public int GetCompanyQuantity(string html)
        {
            int result = 0;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get body content
            var linkDocument = htmlDocument.DocumentNode.Descendants("div")
                .FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("bodyCol"));

            if (linkDocument != null)
            {
                var spanNumber = linkDocument.Descendants("span").FirstOrDefault(x => x.InnerText.Contains("(Hiện có:"));
                if (spanNumber != null)
                {
                    var number = spanNumber.InnerText.Replace("(Hiện có:", string.Empty)
                        .Replace("bố cáo)", string.Empty).Trim();
                    Int32.TryParse(number, out result);
                }
            }
            return result;
        }

        public void GetCompanyList(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get body content
            var links = htmlDocument.DocumentNode.Descendants("h4")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("titleLink"));

            foreach (var htmlNode in links)
            {
                var objLink = htmlNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("href"));
                if (objLink != null)
                {
                    string requestUrl = objLink.Attributes["href"].Value,
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
        public void InsertCompany(string html)
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

                    #region Main Info

                    var mainInfo = htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("infoDetail"));

                    if (mainInfo != null)
                    {
                        foreach (var descendant in mainInfo.Descendants("div"))
                        {
                            var objTitle = descendant.Descendants("span").FirstOrDefault();
                            if (objTitle != null)
                            {
                                objTitle.Remove();
                                string title = objTitle.InnerText.Trim().ToLower(),
                                       value = descendant.InnerText.Trim();

                                switch (title)
                                {
                                    case "tên doanh nghiệp:":
                                        company.Title = value;
                                        break;
                                    case "tên giao dịch:":
                                        company.TransTitle = value;
                                        break;
                                    case "loại hình doanh nghiệp:":
                                        company.CompanyType = value;
                                        break;
                                    case "địa chỉ:":
                                        company.Address = value;
                                        break;
                                    case "tỉnh/thành phố:":
                                        company.City = value;
                                        break;
                                    case "số điện thoại:":
                                        company.Phone = value;
                                        break;
                                    case "fax:":
                                        company.Fax = value;
                                        break;
                                    case "email:":
                                        company.Email = value;
                                        break;
                                    case "website:":
                                        company.Website = value;
                                        break;
                                }

                            }
                        }
                    }

                    #endregion

                    #region Sub Info

                    var subInfo = htmlDocument.DocumentNode.Descendants("div")
                        .FirstOrDefault(d => d.Attributes.Contains("style")
                            && d.Attributes["style"].Value.Contains("background:#f5f5f5; padding:10px"));

                    if (subInfo != null)
                    {
                        foreach (var descendant in subInfo.Descendants("div"))
                        {
                            var objTitle = descendant.Descendants("span").FirstOrDefault();
                            if (objTitle != null)
                            {
                                objTitle.Remove();
                                string title = objTitle.InnerText.Trim().ToLower(),
                                       value = descendant.InnerText.Trim();

                                switch (title)
                                {
                                    case "mã số doanh nghiệp:":
                                        company.CompanyCode = value;
                                        break;
                                    case "ngày hoạt động chính thức:":
                                        company.ActiveDate = GetDate(value);
                                        break;
                                    case "người đại diện pháp luật:":
                                        company.LegalRepresentive = value;
                                        break;
                                    case "nơi thường trú:":
                                        company.LegalRepresentiveAddress = value;
                                        break;
                                    case "vốn điều lệ:":
                                        company.AuthorizedCapital = value;
                                        break;
                                    case "ngành nghề kinh doanh:":
                                        company.DescriptionMajor = value;
                                        break;
                                    case "thông tin thêm:":
                                        company.Description = value;
                                        break;
                                    case "hội đồng quản trị(hoặc danh sách cổ đông):":
                                        company.Directors = value;
                                        break;
                                }

                            }
                        }
                    }

                    var allowedDateObj = htmlDocument.DocumentNode.Descendants("td")
                        .FirstOrDefault(d => d.Id.Equals("scate"));
                    if (allowedDateObj != null)
                    {
                        var span = allowedDateObj.Descendants("span").FirstOrDefault();
                        if (span != null)
                        {
                            span.Remove();
                            company.AllowedDate = GetDate(Regex.Replace(allowedDateObj.InnerText, @"\t|\n|\r", "").Trim());
                        }
                    }

                    #endregion

                               var tmpCompany = RepositoryFactory.Company.GetByCode(company.Title);

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

        private DateTime? GetDate(string value)
        {
            try
            {
                var arr = value.Trim().Split('/');
                int day, month, year;
                Int32.TryParse(arr[0], out day);
                Int32.TryParse(arr[1], out month);
                Int32.TryParse(arr[2], out year);
                return new DateTime(year, month, day);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
