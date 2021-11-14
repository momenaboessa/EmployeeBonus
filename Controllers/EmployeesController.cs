using EmployeeBonus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EmployeeBonus.ViewModels;

namespace EmployeeBonus.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeesController()
        {
            _context = new AppDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employees
                .Include(e => e.Department);

            return View(employees);
        }

        public ActionResult New()
        {
            var employee = new Employee();
            var departments = _context.Departments.ToList();

            var viewModel = new EmployeeBonusViewModel
            {
                Employee = employee,
                Departments = departments
            };
            return View("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var departments = _context.Departments.ToList();

            var viewModel = new EmployeeBonusViewModel
            {
                Employee = employee,
                Departments = departments
            };
            return View("EmployeeForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var Departments = _context.Departments.ToList();
                var viewModel = new EmployeeBonusViewModel
                { 
                    Employee = employee,
                    Departments = Departments
                };
                return View("EmployeeForm", viewModel);
            }
            else if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            else
            {
                var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                if (employeeInDb == null)
                {
                    return HttpNotFound();
                }

                employeeInDb.Name = employee.Name;
                employeeInDb.DepartmentId = employee.DepartmentId;
                employeeInDb.ExperienceLevel = employee.ExperienceLevel;
                employeeInDb.JoiningDate = employee.JoiningDate;
                employeeInDb.Salary = employee.Salary;
                employeeInDb.Bonus = employee.Bonus;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}