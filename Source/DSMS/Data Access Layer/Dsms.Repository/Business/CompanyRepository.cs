using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsms.Entity;

namespace Dsms.Repository
{
    public class CompanyRepository : BaseRepository<CKS_Company>, ICompanyRepository
    {
        public CompanyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
