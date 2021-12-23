using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HR.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public SmartERPStandardContext _db;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<T> data;

        public Repository(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _db = _uow.SmartERPStandardContext;
            data = _db.Set<T>();
        }
        public virtual bool Delete(T entity)
        {

            data.Remove(entity);
            return SaveChange();
        }

        public virtual Task<bool> DeleteAsync(T entity)
        {

            data.Remove(entity);
            return SaveChangeAsnc();
        }

        public virtual void DeleteWithoutSaveChange(T entity) => data.Remove(entity);


        public virtual IQueryable<T> Find(Func<T, bool> predicate) => data.Where(predicate).AsQueryable<T>();


        public virtual IQueryable<T> GetAll() => data.AsQueryable();

        public virtual IQueryable<T> GetAllAsNoTracking() => data.AsNoTracking().AsQueryable();


        public virtual async Task<IQueryable<T>> GetAllAsync() => await Task.FromResult(data.AsQueryable());


        public virtual T GetById(object Id) => data.Find(Id);
        public virtual T GetDEAttachById(object Id) {
            var entity = data.Find(Id);
            _db.Entry(entity).State = EntityState.Detached;
            return entity;
        }


        public virtual bool Insert(T entity)
        {
            data.Add(entity);
            return SaveChange();
        }

        public virtual Task<bool> InsertAsync(T entity)
        {

            data.AddAsync(entity);
            return SaveChangeAsnc();
        }

        public virtual void InsertWithoutSaveChange(T entity) => data.Add(entity);


        public virtual bool SaveChange() => _uow.SaveChanges();


        public virtual Task<bool> SaveChangeAsnc() => _uow.SaveChangesAsync();


        public virtual bool Update(T entity)
        {
            data.Update(entity).State = EntityState.Modified;
            return SaveChange();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            data.Update(entity).State = EntityState.Modified;
            return SaveChangeAsnc();
        }

        public virtual void UpdateWithoutSaveChange(T entity) => data.Update(entity).State = EntityState.Modified;

        public virtual bool InsertRange(IEnumerable<T> entities)
        {
            data.AddRange(entities);
            return SaveChange();
        }

        public virtual void InsertRangeWithoutSaveChange(IEnumerable<T> entities)
        {
            data.AddRange(entities);
        }

        public virtual bool DeleteRange(IEnumerable<T> entity)
        {
            data.RemoveRange(entity);
            return SaveChange();
        }

        public virtual void DeleteRangeWithoutSaveChange(IEnumerable<T> entity)
        {
            data.RemoveRange(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U">The Result Class It Will Be List< <see cref="U"/> ></typeparam>
        /// <param name="query">Query string or Stored Procedure name</param>
        /// <param name="parameters">Parameters </param>
        /// <param name="commandType">Query or StoredProcedure default is StoredProcedure</param>
        /// <returns></returns>
        public List<U> ExecuteStoredProcedure<U>(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            /// in _db.Database.GetDbConnection().ConnectionString if the password didn't get inside connection string
            /// please make sure you add => "Persist Security Info=true;" inside your connection string in appsetting.json
            SqlConnection sqlConnection = new SqlConnection(_db.Database.GetDbConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            if (parameters != null)
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
                }
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            cmd.CommandTimeout = 120;
            cmd.CommandType = commandType;
            var reader = cmd.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader, LoadOption.PreserveChanges);
            sqlConnection.Close();
            return ConvertDataTable<U>(tbl);
        }

        private List<U> ConvertDataTable<U>(DataTable dt)
        {
            List<U> data = new List<U>();
            Type temp = typeof(U);
            foreach (DataRow row in dt.Rows) data.Add(GetItem<U>(row, temp));
            return data;
        }

        private TU GetItem<TU>(DataRow dr, Type temp)
        {
            TU obj = Activator.CreateInstance<TU>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                PropertyInfo pro = temp.GetProperty(column.ColumnName);
                if (pro == null || !pro.CanWrite) continue;
                try
                {
                    object col = dr[column.ColumnName];
                    if (pro.PropertyType.Name == nameof(Boolean) && (col.ToString() == "0" || col.ToString() == "1")) col = col.ToString() != "0";
                    pro.SetValue(obj, col, null);
                }
                catch
                {
                    pro.SetValue(obj, null, null);
                }
            }
            return obj;
        }
    }
}
