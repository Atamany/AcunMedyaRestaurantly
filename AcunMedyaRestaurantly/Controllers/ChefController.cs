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
    public class ChefController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Chefs.ToList();
            return View(value);
        }
        public ActionResult ChefList()
        {
            var value = db.Chefs.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ChefCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChefCreate(Chef model)
        {
            db.Chefs.Add(model);
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult ChefEdit(int id)
        {
            var value = db.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ChefEdit(Chef model)
        {
            var value = db.Chefs.Find(model.ChefId);
            value.Name = model.Name;
            value.Title = model.Title;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }
        public ActionResult ChefDelete(int id)
        {
            var value = db.Chefs.Find(id);
            db.Chefs.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}