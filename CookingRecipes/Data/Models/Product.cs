using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CookingRecipes.Data.DataConstants;

namespace CookingRecipes.Data.Models
{
    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Units { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<ProductInRecipe> ProductsInRecipes { get; set; }
    }
}

