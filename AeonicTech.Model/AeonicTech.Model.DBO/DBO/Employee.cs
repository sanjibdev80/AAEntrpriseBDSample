using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AeonicTech.Model.DBO
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [ForeignKey("Office")]
        public int OfficeId { get; set; }

        //public virtual ICollection<Office> Office { get; set; }

    }
}
