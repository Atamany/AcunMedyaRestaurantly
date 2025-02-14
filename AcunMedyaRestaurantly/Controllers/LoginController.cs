using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedyaRestaurantly.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = db.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username.ToString();
                return RedirectToAction("ProductList", "Product");
            }
            else
            {
                return View();
            }
        }
    }
}