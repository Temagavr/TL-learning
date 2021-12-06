using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeIngredient
    {
        public int Id { get; private set; }
        public int RecipeId { get; private set; }
        public string Title { get; private set; }
        public List<RecipeIngredientItem> Items { get; private set; }

        public RecipeIngredient(
            int recipeId,
            string title
            )
        {
            Title = title;
            RecipeId = recipeId;
        }

        public void SetItems(List<RecipeIngredientItem> ingredientItems)
        {
            Items = ingredientItems;
        }
    }
}
