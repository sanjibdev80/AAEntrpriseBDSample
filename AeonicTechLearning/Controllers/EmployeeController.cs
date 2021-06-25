using System;
using System.Net;
using AeonicTech.Data.Interfaces;
using AeonicTech.Model.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AeonicTech.WebAPI.Controllers
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDTOService _empDTO;
        private readonly IAeonicTechResponseManager _myResponse;

        public EmployeeController(IEmployeeDTOService empDTO, IAeonicTechResponseManager resp)
        {
            _empDTO = empDTO;
            _myResponse = resp;
        }

        // Using DTO representation from service
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), _empDTO.GetEmployees()));
            }
            catch (Exception)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

        [HttpPost("SaveEmployeeData")]
        public IActionResult SaveEmployeeData(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_empDTO.SaveEmployeeData(employee) == true)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), null));
                }
                else
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.NotImplemented, HttpStatusCode.NotImplemented.ToString(), null));
                }
            }
            catch (Exception)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

        [HttpGet("GetByEmployeeId/{id}")]
        public IActionResult GetByEmployeeId(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_empDTO.GetByEmployeeId(id).Count > 0)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), _empDTO.GetByEmployeeId(id)));
                }
                else
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), null));
                }
            }
            catch (Exception)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

        [HttpPut("RemoveEmployeeData")]
        public IActionResult RemoveEmployeeData(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_empDTO.RemoveEmployeeData(employee) == true)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), null));
                }
                else
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.NotImplemented, HttpStatusCode.NotImplemented.ToString(), null));
                }
            }
            catch (Exception)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

        [HttpPost("ModifyEmployeeData")]
        public IActionResult ModifyEmployeeData(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_empDTO.ModifyEmployeeData(employee) == true)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), null));
                }
                else
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.NotImplemented, HttpStatusCode.NotImplemented.ToString(), null));
                }
            }
            catch
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

    }
}
