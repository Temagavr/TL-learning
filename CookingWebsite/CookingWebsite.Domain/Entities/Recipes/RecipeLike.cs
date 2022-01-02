using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeLike
    {
        public int Id { get; protected set; }
        public int UserId { get; protected set; }
        public int RecipeId { get; protected set; }

        protected RecipeLike() { }

        public RecipeLike(
            int userId,
            int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
