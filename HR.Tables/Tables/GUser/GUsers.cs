using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class GUsers
    {
        public GUsers()
        {
            CalAccountUsers = new HashSet<CalAccountUsers>();
            GUserModule = new HashSet<GUserModule>();
            MsBoxUsers = new HashSet<MsBoxUsers>();
            MsCusromerUsers = new HashSet<MsCusromerUsers>();
            MsVendorUsers = new HashSet<MsVendorUsers>();
        }

        public int UserId { get; set; }
        public int? EmpId { get; set; }
        public int? UserGroupId { get; set; }
        public int? UserRoleId { get; set; }
        public bool? IsActive { get; set; }
        public string UserCode { get; set; }
        public int? StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MacAddress { get; set; }
        public string Password { get; set; }
        public byte? UserType { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual GUserRole UserRole { get; set; }
        public virtual ICollection<CalAccountUsers> CalAccountUsers { get; set; }
        public virtual ICollection<GUserModule> GUserModule { get; set; }
        public virtual ICollection<MsBoxUsers> MsBoxUsers { get; set; }
        public virtual ICollection<MsCusromerUsers> MsCusromerUsers { get; set; }
        public virtual ICollection<MsVendorUsers> MsVendorUsers { get; set; }
    }
}
