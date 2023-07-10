using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c =new Context();
        public ActionResult Index(string p)
        {
            var k=from x in c.Cargos select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TrackingCode.Contains(p));
            }
       
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult AddCargo()

        {
            Random rand = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1=rand.Next(0,4);
            k2=rand.Next(0,4);  
            k3=rand.Next(0,4);
            int s1,s2,s3;
            s1=rand.Next(100,1000);
            s2=rand.Next(10,99);
            s3=rand.Next(10,99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[2] + s3 + karakterler[3];
            ViewBag.takipkod = kod;
            return View();

        }
        [HttpPost]
        public ActionResult AddCargo(Cargo k)

        {
            c.Cargos.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");

        }



        public ActionResult CargoTracking(string  id)
        {
            var degerler = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);


        }
    }
}