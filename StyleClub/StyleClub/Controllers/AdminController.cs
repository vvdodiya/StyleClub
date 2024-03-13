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

        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Admin adm)
        {
            Admin ad = db.Admins.Where(x => x.Username == adm.Username && x.Password == adm.Password).SingleOrDefault();
            if(ad!=null)
            {
                Session["id"] = ad.id.ToString();
                return RedirectToAction("Category");
            }
            else
            {
                ViewBag.error = "invalid username or password";
            }
            return View();
        }

        public ActionResult Category()
        {
            if (Session["id"]== null)
            {
                return RedirectToAction("Login");
            }

            
            return View();
        }

        public ActionResult Category(Category cat, HttpPostedFileBase image)
        {
            string path = uploadimage(image);
            if(path.Equals("-1"))
            {
                ViewBag.error = "image could not uploaded";
            }
            else
            {
                Category ca = new Category();
                ca.cat_name = cat.cat_image;
                ca.cat_image = path;
                ca.ad_id_fk = Convert.ToInt32(Session["id"].ToString());
                db.Categories.Add(ca);
                db.SaveChanges();

                return RedirectToAction("Category");
            }
            return View();
        }



    }
}