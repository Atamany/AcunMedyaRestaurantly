using AcunMedyaRestaurantly.Context;
using AcunMedyaRestaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    public class ProductController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Products.ToList();
            return View(value);
        }
        public ActionResult ProductList()
        {
            var value = db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var value = db.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var value = db.Products.Find(model.ProductId);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = db.Products.Find(id);
            db.Products.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}