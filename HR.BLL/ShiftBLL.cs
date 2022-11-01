using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR.Static;
using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Tables.Tables;
using System.Data;

namespace HR.BLL
{
    public class ShiftBLL
    {
        IRepository<HrShifts> _repShift;
        public ShiftBLL(IRepository<HrShifts> repShift)
        {
            _repShift = repShift;
        }
        
        public object Add(ShiftDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.ShiftCode) || string.IsNullOrEmpty(mdl.Name1))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repShift.Find(x => x.ShiftCode == mdl.ShiftCode).FirstOrDefault();
            if (entity == null)
            {
                var action = _repShift.Insert(new HrShifts
                {
                    ShiftCode = mdl.ShiftCode,
                    Name1 = mdl.Name1,
                    Name2 = mdl.Name2,

                    Day1Type = mdl.Day1Type,
                    Day2Type = mdl.Day2Type,
                    Day3Type = mdl.Day3Type,
                    Day4Type = mdl.Day4Type,
                    Day5Type = mdl.Day5Type,
                    Day6Type = mdl.Day6Type,
                    Day7Type = mdl.Day7Type,

                    FirstShfDay1tFrom = mdl.FirstShftDay1From,
                    FirstShftDay2From = mdl.FirstShftDay2From,
                    FirstShftDay3From = mdl.FirstShftDay3From,
                    FirstShftDay4From = mdl.FirstShftDay4From,
                    FirstShftDay5From = mdl.FirstShftDay5From,
                    FirstShftDay6From = mdl.FirstShftDay6From,
                    FirstShftDay7From = mdl.FirstShftDay7From,

                    FirstShftDay1To = mdl.FirstShftDay1To,
                    FirstShftDay2To = mdl.FirstShftDay2To,
                    FirstShftDay3To = mdl.FirstShftDay3To,
                    FirstShftDay4To = mdl.FirstShftDay4To,
                    FirstShftDay5To = mdl.FirstShftDay5To,
                    FirstShftDay6To = mdl.FirstShftDay6To,
                    FirstShftDay7To = mdl.FirstShftDay7To,


                });
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الاضافة بنجاح" : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
            {
                return new
                {
                    Status = 500,
                    message = "هذا الكود موجود مسبقاً"
                };
            }
        }

