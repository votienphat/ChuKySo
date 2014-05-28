using System.Collections.Generic;
using Dsms.Entity;
using Dsms.Repository;

namespace Dsms.Service
{
    public class CompanyService : ICompanyService
    {
        protected CompanyRepository CompanyRepository;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            CompanyRepository = new CompanyRepository(unitOfWork);
        }

        public IEnumerable<CKS_Company> GetCompanies()
        {
            return CompanyRepository.GetAll();
        }
    }
}
