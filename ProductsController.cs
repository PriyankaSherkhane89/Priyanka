using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFLWebApp.Models;

using TFLWebApp.DAL;

namespace TFLWebApp.Controllers
{
    public class ProductsController : Controller
    {

        DbOrmContext entities = new DbOrmContext();

        // GET: Products
        public ActionResult Index()
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            List<Product> products = entities.Products.ToList();
            this.ViewBag.products = products;
            return View();
        }

        public ActionResult List()
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;
            List<Product> products = entities.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

        }


        public ActionResult productDetails(int id)
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            var product = entities.Products.SingleOrDefault(p => p.Id == id);
            
            return Json(product, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Details(int id)
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            var product = entities.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                this.ViewData["product"] = product;
            }
                return View();
        }

        public ActionResult Delete(int id)
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            var product = entities.Products.SingleOrDefault(p => p.Id == id);
            entities.Products.Remove(product ?? throw new InvalidOperationException());
            entities.SaveChanges();   // to reflect
            return RedirectToAction("Index");
        }

        //Data Entry form action methods

        [HttpGet]
        public ActionResult Insert()
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            var product = new Product();
           /* if (product != null)
            {
                this.ViewData["product"] = product;
            }
           */
           //Model Binding
           //automatically Data Validation will be used becuase of 
           //annotations  applied for Product class in ModelStore update, insert, or delete statement affected an unexpected number of rows (0). Entities may have been modified or deleted since entities were loaded. See http://
            return View(product);
        }



        [HttpPost]
        public ActionResult Insert(Product product )
        {


            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            if (ModelState.IsValid)
            {
                //entities.Entry(product).State = System.Data.Entity.EntityState.Modified;
                entities.Products.Add(product);
              //  entities.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Products ON");
                entities.SaveChanges();
              //  entities.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Products OFF");
                return RedirectToAction("Index");
            }
            else
            return View(product);
        }

        public ActionResult Update(int id)
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;

            return View();
        }


        [HttpPost]
        public ActionResult Update(int id, string title, string description, int quantity, int unitprice)
        {
            int currentVisitCount = int.Parse(this.HttpContext.Session["visits"].ToString());
            this.HttpContext.Session["visits"] = currentVisitCount + 1;
            return View();
        }

    }
}