using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace HR.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(SmartERPStandardContext SmartERPStandardContext)
                            => this.SmartERPStandardContext = SmartERPStandardContext;

        public SmartERPStandardContext SmartERPStandardContext { get; }
        public IDbContextTransaction dbContextTransaction { get; set; }


        public virtual void Commit()
        {
            SmartERPStandardContext.Database.CurrentTransaction.Commit();
        }

        public bool SaveChanges()
        {
            try
            {
                return SmartERPStandardContext.SaveChanges() > 0 ? true : false;
            }
            catch(Exception e)
            {

                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await SmartERPStandardContext.SaveChangesAsync()) > 0 ? true : false;
            }
            catch
            {

                return false;
            }
        }


        public void Dispose()
        {
            SmartERPStandardContext.Dispose();
        }
    }
}

