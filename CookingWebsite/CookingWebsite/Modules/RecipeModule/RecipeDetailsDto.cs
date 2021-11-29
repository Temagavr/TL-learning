using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
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
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<string> Steps { get; set; }
    }
}
