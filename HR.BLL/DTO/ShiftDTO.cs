using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class ShiftDTO
    {
        public int ShiftId { get; set; } = 0;
        public string ShiftCode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Day1Name1 { get; set; }
        public string Day1Name2 { get; set; }
        public string Day2Name1 { get; set; }
        public string Day2Name2 { get; set; }
        public string Day3Name1 { get; set; }
        public string Day3Name2 { get; set; }
        public string Day4Name1 { get; set; }
        public string Day4Name2 { get; set; }
        public string Day5Name1 { get; set; }
        public string Day5Name2 { get; set; }
        public string Day6Name1 { get; set; }
        public string Day6Name2 { get; set; }
        public string Day7Name1 { get; set; }
        public string Day7Name2 { get; set; }
        public bool? Day1Type { get; set; }
        public bool? Day2Type { get; set; }
        public bool? Day3Type { get; set; }
        public bool? Day4Type { get; set; }
        public bool? Day5Type { get; set; }
        public bool? Day6Type { get; set; }
        public bool? Day7Type { get; set; }
        public DateTime? FirstShftDay1From { get; set; }
        public DateTime? FirstShftDay1To { get; set; }
        public DateTime? FirstShftDay2From { get; set; }
        public DateTime? FirstShftDay2To { get; set; }
        public DateTime? FirstShftDay3From { get; set; }
        public DateTime? FirstShftDay3To { get; set; }
        public DateTime? FirstShftDay4From { get; set; }
        public DateTime? FirstShftDay4To { get; set; }
        public DateTime? FirstShftDay5From { get; set; }
        public DateTime? FirstShftDay5To { get; set; }
        public DateTime? FirstShftDay6From { get; set; }
        public DateTime? FirstShftDay6To { get; set; }
        public DateTime? FirstShftDay7From { get; set; }
        public DateTime? FirstShftDay7To { get; set; }

        public double HourCount { get; set; } = 0;
        public double NumberOfDays { get; set; } = 0;

    }
    public enum ShiftDays
    {
      السبت=1,الاحد,الاثنين,التلاتاء,الاربعاء,الخميس,الجمعه
    }
}
