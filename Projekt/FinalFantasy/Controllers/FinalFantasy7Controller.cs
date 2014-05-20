using FinalFantasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFantasy.Controllers
{
    public class FinalFantasy7Controller : Controller
    {
        //
        // GET: /FinalFantasy7/

        FinalFantasyEntities db = new FinalFantasyEntities();

        //Visar en sida med ett visst id
        public ActionResult FinalFantasy7(int id)
        {
            var game = db.Sites.Find(id);
            return View(game);
        }

    }
}