        public object Edit(ShiftDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.ShiftCode) || string.IsNullOrEmpty(mdl.Name1))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repShift.GetById(mdl.ShiftId);
            if (entity != null)
            {
                entity.Name1 = mdl.Name1;
                entity.Name2 = mdl.Name2;
                entity.ShiftCode = mdl.ShiftCode;

                entity.Day1Type = mdl.Day1Type;
                entity.Day2Type = mdl.Day2Type;
                entity.Day3Type = mdl.Day3Type;
                entity.Day4Type = mdl.Day4Type;
                entity.Day5Type = mdl.Day5Type;
                entity.Day6Type = mdl.Day6Type;
                entity.Day7Type = mdl.Day7Type;

                entity.FirstShfDay1tFrom = mdl.FirstShftDay1From;
                entity.FirstShftDay2From = mdl.FirstShftDay2From;
                entity.FirstShftDay3From = mdl.FirstShftDay3From;
                entity.FirstShftDay4From = mdl.FirstShftDay4From;
                entity.FirstShftDay5From = mdl.FirstShftDay5From;
                entity.FirstShftDay6From = mdl.FirstShftDay6From;
                entity.FirstShftDay7From = mdl.FirstShftDay7From;

                entity.FirstShftDay1To = mdl.FirstShftDay1To;
                entity.FirstShftDay2To = mdl.FirstShftDay2To;
                entity.FirstShftDay3To = mdl.FirstShftDay3To;
                entity.FirstShftDay4To = mdl.FirstShftDay4To;
                entity.FirstShftDay5To = mdl.FirstShftDay5To;
                entity.FirstShftDay6To = mdl.FirstShftDay6To;
                entity.FirstShftDay7To = mdl.FirstShftDay7To;

                var action = _repShift.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم التعديل بنجاح" : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
                return new
                {
                    Status = 500,
                    message = "حدث خطأ ما اعد المحاولة"
                };

        }

        public IEnumerable<ShiftDTO> Shifts()
        {
            var shifts = _repShift.GetAll().Where(x => !x.DeletedAt.HasValue).Select(mdl => new ShiftDTO
            {
                ShiftCode = mdl.ShiftCode,
                ShiftId = mdl.ShiftId,
                Name1 = mdl.Name1,
                Name2 = mdl.Name2,

                Day1Type = mdl.Day1Type,
                Day2Type = mdl.Day2Type,
                Day3Type = mdl.Day3Type,
                Day4Type = mdl.Day4Type,
                Day5Type = mdl.Day5Type,
                Day6Type = mdl.Day6Type,
                Day7Type = mdl.Day7Type,

                FirstShftDay1From = mdl.FirstShfDay1tFrom,
                FirstShftDay2From = mdl.FirstShftDay2From,
                FirstShftDay3From = mdl.FirstShftDay3From,
                FirstShftDay4From = mdl.FirstShftDay4From,
                FirstShftDay5From = mdl.FirstShftDay5From,
                FirstShftDay6From = mdl.FirstShftDay6From,
                FirstShftDay7From = mdl.FirstShftDay7From,

                FirstShftDay1To = mdl.FirstShftDay1To,
                FirstShftDay2To = mdl.FirstShftDay2To,
                FirstShftDay3To = mdl.FirstShftDay3To,
                FirstShftDay4To = mdl.FirstShftDay4To,
                FirstShftDay5To = mdl.FirstShftDay5To,
                FirstShftDay6To = mdl.FirstShftDay6To,
                FirstShftDay7To = mdl.FirstShftDay7To,
            }).ToList();

            shifts.ForEach(x =>
            {
                x.HourCount =
                ((x.Day1Type.HasValue && x.Day1Type.Value) ? (x.FirstShftDay1To - x.FirstShftDay1From).Value.Hours + ((x.FirstShftDay1To - x.FirstShftDay1From).Value.Minutes / 60) : 0) +
                ((x.Day2Type.HasValue && x.Day2Type.Value) ? (x.FirstShftDay2To - x.FirstShftDay2From).Value.Hours + ((x.FirstShftDay2To - x.FirstShftDay2From).Value.Minutes / 60) : 0) +
                ((x.Day3Type.HasValue && x.Day3Type.Value) ? (x.FirstShftDay3To - x.FirstShftDay3From).Value.Hours + ((x.FirstShftDay3To - x.FirstShftDay3From).Value.Minutes / 60) : 0) +
                ((x.Day4Type.HasValue && x.Day4Type.Value) ? (x.FirstShftDay4To - x.FirstShftDay4From).Value.Hours + ((x.FirstShftDay4To - x.FirstShftDay4From).Value.Minutes / 60) : 0) +
                ((x.Day5Type.HasValue && x.Day5Type.Value) ? (x.FirstShftDay5To - x.FirstShftDay5From).Value.Hours + ((x.FirstShftDay5To - x.FirstShftDay5From).Value.Minutes / 60) : 0) +
                ((x.Day6Type.HasValue && x.Day6Type.Value) ? (x.FirstShftDay6To - x.FirstShftDay6From).Value.Hours + ((x.FirstShftDay6To - x.FirstShftDay6From).Value.Minutes / 60) : 0) +
                ((x.Day7Type.HasValue && x.Day7Type.Value) ? (x.FirstShftDay7To - x.FirstShftDay7From).Value.Hours + ((x.FirstShftDay7To - x.FirstShftDay7From).Value.Minutes / 60) : 0);

                x.NumberOfDays =
                ((x.Day1Type.HasValue && x.Day1Type.Value) ? 1 : 0) +
                ((x.Day2Type.HasValue && x.Day2Type.Value) ? 1 : 0) +
                ((x.Day3Type.HasValue && x.Day3Type.Value) ? 1 : 0) +
                ((x.Day4Type.HasValue && x.Day4Type.Value) ? 1 : 0) +
                ((x.Day5Type.HasValue && x.Day5Type.Value) ? 1 : 0) +
                ((x.Day6Type.HasValue && x.Day6Type.Value) ? 1 : 0) +
                ((x.Day7Type.HasValue && x.Day7Type.Value) ? 1 : 0);
            });

            return shifts.Select(x => new ShiftDTO { ShiftId = x.ShiftId, Name1 = x.Name1, HourCount = x.HourCount, NumberOfDays = x.NumberOfDays }).ToList();
        }

        public PeriodsTablesVM Period()
        {
            string sql = @"select top 1 PeriodWorkDays, DailyWorkHours from Hr_PeriodsTables";

            PeriodsTablesVM period = _repShift.ExecuteStoredProcedure<PeriodsTablesVM>(sql, null, CommandType.Text)[0];
            return period;
        }

        public object DisplayDataForEdit(int id)
        {
            return _repShift.Find(x => x.ShiftId == id).Select(x => new
            {
                x.ShiftId,
                x.ShiftCode,
                x.Name2,
                x.Name1,

                x.Day1Type,
                x.Day2Type,
                x.Day3Type,
                x.Day4Type,
                x.Day5Type,
                x.Day6Type,
                x.Day7Type,

                FirstShftDay1From = x.FirstShfDay1tFrom.HasValue ? x.FirstShfDay1tFrom.Value.ToString("HH:mm") : "",
                FirstShftDay2From = x.FirstShftDay2From.HasValue ? x.FirstShftDay2From.Value.ToString("HH:mm") : "",
                FirstShftDay3From = x.FirstShftDay3From.HasValue ? x.FirstShftDay3From.Value.ToString("HH:mm") : "",
                FirstShftDay4From = x.FirstShftDay4From.HasValue ? x.FirstShftDay4From.Value.ToString("HH:mm") : "",
                FirstShftDay5From = x.FirstShftDay5From.HasValue ? x.FirstShftDay5From.Value.ToString("HH:mm") : "",
                FirstShftDay6From = x.FirstShftDay6From.HasValue ? x.FirstShftDay6From.Value.ToString("HH:mm") : "",
                FirstShftDay7From = x.FirstShftDay7From.HasValue ? x.FirstShftDay7From.Value.ToString("HH:mm") : "",

                FirstShftDay1To = x.FirstShftDay1To.HasValue ? x.FirstShftDay1To.Value.ToString("HH:mm") : "",
                FirstShftDay2To = x.FirstShftDay2To.HasValue ? x.FirstShftDay2To.Value.ToString("HH:mm") : "",
                FirstShftDay3To = x.FirstShftDay3To.HasValue ? x.FirstShftDay3To.Value.ToString("HH:mm") : "",
                FirstShftDay4To = x.FirstShftDay4To.HasValue ? x.FirstShftDay4To.Value.ToString("HH:mm") : "",
                FirstShftDay5To = x.FirstShftDay5To.HasValue ? x.FirstShftDay5To.Value.ToString("HH:mm") : "",
                FirstShftDay6To = x.FirstShftDay6To.HasValue ? x.FirstShftDay6To.Value.ToString("HH:mm") : "",
                FirstShftDay7To = x.FirstShftDay7To.HasValue ? x.FirstShftDay7To.Value.ToString("HH:mm") : "",
            }).FirstOrDefault();
        }

        public object Delete(int id)
        {
            var entity = _repShift.GetById(id);
            if (entity != null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.DeletedBy = "1";
                var action = _repShift.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الحذف بنجاح" : "حدث خطأ ما اعد المحاولة"
                };
            }
            return new
            {
                Status = 500,
                message = "حدث خطأ ما اعد المحاولة"
            };
        }

        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            var query = _repShift.GetAll().Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;
            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.Name1.ToLower().Contains(mdl.SSearch.ToLower())
            || x.ShiftCode.ToLower().Contains(mdl.SSearch.ToLower())));
            
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };

            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
                name = x.Name1,
                nameE = x.Name2,
                code = x.ShiftCode,
                id = x.ShiftId
            });
            return new DataTableResponse(total, _data.ToList());
        }

        public object GetItemByIndex(int index)
        {
            var query = $@" select * from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
                    from [dbo].[Hr_Shifts] t where DeletedAt is null )ww
                    where rowNum={index}";

            var data = _repShift.ExecuteStoredProcedure<HrShifts>(query, null, System.Data.CommandType.Text).Select(x => new
            {
                x.ShiftId,
                x.ShiftCode,
                x.Name2,
                x.Name1,

                x.Day1Type,
                x.Day2Type,
                x.Day3Type,
                x.Day4Type,
                x.Day5Type,
                x.Day6Type,
                x.Day7Type,
                
                FirstShftDay1From = x.FirstShfDay1tFrom.HasValue ? x.FirstShfDay1tFrom.Value.ToString("HH:mm") : "",
                FirstShftDay2From = x.FirstShftDay2From.HasValue ? x.FirstShftDay2From.Value.ToString("HH:mm") : "",
                FirstShftDay3From = x.FirstShftDay3From.HasValue ? x.FirstShftDay3From.Value.ToString("HH:mm") : "",
                FirstShftDay4From = x.FirstShftDay4From.HasValue ? x.FirstShftDay4From.Value.ToString("HH:mm") : "",
                FirstShftDay5From = x.FirstShftDay5From.HasValue ? x.FirstShftDay5From.Value.ToString("HH:mm") : "",
                FirstShftDay6From = x.FirstShftDay6From.HasValue ? x.FirstShftDay6From.Value.ToString("HH:mm") : "",
                FirstShftDay7From = x.FirstShftDay7From.HasValue ? x.FirstShftDay7From.Value.ToString("HH:mm") : "",
                
                FirstShftDay1To = x.FirstShftDay1To.HasValue ? x.FirstShftDay1To.Value.ToString("HH:mm") : "",
                FirstShftDay2To = x.FirstShftDay2To.HasValue ? x.FirstShftDay2To.Value.ToString("HH:mm") : "",
                FirstShftDay3To = x.FirstShftDay3To.HasValue ? x.FirstShftDay3To.Value.ToString("HH:mm") : "",
                FirstShftDay4To = x.FirstShftDay4To.HasValue ? x.FirstShftDay4To.Value.ToString("HH:mm") : "",
                FirstShftDay5To = x.FirstShftDay5To.HasValue ? x.FirstShftDay5To.Value.ToString("HH:mm") : "",
                FirstShftDay6To = x.FirstShftDay6To.HasValue ? x.FirstShftDay6To.Value.ToString("HH:mm") : "",
                FirstShftDay7To = x.FirstShftDay7To.HasValue ? x.FirstShftDay7To.Value.ToString("HH:mm") : "",
            }).FirstOrDefault();
            return (data);
        }

        public int GetCount() => _repShift.Find(x => !x.DeletedAt.HasValue).Count();

        public class PeriodsTablesVM
        {
            public int PeriodWorkDays { get; set; }
            public int DailyWorkHours { get; set; }
        }
    }
}
