using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace FinalFantasy.Controllers
{
    public class FinalFantasy1Controller : Controller
    {
        //
        // GET: /FinalFantasy1/

        FinalFantasyEntities db = new FinalFantasyEntities();

        public ActionResult FinalFantasy1(int id)
        {
            var game = db.Sites.Find(id);
            return View(game);
        }

        //Hämtar ut alla kommentarerna som tillhör en viss sida
        public ActionResult Details(int id)
        {
            var comment = db.Comments.Where(c => c.SiteID == id);
            return View(comment);
        }

        //Sapa kommentarer
        public ActionResult Create()
        {
            return View();
        }

        //När man ska posta till databasen så tar denna hand om det
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comments createComment)
        {
            if (ModelState.IsValid)
            {
                createComment.SiteID = 1;
                db.Comments.Add(createComment);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = "1" });
            }
            return View(createComment);
        }

        //Redigera kommentarer
        public ActionResult Edit(int id)
        {
            var comment = db.Comments.Find(id);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comments editComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = "1" });
            }
            return View(editComment);
        }

        //Radera kommentarer
        public ActionResult Delete(int id)
        {
            var comment = db.Comments.Find(id);
            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = "1" });
        }
    }
}
