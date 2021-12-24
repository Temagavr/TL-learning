using System.Collections.Generic;

namespace CookingWebsite.Modules.RecipeCreateModule
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
