using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class LocationDTO
    {
        public int LocationId { get; set; } = 0;
        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
