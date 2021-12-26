using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeCreateModule
{
    public class RecipeIngredientItemDto
    {
        public int RecipeIngredientId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
