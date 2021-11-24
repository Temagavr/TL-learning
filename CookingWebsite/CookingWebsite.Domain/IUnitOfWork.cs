using System.Threading.Tasks;

namespace CookingWebsite.Domain
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
