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
    public class GalleryController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Galleries.ToList();
            return View(value);
        }
        public ActionResult GalleryList()
        {
            var value = db.Galleries.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult GalleryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GalleryCreate(Gallery model)
        {
            db.Galleries.Add(model);
            db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        [HttpGet]
        public ActionResult GalleryEdit(int id)
        {
            var value = db.Galleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult GalleryEdit(Gallery model)
        {
            var value = db.Galleries.Find(model.GalleryId);
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        public ActionResult GalleryDelete(int id)
        {
            var value = db.Galleries.Find(id);
            db.Galleries.Remove(value);
            db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
    }
}