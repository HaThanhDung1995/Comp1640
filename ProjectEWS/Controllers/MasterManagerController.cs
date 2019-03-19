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
    public class MasterManagerController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: SemesterManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Masters.ToList();
            var model = new Master();
            
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Masters.ToList();
            var model = dbc.Masters.Find(Id);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Master model)
        {
            try
            {
                dbc.Masters.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Masters.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(Master model)
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
                ViewBag.Items = dbc.Masters.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Masters.Find(Id);
            try
            {
                dbc.Masters.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Masters.ToList();
                return View("Index", model);
            }
        }
    }
}