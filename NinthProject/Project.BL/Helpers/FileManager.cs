using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Helpers
{
    public static class FileManager
    {
        public static async Task<string> ImageUpload(this IFormFile file, string envpath, params string[] folders)
        {
            string uploadPath = envpath;
            string path = string.Empty;
            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            uploadPath = uploadPath + "/" + path;
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            filename = filename + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string mainPath = uploadPath + filename;
            using var stream = new FileStream(mainPath, FileMode.Create);
            await file.CopyToAsync(stream);
            return filename;
        }
        public static bool CheckType(IFormFile file,string requiredType)=>file.ContentType.Contains(requiredType);
    }
}
