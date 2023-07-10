using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace OnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {

            var degerler = c.Products.ToList();
            return View(degerler);
        }

  
            public ActionResult AddProduct()
        { 
            
            List<SelectListItem> deger1=(from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.CategoryId.ToString(),
                                         }
                                         ).ToList();

            ViewBag.dgr1 = deger1;
           
            
            return View();
        
        
        }

        







        [HttpPost]

        public ActionResult AddProduct(Product p) 
        
        
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        
        
        }
        public ActionResult DeleteProduct(int id)
        
        {
            var pr = c.Products.Find(id);
          c.Products.Remove(pr);
            c.SaveChanges();
            return View("Index"); }    



        public ActionResult GetProduct(int id) 
        
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString(),
                                           }
                                           ).ToList();

            ViewBag.dgr1 = deger1;


            var pro =c.Products.Find(id);
            return View("GetProduct", pro);
        
        }

        public ActionResult UpdateProduct(Product p)
        {


            var prod =c.Products.Find(p.ProductId);
            prod.ProductName = p.ProductName;
            prod.Brand= p.Brand;
            prod.PurchasePrice= p.PurchasePrice;
            prod.SalePrice= p.SalePrice;
            prod.Stock=p.Stock;
            prod.Categories= p.Categories;
            c.SaveChanges();
            return RedirectToAction("Index");
            


        }
        public ActionResult ProductList()
        {
            var degerler = c.Products.ToList();
            
            
            return View( degerler); }

        [HttpGet]
        public ActionResult NewSale(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelName + "" + x.PersonalSurname,
                                               Value = x.PersonelId.ToString()




                                           }).ToList();
            List<SelectListItem> v2 = (from x in c.Currents.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CurrentName + "" + x.CurrentSurname,
                                           Value = x.CurrentId.ToString()

                                       }).ToList();
            ViewBag.pr3 = v2;
            ViewBag.np = deger3;
            var pr = c.Products.Find(id);
            ViewBag.pr1 = pr.ProductId;
            ViewBag.pr2 = pr.SalePrice;
          

            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesTransaction s)
        {

            c.SalesTransactions.Add(s);
            c.SaveChanges();
            return View("Index");
          }


    }
}