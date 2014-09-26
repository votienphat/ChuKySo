namespace ChuKySo.BL.Business
{
    public interface IDuLieuCongTy
    {
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
