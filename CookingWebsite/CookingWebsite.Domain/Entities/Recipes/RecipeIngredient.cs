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

        protected RecipeIngredient() { }

        public RecipeIngredient(
            string title,
            List<RecipeIngredientItem> items
            )
        {
            Title = title;
            Items = items;
        }
    }
}
