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
    public class ProductController : Controller
    {
        RestaurantlyContext db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var value = db.Products.ToList();
            return View(value);
        }
        public ActionResult ProductList(string searchText)
        {
            List<Product> values;
            if(searchText != null)
            {
                values = db.Products.Where(x => x.Name.Contains(searchText)).ToList();

                return View(values);
            }
            var value = db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
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

            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var value = db.Products.Find(model.ProductId);
            value.Name = model.Name;
            value.Description = model.Description;
            value.Price = model.Price;
            value.ImageUrl = model.ImageUrl;
            value.CategoryId = model.CategoryId;
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