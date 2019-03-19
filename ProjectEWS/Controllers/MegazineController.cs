using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;
using ProjectEWS.Filter;
using ProjectEWS.Utils;

namespace ProjectEWS.Controllers
{
    public class MegazineController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Megazine
        [Student()]
        public ActionResult Index()
        {
            ViewBag.SemesterId = new SelectList(dbc.Semesters, "Id", "Name");
            Magazine magazine=new Magazine();
            magazine.SentDate=DateTime.Now;
            return View(magazine);
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase ImageUpload,string Comment,DateTime SentDate,int SemesterId,bool Agree)
        {
            ViewBag.SemesterId = new SelectList(dbc.Semesters, "Id", "Name");
            Magazine magazine2 = new Magazine();
            magazine2.SentDate = DateTime.Now;
            var message = "";
            var url = "";
            var studentId = Session["Student"] as Student;
            if (ImageUpload!=null)
            {
                url = Guid.NewGuid() + ImageUpload.FileName.Substring(ImageUpload.FileName.LastIndexOf("."));
                ImageUpload.SaveAs(Server.MapPath("~/images/products/" + url));
            }
            else
            {
                url = "Product.png";
            }
            Magazine magazine=new Magazine
            {
                Comment = Comment,
                SemesterId = SemesterId,
                SentDate = SentDate,
                StudentId = studentId.Id,
                 Url = url
            };
            try
            {
                var seme = dbc.Semesters.Find(SemesterId);
                var moderator = dbc.Students.AsNoTracking().SingleOrDefault(a => a.Id == studentId.Id);
                var deadlin = seme.EndDate;
                if (seme != null)
                {
                    if (Agree == true)
                    {
                        if (DateTime.Compare(SentDate, deadlin) > 0)
                        {
                            
                                message = "Hết hạn gửi bài";
                        }
                        else
                        {
                            dbc.Magazines.Add(magazine);
                            dbc.SaveChanges();
                            var cordinator = moderator.Coordinator.Email;
                            XMailer.Send(cordinator, "Notication", "Student"+studentId.FullName+"Have upload new record ");
                            message = "Submit Successfully";
                        }
                    }
                    else
                    {
                        message = "You have to agree with our policy";
                    }
                }
                
                ViewBag.message = message;
            }
            catch (Exception) { }
            return View(magazine2);
        }
    }
}