using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class ReportsBLL
    {
        private IRepository<HrEmployees> _rep;

        public ReportsBLL(IRepository<HrEmployees> rep)
        {
            _rep = rep;
        }

        // reportType 1=> day 2=> week  3=> month 4=> year
        public object GetDelayReport(string LanguageKey, int pageIndex = 1, int reportType = 1)
        {
            var data = _rep.ExecuteStoredProcedure<DelayReportDTO>("Hr_GetDelayReport",
                      new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=reportType,ParameterName="@reportType"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=(pageIndex-1)*10,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=10,ParameterName="@Length"}
            });
            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(data.FirstOrDefault()?.Total ?? 0) / 10),
                data = data.ToList().Select(x => new
                {
                    EmployeeName = x.Name1,
                    Delay = new
                    {
                        hour = (x.MinCount / 60).ToString(),
                        Minute = (x.MinCount - (x.MinCount / 60) * 60).ToString()
                    },
                    DelayCost = Math.Round(x.DelayCost, 3)
                })
            };
        }

        public object GetDelayDetailsReport(int pageIndex = 1)
        {
            var data = _rep.ExecuteStoredProcedure<DelayReportDTO>("Hr_EmpolyeeDelayDetails",
                      new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=(pageIndex-1)*10,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=10,ParameterName="@Length"}
            });
            return new
            {
                pagesCount = (int)Math.Ceiling((decimal)(data.FirstOrDefault()?.Total ?? 0) / 10),
                data = data.ToList().Select(x => new
                {
                    EmployeeName = x.Name1,
                    day = new
                    {
                        Delay = new
                        {
                            hour = (GetMinuteAndCost(x.DayMinuteWithCost).Item1 / 60).ToString(),
                            Minute = (GetMinuteAndCost(x.DayMinuteWithCost).Item1 - (GetMinuteAndCost(x.DayMinuteWithCost).Item1 / 60) * 60).ToString()
                        },
                        DelayCost = Math.Round(GetMinuteAndCost(x.DayMinuteWithCost).Item2, 3)
                    }
                    ,
                    week = new
                    {
                        Delay = new
                        {
                            hour = (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 / 60).ToString(),
                            Minute = (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 - (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 / 60) * 60).ToString()
                        },
                        DelayCost = Math.Round(GetMinuteAndCost(x.WeekMinuteWithCost).Item2, 3)
                    },

                    month = new
                    {
                        Delay = new
                        {
                            hour = (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 / 60).ToString(),
                            Minute = (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 - (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 / 60) * 60).ToString()
                        },
                        DelayCost = Math.Round(GetMinuteAndCost(x.MonthMinuteWithCost).Item2, 3)
                    }
                    ,
                    year = new
                    {
                        Delay = new
                        {
                            hour = (GetMinuteAndCost(x.YearMinuteWithCost).Item1 / 60).ToString(),
                            Minute = (GetMinuteAndCost(x.YearMinuteWithCost).Item1 - (GetMinuteAndCost(x.YearMinuteWithCost).Item1 / 60) * 60).ToString()
                        },
                        DelayCost = Math.Round(GetMinuteAndCost(x.YearMinuteWithCost).Item2, 3)
                    }
                })
            };
        }

        public Tuple<int, decimal> GetMinuteAndCost(string k)
        {
            if (k == null)
            {
                return new Tuple<int, decimal>(0, 0);
            }
            var x = k.Split(',');
            return new Tuple<int, decimal>(int.Parse(x[0]), decimal.Parse(x[1]));
        }

        public DataTableResponse LoadDelayReport(DataTableDTO mdl, bool getDailyCost = false)
        {
            List<DelayReportDTO> data = _rep.ExecuteStoredProcedure<DelayReportDTO>("Hr_GetDelayReport", new Microsoft.Data.SqlClient.SqlParameter[]{
                new Microsoft.Data.SqlClient.SqlParameter{Value=mdl.reportType,ParameterName="@reportType"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=mdl.IDisplayStart,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=mdl.IDisplayLength,ParameterName="@Length"}
            });

            if (getDailyCost)
            {
                List<int> ids = data.Select(x => x.Emp_Id).ToList();
                List<HrEmployees> employees = _rep.Find(x => ids.Contains(x.EmpId)).ToList();

                foreach (DelayReportDTO item in data)
                {
                    item.DailyCost = employees.FirstOrDefault(x => x.EmpId == item.Emp_Id)?.DailyCost ?? 0;
                }
            }

          var response =   new DataTableResponse(data.FirstOrDefault()?.Total ?? 0, data.ToList().Select(x => new
                           {
                               EmployeeName = x.Name1,
                               Delay = new
                               {
                                   dailyCost = x.DailyCost,
                                   hour = (x.MinCount / 60).ToString(),
                                   Minute = (x.MinCount - (x.MinCount / 60) * 60).ToString()
                               },
                               DelayCost = Math.Round(x.DelayCost, 3)
                           }));
                      
            return response;
        }

        public DataTableResponse LoadDelayDetailsReport(DataTableDTO mdl)
        {

            var data = _rep.ExecuteStoredProcedure<DelayReportDTO>("Hr_EmpolyeeDelayDetails",
                      new Microsoft.Data.SqlClient.SqlParameter[]
            {
                new Microsoft.Data.SqlClient.SqlParameter{Value=mdl.IDisplayStart,ParameterName="@DisplayStart"},
                new Microsoft.Data.SqlClient.SqlParameter{Value=mdl.IDisplayLength,ParameterName="@Length"}
            });
            return new DataTableResponse(data.FirstOrDefault()?.Total ?? 0, data.ToList().Select(x => new
            {
                EmployeeName = x.Name1,
                day = new
                {
                    Delay = new
                    {
                        hour = (GetMinuteAndCost(x.DayMinuteWithCost).Item1 / 60).ToString(),
                        Minute = (GetMinuteAndCost(x.DayMinuteWithCost).Item1 - (GetMinuteAndCost(x.DayMinuteWithCost).Item1 / 60) * 60).ToString()
                    },
                    DelayCost = Math.Round(GetMinuteAndCost(x.DayMinuteWithCost).Item2, 3)
                }
                    ,
                week = new
                {
                    Delay = new
                    {
                        hour = (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 / 60).ToString(),
                        Minute = (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 - (GetMinuteAndCost(x.WeekMinuteWithCost).Item1 / 60) * 60).ToString()
                    },
                    DelayCost = Math.Round(GetMinuteAndCost(x.WeekMinuteWithCost).Item2, 3)
                },

                month = new
                {
                    Delay = new
                    {
                        hour = (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 / 60).ToString(),
                        Minute = (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 - (GetMinuteAndCost(x.MonthMinuteWithCost).Item1 / 60) * 60).ToString()
                    },
                    DelayCost = Math.Round(GetMinuteAndCost(x.MonthMinuteWithCost).Item2, 3)
                }
                    ,
                year = new
                {
                    Delay = new
                    {
                        hour = (GetMinuteAndCost(x.YearMinuteWithCost).Item1 / 60).ToString(),
                        Minute = (GetMinuteAndCost(x.YearMinuteWithCost).Item1 - (GetMinuteAndCost(x.YearMinuteWithCost).Item1 / 60) * 60).ToString()
                    },
                    DelayCost = Math.Round(GetMinuteAndCost(x.YearMinuteWithCost).Item2, 3)
                }
            }));

        }
    }
}
