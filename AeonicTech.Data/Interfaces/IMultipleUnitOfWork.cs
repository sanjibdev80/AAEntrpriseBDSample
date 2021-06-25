using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AeonicTech.Model.DBO;

namespace AeonicTech.Data.Interfaces
{
    public interface IMultipleUnitOfWork: IDisposable
    {
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<Office> OfficeRepository { get; }

        void Save();
        Task<bool> SaveAsync();
    }
}
