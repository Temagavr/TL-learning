using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    public class RecipeCardDto
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
    }
}
