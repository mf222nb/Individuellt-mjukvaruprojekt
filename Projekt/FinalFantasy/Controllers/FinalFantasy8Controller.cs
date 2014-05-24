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
    public class FinalFantasy8Controller : Controller
    {
        //
        // GET: /FinalFantasy8/

        FinalFantasyEntities db = new FinalFantasyEntities();

        //Visar en sida med ett visst id
        public ActionResult FinalFantasy8(int id)
        {
            var game = db.Sites.Find(id);
            return View(game);
        }

        //Visar alla kommentarer som tillhör en viss sida
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
                createComment.SiteID = 8;
                db.Comments.Add(createComment);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = "8" });
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
                return RedirectToAction("Details", new { id = "8" });
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
            return RedirectToAction("Details", new { id = "8" });
        }
    }
}
