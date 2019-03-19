using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;
using ProjectEWS.Filter;

namespace ProjectEWS.Controllers
{
    public class CoordinatorController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Coordinator
        public ActionResult Login(string ReturnUrl, string Message)
        {
            if (ReturnUrl != null && Message != null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                ViewBag.Message = Message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password, string ReturnUrl)
        {
            var model = dbc.Coordinators.AsNoTracking().SingleOrDefault(a => a.UserName == Username && a.Pass == Password);
            if (model != null)
            {
                Session["Cordinator"] = model;
                ViewBag.Message = "Login Succesfully";
                if (ReturnUrl != "")
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }

            return View();
        }
        [Coordinator()]
        public ActionResult MagazineByCordinator()
        {
            var cor = Session["Cordinator"] as Coordinator;
            
            if (cor != null)
            {
                var model = dbc.Coordinators.Find(cor.Id);
                if (model != null)
                {
                    var list = model.Students.ToList();
                    
                    
                    return View(list);
                }
            }
            
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Cordinator");
            return RedirectToAction("Login");
        }
    }
}