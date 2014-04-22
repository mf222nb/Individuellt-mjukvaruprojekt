using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalFantasy.Models;

namespace FinalFantasy.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/
        FinalFantasyEntities gameDB = new FinalFantasyEntities();

        public ActionResult Index()
        {
            var games = gameDB.Site.ToList();
            return View(games);
        }

        public ActionResult Details(string game) 
        {
            var site = new Site { SiteName = "Sida " + game };

            return View(site);
        }
    }
}
