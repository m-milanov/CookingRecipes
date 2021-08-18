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
        [Required]
        public string ImageUrl { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Fat { get; set; }

        [Required]
        public string Description { get; set; }

        public IEnumerable<ProductInRecipe> ProductsInRecipes { get; set; }
    }
}

