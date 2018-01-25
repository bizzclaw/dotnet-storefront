using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.Models;

namespace StoreFront.Controllers
{
    public class ProductsController : Controller
    {

        private IStoreFrontRepository storeFrontRepo;


        public ProductsController(IStoreFrontRepository repo = null)
        {
            this.storeFrontRepo = repo ?? new EFStoreFrontRepository();
        }

        public Product GetProductById(int id)
        {
            return storeFrontRepo.Products.FirstOrDefault(Products => Products.Id == id);
        }


        public IActionResult Index()
        {
            return View(storeFrontRepo.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisProduct = GetProductById(id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        public IActionResult CreateReview(int id)
        {
            ViewBag.Product = GetProductById(id);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            storeFrontRepo.Save(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            review.Rating = Math.Min(10, Math.Max(0, review.Rating)); // Serverside validation

           // db.Reviews.Add(review);
           // db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = GetProductById(id);
            return View(thisProduct);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            storeFrontRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisProduct = GetProductById(id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = GetProductById(id);
            storeFrontRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }
    }
}