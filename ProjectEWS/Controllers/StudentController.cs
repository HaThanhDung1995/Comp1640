using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;

namespace ProjectEWS.Controllers
{
    public class StudentController : Controller
    {
        DataContext dbc = new DataContext();
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
            var model = dbc.Students.AsNoTracking().SingleOrDefault(a => a.UserName == Username && a.Pass == Password);
            if (model != null)
            {
                Session["Student"] = model;
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

        // GET: Student
        public ActionResult Register()
        {
            ViewBag.CoordinatorId = new SelectList(dbc.Coordinators, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public ActionResult Register(HttpPostedFileBase ImageUpload, string Username, string Pass, string FullName, int CoordinatorId)
        {
            ViewBag.CoordinatorId = new SelectList(dbc.Coordinators, "Id", "FullName");
            var message = "";
            var url = "";
            if (ImageUpload.ContentLength > 0)
            {
                url = Guid.NewGuid() + ImageUpload.FileName.Substring(ImageUpload.FileName.LastIndexOf("."));
                ImageUpload.SaveAs(Server.MapPath("~/images/products/" + url));
            }
            else
            {
                url = "Product.png";
            }
            Student student = new Student
            {
                Pass = Pass,
                UserName = Username,
                FullName = FullName,
                CoordinatorId = CoordinatorId,
                ImgUrl = url
            };
            dbc.Students.Add(student);
            dbc.SaveChanges();
            return RedirectToAction("Register");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Student");
            return RedirectToAction("Login");
        }
    }
}