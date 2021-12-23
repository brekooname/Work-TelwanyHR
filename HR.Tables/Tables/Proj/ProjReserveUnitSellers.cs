using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class ProjReserveUnitSellers
    {
        public int ReservSellerId { get; set; }
        public int? ReservId { get; set; }
        public int? ResourceId { get; set; }
        public bool? IsMainOwner { get; set; }
        public byte? ResourceType { get; set; }
        public int? ResourceAccountId { get; set; }
        public int? HelpAccId { get; set; }
        public string HelpAccType { get; set; }
        public string AccountDescription { get; set; }
        public decimal? ShareValue { get; set; }
        public decimal? SharePercent { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }

        public virtual ProjUnitReservation Reserv { get; set; }
    }
}
