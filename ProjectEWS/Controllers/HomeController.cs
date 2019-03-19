using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectEWS.Entity;
using ProjectEWS.Filter;

namespace ProjectEWS.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //DateTime date2 = new DateTime(2009, 5, 1, 8, 30, 52);
            //var message = "";
            //if (DateTime.Compare(date1, date2)<0)
            //{
            //    message = "date1 is less than date2";

            //}

            //if (DateTime.Compare(date1, date2) > 0)
            //{
            //    message = "date1 greater than date2";
            //}

            //ViewBag.Message = message;
            //DataContext dbc =new DataContext();;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}