using System;
using System.Collections.Generic;
using AeonicTech.Data.Interfaces;
using AeonicTech.Model.DTO;

namespace AeonicTech.Core.Service.Manager
{
    public class AeonicTechResponseManager : IAeonicTechResponseManager
    {
        public AeonicTechResponse ATResponse(int ResponseCode, string ResponseMessage, IEnumerable<object> ResponseData)
        {
            AeonicTechResponse aeonicTechResponse = new AeonicTechResponse();
            aeonicTechResponse.ResponseCode = ResponseCode;
            aeonicTechResponse.ResponseMessage = ResponseMessage;
            aeonicTechResponse.ResponseData = ResponseData;
            return aeonicTechResponse;
        }
    }
}
