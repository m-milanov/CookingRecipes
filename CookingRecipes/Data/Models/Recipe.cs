using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CookingRecipes.Data.DataConstants;

namespace CookingRecipes.Data.Models
{
    public class Recipe
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(RecipeNameMaxLength)]
        public string Name { get; set; }

        public int TimeToCook { get; set; }

        public int TimeToPrepare { get; set; }

        public int Temperature { get; set; }

        [Required]
        public ICollection<ProductInRecipe> Products { get; set; }

        public string ImageUrl { get; set; }
    }
}

