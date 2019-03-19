using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEWS.Entity;
using ProjectEWS.Filter;

namespace ProjectEWS.Controllers
{
    [Author(PermissionNames = "Manager")]
    public class MangerController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Manger
        public ActionResult Index()
        {
            var model = dbc.Magazines.AsNoTracking().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Zip()
        {
            var model = dbc.Magazines.AsNoTracking().ToList();
            ViewBag.Message = "Your contact page.";
            try
            {
                string path = Server.MapPath("~/images/products/");
                string archive_path = Server.MapPath("~/Archived/");
                if (!Directory.Exists(archive_path))
                {
                    Directory.CreateDirectory(archive_path);
                }

                var url =  "uploaded_" + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() +
                          DateTime.Now.Second.ToString() + ".zip";
                ViewBag.url = url;
                System.IO.Compression.ZipFile.CreateFromDirectory(path,archive_path+ url);
            }
            catch { }
            return View("Index", model);
        }
        public ActionResult DownloadFile(String url)
        {
            string filename = url;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Archived/" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}