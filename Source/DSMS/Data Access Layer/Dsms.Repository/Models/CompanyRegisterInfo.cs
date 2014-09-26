namespace Dsms.Repository.Models
{
    public class CompanyRegisterInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CompanyType { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Quantity of contracts that company signed
        /// </summary>
        public int ContractQuantity { get; set; }

        public string TokenTypeId { get; set; }

        /// <summary>
        /// Amount of current contract
        /// </summary>
        public int? Amount { get; set; }
    }
}
