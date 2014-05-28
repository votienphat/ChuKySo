//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dsms.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CKS_Agent
    {
        public CKS_Agent()
        {
            this.CKS_AgentProvider = new HashSet<CKS_AgentProvider>();
            this.CKS_AgentTokenType = new HashSet<CKS_AgentTokenType>();
            this.CKS_AgentUser = new HashSet<CKS_AgentUser>();
            this.CKS_Contract = new HashSet<CKS_Contract>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual ICollection<CKS_AgentProvider> CKS_AgentProvider { get; set; }
        public virtual ICollection<CKS_AgentTokenType> CKS_AgentTokenType { get; set; }
        public virtual ICollection<CKS_AgentUser> CKS_AgentUser { get; set; }
        public virtual ICollection<CKS_Contract> CKS_Contract { get; set; }
    }
}