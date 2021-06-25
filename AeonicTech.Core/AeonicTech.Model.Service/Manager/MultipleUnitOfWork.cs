using System;
using System.Threading.Tasks;
using AeonicTech.Data.Infrastructure;
using AeonicTech.Data.Interfaces;
using AeonicTech.Data.Repositories;
using AeonicTech.Model.DBO;
using Microsoft.EntityFrameworkCore;

namespace AeonicTech.Core.Service.Manager
{
    public class MultipleUnitOfWork: IMultipleUnitOfWork
    {
        private readonly AppDBContext _context = null;

        public MultipleUnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public IGenericRepository<Employee> EmployeeRepository => new GenericRepository<Employee>(_context);

        public IGenericRepository<Office> OfficeRepository => new GenericRepository<Office>(_context);

        public void Dispose()
        {
            this._context?.Dispose();
        }

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
