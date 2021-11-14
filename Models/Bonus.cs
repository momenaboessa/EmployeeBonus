using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeBonus.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string EmployeeName { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int ExperienceLevel { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public int BonusAmount {
            get 
            {
                if (DateTime.Today.Month - JoiningDate.Month >= 0 && DateTime.Today.Day >= JoiningDate.Day && DateTime.Today.Year > JoiningDate.Year)
                {
                    return (int)Salary * 2;
                }
                return 0;
            }
        }

    }
}