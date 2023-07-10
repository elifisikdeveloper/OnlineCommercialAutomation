using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineCommercialAutomation.Models.Classes;


namespace OnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Categories.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddCategory() 
        
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult AddCategory( Category k)

        {
            c.Categories.Add(k);
            c.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteCategory(int id) 
        
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
             return RedirectToAction("Index");
        
        
        }
       

        public ActionResult GetCategory(int id)
        {


            var ca =c.Categories.Find(id);
            return View("GetCategory", ca);
        }

        public ActionResult UpdateCategory(Category k)
        {
            var cate = c.Categories.Find(k.CategoryId);
            cate.CategoryName = k.CategoryName;
            c.SaveChanges();


                return RedirectToAction("Index");
        }





    }
}