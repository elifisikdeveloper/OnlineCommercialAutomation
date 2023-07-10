using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class SalesTransactionController : Controller
    {
        Context c = new Context();
        // GET: SalesTransaction
        public ActionResult Index()
        {
            var degerler = c.SalesTransactions.ToList();
            return View(degerler);
        }



        [HttpGet]
        public ActionResult AddS()
        {
            List<SelectListItem> v1 = (from x in c.Products.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ProductName,
                                           Value = x.ProductId.ToString()

                                       }).ToList();
            List<SelectListItem> v2 = (from x in c.Currents.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CurrentName + "" + x.CurrentSurname,
                                           Value = x.CurrentId.ToString()

                                       }).ToList();
            List<SelectListItem> v3 = (from x in c.Personals.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.PersonelName + "" + x.PersonalSurname,
                                           Value = x.PersonelId.ToString()

                                       }).ToList();

            ViewBag.dg1 = v1;
            ViewBag.dg2 = v2;
            ViewBag.dg3 = v3;



            return View();
        }

        [HttpPost]
        public ActionResult AddS(SalesTransaction s)
        {



            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return View("Index");



        }
        public ActionResult GetS( int id)
        {

            List<SelectListItem> v1 = (from x in c.Products.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ProductName,
                                           Value = x.ProductId.ToString()

                                       }).ToList();
            List<SelectListItem> v2 = (from x in c.Currents.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CurrentName + "" + x.CurrentSurname,
                                           Value = x.CurrentId.ToString()

                                       }).ToList();
            List<SelectListItem> v3 = (from x in c.Personals.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.PersonelName + "" + x.PersonalSurname,
                                           Value = x.PersonelId.ToString()

                                       }).ToList();

            ViewBag.dg1 = v1;
            ViewBag.dg2 = v2;
            ViewBag.dg3 = v3;


            var deger = c.SalesTransactions.Find(id);
            return View("GetS",deger);
        }
        public ActionResult UpdateSales(SalesTransaction s){

            var deger = c.SalesTransactions.Find(s.SalesTransactionId);
            deger.SalesTransactionId = s.SalesTransactionId;
            deger.CurrentId = s.CurrentId;
            deger.Date = s.Date;
            deger.Piece = s.Piece;
            deger.Price = s.Price;
            deger.TotalPrice    = s.TotalPrice;
            deger.PersonelId = s.PersonelId;
            c.SaveChanges();
         return RedirectToAction("Index");
        
        }

        public ActionResult SalesDetail( int id)
        {


            var degerlert=c.SalesTransactions.Where(x=>x.SalesTransactionId == id);
            return View(degerlert);
        }

    }     
}


