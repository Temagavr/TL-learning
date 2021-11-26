using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule
{
    public class LoadMoreRecipesDto
    {
        public int Skip;
        public int Take;
        public string SearchString;
    }
}
