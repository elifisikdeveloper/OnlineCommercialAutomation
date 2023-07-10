using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c =new Context();
        public ActionResult Index()
        {

            var degerler = c.Currents.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddCurrent() 
        
        
        { return View(); }


        [HttpPost]
        public ActionResult AddCurrent(Current cu)
        {
            var cur = c.Currents.Add(cu);

            c.SaveChanges();
            
            return RedirectToAction("Index"); }


        public ActionResult GetCurrent(int id) {

            var cari = c.Currents.Find(id);
            return View("GetCurrent",cari);
            
            
             }    



        public ActionResult UpdateCurrent(Current cu) { 
            
            var curr=c.Currents.Find(cu.CurrentId);
            curr.CurrentName = cu.CurrentName;
            curr.CurrentSurname = cu.CurrentSurname;
            curr.CjurrentCity = cu.CjurrentCity;
            curr.CurrentMail = cu.CurrentMail;
            c.SaveChanges();
            
            
            
            return View("Index"); }


        public ActionResult CurrentSellingDetail(int id)

        {
            var cu = c.SalesTransactions.Where(x => x.CurrentId == id).ToList();


            return View(cu);
        }

       

    }
}