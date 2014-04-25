using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFantasy.Controllers
{
    public class FinalFantasy1Controller : Controller
    {
        //
        // GET: /FinalFantasy1/

        FinalFantasyEntities gameDB = new FinalFantasyEntities();

        public ActionResult FinalFantasy1(int id)
        {
            var game = gameDB.Sites.Find(id);
            return View(game);
        }

    }
}
