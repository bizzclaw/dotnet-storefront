using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

namespace Gummi.Controllers
{
    public class ProductsController : Controller
    {

        private GummiDbContext db = new GummiDbContext();

        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(Products => Products.Id == id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(Products => Products.Id == id);
            return View(thisProduct);

        }

        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(Products => Products.Id == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(Products => Products.Id == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}