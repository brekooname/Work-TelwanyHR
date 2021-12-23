using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class SrJobOrder
    {
        public SrJobOrder()
        {
            SrJobAdditionalCost = new HashSet<SrJobAdditionalCost>();
            SrJobComments = new HashSet<SrJobComments>();
            SrJobExtrnalExpens = new HashSet<SrJobExtrnalExpens>();
            SrJobFiles = new HashSet<SrJobFiles>();
            SrJobSparts = new HashSet<SrJobSparts>();
            SrJobSwages = new HashSet<SrJobSwages>();
        }

        public int JorderId { get; set; }
        public int? TrNo { get; set; }
        public DateTime? TrDate { get; set; }
        public int? SrTypId { get; set; }
        public int? ReciptionId { get; set; }
        public int? CustId { get; set; }
        public int? VehicleId { get; set; }
        public int? StoreId { get; set; }
        public int? BookId { get; set; }
        public int? TermId { get; set; }
        public int? FinancialIntervalsId { get; set; }
        public int? Aid { get; set; }
        public int? AccountId { get; set; }
        public int? AddAccountId { get; set; }
        public int? CostCenterId { get; set; }
        public int? CostCenterId2 { get; set; }
        public string ManualTrNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int? CurrencyId { get; set; }
        public string Remarks { get; set; }
        public decimal? SparePrts { get; set; }
        public decimal? Wages { get; set; }
        public decimal? Expense { get; set; }
        public decimal? OtherCosts { get; set; }
        public decimal? NetValue { get; set; }
        public bool? CustSatisfy { get; set; }
        public DateTime? ExitDate { get; set; }
        public int? ApprovedBy { get; set; }
        public bool? FreeService { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SrReciption Reciption { get; set; }
        public virtual SrServiceTypes SrTyp { get; set; }
        public virtual SrVehicles Vehicle { get; set; }
        public virtual ICollection<SrJobAdditionalCost> SrJobAdditionalCost { get; set; }
        public virtual ICollection<SrJobComments> SrJobComments { get; set; }
        public virtual ICollection<SrJobExtrnalExpens> SrJobExtrnalExpens { get; set; }
        public virtual ICollection<SrJobFiles> SrJobFiles { get; set; }
        public virtual ICollection<SrJobSparts> SrJobSparts { get; set; }
        public virtual ICollection<SrJobSwages> SrJobSwages { get; set; }
    }
}
