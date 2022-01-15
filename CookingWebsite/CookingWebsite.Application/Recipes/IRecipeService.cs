using CookingWebsite.Application.Recipes.RecipeDtos;
using CookingWebsite.Domain.Entities.Recipes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Recipes
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeOfDay();
        Task AddRecipe(AddRecipeDto addRecipeDto, int authorId);
        Task UpdateRecipe(UpdateRecipeDto updateRecipeDto);
        Task AddLike(int recipeId, int userId);
        Task RemoveLike(int recipeId, int userId);
        Task AddFavourite(int recipeId, int userId);
        Task RemoveFavourite(int recipeId, int userId);
        Task<List<Recipe>> GetUserFavourites(int skip, int take, int userId);
    }
}
