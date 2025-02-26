using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using AcunMedyaRestaurantly.Entities;
using System.IO;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        [HttpGet]
        public ActionResult Index()
        {
            if(Session["ID"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = db.Admins.Find(Session["ID"]);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var value = db.Admins.Find(p.AdminId);
            if(value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz şifre yanlış!");
            }
            if (p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Images\\";
                var fileName = Path.Combine(saveLocation,p.ImageFile.FileName);
                p.ImageFile.SaveAs(fileName);
                value.ImageUrl = "/Images/" + p.ImageFile.FileName;
            }
            else
            {

                value.ImageUrl = p.ImageUrl;
            }
            value.Username = p.Username;
            value.Password = p.Password;
            value.Name = p.Name;
            value.Surname = p.Surname;
            value.Email = p.Email;
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }
    }
}