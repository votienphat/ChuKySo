using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dsms.Entity;
using Dsms.Repository.Models;
using Dsms.Repository.Models.Request;

namespace Dsms.Repository
{
    public class ContractRepository : BaseRepository<CKS_Contract>, IContractRepository
    {

        public ContractRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
