using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaRestaurantly.Context;

namespace AcunMedyaRestaurantly.Controllers
{
    public class AdminLayoutController : Controller
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
        public PartialViewResult PartialNavbar()
        {
            var mesajlar = db.Contacts.ToList();
            var values = db.Notifications.Where(x => x.isRead == false).ToList();
            var notificationIsReadyByFalseCount = values.Count();
            ViewBag.notificationIsReadyByFalseCount = notificationIsReadyByFalseCount;
            ViewBag.mesajlar = mesajlar;
            ViewBag.okunmamisMesajSayisi = db.Contacts.Where(x=>x.isRead==false).Count();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var notification = db.Notifications.Find(id);
            notification.isRead = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var message = db.Contacts.Find(id);
            message.isRead = true;
            db.SaveChanges();
            return RedirectToAction("Index","Dashboard");
        }
    }
}