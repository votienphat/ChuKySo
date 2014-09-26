using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsms.Entity;
using Dsms.Repository.Models;
using Dsms.Repository.Models.Request;

namespace Dsms.Service
{
    public interface ICompanyService
    {
        /// <summary>
        /// Get company with contract info
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<CompanyRegisterInfo> GetCompanies(SearchCompanyRequest request);

        /// <summary>
        /// Insert new company
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int Create(CKS_Company item);

        /// <summary>
        /// Insert new company
        /// </summary>
        /// <param name="company"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        int CreateWithContract(CKS_Company company, CKS_Contract contract);

        /// <summary>
        /// Update company info
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        int Update(CKS_Company company);
    }
}
