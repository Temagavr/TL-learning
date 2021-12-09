using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Files
{
    public class FileService : IFileService
    {
        private const string Storage = @"E:\TL-learning\CookingWebsite\CookingWebsite\ClientApp\src\assets";

        public async Task<FileSaveResult> SaveAsync(File formFile, string relativePath)
        {
            string fullPath = Storage + relativePath; 
            Directory.CreateDirectory(fullPath);

            string fileName = $"{Guid.NewGuid().ToString()}.{formFile.FileExtension}";
            var newFilePath = $@"{fullPath}\{fileName}";
            using (FileStream fs = System.IO.File.Create(newFilePath))
            {
                await fs.WriteAsync(formFile.Data);
            }

            string folderName = fullPath.Split(@"\").Last();
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
