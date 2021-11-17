using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingWebsite.Domain;

namespace CookingWebsite.Infrastructure.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CookingWebsiteDbContext _dbContext;

        public UnitOfWork( CookingWebsiteDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
