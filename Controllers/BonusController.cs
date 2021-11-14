using EmployeeBonus.Models;
using EmployeeBonus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EmployeeBonus.Controllers
{
    public class BonusController : Controller
    {
        private readonly AppDbContext _context;
        public BonusController()
        {
            _context = new AppDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Bonus
        public ActionResult Index()
        {
            IEnumerable<Bonus> bonus = _context.Bonus
                .Include(b => b.Department);

            return View(bonus);
        }

        public ActionResult New()
        {
            var bonus = new Bonus();
            var departments = _context.Departments.ToList();

            var viewModel = new EmployeeBonusViewModel
            {
                Bonus = bonus,
                Departments = departments
            };
            return View("BonusForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var bonus = _context.Bonus.SingleOrDefault(b => b.Id == id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            var departments = _context.Departments.ToList();

            var viewModel = new EmployeeBonusViewModel
            {
                Bonus = bonus,
                Departments = departments
            };
            return View("BonusForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var bonus = _context.Bonus.SingleOrDefault(e => e.Id == id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            _context.Bonus.Remove(bonus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bonus bonus)
        {
            if (!ModelState.IsValid)
            {
                var Departments = _context.Departments.ToList();
                var viewModel = new EmployeeBonusViewModel
                {
                    Bonus = bonus,
                    Departments = Departments
                };
                return View("BonusForm", viewModel);
            }
            else if (bonus.Id == 0)
            {
                _context.Bonus.Add(bonus);
                _context.SaveChanges();
            }
            else
            {
                var bonusInDb = _context.Bonus.SingleOrDefault(b => b.Id == bonus.Id);
                if (bonusInDb == null)
                {
                    return HttpNotFound();
                }

                bonusInDb.EmployeeName = bonus.EmployeeName;
                bonusInDb.DepartmentId = bonus.DepartmentId;
                bonusInDb.ExperienceLevel = bonus.ExperienceLevel;
                bonusInDb.JoiningDate = bonus.JoiningDate;
                bonusInDb.Salary = bonus.Salary;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}