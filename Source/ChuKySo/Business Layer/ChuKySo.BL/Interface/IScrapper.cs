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
    }
}
