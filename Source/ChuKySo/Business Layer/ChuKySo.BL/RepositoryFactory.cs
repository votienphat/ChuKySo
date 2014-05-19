using ChuKySo.BL.Repository;

namespace ChuKySo.BL
{
    public class RepositoryFactory
    {
        public static ICompanyRepository Company { get { return new CompanyRepository(); } }
    }
}
