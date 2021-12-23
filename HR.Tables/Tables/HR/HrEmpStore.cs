using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpStore
    {
        public HrEmpStore()
        {
         
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpStoreId { get; set; }
        [ForeignKey(nameof(Stores))]
        public int StoreId { get; set; }
        [ForeignKey(nameof(HrEmployees))]
        public int EmpId { get; set; }
        public MsStores Stores { get; set; }
        public HrEmployees HrEmployees { get; set; }
    }
}
