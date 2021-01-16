using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Interfaces
{
    public interface IFileService
    {
        bool UploadFile(string dir, IFormFile file, string name);
        void CreateFile(string dir, string name, string content);
        string ReadFile(string path);

    }
}