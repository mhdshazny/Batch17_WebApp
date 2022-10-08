using Batch17_WebApp.Db;
using Batch17_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch17_WebApp.Controllers
{
    public class SalaryController : Controller
    {
        private readonly AppDbContext dbContext;

        public SalaryController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: SalaryController/Create/EmpID
        public ActionResult Create(int id)
        {
            EmployeeModel empdata = dbContext.Employees.Include(i=>i.Salaries).FirstOrDefault(i=>i.ID==id);
            ViewBag.EmpID = empdata.ID;
            ViewBag.EmpName = empdata.Name;
            ViewBag.EmpAddress = empdata.Address;
            ViewBag.EmpStatus = empdata.Status;
            return View();
        }

        // POST: SalaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaryModel Data)
        {
            try
            {
                Data.ID = 0;
                dbContext.Entry(Data).State = EntityState.Added;
                dbContext.Salaries.Add(Data);
                int i = dbContext.SaveChanges();
                if (i>0)
                    return RedirectToActionPermanent("Details", "Employee", Data.Employee.ID);
                else
                    return RedirectToActionPermanent("Details", "Employee", Data.Employee.ID);

            }
            catch (Exception er)
            {
                return RedirectToActionPermanent("Details", "Employee", Data.Employee.ID);
            }
        }

        // GET: SalaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
