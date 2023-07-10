using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Invoices.ToList();
            return View(degerler);
        }

        public ActionResult AddInvoice()

        { return View(); }



        [HttpPost]
        public ActionResult AddInvoice(Invoice i)
        { 
             c.Invoices.Add(i);
            c.SaveChanges();
        return View("Index");
        
        
        }
        public ActionResult GetInvoice(int id)


        {
            var pe = c.Invoices.Find(id);
            return View("GetInvoice", pe);

        }

        public ActionResult UpdateInvoice(Invoice p)
        {
            var dep = c.Invoices.Find(p.InvoiceId);
            dep.InvoiceSerialNo = p.InvoiceSerialNo;
            dep.InvoiceRotationNo = p.InvoiceRotationNo;
            dep.Time = p.Time;
            dep.Deliverer = p.Deliverer;
            dep.Recipient=p.Recipient;
            dep.TotalPrice=p.TotalPrice;
            dep.TaxOffice=p.TaxOffice;  
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult InvoiceItem(int id)
        {
            var degerler=c.InvoiceItems.Where(x=>x.InvoiceId==id).ToList(); 
        

            
            
            
            return View(degerler); } 


    }
}