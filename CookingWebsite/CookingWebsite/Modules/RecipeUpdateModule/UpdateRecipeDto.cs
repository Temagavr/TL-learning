﻿using System.Collections.Generic;

namespace CookingWebsite.Modules.RecipeUpdateModule
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public List<RecipeStepDto> Steps { get; set; }
    }
}
