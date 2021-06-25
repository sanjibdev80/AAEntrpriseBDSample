using System;
using System.Collections.Generic;
using AeonicTech.Model.DTO;

namespace AeonicTech.Data.Interfaces
{
    public interface IOfficeDTOService
    {
        List<OfficeDTO> GetOffices();
        List<OfficeDetailsDTO> GetOfficeDetails(int id);

        bool SaveOfficeData(OfficeDetailsDTO office);
        List<OfficeDTO> GetByOfficeId(int id);
        bool RemoveOfficeData(OfficeDTO office);
        bool ModifyOfficeData(OfficeDTO office);
    }
}
