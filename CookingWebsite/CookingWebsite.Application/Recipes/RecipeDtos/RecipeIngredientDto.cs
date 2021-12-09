using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes.RecipeDtos
{
    public class RecipeIngredientDto
    {
        public string Title { get; set; }
        public List<RecipeIngredientItemDto> Items { get; set; }
    }
}
