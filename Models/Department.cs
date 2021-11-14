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
        public string Name { get; set; }
    }
}