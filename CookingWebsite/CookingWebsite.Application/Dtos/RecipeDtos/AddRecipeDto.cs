using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Dtos.RecipeDtos
{
    public class AddRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public int PersonsCount { get; set; }
    }
}
