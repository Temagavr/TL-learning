using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Domain.Entities.Recipes
{
    public class RecipeTag
    {
        public int Id { get; private set; }
        public int RecipeId  { get; private set; }
        public string TagName { get; private set; }

        protected RecipeTag() { }

        public RecipeTag(
            string tag
            )
        {
            TagName = tag;
        }
    }
}
