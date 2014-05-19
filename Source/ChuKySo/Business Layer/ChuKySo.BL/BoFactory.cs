using ChuKySo.BL.Business;

namespace ChuKySo.BL
{
    public class BoFactory
    {
        public static IBoCaoDn BoCaoDn { get { return new BoCaoDn(); } }
        public static IDanhBaDoanhNghiep DanhBaDoanhNghiep { get { return new DanhBaDoanhNghiep(); } }
        public static IScrapper Scrapper { get { return new Scrapper(); } }
    }
}
