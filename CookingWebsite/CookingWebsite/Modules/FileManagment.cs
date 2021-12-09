using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CookingWebsite.Application.Files;

namespace CookingWebsite.Modules
{
    public class FileManagment
    {
        public static async Task<Application.Files.File> CreateAsync(IFormFile formFile)
        {
            byte[] fileBytes = await FileToBytes(formFile);

            return new Application.Files.File
            (
                fileBytes,
                formFile.FileName,
                formFile.FileName.Split('.').Last()
            );
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
