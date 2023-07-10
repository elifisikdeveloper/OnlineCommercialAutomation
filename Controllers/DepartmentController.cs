using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Departments.ToList();
            return View(degerler);
        }



        [HttpGet]
        public ActionResult AddDepartment() 
        
        {
            

            return View();

        }



        [HttpPost]
        public ActionResult AddDepartment(  Department d)

        {
            c.Departments.Add(d);
            c.SaveChanges();


            return RedirectToAction("Index");

        }

        public ActionResult DeleteDepartment(int id)
        {

            var de=c.Departments.Find(id);
            c.Departments.Remove(de);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]

        public ActionResult GetDepartment(int id) 
        {
            var dep = c.Departments.Find(id);

            return View("GetDepartment", dep);
        
        }

      
        public ActionResult UpdateDepartment    (Department d)
        {
            var dep = c.Departments.Find(d.DepartmentId);
            dep.DepartmentName = d.DepartmentName;
            c.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult PersonelDetail(int id)
        {

            var degerler = c.Personals.Where(x => x.DepartmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(x => x.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;

            return View(degerler);
        }

        public ActionResult PersonelSellingDetail(int id)


        {
            var degerler = c.SalesTransactions.Where(x => x.PersonelId == id).ToList();

            return View(degerler);
        }



    }
}