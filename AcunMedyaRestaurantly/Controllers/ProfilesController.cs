using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using AcunMedyaRestaurantly.Entities;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        [HttpGet]
        public ActionResult Index()
        {
            var value = db.Admins.Find(Session["ID"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            value.Username = p.Username;
            value.Password = p.Password;
            value.Name = p.Name;
            value.Surname = p.Surname;
            value.ImageUrl = p.ImageUrl;
            value.Email = p.Email;
            db.SaveChanges();
            return RedirectToAction("Index", "Profiles");
        }
    }
}