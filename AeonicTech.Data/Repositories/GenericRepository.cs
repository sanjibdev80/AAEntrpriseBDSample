using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AeonicTech.Data.Infrastructure;
using AeonicTech.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AeonicTech.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context = null;
        private readonly DbSet<TEntity> _entities = null;

        public GenericRepository(AppDBContext context)
        {
            this._context = context;
            this._entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this._entities.Add(entity);
            this._context.Entry(entity).State = EntityState.Added;
        }

        public void AddAsync(TEntity entity)
        {
            this._entities.AddAsync(entity);
            this._context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            this._entities.Remove(entity);
            this._context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._entities.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return this._entities.ToListAsync();
        }

        public TEntity GetById(int Id)
        {
            return this._entities.Find(Id);
        }

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this._entities.Where(predicate);
        }

        public void Update(TEntity entity)
        {
            this._entities.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
        }
    }
}
