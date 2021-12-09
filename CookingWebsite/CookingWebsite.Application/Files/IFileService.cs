using System.Threading.Tasks;
using static CookingWebsite.Application.Files.FileService;

namespace CookingWebsite.Application.Files
{
    public interface IFileService
    {
        Task<FileSaveResult> SaveAsync(File formFile, string relativePath);
    }
}
