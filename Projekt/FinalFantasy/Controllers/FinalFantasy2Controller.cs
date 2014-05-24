using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFantasy.Controllers
{
    public class FinalFantasy2Controller : Controller
    {
        //
        // GET: /FinalFantasy2/

        FinalFantasyEntities db = new FinalFantasyEntities();

        public ActionResult FinalFantasy2(int id)
        {
            var game = db.Sites.Find(id);
            return View(game);
        }

        //Hämtar ut alla kommentarer som tillhör ett visst sidID
        public ActionResult Details(int id)
        {
            var comment = db.Comments.Where(c => c.SiteID == id); ;
            return View(comment);
        }

        //Sapa kommentarer
        public ActionResult Create()
        {
            return View();
        }

        //När man ska posta till databasen så tar denna Create hand om det
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comments createComment)
        {
            if (ModelState.IsValid)
            {
                createComment.SiteID = 2;
                db.Comments.Add(createComment);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = "2" });
            }
            return View(createComment);
        }

        //Redigera kommentarer
        public ActionResult Edit(int id)
        {
            var comment = db.Comments.Find(id);
            return View(comment);
        }

        //När det ska ske en post så tar denna Edit hand om det
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comments editComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = "2" });
            }
            return View(editComment);
        }

        //Radera kommentarer
        public ActionResult Delete(int id)
        {
            var comment = db.Comments.Find(id);
            return View(comment);
        }

        //När det sker en post och man ska ta bort en kommentar så tar denna DeleteConfirmed hand om detta.
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = "2" });
        }
    }
}
