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
    }
}