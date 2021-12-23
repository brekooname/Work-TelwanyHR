using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int StoreId { get; set; }
    }
    public class Point
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string Qr { get; set; }
    }
}
