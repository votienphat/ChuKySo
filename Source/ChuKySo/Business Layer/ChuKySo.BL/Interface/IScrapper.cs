using System;
using System.Collections.Generic;
using ChuKySo.BL.Model;

namespace ChuKySo.BL.Business
{
    public interface IScrapper
    {
        /// <summary>
        /// Tìm thông tin công ty
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int SearchingCompany(string link);

        /// <summary>
        /// Lấy thông tin công ty. Phiên bản mới
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="urls"></param>
        /// <param name="setTextCallback">Nếu khác null thì sẽ ghi log</param>
        void GetCompany(int siteId, List<RequestCompanyModel> urls, Delegate setTextCallback = null);

        /// <summary>
        /// Lấy danh sách khu vực, ngành nghề
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="siteUrl"></param>
        List<AreaModel> GetArea(int siteId, string siteUrl);
    }
}
