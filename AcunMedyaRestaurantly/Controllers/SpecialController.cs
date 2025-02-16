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
    public class SpecialController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Specials.ToList();
            return View(value);
        }
        public ActionResult SpecialList()
        {
            var value = db.Specials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult SpecialCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpecialCreate(Special model)
        {
            db.Specials.Add(model);
            db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        [HttpGet]
        public ActionResult SpecialEdit(int id)
        {
            var value = db.Specials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SpecialEdit(Special model)
        {
            var value = db.Specials.Find(model.SpecialId);
            value.Title = model.Title;
            value.ShortDescription = model.ShortDescription;
            value.FullDescription = model.FullDescription;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        public ActionResult SpecialDelete(int id)
        {
            var value = db.Specials.Find(id);
            db.Specials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
    }
}