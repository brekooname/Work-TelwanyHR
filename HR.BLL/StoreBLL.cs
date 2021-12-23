using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

using HR.BLL.DTO;
using HR.Common;
using HR.DAL;
using HR.Tables.Tables;

using static System.Collections.Specialized.BitVector32;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HR.BLL
{
    public class StoreBLL
    {
        IRepository<MsStores> _repStore;
        public StoreBLL(IRepository<MsStores> repStore)
        {
            _repStore = repStore;
        }
        public object Add(StoreDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.StoreCode) || string.IsNullOrEmpty(mdl.StoreDescA) || string.IsNullOrEmpty(mdl.Lat) || string.IsNullOrEmpty(mdl.Lng))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repStore.Find(x => x.StoreCode == mdl.StoreCode).FirstOrDefault();
            if (entity == null)
            {
                var action = _repStore.Insert(new MsStores
                {
                    StoreCode = mdl.StoreCode,
                    StoreDescA = mdl.StoreDescA,
                    StoreDescE = mdl.StoreDescE,
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
                return new
                {
                    Status = 500,
                    message = "هذا الكود موجود مسبقاً"
                };
            }
        }

        public object Edit(StoreDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.StoreCode) || string.IsNullOrEmpty(mdl.StoreDescA) || string.IsNullOrEmpty(mdl.Lat) || string.IsNullOrEmpty(mdl.Lng))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repStore.GetById(mdl.StoreId);
            if (entity != null)
            {
                entity.StoreDescA = mdl.StoreDescA;
                entity.StoreDescE = mdl.StoreDescE;
                entity.StoreCode = mdl.StoreCode;
                entity.Lat = mdl.Lat;
                entity.Lng = mdl.Lng;
                var action = _repStore.Update(entity);
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
            return _repStore.Find(x => x.StoreId == id).Select(x => new { x.StoreId, x.StoreCode, x.Lat, x.Lng, x.StoreDescA, x.StoreDescE }).FirstOrDefault();
        }

        public object GetItemByIndex(int index)
        {
            var query = $@" select * from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
from [dbo].[MS_Stores] t where DeletedAt is null )ww

where rowNum={index} 
";
            var data = _repStore.ExecuteStoredProcedure<MsStores>
                (query, null, System.Data.CommandType.Text).Select(x => new { x.StoreId, x.StoreCode, x.Lat, x.Lng, x.StoreDescA, x.StoreDescE }).FirstOrDefault();

            return (data);
        }


        public object Delete(int id)
        {
            var entity = _repStore.GetById(id);
            if (entity != null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(3);
                entity.DeletedBy = "1";
                var action = _repStore.Update(entity);
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


        public SelectList Stores()
        {
            return new SelectList(_repStore.GetAll().Where(x => !x.DeletedAt.HasValue).Select(x => new { Id = x.StoreId, Name = x.StoreDescA }).ToList(), "Id", "Name");
        }
        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            var query = _repStore.GetAll().Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.StoreDescA.ToLower().Contains(mdl.SSearch.ToLower())
            || x.StoreCode.ToLower().Contains(mdl.SSearch.ToLower()))

            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
                name = x.StoreDescA,
                nameE = x.StoreDescE,
                code = x.StoreCode,
                id = x.StoreId,
                x.Lat,
                x.Lng
            });
            return new DataTableResponse(total, _data.ToList());
        }

        public int GetCount()
          => _repStore.Find(x => !x.DeletedAt.HasValue).Count();
    }
}
