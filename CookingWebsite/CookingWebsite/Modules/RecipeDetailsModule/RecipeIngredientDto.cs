using System.Collections.Generic;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    public class RecipeIngredientDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public List<RecipeIngredientItemDto> Items { get; set; }
    }
}
