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
    public class CourseManagerController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: CourseManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Courses.ToList();
            var model = new Cours();
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Courses.ToList();
            var model = dbc.Courses.Find(Id);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Cours model)
        {
            try
            {
                dbc.Courses.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Courses.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(Cours model)
        {
            try
            {
                dbc.Entry(model).State = EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("Edit", new { model.Id });
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
                ViewBag.Items = dbc.Courses.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Courses.Find(Id);
            try
            {
                dbc.Courses.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Courses.ToList();
                return View("Index", model);
            }
        }
    }
}