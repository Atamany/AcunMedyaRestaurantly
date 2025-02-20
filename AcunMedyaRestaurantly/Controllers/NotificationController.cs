using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Notifications.ToList();
            return View(value);
        }
        public ActionResult NotificationList()
        {
            var value = db.Notifications.ToList();
            return View(value);
        }
        public ActionResult Okundu(int id)
        {
            var value = db.Notifications.Find(id);
            value.isRead = true;
            db.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}