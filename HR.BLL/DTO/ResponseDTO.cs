using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class ResponseDTO
    {
        public bool status { get; set; } = false;
        public string message { get; set; }
        public int responseCode { get; set; }
    }
}
