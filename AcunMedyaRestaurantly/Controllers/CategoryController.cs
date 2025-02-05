using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class CategoryController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Categories.ToList();
            return View(value);
        }
        public ActionResult CategoryList()
        {
            var value = db.Categories.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate(Category model)
        {
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}