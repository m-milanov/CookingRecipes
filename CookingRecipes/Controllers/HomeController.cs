using CookingRecipes.Data;
using CookingRecipes.Models;
using CookingRecipes.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CookingRecipes.Controllers
{
    public class HomeController : Controller
    {
        private readonly CookingRecipesDbContext data;
        public HomeController(CookingRecipesDbContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var stats = new StatisticsIndexViewModel();

            FillStats(stats, data);

            return View(stats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void FillStats(StatisticsIndexViewModel stats, CookingRecipesDbContext data)
        {
            stats.TotalProducts = data.Products.Count();
            stats.TotalRecipes = data.Recipes.Count();
            stats.TotalUsers = 0;
        }
    }
}
