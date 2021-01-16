using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using System.Net;
using System.IO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileSer;
        public FileController(IFileService fileSer)
        {
            _fileSer = fileSer;
        }

        [HttpGet("download/{path}")]
        public IActionResult Download(string path)
        {
            return File(path, "json");
        }

        [HttpGet("content/{path}")]
        public string Get(string path)
        {
            return _fileSer.ReadFile(path);
        }

        [HttpPost("upload/{path}")]
        public IActionResult Upload(IFormFile file, string path)
        {
            if (file == null) return BadRequest();
            _fileSer.UploadFile(path, file, "demo");
            return NoContent();
        }

        [HttpPost("content/{path}")]
        public IActionResult Create(string path, string name, string content)
        {
            _fileSer.CreateFile(path, name, "demo");
            return NoContent();
        }


    }
}