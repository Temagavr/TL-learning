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
        public int LikesCount { get; private set; }
        public int FavouritesCount { get; private set; }
        public string AuthorUsername { get; private set; }

        public Recipe(
            string imageUrl,
            string title,
            string description,
            int cookingTime,
            int personsCount,
            int likesCount,
            int favouritesCount,
            string authorUsername
            )
        {
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
            CookingTime = cookingTime;
            PersonsCount = personsCount;
            LikesCount = likesCount;
            FavouritesCount = favouritesCount;
            AuthorUsername = authorUsername;
        }
    }
}
