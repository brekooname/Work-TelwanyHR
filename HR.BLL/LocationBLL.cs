using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HR.Static;
using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Tables.Tables;

using Microsoft.AspNetCore.Mvc.Rendering;

using static HR.BLL.AccountBll;

namespace HR.BLL
{
    public class LocationBLL
    {
        IRepository<HrLocation> _repLocation;
        public LocationBLL(IRepository<HrLocation> repLocation)
        {
            _repLocation = repLocation;
        }
        public object Add(LocationDTO mdl)
        {
            if(string.IsNullOrEmpty(mdl.Code)|| string.IsNullOrEmpty(mdl.Name1)|| string.IsNullOrEmpty(mdl.Lat)|| string.IsNullOrEmpty(mdl.Lng))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repLocation.Find(x => x.Code == mdl.Code).FirstOrDefault();
            if (entity == null)
            {
                var action = _repLocation.Insert(new HrLocation
                {
                    Code = mdl.Code,
                    Name1 = mdl.Name1,
                    Name2 = mdl.Name2,
                    Lat = mdl.Lat,
                    Lng = mdl.Lng
                });
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الاضافة بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
            {
             return   new
                {
                    Status =500,
                    message = "هذا الكود موجود مسبقاً"
                };
            }
        }


        public SelectList locations()
{
            return new SelectList(_repLocation.GetAll().Where(x => !x.DeletedAt.HasValue).Select(x => new { Id = x.LocationId, Name = x.Name1 }).ToList(), "Id", "Name");
        }
        public object Edit(LocationDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.Code) || string.IsNullOrEmpty(mdl.Name1) || string.IsNullOrEmpty(mdl.Lat) || string.IsNullOrEmpty(mdl.Lng))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repLocation.GetById(mdl.LocationId);
            if (entity != null)
            {
                entity.Name1 = mdl.Name1;
                entity.Name2 = mdl.Name2;
                entity.Code = mdl.Code;
                entity.Lat = mdl.Lat;
                entity.Lng = mdl.Lng;
                var action = _repLocation.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم التعديل بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
                };
            }
            else
                return new
                {
                    Status = 500,
                    message = "حدث خطأ ما اعد المحاولة"
                };
        
        }

        public object DisplayDataForEdit(int id)
        {
            return _repLocation.Find(x => x.LocationId == id).Select(x => new { x.LocationId, x.Code, x.Lat, x.Lng,x.Name2,x.Name1 }).FirstOrDefault();
        }


        public object GetItemByIndex(int index)
        {
            var query = $@" select * from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
from [dbo].[Hr_Location] t where DeletedAt is null )ww

where rowNum={index} 
";
            var data = _repLocation.ExecuteStoredProcedure<HrLocation>
                (query, null, System.Data.CommandType.Text).Select(x => new { x.LocationId, x.Code, x.Lat, x.Lng, x.Name2, x.Name1 }).FirstOrDefault();

            return (data);
        }

        public object Delete(int id)
        {
            var entity = _repLocation.GetById(id);
            if (entity!=null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.DeletedBy = "1";
                var action = _repLocation.Update(entity);
                return new
                {
                    Status = action ? 200 : 500,
                    message = action ? "تم الحذف بنجاح"

                            : "حدث خطأ ما اعد المحاولة"
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
            var query = _repLocation.GetAll().Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.Name1.ToLower().Contains(mdl.SSearch.ToLower())
            || x.Code.ToLower().Contains(mdl.SSearch.ToLower()))
          
            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
               name= x.Name1,
               nameE=x.Name2,
               code = x.Code,
              id= x.LocationId,
           x.Lat,
           x.Lng
            });
            return new DataTableResponse(total, _data.ToList());
        }


        public int GetCount()
          => _repLocation.Find(x => !x.DeletedAt.HasValue).Count();

    }
}
