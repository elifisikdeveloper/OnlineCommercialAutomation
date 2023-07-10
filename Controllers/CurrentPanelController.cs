using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var degerler=c.Currents.FirstOrDefault(x=>x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }


        public ActionResult Siparislerim()
        {

            var mail =(string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault(); 
            var degerler=c.SalesTransactions.Where(x=>x.CurrentId==id).ToList();
            return View(degerler);  


        }
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var mesajlar =c.Messages.Where(x=>x.Recipient==mail).ToList();
            var gelensayisi=c.Messages.Count(x=>x.Recipient==mail).ToString();
            ViewBag.d1=gelensayisi;
            return View(mesajlar);
         
           
        }
        [HttpGet]
        public ActionResult SentMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var mesajlar = c.Messages.Where(x => x.Sender == mail).ToList();
            var gidensayisi = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);


        }
        [HttpGet]
        public ActionResult MessageDetails(int id)
        {
            var degerler = c.Messages.Where(x => x.MessageId == id).ToList();   
            var mail = (string)Session["CurrentMail"];
            var gelensayisi=c.Messages.Count(x=>x.Recipient == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi=c.Messages.Count(x=>x.Sender == mail).ToString();
            ViewBag.d2=gidensayisi;

            
            return View(degerler);


        }
    }
}