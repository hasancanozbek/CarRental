using Microsoft.AspNetCore.Http;
using NotImplementedException = System.NotImplementedException;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                var extension = Path.GetExtension(file.FileName);
                var fileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + extension;
                using (var fileStream = new FileStream(Path.Combine(root, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return fileName;
            }

            return null;
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            { 
                File.Delete(filePath);
            }
        }
    }
}
