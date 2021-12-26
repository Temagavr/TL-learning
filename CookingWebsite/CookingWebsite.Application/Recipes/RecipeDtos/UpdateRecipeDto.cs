using CookingWebsite.Application.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes.RecipeDtos
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public File Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<RecipeStepDto> Steps { get; set; }
        public List<RecipeTagDto> Tags { get; set; }
    }
}
