
namespace CookingWebsite.Application.Dtos.RecipeDtos
{
    public class AddRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public string AuthorUsername { get; set; }
        public RecipeIngredientDto recipeIngredient { get; set; }
    }
}
