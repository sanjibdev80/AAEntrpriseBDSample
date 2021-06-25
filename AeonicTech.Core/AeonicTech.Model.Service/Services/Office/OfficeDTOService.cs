using System;
using System.Collections.Generic;
using System.Linq;
using AeonicTech.Data.Interfaces;
using AeonicTech.Model.DBO;
using AeonicTech.Model.DTO;

namespace AeonicTech.Core.Service.Manager
{
    public class OfficeDTOService: IOfficeDTOService
    {
        private IBaseUnitOfWork<Office> _ofcRepo;
        private IBaseUnitOfWork<Employee> _empRepo;

        public OfficeDTOService(
            IBaseUnitOfWork<Office> ofcRepo,
            IBaseUnitOfWork<Employee> empRepo)
        {
            _ofcRepo = ofcRepo;
            _empRepo = empRepo;
        }

        public List<OfficeDTO> GetByOfficeId(int id)
        {
            var offices = _ofcRepo.AnyRepo.GetAll();
            var employees = _empRepo.AnyRepo.GetAll();

            var officeDTO = (from off in offices
                                    join emp in employees on off.EmployeeId equals emp.Id into table1
                                    from t1 in table1.DefaultIfEmpty()
                                    where off.Id == id
                                    select new OfficeDTO()
                                    {
                                        Id = off.Id,
                                        EmployeeName = t1.Name
                                    }).ToList();

            return officeDTO;
        }

        public List<OfficeDetailsDTO> GetOfficeDetails(int id)
        {
            var offices = _ofcRepo.AnyRepo.GetAll();
            var employees = _empRepo.AnyRepo.GetAll();

            var officeDetailsDTO = (from off in offices
                                    join emp in employees on off.EmployeeId equals emp.Id into table1
                                    from t1 in table1.DefaultIfEmpty()
                                    where off.Id == id
                                    select new OfficeDetailsDTO()
                                    {
                                        Id = off.Id,
                                        Location = off.Location,
                                        EmployeeName = t1.Name
                                    }).ToList();

            return officeDetailsDTO;
        }

        public List<OfficeDTO> GetOffices()
        {
            var offices = _ofcRepo.AnyRepo.GetAll();
            var employees = _empRepo.AnyRepo.GetAll();

            var officeDTO = (from off in offices
                             join emp in employees on off.EmployeeId equals emp.Id into table1
                             from t1 in table1.DefaultIfEmpty()
                             select new OfficeDTO()
                             {
                                 Id = off.Id,
                                 EmployeeName = t1.Name
                             }).ToList();

            return officeDTO;
        }

        public bool ModifyOfficeData(OfficeDTO office)
        {
            bool _retVal = false;

            try
            {
                var offices = _ofcRepo.AnyRepo.GetById(office.Id);
                if (office != null)
                {
                    var employees = _empRepo.AnyRepo.GetById(offices.EmployeeId);
                    var ofc = new Office
                    {
                        Id = offices.Id,
                        Location = offices.Location,
                        EmployeeId = offices.EmployeeId,
                        Employee = employees
                    };

                    _ofcRepo.AnyRepo.Update(ofc);
                    _ofcRepo.Save();
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

        public bool RemoveOfficeData(OfficeDTO office)
        {
            bool _retVal = false;

            try
            {
                var offices = _ofcRepo.AnyRepo.GetById(office.Id);
                if (office != null)
                {
                    var employees = _empRepo.AnyRepo.GetById(offices.EmployeeId);
                    var ofc = new Office
                    {
                        Id = offices.Id,
                        Location = offices.Location,
                        EmployeeId = offices.EmployeeId,
                        Employee = employees
                    };

                    _ofcRepo.AnyRepo.Delete(ofc);
                    _ofcRepo.Save();
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

        public bool SaveOfficeData(OfficeDetailsDTO office)
        {
            bool _retVal = false;

            try
            {
                var offices = _ofcRepo.AnyRepo.GetById(office.Id);
                int _empId = 0;
                if (offices == null)
                {
                    _empId = 0;
                }
                else
                {
                    _empId = offices.EmployeeId;
                }

                if (offices == null)
                {
                    var employees = new Employee
                    {
                        Id = _empId,
                        Name = office.EmployeeName,
                        OfficeId = office.Id
                    };

                    var ofc = new Office
                    {
                        Id = office.Id,
                        Location = office.Location,
                        EmployeeId = _empId,
                        Employee = employees
                    };

                    _ofcRepo.AnyRepo.Add(ofc);
                    _ofcRepo.Save();
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
