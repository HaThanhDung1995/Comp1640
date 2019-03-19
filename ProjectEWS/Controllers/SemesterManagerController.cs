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
    public class SemesterManagerController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: SemesterManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Semesters.ToList();
            var model = new Semester();
            model.StartDate = DateTime.Now;
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Semesters.ToList();
            var model = dbc.Semesters.Find(Id);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Semester model)
        {
            try
            {
                dbc.Semesters.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Semesters.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(Semester model)
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
                ViewBag.Items = dbc.Semesters.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Semesters.Find(Id);
            try
            {
                dbc.Semesters.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Semesters.ToList();
                return View("Index", model);
            }
        }
    }
}