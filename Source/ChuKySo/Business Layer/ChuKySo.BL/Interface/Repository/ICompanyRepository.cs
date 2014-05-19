using ChuKySo.BL.Model.Entity;

namespace ChuKySo.BL.Repository
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Insert Company
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        CKS_Company Insert(CKS_Company item);

        /// <summary>
        /// Get Company by name
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CKS_Company GetByTitle(string value);

        /// <summary>
        /// Get Company by code
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        CKS_Company GetByCode(string value);
    }
}
