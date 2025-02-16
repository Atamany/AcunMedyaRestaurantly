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
    public class FeatureController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Features.ToList();
            return View(value);
        }
        public ActionResult FeatureList()
        {
            var value = db.Features.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult FeatureCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeatureCreate(Feature model)
        {
            db.Features.Add(model);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public ActionResult FeatureEdit(int id)
        {
            var value = db.Features.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult FeatureEdit(Feature model)
        {
            var value = db.Features.Find(model.FeatureId);
            value.Subtitle = model.Subtitle;
            value.Title = model.Title;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        public ActionResult FeatureDelete(int id)
        {
            var value = db.Features.Find(id);
            db.Features.Remove(value);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}