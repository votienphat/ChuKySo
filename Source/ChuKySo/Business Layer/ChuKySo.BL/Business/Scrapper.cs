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

    }
}
