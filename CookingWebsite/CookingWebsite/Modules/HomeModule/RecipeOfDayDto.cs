using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.HomeModule
{
    public class RecipeOfDayDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int LikesCount { get; set; }
        public string AuthorUsername { get; set; }
    }
}
