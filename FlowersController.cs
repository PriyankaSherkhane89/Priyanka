using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFLWebApp.Models;
using TFLWebApp.DAL;

namespace TFLWebApp.Controllers
{
    public class FlowersController : Controller
    {
        DbOrmContext entities = new DbOrmContext();

        // GET: Flowers
        public ActionResult Index()
        {
            List<Flower> flowers = entities.flowers.ToList();
            this.ViewBag.flowers1 = flowers;
            return View();
        }
        public ActionResult Details(int id)
        {
            var flower = entities.flowers.SingleOrDefault(f => f.fid == id);
            if(flower!=null)
            {
                this.ViewData["flower"] = flower;
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var flower = entities.flowers.SingleOrDefault(f => f.fid == id);
            entities.flowers.Remove(flower ?? throw new InvalidOperationException());
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Insert()
        {
            var flower = new Flower();
            /*if(flower!=null)
            {
                this.ViewData["flower"] = flower;
            }*/
            return View(flower);
        }

        [HttpPost]
        public ActionResult Insert(Flower flower)
        {
            if(ModelState.IsValid)
            {
                //entities.Entry(flower).State = System.Data.Entity.EntityState.Modified;
                entities.flowers.Add(flower);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(flower);
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, string name, double price, int quantity)
        {
            return View();
        }
    }
}