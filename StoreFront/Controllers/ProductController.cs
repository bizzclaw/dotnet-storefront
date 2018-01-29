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
            
            return storeFrontRepo.Products.Include(product => product.Reviews).FirstOrDefault(Products => Products.Id == id);
        }


        public IActionResult Index()
        {
            return View(storeFrontRepo.Products.Include(p => p.Reviews).ToList());
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

        public IActionResult CreateReview(int id)
        {
            Product product = GetProductById(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                CreateReviewModel reviewModel = new CreateReviewModel();
                reviewModel.Product = product;
                reviewModel.Review = new Review();
                return View(reviewModel);
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            storeFrontRepo.Save(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateReview(CreateReviewModel reviewModel)
        {
            Review review = reviewModel.Review;
            storeFrontRepo.Save(review);
            return RedirectToAction("details", "Products", new {id = reviewModel.Review.ProductId });
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