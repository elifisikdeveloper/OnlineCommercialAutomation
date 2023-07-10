using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class PersonelController : Controller
    {
        Context c=new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personals.ToList();
            return View(degerler);
        }

        public ActionResult AddPersonal() { return View(); }



        [HttpPost]
        public ActionResult AddPersonal(Personal p)
        {
            if (Request.Files.Count>0)
            {string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + filename + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelImage = "/Image/" + filename + uzantı;

            }
            c.Personals.Add(p);
            c.SaveChanges();

            return View("Index");
        }

        public ActionResult DeletePersonal(int id)
        {
            var degerler = c.Personals.Find(id);
            c.Personals.Remove(degerler);
            c.SaveChanges();
            return View();
        }

        public ActionResult GetPersonal(int id)


        {

            var pe = c.Personals.Find(id);
            return View("GetPersonal", pe);

        }

        public ActionResult UpdatePersonal(Personal p)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + filename + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelImage = "/Image/" + filename + uzantı;

            }
            var dep = c.Personals.Find(p.PersonelId);
            dep.PersonelName = p.PersonelName;
            dep.PersonalSurname = p.PersonalSurname;
            dep.PersonelImage = p.PersonelImage;
            dep.DepartmentId = p.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult PersonelContact()
        {
           var  degerler = c.Personals.ToList(); 
            
            return View(degerler); }

    }
}