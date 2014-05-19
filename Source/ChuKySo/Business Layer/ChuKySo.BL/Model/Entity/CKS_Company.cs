//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChuKySo.BL.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CKS_Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TransTitle { get; set; }
        public string CompanyType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<System.DateTime> ActiveDate { get; set; }
        public string LegalRepresentive { get; set; }
        public string LegalRepresentiveAddress { get; set; }
        public string AuthorizedCapital { get; set; }
        public string DescriptionMajor { get; set; }
        public string Description { get; set; }
        public string Directors { get; set; }
        public string Avatar { get; set; }
        public Nullable<System.DateTime> AllowedDate { get; set; }
        public bool IsDisabled { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
