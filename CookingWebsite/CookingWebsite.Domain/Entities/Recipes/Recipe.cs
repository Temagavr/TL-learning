using System.Collections.Generic;

namespace CookingWebsite.Domain.Entities.Recipes
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string ImageUrl { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CookingTime { get; private set; }
        public int PersonsCount { get; private set; }
        public string AuthorUsername { get; private set; }
        public List<RecipeIngredient> Ingredients { get; private set; }
        public List<RecipeStep> Steps { get; private set; }
        public List<RecipeTag> Tags { get; private set; }
        public int AuthorId { get; private set; }

        protected Recipe() { }

        public Recipe(
            string imageUrl,
            string title,
            string description,
            int cookingTime,
            int personsCount,
            string authorUsername,
            List<RecipeIngredient> ingredients,
            List<RecipeStep> steps,
            List<RecipeTag> tags,
            int authorId
            )
        {
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
            CookingTime = cookingTime;
            PersonsCount = personsCount;
            AuthorUsername = authorUsername;
            Ingredients = ingredients;
            Steps = steps;
            Tags = tags;
            AuthorId = authorId;
        }

        public void Update(
            string imageUrl,
            string title,
            string description,
            int cookingTime,
            int personsCount,
            List<RecipeIngredient> ingredients,
            List<RecipeStep> steps,
            List<RecipeTag> tags
            )
        {
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
            CookingTime = cookingTime;
            PersonsCount = personsCount;
            Ingredients = ingredients;
            Steps = steps;
			Tags = tags;        
        }
    }
}
