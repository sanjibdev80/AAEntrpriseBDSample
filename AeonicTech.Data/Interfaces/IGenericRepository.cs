using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AeonicTech.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddAsync(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity GetById(int Id);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);
    }
}
