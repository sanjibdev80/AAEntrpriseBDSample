using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AeonicTech.Model.DTO
{
    [DataContract]
    public class OfficeDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }
    }
}
