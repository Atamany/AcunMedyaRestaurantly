using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ChefCount = db.Chefs.Count();
            ViewBag.EventCount = db.Events.Count();
            ViewBag.GalleryCount = db.Galleries.Count();
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.ReservationCount = db.Reservations.Count();
            ViewBag.ServiceCount = db.Services.Count();
            ViewBag.SpecialCount = db.Specials.Count();
            ViewBag.TestimonialCount = db.Testimonials.Count();
            ViewBag.MessageCount = db.Contacts.Count();
            ViewBag.NotificationCount = db.Notifications.Count();
            ViewBag.AdminCount = db.Admins.Count();
            return View();
        }
    }
}