using System;
using System.Collections.Generic;
using System.Linq;
using AeonicTech.Data.Interfaces;
using AeonicTech.Model.DBO;
using AeonicTech.Model.DTO;

namespace AeonicTech.Core.Service.Manager
{
    public class EmployeeDTOService: IEmployeeDTOService
    {
        private IMultipleUnitOfWork _uow;

        public EmployeeDTOService(IMultipleUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<EmployeeDTO> GetByEmployeeId(int id)
        {
            var offices = _uow.OfficeRepository.GetAll();
            var employees = _uow.EmployeeRepository.GetAll();

            var _emp = (from off in offices
                        join emp in employees on off.EmployeeId equals emp.Id into table1
                        from t1 in table1.DefaultIfEmpty()
                        where t1.Id == id
                        select new EmployeeDTO()
                        {
                            Id = t1.Id,
                            EmployeeName = t1.Name,
                            OfficeLocation = off.Location
                        }
                       ).ToList();

            return _emp;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var offices = _uow.OfficeRepository.GetAll();
            var employees = _uow.EmployeeRepository.GetAll();

            var empDTO = (from off in offices
                             join emp in employees on off.EmployeeId equals emp.Id into table1
                             from t1 in table1.DefaultIfEmpty()
                             select new EmployeeDTO()
                             {
                                 Id = t1.Id,
                                 EmployeeName = t1.Name,
                                 OfficeLocation = off.Location
                             }).ToList();

            return empDTO;
        }

        public bool ModifyEmployeeData(EmployeeDTO employee)
        {
            bool _retVal = false;

            try
            {
                var employees = _uow.EmployeeRepository.GetById(employee.Id);

                if (employees != null)
                {
                    var emp = new Employee
                    {
                        Id = employee.Id,
                        Name = employee.EmployeeName,
                        OfficeId = employees.OfficeId
                    };

                    _uow.EmployeeRepository.Update(emp);
                    _uow.Save();
                    _retVal = true;
                }
                else
                {
                    _retVal = false;
                }
            }
            catch(Exception)
            {
                _retVal = false;
            }

            return _retVal;
        }

        public bool RemoveEmployeeData(EmployeeDTO employee)
        {
            bool _retVal = false;

            try
            {
                var employees = _uow.EmployeeRepository.GetById(employee.Id);

                int _offId = 0;
                if (employees == null)
                {
                    _offId = 0;
                }
                else
                {
                    _offId = employees.OfficeId;
                }

                if (employees != null)
                {
                    var emp = new Employee
                    {
                        Id = employee.Id,
                        Name = employee.EmployeeName,
                        OfficeId = employees.OfficeId
                    };

                    var _ofc = new Office
                    {
                        Id = _offId,
                        Location = employee.OfficeLocation,
                        EmployeeId = employee.Id,
                        Employee = employees
                    };

                    _uow.EmployeeRepository.Delete(emp);
                    //_uow.OfficeRepository.Delete(_ofc);
                    _uow.Save();
                    _retVal = true;
                }
                else
                {
                    _retVal = false;
                }
            }
            catch (Exception)
            {
                _retVal = false;
            }

            return _retVal;
        }

        public bool SaveEmployeeData(EmployeeDTO employee)
        {
            bool _retVal = false;

            try
            {
                var employees = _uow.EmployeeRepository.GetById(employee.Id);

                int _offId = 0;
                if (employees == null)
                {
                    _offId = 0;
                }
                else
                {
                    _offId = employees.OfficeId;
                }

                if (employees == null)
                {
                    var _ofc = new Office
                    {
                        Id = _offId,
                        Location = employee.OfficeLocation,
                        EmployeeId = employee.Id,
                        Employee = employees
                    };

                    var emp = new Employee
                    {
                        Id = employee.Id,
                        Name = employee.EmployeeName,
                        OfficeId = _ofc.Id
                    };

                    _uow.EmployeeRepository.Add(emp);
                    _uow.OfficeRepository.Add(_ofc);
                    _uow.Save();

                    _retVal = true;
                }
                else
                {
                    _retVal = false;
                }
            }
            catch (Exception)
            {
                _retVal = false;
            }

            return _retVal;
        }

    }
}
