using CookingRecipes.Data.Models;
using CookingRecipes.Data;
using CookingRecipes.Models;
using CookingRecipes.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace CookingRecipes.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CookingRecipesDbContext data;

        public ProductsController(CookingRecipesDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var products = this.data
                .Products
                .OrderByDescending(p => p.Id)
                .Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Units = p.Units,
                    ImageUrl = p.ImageUrl
                }).ToList();

            return View(products);
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddProductFormModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productData = new Product
            {
                Name = product.Name,
                Units = product.Units,
                ImageUrl = product.ImageUrl
            };
            this.data.Products.Add(productData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
