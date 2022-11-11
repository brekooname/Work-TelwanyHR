using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HR.Tables.Tables
{
    public partial class HrEmpLocations
    {
        public HrEmpLocations()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpLocationId { get; set; }
        [ForeignKey(nameof(HrLocation))]
        public int LocationId { get; set; }
        [ForeignKey(nameof(HrEmployees))]
        public int EmpId { get; set; }
        public HrLocation HrLocation { get; set; }
        public HrEmployees HrEmployees { get; set; }
    }
}
