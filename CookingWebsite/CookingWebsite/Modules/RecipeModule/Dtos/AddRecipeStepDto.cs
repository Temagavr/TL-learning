﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.RecipeModule.Dtos
{
    public class AddRecipeStepDto
    {
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }
}