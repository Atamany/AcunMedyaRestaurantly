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
    public class TestimonialController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Testimonials.ToList();
            return View(value);
        }
        public ActionResult TestimonialList()
        {
            var value = db.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult TestimonialCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestimonialCreate(Testimonial model)
        {
            db.Testimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult TestimonialEdit(int id)
        {
            var value = db.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult TestimonialEdit(Testimonial model)
        {
            var value = db.Testimonials.Find(model.TestimonialId);
            value.Name = model.Name;
            value.Title = model.Title;
            value.Description = model.Description;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult TestimonialDelete(int id)
        {
            var value = db.Testimonials.Find(id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}