using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Reservations.ToList();
            return View(value);
        }
        public ActionResult ReservationList()
        {
            var value = db.Reservations.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ReservationCreate()
        {
            List<SelectListItem> statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Onay Bekliyor", Text = "Onay Bekliyor..." },
                new SelectListItem { Value = "Onaylandı", Text = "Onaylandı..." },
                new SelectListItem { Value = "İptal Edildi", Text = "İptal Edildi..." }
            };
            ViewBag.v = statusList;

            return View();
        }
        [HttpPost]
        public ActionResult ReservationCreate(Reservation model)
        {
            db.Reservations.Add(model);
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {
            List<SelectListItem> statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Onay Bekliyor", Text = "Onay Bekliyor..." },
                new SelectListItem { Value = "Onaylandı", Text = "Onaylandı..." },
                new SelectListItem { Value = "İptal Edildi", Text = "İptal Edildi..." }
            };
            ViewBag.v = statusList;
            var value = db.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ReservationEdit(Reservation model)
        {
            var value = db.Reservations.Find(model.ReservationId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Phone = model.Phone;
            value.Description = model.Description;
            value.Date = model.Date;
            value.Time = model.Time;
            value.GuestCount = model.GuestCount;
            value.ReservationStatus = model.ReservationStatus;
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationDelete(int id)
        {
            var value = db.Reservations.Find(id);
            db.Reservations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}