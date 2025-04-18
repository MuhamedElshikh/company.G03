using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;


namespace company.G3.BLL.servises.AttachementServises
{
    public class AttachementServises : IAttachementServises
    {
        List<string> AllowedExtensions = new List<string> { ".jpg", ".png", ".Jpeg" };
        const int MaxSize = 2 * 1024 * 1024;

        public string? Upload(IFormFile File, string FolderName)
        {
            var Extension = Path.GetExtension(File.FileName);

            if (!AllowedExtensions.Contains(Extension)) return null;
            if (File.Length == 0 || File.Length > MaxSize) return null;

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            var fileName = $"{Guid.NewGuid()}_{File.FileName}";
            var filePath = Path.Combine(FolderPath, fileName);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            File.CopyTo(fileStream);
            return fileName;
        }


        public bool Delete(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                return true;
            }
            return false;
        }
    }
}
