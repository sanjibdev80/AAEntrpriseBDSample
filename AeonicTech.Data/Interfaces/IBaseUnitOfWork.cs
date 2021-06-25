using System;
using System.Threading.Tasks;
using AeonicTech.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AeonicTech.Data.Interfaces
{
    public interface IBaseUnitOfWork<TEntity> where TEntity : class
    {
        IGenericRepository<TEntity> AnyRepo { get; }

        void Save();

        Task<bool> SaveAsync();
    }
}
