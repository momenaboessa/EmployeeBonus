using EmployeeBonus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeBonus.ViewModels
{
    public class EmployeeBonusViewModel
    {
        public Employee Employee { get; set; }
        public virtual List<Department> Departments { get; set; }
    }
}