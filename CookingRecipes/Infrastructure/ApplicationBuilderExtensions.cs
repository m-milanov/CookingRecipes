using CookingRecipes.Data;
using CookingRecipes.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CookingRecipes.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<CookingRecipesDbContext>();
            data.Database.Migrate();
            SeedProducts(data);

            return app;
        }

        private static void SeedProducts(CookingRecipesDbContext data)
        {
            if (data.Products.Any())
                return;

            data.Products.Add(new Product { Name = "Egg", Units = "Number", });
            data.SaveChanges();
        }
    }
}