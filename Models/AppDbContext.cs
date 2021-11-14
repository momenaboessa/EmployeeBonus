using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeBonus.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Bonus> Bonus { get; set; }

    }
}