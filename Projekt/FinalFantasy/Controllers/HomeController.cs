using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFantasy.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        FinalFantasyEntities db = new FinalFantasyEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);

                //Spara bilden i mappen
                file.SaveAs(physicalPath);

                //spara i databasen
                Image newRecord = new Image();
                newRecord.Name = ImageName;
                db.Images.Add(newRecord);
                db.SaveChanges();
            }
            return RedirectToAction("Gallery");
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}
