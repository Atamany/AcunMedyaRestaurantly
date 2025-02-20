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
    public class EventController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Events.ToList();
            return View(value);
        }
        public ActionResult EventList()
        {
            var value = db.Events.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EventCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EventCreate(Event model)
        {
            db.Events.Add(model);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        [HttpGet]
        public ActionResult EventEdit(int id)
        {
            var value = db.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EventEdit(Event model)
        {
            var value = db.Events.Find(model.EventId);
            value.Title = model.Title;
            value.Price = model.Price;
            value.Message1 = model.Message1;
            value.Message2 = model.Message2;
            value.Message3 = model.Message3;
            value.Message4 = model.Message4;
            value.Message5 = model.Message5;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
        public ActionResult EventDelete(int id)
        {
            var value = db.Events.Find(id);
            db.Events.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EventList");
        }
    }
}