using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineCommercialAutomation.Models.Classes;
namespace OnlineCommercialAutomation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c=new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {


            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current cu)
        { 
            c.Currents.Add(cu);
            c.SaveChanges();


            return PartialView();
        }




        [HttpGet]
        public ActionResult CariLogin1() { return View(); }






        [HttpPost]
        public ActionResult CariLogin1(Current cu)
        { 
        
        var bilgiler=c.Currents.FirstOrDefault(X=>X.CurrentMail==cu.CurrentMail && X.CurrentPassword==cu.CurrentPassword);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
                Session["CurrentMail"]=bilgiler.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");

            }
            else
            {

                return RedirectToAction("Index");
            }


        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();




        }
        //[HttpPost]
        //public ActionResult AdminLogin(Admin p)
        //{
        //    var bilgiler=c.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);   

        //    if(bilgiler!=null)
        //    {
        //        FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
        //        Session["UserName"]=bilgiler.UserName.ToString();
        //        return RedirectToAction("Index ", "Category");

        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }






        //}

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            if (!string.IsNullOrEmpty(p.UserName) && !string.IsNullOrEmpty(p.Password))
            {
                var bilgiler = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                    Session["UserName"] = bilgiler.UserName.ToString();
                    return RedirectToAction("Index", "Category");
                }
            }

            // Kullanıcı adı veya parola boş veya geçersiz olduğunda
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya parola";
            return RedirectToAction("Index", "Login");
        }

















        //[HttpGet]
        //public ActionResult Partial2()
        //{


        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Partial2(Current cu)
        //{
        // var bilgiler =c.Currents.FirstOrDefault(x=>x.CurrentMail==cu.CurrentMail && x.CurrentPassword==cu.CurrentPassword);
        //    if (bilgiler !=null)
        //    {
        //        FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
        //        Session["CurrentMail"] = bilgiler.CurrentMail.ToString();
        //            return RedirectToAction("Index","CurrentPanel");
        //    }
        //    else
        //    {
        //        return PartialView("Index","Login");
        //    }


        //}
    }
}