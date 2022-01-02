using System.Collections.Generic;

namespace CookingWebsite.Modules.RecipeDetailsModule
{
    public class RecipeDetailsDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public int LikesCount { get; set; }
        public int FavouritesCount { get; set; }
        public string AuthorUsername { get; set; }
        public bool IsCanModify { get; set; }
        public bool IsLiked { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public List<string> Tags { get; set; }
    }
}
