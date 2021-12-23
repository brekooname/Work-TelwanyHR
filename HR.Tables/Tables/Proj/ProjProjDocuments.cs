using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjProjDocuments
    {
        public int ProjDocumentId { get; set; }
        public int? ProjectId { get; set; }
        public Guid Fsid { get; set; }
        public int? OwnShipBondId { get; set; }
        public int? ShelvId { get; set; }
        public string PaperNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public long? AttachSerial { get; set; }
        public string SearchTags { get; set; }
        public string AttachPath { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string IssuePlace { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public byte[] Fdata { get; set; }

        public virtual CodOwnershipBonds OwnShipBond { get; set; }
        public virtual ProjProjects Project { get; set; }
    }
}
