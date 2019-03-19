using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;
using ProjectEWS.Filter;
using ProjectEWS.Models;

namespace ProjectEWS.Controllers
{
    [Author(PermissionNames = "Guest|Admin")]
    public class ReportController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Report
        public ActionResult Index()
        {

            var list2 = dbc.Magazines.ToList().ToList();
            var list = dbc.Magazines.Select(a => a.StudentId).ToList();
            ViewBag.Count = list2.Count();
            var list3 = dbc.Magazines.Where(a => a.SemesterId == 1).ToList().Count;
            var list4 = dbc.Magazines.Where(a => a.SemesterId == 2).ToList().Count; 
            var list5 = dbc.Magazines.Where(a => a.Comment == null).ToList().Count;
            
            var list7 = dbc.Magazines.Where(a => a.Student.Coordinator.Cours.Id == 1).ToList().Count;
            var list8 = dbc.Magazines.Where(a => a.Student.Coordinator.Cours.Id == 2).ToList().Count;
            ViewBag.SemesSpring = list3;
            ViewBag.SemesSummer = list4;
            ViewBag.Comment = list5;
            ViewBag.It = list7;
            ViewBag.Business = list8;
            return View(list);
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult ChartByNumberOfFile()
        {
            var model = dbc.Magazines.GroupBy(m => m.Student).Select(d => new Report
            {
                Group = d.Key.FullName,
                Quantity = d.Count()
            });
            return Json(new {model }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChartByNumberOfFile2()
        {
            var model = dbc.Magazines.GroupBy(a => a.Student.Coordinator.Cours).Select(d => new Report
            {
                Group = d.Key.Name,
                Quantity = d.Count()
            });
            return Json(new { model }, JsonRequestBehavior.AllowGet);
        }

    }
}