using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeIngredientItem
    {
        public int Id { get; private set; }
        public int RecipeIngredientId { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }

        public RecipeIngredientItem(
            int recipeIngredientId,
            string name,
            string value
            )
        {
            RecipeIngredientId = recipeIngredientId;
            Name = name;
            Value = value;
        }
    }
}
