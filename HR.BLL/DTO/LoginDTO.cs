using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string QrCode { get; set; }
        public string MacAddress { get; set; }
    }
}
