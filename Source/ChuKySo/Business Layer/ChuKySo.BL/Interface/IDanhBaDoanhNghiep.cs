namespace ChuKySo.BL.Business
{
    public interface IDanhBaDoanhNghiep
    {
        /// <summary>
        /// Get company from site danhbadoanhnghiep.vn
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int SearchingCompany(string link);
    }
}
