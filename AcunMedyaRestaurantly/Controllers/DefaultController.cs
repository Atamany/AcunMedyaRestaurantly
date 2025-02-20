using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class DefaultController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = db.Adresses.Select(x=>x.Call).FirstOrDefault();
            ViewBag.OpenHours = db.Adresses.Select(x=>x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.Subtitle = db.Features.Select(x => x.Subtitle).FirstOrDefault();
            ViewBag.Title = db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.ImageUrl = db.Features.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var value = db.Services.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialMenu()
        {
            var value = db.Products.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate = DateTime.Now;
            model.isRead = false;
            db.Contacts.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");

        }
        public PartialViewResult PartialSpecial()
        {
            var value = db.Specials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialBookaTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookTableAdd(Reservation model)
        {
            model.ReservationStatus = "Onay Bekliyor";
            db.Reservations.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Rezervasyon Başvurusu Başarılı";
            return View("Index");

        }
        public PartialViewResult PartialTestimonial()
        {
            var value = db.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialChef()
        {
            var value = db.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialEvent()
        {
            var value = db.Events.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFooter()
        {
            var value = db.Adresses.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialGallery()
        {
            var value = db.Galleries.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialAdress()
        {
            ViewBag.Location = db.Adresses.Select(x => x.Location).FirstOrDefault();
            ViewBag.OpenHours = db.Adresses.Select(x => x.OpenHours).FirstOrDefault();
            ViewBag.Email = db.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.Call = db.Adresses.Select(x => x.Call).FirstOrDefault();
            return PartialView();
        }

    }
}