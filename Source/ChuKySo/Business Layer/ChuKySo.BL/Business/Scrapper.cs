using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using ChuKySo.BL.Business;
using ChuKySo.BL.Enums;
using ChuKySo.BL.Model;
using ChuKySo.BL.Model.Entity;
using Common;
using HtmlAgilityPack;
using Log;

namespace ChuKySo.BL.Business
{
    public class Scrapper : IScrapper
    {
        public int SearchingCompany(string link)
        {
            int result = 0;
            if (link.ToLower().Contains("bocaodn.tienphong.vn"))
            {
                result = BoFactory.BoCaoDn.SearchingCompany(link);
            }
            else if (link.ToLower().Contains("danhbadoanhnghiep.vn"))
            {
                result = BoFactory.DanhBaDoanhNghiep.SearchingCompany(link);
            }
            else if (link.ToLower().Contains("dulieucongty.com"))
            {
                result = BoFactory.DuLieuCongTy.SearchingCompany(link);
            }

            return result;
        }

        /// <summary>
        /// Lấy thông tin công ty. Phiên bản mới
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="urls"></param>
        /// <param name="setTextCallback">Nếu khác null thì sẽ ghi log</param>
        public void GetCompany(int siteId, List<RequestCompanyModel> urls, Delegate setTextCallback = null)
        {
            switch (siteId)
            {
                case (int)SiteId.BoCaoDoanhNghiep:
                    break;
                case (int)SiteId.DanhBaDoanhNghiep:
                    break;
                case (int)SiteId.DuLieuCongTy:
                    BoFactory.DuLieuCongTy.GetCompany(urls, setTextCallback);
                    break;
            }

        }

        /// <summary>
        /// Lấy danh sách khu vực, ngành nghề
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="siteUrl"></param>
        public List<AreaModel> GetArea(int siteId, string siteUrl)
        {
            var result = new List<AreaModel>();

            switch (siteId)
            {
                case (int)SiteId.BoCaoDoanhNghiep:
                    break;
                case (int)SiteId.DanhBaDoanhNghiep:
                    break;
                case (int)SiteId.DuLieuCongTy:
                    result = BoFactory.DuLieuCongTy.GetArea(siteUrl);
                    break;
            }

            return result;
        }

    }
}
