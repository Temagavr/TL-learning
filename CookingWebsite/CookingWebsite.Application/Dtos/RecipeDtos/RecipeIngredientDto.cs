using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Dtos.RecipeDtos
{
    public class RecipeIngredientDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public List<RecipeIngredientItemDto> IngredientsList { get; set; }
    }
}
