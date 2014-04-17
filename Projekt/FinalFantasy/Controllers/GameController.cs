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

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Details(int id) 
        {
            var site = new Site { Sida = "Sida " + id };

            return View(site);
        }
    }
}
