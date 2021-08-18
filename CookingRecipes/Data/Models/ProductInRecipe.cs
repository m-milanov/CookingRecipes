using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookingRecipes.Data.Models
{
    public class ProductInRecipe
    {
        public int Id { get; init; }

        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Specification{ get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}

