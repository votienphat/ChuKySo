using System.Linq;
using ChuKySo.BL.Model.Entity;
using ChuKySo.BL.Repository;

namespace ChuKySo.BL.Repository
{
    class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CKS_Company Insert(CKS_Company item)
        {
            dbEntities.CKS_Company.Add(item);
            dbEntities.SaveChanges();
            return item;
        }

        public CKS_Company GetByTitle(string value)
        {
            return (from x in dbEntities.CKS_Company
                    where x.Title.ToLower().Equals(value.ToLower())
                    select x).FirstOrDefault();
        }

        public CKS_Company GetByCode(string value)
        {
            return (from x in dbEntities.CKS_Company
                    where x.CompanyCode.ToLower().Equals(value.ToLower())
                    select x).FirstOrDefault();
        }
    }
}
