using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StyleClub.Models;

namespace StyleClub.Controllers
{
    public class AdminController : Controller
    {
        StyleClubdbEntities db = new StyleClubdbEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }


    }
}