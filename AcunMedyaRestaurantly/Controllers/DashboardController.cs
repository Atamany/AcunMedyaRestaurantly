using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ChefCount = db.Chefs.Count();
            ViewBag.SpecialCount = db.Specials.Count();
            ViewBag.MessageCount = db.Contacts.Count();
            ViewBag.NotificationCount = db.Notifications.Count();
            ViewBag.ReservationCount = db.Reservations.Count();
            ViewBag.TestimonialCount = db.Testimonials.Count();
            return View();
        }
        public PartialViewResult ReservationPartial()
        {
            var value = db.Reservations.ToList();
            return PartialView(value);
        }
    }
}