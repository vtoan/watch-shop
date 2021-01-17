using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Web.Interfaces;

namespace Web.Services
{

    public class FileService : IFileService
    {
        private string webRootPath = "";
        private ILogger _logger;
        public FileService(IWebHostEnvironment environment, ILogger<string> logger)
        {
            _logger = logger;
            webRootPath = environment.WebRootPath;
        }
        public bool UploadFile(string dir, IFormFile file, string name)
        {
            try
            {
                //Check folder
                string folderPath = CheckPath(dir);
                //Save file
                string filePath = Path.Combine(folderPath, name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Upload file " + dir);
                return false;
            }
        }

        public void CreateFile(string dir, string name, string content)
        {
            try
            {
                string folderPath = CheckPath(dir);
                string filePath = Path.Combine(folderPath, name);
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Create file " + dir);
            }
        }

        public string ReadFile(string path)
        {
            try
            {
                var task = System.IO.File.ReadAllTextAsync(path);
                task.Start();
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Red file " + path);
                return null;
            }
        }

        private string CheckPath(string dir)
        {
            string folderPath = Path.Combine(webRootPath, dir);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return folderPath;
        }

    }
}