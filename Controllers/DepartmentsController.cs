using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EmployeeBonus.Models;

namespace EmployeeBonus.Controllers
{
    
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;
        public DepartmentsController()
        {
            _context = new AppDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Deparments
        public ActionResult Index()
        {
            IEnumerable<Department> departments = _context.Departments.ToList();

            return View(departments);
        }

        public ActionResult New()
        {
            var department = new Department();
           
            return View("DepartmentForm", department);
        }

        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(e => e.Id == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            
            return View("DepartmentForm", department);
        }

        public ActionResult Delete(int id)
        {
            var department = _context.Departments.SingleOrDefault(d => d.Id == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmentForm", department);
            }
            else if (department.Id == 0)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            else
            {
                var departmentInDb = _context.Departments.SingleOrDefault(d => d.Id == department.Id);
                if (departmentInDb == null)
                {
                    return HttpNotFound();
                }

                departmentInDb.Name = department.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}