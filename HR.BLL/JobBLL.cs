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



namespace HR.BLL
{
    public class JobBLL
    {
        IRepository<HrJobs> _repJob;
        public JobBLL(IRepository<HrJobs> repJob)
        {
            _repJob = repJob;
        }
        public object Add(JobDTO mdl)
        {
            if(string.IsNullOrEmpty(mdl.Jcode)|| string.IsNullOrEmpty(mdl.Jname1))
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repJob.Find(x => x.Jcode == mdl.Jcode).FirstOrDefault();
            if (entity == null)
            {
                var action = _repJob.Insert(new HrJobs
                {
                    Jcode = mdl.Jcode,
                    Jname1 = mdl.Jname1,
                    Jname2 = mdl.Jname2
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

        public object Edit(JobDTO mdl)
        {
            if (string.IsNullOrEmpty(mdl.Jcode) || string.IsNullOrEmpty(mdl.Jname1) )
                return new
                {
                    Status = 500,
                    message = "ادخل الحقول الفارغة"
                };

            var entity = _repJob.GetById(mdl.JobId);
            if (entity != null)
            {
                entity.Jname1 = mdl.Jname1;
                entity.Jname2 = mdl.Jname2;
                entity.Jcode = mdl.Jcode;
                var action = _repJob.Update(entity);
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
            return _repJob.Find(x => x.JobId == id).Select(x => new { x.JobId, x.Jcode,x.Jname2,x.Jname1 }).FirstOrDefault();
        }


        public object Delete(int id)
        {
            var entity = _repJob.GetById(id);
            if (entity!=null)
            {
                entity.DeletedAt = DateTime.UtcNow.AddHours(HourServer.hours);
                entity.DeletedBy = "1";
                var action = _repJob.Update(entity);
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

        public SelectList Jobs()
        {
            return new SelectList(_repJob.GetAll().Where(x => !x.DeletedAt.HasValue).Select(x => new { Id = x.JobId, Name = x.Jname1 }).ToList(), "Id", "Name");
        }

        public DataTableResponse LoadData(DataTableDTO mdl)
        {
            var query = _repJob.GetAll().Where(x => x.DeletedAt == null);
            var total = query?.Count() ?? 0;

            var data = query.Where(x => (mdl.SSearch.IsEmpty()
            || x.Jname1.ToLower().Contains(mdl.SSearch.ToLower())
            || x.Jcode.ToLower().Contains(mdl.SSearch.ToLower()))
          
            );
            data = (mdl.SSortDir_0) switch
            {
                SortingDir.asc => data.OrderBy(x => x.CreatedAt),
                SortingDir.Desc => data.OrderByDescending(x => x.CreatedAt),
                _ => data
            };
            var _data = data.Skip(mdl.IDisplayStart).Take(mdl.IDisplayLength).ToList().Select(x => new
            {
               name= x.Jname1,
               nameE=x.Jname2,
               code = x.Jcode,
              id= x.JobId
            });
            return new DataTableResponse(total, _data.ToList());
        }

        public object GetItemByIndex(int index)
        {
            var query = $@" select JobId, Jcode,Jname2,Jname1 from ( select ROW_NUMBER() over (order by CreatedAt  ) 'rowNum',*
from [dbo].[Hr_Jobs] t where DeletedAt is null )ww

where rowNum={index} 
";
            var data = _repJob.ExecuteStoredProcedure<HrJobs>
                (query, null, System.Data.CommandType.Text).Select(x => new { x.JobId, x.Jcode,x.Jname2,x.Jname1 }).FirstOrDefault();

            return (data);
        }

        public int GetCount()
          => _repJob.Find(x => !x.DeletedAt.HasValue).Count();
    }
}
