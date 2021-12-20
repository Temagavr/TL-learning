using CookingWebsite.Application.Files;
using System.Collections.Generic;

namespace CookingWebsite.Application.Recipes.RecipeDtos
{
    public class AddRecipeDto
    {
        public File Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public string AuthorUsername { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<RecipeStepDto> Steps { get; set; }
        public List<RecipeTagDto> Tags { get; set; }
    }
}
