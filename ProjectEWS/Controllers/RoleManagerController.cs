using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;

namespace ProjectEWS.Controllers
{
    public class RoleManagerController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: SemesterManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Roles.ToList();
            var model = new Role();

            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Roles.ToList();
            var model = dbc.Roles.Find(Id);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Role model)
        {
            try
            {
                dbc.Roles.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Roles.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(Role model)
        {
            try
            {
                dbc.Entry(model).State = EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
                ViewBag.Items = dbc.Roles.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Roles.Find(Id);
            try
            {
                dbc.Roles.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Roles.ToList();
                return View("Index", model);
            }
        }
    }
}