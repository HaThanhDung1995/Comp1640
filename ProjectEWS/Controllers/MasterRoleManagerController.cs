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
    public class MasterRoleManagerController : Controller
    {
        // GET: MasterRoleManager
        DataContext dbc = new DataContext();
        // GET: CourseManager
        public ActionResult Index()
        {
            ViewBag.Items = dbc.MasterRoles.ToList();
            var model = new MasterRole();
            ViewBag.RoleId = new SelectList(dbc.Roles, "Id", "Name");
            ViewBag.MasterId = new SelectList(dbc.Masters, "Id", "Username");
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.MasterRoles.ToList();
            var model = dbc.MasterRoles.Find(Id);
            ViewBag.RoleId = new SelectList(dbc.Roles, "Id", "Name",model.RoleId);
            ViewBag.MasterId = new SelectList(dbc.Masters, "Id", "Username",model.MasterId);
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Insert(MasterRole model)
        {
            try
            {
                dbc.MasterRoles.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.MasterRoles.ToList();
                return View("Index", model);
            }
        }
        [HttpPost]
        public ActionResult Update(MasterRole model)
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
                ViewBag.Items = dbc.MasterRoles.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.MasterRoles.Find(Id);
            try
            {
                dbc.MasterRoles.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.MasterRoles.ToList();
                return View("Index", model);
            }
        }
    }
}