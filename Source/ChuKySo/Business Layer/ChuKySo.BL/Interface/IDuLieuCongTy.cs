using System;
using System.Collections.Generic;
using ChuKySo.BL.Model;

namespace ChuKySo.BL.Business
{
    public interface IDuLieuCongTy
    {
        /// <summary>
        /// Lấy thông tin công ty. Phiên bản mới
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="setTextCallback">Nếu khác null thì sẽ ghi log</param>
        void GetCompany(List<RequestCompanyModel> urls, Delegate setTextCallback = null);

        /// <summary>
        /// Lấy danh sách khu vực
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        /// <history>
        /// 25/09/14 phat.vo: Create new
        /// </history>
        List<AreaModel> GetArea(string siteUrl);
        
        /// <summary>
        /// Get company from site danhbadoanhnghiep.vn
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        /// <history>
        /// 18/09/2014 phat.vo: Create new
        /// </history>
        int SearchingCompany(string link);
    }
}
