namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeFavourite
    {
        public int Id { get; protected set; }
        public int UserId { get; protected set; }
        public int RecipeId { get; protected set; }

        protected RecipeFavourite() { }

        public RecipeFavourite(
            int userId,
            int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}
