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
    public class CoordinatorManagerController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: CourseManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Coordinators.ToList();
            var model = new Coordinator();
            ViewBag.CourseId = new SelectList(dbc.Courses, "Id", "Name");
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Coordinators.ToList();
            var model = dbc.Coordinators.Find(Id);
            ViewBag.CourseId = new SelectList(dbc.Courses, "Id", "Name",model.CourseId);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Coordinator model)
        {
            try
            {
                dbc.Coordinators.Add(model);
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
        public ActionResult Update(Coordinator model)
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
                ViewBag.Items = dbc.Coordinators.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Coordinators.Find(Id);
            try
            {
                dbc.Coordinators.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Coordinators.ToList();
                return View("Index", model);
            }
        }
    }
}