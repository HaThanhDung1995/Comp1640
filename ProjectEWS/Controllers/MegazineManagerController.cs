using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;
using ProjectEWS.Filter;

namespace ProjectEWS.Controllers
{
    [Author(PermissionNames = "Admin")]
    public class MegazineManagerController : Controller
    {
        // GET: MegazineManager
        DataContext dbc = new DataContext();
        // GET: CourseManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Magazines.ToList();
            
            
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Magazines.Find(Id);
            if (model.Url != "Product.png")
            {
                System.IO.File.Delete(Server.MapPath("~/images/products/" + model.Url));
            }
            try
            {
                dbc.Magazines.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Magazines.ToList();
                return View("Index", model);
            }
        }
    }
}