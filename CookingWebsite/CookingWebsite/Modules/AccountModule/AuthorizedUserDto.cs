using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Modules.AccountModule
{
    public class AuthorizedUserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
    }
}
