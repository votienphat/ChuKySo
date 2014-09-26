using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dsms.Entity;
using Dsms.Repository.Models;
using Dsms.Repository.Models.Request;

namespace Dsms.Repository
{
    public class CompanyRepository : BaseRepository<CKS_Company>, ICompanyRepository
    {
        public CompanyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
