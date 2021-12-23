using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class StoreDTO
    {
        public int StoreId { get; set; } = 0;
        public string StoreCode { get; set; }
        public string StoreDescA { get; set; }
        public string StoreDescE { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
