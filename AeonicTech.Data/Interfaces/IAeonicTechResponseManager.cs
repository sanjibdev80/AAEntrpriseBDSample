using System;
using System.Collections.Generic;
using AeonicTech.Model.DTO;

namespace AeonicTech.Data.Interfaces
{
    public interface IAeonicTechResponseManager
    {
        AeonicTechResponse ATResponse(int ResponseCode, string ResponseMessage, IEnumerable<object> ResponseData);
    }
}
