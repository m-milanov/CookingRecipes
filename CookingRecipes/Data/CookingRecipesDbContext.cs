using CookingRecipes.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingRecipes.Data
{
    public class CookingRecipesDbContext : IdentityDbContext
    {
        public CookingRecipesDbContext(DbContextOptions<CookingRecipesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; init; }
        public DbSet<ProductInRecipe> ProductsInRecipes { get; init; }
        public DbSet<Product> Products { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ProductInRecipe>()
                .HasOne(p => p.Recipe)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<ProductInRecipe>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductsInRecipes)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
