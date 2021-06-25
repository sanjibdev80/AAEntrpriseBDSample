using System;
using System.Collections.Generic;
using AeonicTech.Model.DTO;

namespace AeonicTech.Data.Interfaces
{
    public interface IEmployeeDTOService
    {
        List<EmployeeDTO> GetEmployees();
        bool SaveEmployeeData(EmployeeDTO employee);
        List<EmployeeDTO> GetByEmployeeId(int id);
        bool RemoveEmployeeData(EmployeeDTO employee);
        bool ModifyEmployeeData(EmployeeDTO employee);
    }
}
