using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Files
{
    public class FileService : IFileService
    {
        private const string ImagesPath = @"E:\TL-learning\CookingWebsite\CookingWebsite\ClientApp\src\assets\recipes";

        public async Task<FileSaveResult> SaveAsync(File formFile)
        {
            Directory.CreateDirectory(ImagesPath);

            string fileName = $"{Guid.NewGuid().ToString()}.{formFile.FileExtension}";
            var newFilePath = $@"{ImagesPath}\{fileName}";
            using (FileStream fs = System.IO.File.Create(newFilePath))
            {
                await fs.WriteAsync(formFile.Data);
            }

            string folderName = ImagesPath.Split(@"\").Last();
            return new FileSaveResult
            {
                RelativePath = $@"{folderName}/{fileName}"
            };
        }

        public class FileSaveResult
        {
            public string RelativePath { get; set; }
        }
    }
}
