using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HR.BLL.DTO
{
    public class DataTableDTO
    {

        #region Private

        private int _Length = 0;
        private int _Start;
        private string _Search = null;

        #endregion


        public int IColumns { get; set; }

        public string SColumns { get; set; }

        public int IDisplayStart
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        public int Start
        {
            get => _Start;
            set
            {
                if (value != 0)
                {
                    _Start = value;
                }
            }
        }

        public int IDisplayLength
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public int Length
        {
            get => _Length; set
            {
                if (value != 0)
                {
                    _Length = value;
                }
            }
        }

        public string MDataProp_0 { get; set; }

        public bool BSortable_0 { get; set; }


        public int ISortCol_0 { get; set; }
        public int reportType { get; set; } = 1;


        public SortingDir SSortDir_0 { get; set; }

        public int ISortingCols { get; set; }

        public string SSearch
        {
            get => _Search;
            set
            {
                if (value != null)
                {
                    _Search = value;
                }
            }
        }
        public string term { get; set; }
        public Dictionary<string, string> Search
        {
            get => new Dictionary<string, string>() { { "Search", _Search } };
            set
            {
                if (value != null && value.ContainsKey("value"))
                {
                    _Search = value["value"];
                }
            }
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string PortfolioNo { get; set; }
        public string Phone { get; set; }
        public int? StockEffect { get; set; }
        public int? CashEffect1 { get; set; }
        public int? StockBrokersId { get; set; }
        public DateTime? dateTo { get; set; }
        public DateTime? dateFrom { get; set; }

    }

    public enum SortingDir { asc, Desc }

    public class SearchMdl
    {
        public int? TrNo { get; set; }
        public int? StockId { get; set; }
        public int? ToStockPortfolioId { get; set; }
        public int? FromStockPortfolioId { get; set; }
        public int? StockPortfolioId { get; set; }
        public DateTime? TrDate { get; set; }
    }

    public class SearchResultDTO
    {
        public long rowNum { get; set; }
        public int TrNo { get; set; }
        public int ToStockPortfolioId { get; set; }
        public int FromStockPortfolioId { get; set; }
        public string StockName { get; set; }
        public string TrDate { get; set; }
        public string FromPortName { get; set; }
        public string ToPortName { get; set; }
        public string PortName { get; set; }
    }
}
