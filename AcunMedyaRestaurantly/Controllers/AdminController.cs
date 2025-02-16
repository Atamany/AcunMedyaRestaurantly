using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Admins.ToList();
            return View(value);
        }
        public ActionResult AdminList()
        {
            var value = db.Admins.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AdminCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCreate(Admin model)
        {
            db.Admins.Add(model);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            var value = db.Admins.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin model)
        {
            var value = db.Admins.Find(model.AdminId);
            value.Username = model.Username;
            value.Password = model.Password;
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
        public ActionResult AdminDelete(int id)
        {
            var value = db.Admins.Find(id);
            db.Admins.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
    }
}