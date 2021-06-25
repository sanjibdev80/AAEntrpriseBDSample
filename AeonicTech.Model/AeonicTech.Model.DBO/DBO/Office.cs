using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeonicTech.Model.DBO
{
    public class Office
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }



        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
