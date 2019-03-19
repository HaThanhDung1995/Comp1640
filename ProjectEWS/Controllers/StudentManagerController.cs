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
    public class StudentManagerController : Controller
    {
        // GET: StudentManager
        DataContext dbc = new DataContext();
        // GET: CourseManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Students.ToList();
            var model = new Student();
            ViewBag.CoordinatorId = new SelectList(dbc.Coordinators, "Id", "FullName");
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Students.ToList();
            var model = dbc.Students.Find(Id);
            ViewBag.CoordinatorId = new SelectList(dbc.Coordinators, "Id", "FullName", model.CoordinatorId);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(Student model)
        {
            try
            {
                var file = Request.Files["UpImage"];
                if (file.ContentLength > 0)
                {
                    model.ImgUrl = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                    file.SaveAs(Server.MapPath("~/images/products/" + model.ImgUrl));
                }
                else
                {
                    model.ImgUrl = "Product.png";
                }
                dbc.Students.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Students.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(Student model)
        {
            var file = Request.Files["UpImage"];
            if (file.ContentLength > 0)
            {
                if (model.ImgUrl != "Product.png")
                {
                    System.IO.File.Delete(Server.MapPath("~/images/products/" + model.ImgUrl));
                }
                model.ImgUrl = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/images/products/" + model.ImgUrl));
            }
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
                ViewBag.Items = dbc.Students.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Students.Find(Id);
            if (model.ImgUrl != "Product.png")
            {
                System.IO.File.Delete(Server.MapPath("~/images/products/" + model.ImgUrl));
            }
            try
            {
                dbc.Students.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Students.ToList();
                return View("Index", model);
            }
        }
    }
}