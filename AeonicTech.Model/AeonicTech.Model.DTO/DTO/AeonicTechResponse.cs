using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AeonicTech.Model.DTO
{
    public class AeonicTechResponse
    {
        [Required]
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = null;

        public IEnumerable<object> ResponseData { get; set; } = null;

        public AeonicTechResponse(AeonicTechResponse aeoniTechResponse)
        {
            aeoniTechResponse.ResponseCode = ResponseCode;
            aeoniTechResponse.ResponseData = ResponseData;
            aeoniTechResponse.ResponseMessage = ResponseMessage;
        }

        public AeonicTechResponse()
        {
        }
    }
}
