using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Dsms.Entity;
using Dsms.Repository;
using Dsms.Repository.Models;
using Dsms.Repository.Models.Request;

namespace Dsms.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IContractRepository _contractRepository;

        public CompanyService(ICompanyRepository companyRepository, IContractRepository contractRepository)
        {
            _companyRepository = companyRepository;
            _contractRepository = contractRepository;
        }

        public IQueryable<CompanyRegisterInfo> GetCompanies(SearchCompanyRequest request)
        {
            string keywords = request.Keywords;

            var query = from company
                in _companyRepository.Get(x => string.IsNullOrEmpty(keywords) || x.Title.Contains(keywords))
                join contract in _contractRepository.Get()
                    on company.Id equals contract.CompanyId into joinTable
                from j in joinTable.DefaultIfEmpty()
                group company by new
                                 {
                                     company.Id,
                                     company.Title,
                                     company.Address,
                                     company.CompanyType
                                 }
                into g
                let totalQuantities = g.Sum(m => m.CKS_Contract.Count)
                select new CompanyRegisterInfo
                       {
                           Id = g.Key.Id,
                           Title = g.Key.Title,
                           Address = g.Key.Address,
                           CompanyType = g.Key.CompanyType,
                           ContractQuantity = totalQuantities
                       };

            return query
                .OrderBy(x => x.Title)
                .Skip(request.PageIndex*request.PageSize)
                .Take(request.PageSize);
        }

        public int Create(CKS_Company item)
        {
            return _companyRepository.Insert(item);
        }

        public int CreateWithContract(CKS_Company company, CKS_Contract contract)
        {
            if (Create(company) > 0)
            {
                contract.CompanyId = company.Id;
            }

            return 0;
        }

        public int Update(CKS_Company item)
        {
            return _companyRepository.Update(item);
        }
    }
}
