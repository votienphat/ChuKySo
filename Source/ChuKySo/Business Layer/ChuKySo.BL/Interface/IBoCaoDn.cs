namespace ChuKySo.BL.Business
{
    public interface IBoCaoDn
    {
        /// <summary>
        /// Get company from site bocaodn.tienphong.vn
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int SearchingCompany(string link);
    }
}
