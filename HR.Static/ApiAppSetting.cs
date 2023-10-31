using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Static
{
    public class ApiAppSetting
    {
        public int Id { get; set; }
        public string ProductKey { get; set; }
        public string Url { get; set; }
        public bool IsDefault { get; set; }
    }
}