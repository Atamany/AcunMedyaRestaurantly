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
    public class AboutController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Abouts.ToList();
            return View(value);
        }
        public ActionResult AboutList()
        {
            var value = db.Abouts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutCreate(About model)
        {
            db.Abouts.Add(model);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var value = db.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AboutEdit(About model)
        {
            var value = db.Abouts.Find(model.AboutId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutDelete(int id)
        {
            var value = db.Abouts.Find(id);
            db.Abouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}