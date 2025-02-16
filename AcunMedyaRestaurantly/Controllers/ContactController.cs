using AcunMedyaRestaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Contacts.ToList();
            return View(value);
        }
        public ActionResult ContactList()
        {
            var value = db.Contacts.ToList();
            return View(value);
        }
    }
}