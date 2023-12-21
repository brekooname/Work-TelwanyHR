using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Tables.Tables
{
    public class Mobile_Attendance
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        [ForeignKey(nameof(HrEmployees))]
        public int? Emp_Id { get; set; }
        [ForeignKey(nameof(MsStores))]
        public int? StoreId { get; set; }
        [ForeignKey(nameof(HrShifts))]
        public int? ShftId { get; set; }
        public DateTime? TrDate { get; set; }
        public bool? In { get; set; }
        public bool? Out { get; set; }
        public bool? Status { get; set; }
        public double? Distance { get; set; }
        public string Qr { get; set; }
        public string LocationName { get; set; }
        public HrShifts HrShifts { get; set; }
        public HrEmployees HrEmployees { get; set; }
        public MsStores MsStores { get; set; }
    }
}


//AttendanceId int identity(1,1) primary key,
//Emp_Id int ,
//TrDate datetime2,

//[In] bit,

//[Out] bit,
//StoreId int