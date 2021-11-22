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
        //public List<RecipeIngredientItem> IngredientsList { get; private set; }

        public RecipeIngredient(
            int recipeId,
            string title
            //List<RecipeIngredientItem> ingredientsList
            )
        {
            Title = title;
            RecipeId = recipeId;
            //IngredientsList = ingredientsList;
        }
    }
}
