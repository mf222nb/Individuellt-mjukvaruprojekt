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

        //Ladda upp bild
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);
                
                //Hämtar filändelsen
                var fileExtension = Path.GetExtension(file.FileName);

                //Array med godkända filändelser
                var imgExtList = new string[] { ".jpg", ".jpeg", ".png" };
                
                //Om filen innehåller något av de godkända filändelserna så sparas bilden
                if (imgExtList.Contains(fileExtension))
                {
                    //Spara bilden i mappen
                    file.SaveAs(physicalPath);

                    //spara i databasen
                    Image newRecord = new Image();
                    newRecord.Name = ImageName;
                    db.Images.Add(newRecord);
                    db.SaveChanges();
                }
                //Om det inte är en godkänd filändelse så visas ett felmeddelande för användaren
                else
                {
                    TempData["Error"] = "Kan enbart ladda upp bilder i png eller jpg"; 
                    return RedirectToAction("Gallery");
                }
            }
            return RedirectToAction("Gallery");
        }

        //Komma till sidan med bilder
        public ActionResult Gallery()
        {
            var image = db.Images.ToList();
            ViewData["Error"] = TempData["Error"];
            return View(image);
        }

        //Tar en till en sida som har hand om uppladdningen, med en knapp att välja fil och en knapp för att ladda upp
        public ActionResult Upload()
        {
            return View();
        }

        //Radera bild
        public ActionResult Delete(int id)
        {
            var image = db.Images.Find(id);
            return View(image);
        }

        //Tar bort en bild från katalogen som de ligger i och tar bort namnet ur databasen
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var image = db.Images.Find(id);

            string physicalPath = Server.MapPath("~/Images/" + image.Name);

            db.Images.Remove(image);
            db.SaveChanges();
            System.IO.File.Delete(physicalPath);
            return RedirectToAction("Gallery");
        }
    }
}
