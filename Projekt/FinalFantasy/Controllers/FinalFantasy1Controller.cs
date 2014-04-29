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
            var comment = db.Comments.Where(c => c.SiteID == id); ;
            return View(comment);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Comments comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(comment);
        }

        public ActionResult Edit(int id)
        {
            var comment = db.Comments.Find(id);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comments comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(comment);
        }
    }
}
