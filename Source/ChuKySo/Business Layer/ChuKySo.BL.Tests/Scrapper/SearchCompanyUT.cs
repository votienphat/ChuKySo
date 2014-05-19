using ChuKySo.BL.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChuKySo.BL.Tests.Scrapper
{
    [TestClass]
    public class SearchCompanyUT
    {
        [TestMethod]
        public void InsertCompany()
        {
            string url = "http://www.danhbadoanhnghiep.vn/result.asp";
            BoFactory.Scrapper.SearchingCompany(url);
        }
    }
}
