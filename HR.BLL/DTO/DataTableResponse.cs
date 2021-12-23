using System;
using System.Collections.Generic;
using System.Text;

namespace HR.BLL.DTO
{
    public class DataTableResponse
    {
        public DataTableResponse() { }

        public DataTableResponse(long ITotalRecords, object Data)
        {
            this.ITotalRecords = ITotalRecords;
            AaData = Data;
        }

        public long ITotalRecords { get; set; }

        public long ITotalDisplayRecords => ITotalRecords;

        public object AaData { get; set; }

        public object Data => AaData;

    }
}
