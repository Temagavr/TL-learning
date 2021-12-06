using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingWebsite.Application.Files
{
    public class FileService : IFileService
    {
        public byte[] Data { get; private set; }
        public string FileName { get; private set; }
        public string FileExtension { get; private set; }

        public static async Task<FileService> CreateAsync(IFormFile formFile)
        {
            byte[] fileBytes = await FileToBytes(formFile);

            return new FileService
            {
                Data = fileBytes,
                FileName = formFile.FileName,
                FileExtension = formFile.FileName.Split('.').Last()
            };
        }

        private static async Task<byte[]> FileToBytes(IFormFile formFile)
        {
            using (var ms = new MemoryStream())
            using (Stream stream = formFile.OpenReadStream())
            {
                await stream.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

    }
}
