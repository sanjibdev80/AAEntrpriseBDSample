using System;
using System.Runtime.Serialization;

namespace AeonicTech.Model.DTO
{
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public string OfficeLocation { get; set; }
    }
}
