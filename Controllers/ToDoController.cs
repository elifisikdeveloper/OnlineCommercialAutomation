using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Categories.Count().ToString();
            ViewBag.d3 = deger3;
            var degerler = c.ToDos.ToList();

            return View(degerler);
        }

        public ActionResult AddToDo()
        { return View(); }
    }
}