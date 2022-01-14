using CookingWebsite.Domain.Entities.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.UserFavouritesModule
{
    public interface IRecipeCardBuilder
    {
        Task<List<RecipeCardDto>> Build(List<Recipe> recipes, int authorizedUserId);
    }
}
