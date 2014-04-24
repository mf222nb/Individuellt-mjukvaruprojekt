using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFantasy.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        FinalFantasyEntities gameDB = new FinalFantasyEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult FinalFantasy1(int id)
        {
            var game = gameDB.Sites.Find(id);
            return View(game);
        }

        public ActionResult FinalFantasy2(int id)
        {
            var game = gameDB.Sites.Find(id);
            return View(game);
        }
    }
}
