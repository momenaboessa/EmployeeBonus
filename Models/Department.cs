using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBonus.Models
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }

        public virtual List<Bonus> Bonus { get; set; }
    }
}