using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class EmployeeOrdersDTO
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public DateTime? TrDate { get; set; }
        public string TrNo { get; set; }
        public string Type { get; set; }
        public string StatusKey { get; set; }
        public string Status { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string RequestImageUrl { get; set; }
        public int TypeId
        {
            get
            {
                return (int)Enum.Parse<OrderTypeEnum>(Type);
            }
        }
    }
    public enum OrderTypeEnum
    {
        Vacation = 1, Loan, LeavePermision
    }
    public enum StatusEnum
    {

        pending = 1, accepted, rejected
    }
}
