using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class MsStores
    {
        public MsStores()
        {
            CalJurnalEntry = new HashSet<CalJurnalEntry>();
            MsPartition = new HashSet<MsPartition>();
        }

        public int StoreId { get; set; }
        public int? UserId { get; set; }
        public int? UserGroupId { get; set; }
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public bool? StoreType { get; set; }
        public string StorePosition { get; set; }
        public string StoreKeeper { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Remarks { get; set; }
        public string PrintField1Font { get; set; }
        public string PrintField2Font { get; set; }
        public string PrintField3Font { get; set; }
        public string PrintField4Font { get; set; }
        public string PrintField5Font { get; set; }
        public string PrintField1FontColor { get; set; }
        public string PrintField2FontColor { get; set; }
        public string PrintField3FontColor { get; set; }
        public string PrintField4FontColor { get; set; }
        public string PrintField5FontColor { get; set; }
        public byte? PrintField1FontSize { get; set; }
        public byte? PrintField2FontSize { get; set; }
        public byte? PrintField3FontSize { get; set; }
        public byte? PrintField4FontSize { get; set; }
        public byte? PrintField5FontSize { get; set; }
        public byte? PrintField1FontStyle { get; set; }
        public byte? PrintField2FontStyle { get; set; }
        public byte? PrintField3FontStyle { get; set; }
        public byte? PrintField4FontStyle { get; set; }
        public byte? PrintField5FontStyle { get; set; }
        public int? BoxId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CityId { get; set; }
        public byte[] BranchLogo { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public virtual MsBoxBank Box { get; set; }
        public virtual ICollection<CalJurnalEntry> CalJurnalEntry { get; set; }
        public virtual ICollection<MsPartition> MsPartition { get; set; }
    }
}
