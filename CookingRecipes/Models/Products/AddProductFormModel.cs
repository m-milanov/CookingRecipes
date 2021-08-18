using System.ComponentModel.DataAnnotations;
using static CookingRecipes.Data.DataConstants;

namespace CookingRecipes.Models.Products
{
    public class AddProductFormModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = 2)]
        public string Name { get; init; }

        [Required]
        public string Units { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Fat { get; set; }

        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}