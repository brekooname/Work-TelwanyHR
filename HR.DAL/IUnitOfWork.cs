
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace HR.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        SmartERPStandardContext SmartERPStandardContext { get; }
        IDbContextTransaction dbContextTransaction { get; set; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        void Commit();
    }
}
