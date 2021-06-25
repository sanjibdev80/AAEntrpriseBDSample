using System;
using System.Threading.Tasks;
using AeonicTech.Data.Infrastructure;
using AeonicTech.Data.Interfaces;
using AeonicTech.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AeonicTech.Core.Service.Manager
{
    public class BaseUnitOfWork<TEntity> : IBaseUnitOfWork<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context = null;
        private readonly DbSet<TEntity> _entities = null;

        public BaseUnitOfWork(AppDBContext context)
        {
            this._context = context;
            this._entities = _context.Set<TEntity>();
        }

        public IGenericRepository<TEntity> AnyRepo => new GenericRepository<TEntity>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
