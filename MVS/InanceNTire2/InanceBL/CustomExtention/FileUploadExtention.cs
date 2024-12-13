using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceBL.CustomExtention
{
    public static class FileUploadExtention
    {

        private static bool FileIsTrue(IFormFile file)
        {
            if (file == null || file.Length==0)
            {
                return false;
            }
            return true;
        }

        public static async Task<string> FileUpload(this IFormFile file, string FolderPath)
        {

            if (FileIsTrue(file) == false) 
            {
                throw new ArgumentException("Fayl mövcud deyil və ya boşdur.");
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);

            IsFolder(uploadFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
               await  file.CopyToAsync(stream);

            }


            return uniqueFileName;
        }

        private static void IsFolder(string a)
        {
            if (!Directory.Exists(a))
            {
                Directory.CreateDirectory(a);
            }
        }
    }
}
