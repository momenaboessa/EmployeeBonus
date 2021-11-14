using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBonus.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string ExperienceLevel { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Salary { get; set; }
        public int Bonus { get; set; }

    }
}