using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule.Dtos
{
    public class AddRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public string AuthorUsername { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<RecipeStepDto> Steps { get; set; }
    }
}
