using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsms.Entity;

namespace Dsms.Service
{
    public interface ICompanyService
    {
        IEnumerable<CKS_Company> GetCompanies();
    }
}
