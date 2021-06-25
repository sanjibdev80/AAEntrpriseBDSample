using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AeonicTech.Core.Service.Manager;
using AeonicTech.Model.DTO;
using System.Net;
using AeonicTech.Data.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AeonicTech.WebAPI.Controllers
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeDTOService _offDTO;
        private readonly IAeonicTechResponseManager _myResponse;

        public OfficeController(IOfficeDTOService offDTO, IAeonicTechResponseManager resp)
        {
            _offDTO = offDTO;
            _myResponse = resp;
        }

        // Using DTO representation from service
        [HttpGet("GetOffices")]
        public IActionResult GetOffices()
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), _offDTO.GetOffices()));
            }
            catch (Exception)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), null));
            }
        }

        [HttpGet("GetOffices/{id}")]
        public IActionResult GetOfficeDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_offDTO.GetOfficeDetails(id).Count > 0)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), _offDTO.GetOfficeDetails(id)));
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

        [HttpPost("SaveOfficeData")]
        public IActionResult SaveOfficeData(OfficeDetailsDTO office)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_offDTO.SaveOfficeData(office) == true)
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

        [HttpGet("GetByOfficeId/{id}")]
        public IActionResult GetByOfficeId(int id)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_offDTO.GetByOfficeId(id).Count > 0)
                {
                    return Ok(_myResponse.ATResponse((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), _offDTO.GetByOfficeId(id)));
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

        [HttpPut("RemoveOfficeData")]
        public IActionResult RemoveOfficeData(OfficeDTO office)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_offDTO.RemoveOfficeData(office) == true)
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

        [HttpPost("ModifyOfficeData")]
        public IActionResult ModifyOfficeData(OfficeDTO office)
        {
            if (!ModelState.IsValid)
            {
                return Ok(_myResponse.ATResponse((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), null));
            }

            try
            {
                if (_offDTO.ModifyOfficeData(office) == true)
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

    }
}
