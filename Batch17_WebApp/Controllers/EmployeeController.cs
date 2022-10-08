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
    public class EmployeeController : Controller
    {
        private readonly AppDbContext dbContext;
        public EmployeeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: EmployeeController
        public ActionResult Index(ReturnModel data = null) 
        {
            if (data == null || data.Model==null)
            {
                var Data = dbContext.Employees.ToList();
                return View(Data);
            }
            else
            {
                ViewBag.ReturnModel = data;
                return View();
            }
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeModel Data = dbContext.Employees.Include(i=>i.Salaries).Where(x=>x.ID==id).FirstOrDefault();
            return View(Data);
        }

        // GET: EmployeeController/Create
        public ActionResult Create(ReturnModel data=null)
        {
            if (data == null || data.Model == null)
                return View();
            else
                ViewBag.ReturnModel = data;
                return View(data.Model);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel data)
        {
            try
            {
                if (data!=null)
                {
                    dbContext.Employees.Add(data);
                    int result = dbContext.SaveChanges();
                    if (result > 0) return RedirectToAction(nameof(Index),"Employee",new ReturnModel { Status= ReturnStatus.success.ToString(), Message="Data Inserted Successfully"});
                    else return RedirectToAction(nameof(Create),"Employee",new ReturnModel { Status= ReturnStatus.failed.ToString(), Message="Data Inserted Successfully", Model=data});
                }
                else
                    return RedirectToAction(nameof(Index), "Employee", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Data Captured", Model=new EmployeeModel { } });
            }
            catch(Exception er)
            {
                return RedirectToAction(nameof(Create), "Employee", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown"+ er.Message });
            }
        }

        // GET: EmployeeController/Update/5
        public ActionResult Update(int id, ReturnModel data = null)
        {
            if (data == null || data.Model == null)
            {
                var records = dbContext.Employees.Find(id);
                if (records != null)
                    return View(records);
                else
                    return RedirectToAction(nameof(Index), "Employee", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found" });
            }
            else
                ViewBag.ReturnModel = data;
                return View(data.Model);


        }

        // POST: EmployeeController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, EmployeeModel data)
        {
            try
            {
                if (data!=null)
                {
                    dbContext.Employees.Update(data);
                    int result = await dbContext.SaveChangesAsync();
                    if (result > 0) return RedirectToAction(nameof(Index), "Employee", new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Data Updated Successfully" });
                    else return RedirectToAction(nameof(Update), "Employee", new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Update Failed", Model = data });
                }
                return RedirectToAction(nameof(Update), "Employee", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found", Model = new EmployeeModel { } });
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Update), "Employee", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }

        // EmployeeController/Delete/5
        public async Task<ActionResult<ReturnModel>> Delete(int id, EmployeeModel data)
        {
            try
            {
                if (id > 0)
                {
                    data = dbContext.Employees.Find(id);
                    dbContext.Employees.Remove(data);
                    int result = await dbContext.SaveChangesAsync();
                    if (result > 0) return new ReturnModel { Status = ReturnStatus.success.ToString(), Message = "Record Removed Successfully" };
                    else return new ReturnModel { Status = ReturnStatus.failed.ToString(), Message = "Record Removal Failed", Model = data };
                }
                return RedirectToAction(nameof(Index), "Employee", new ReturnModel { Status = ReturnStatus.NoData.ToString(), Message = "No Records Found"});
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Index), "Employee", new ReturnModel { Status = ReturnStatus.serverFailed.ToString(), Message = "Exception thrown :" + er.Message });
            }
        }
    }
}
