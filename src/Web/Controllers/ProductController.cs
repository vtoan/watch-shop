using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ICollection<Product> GetList()
        {
            var re = _service.AddItem(null);
            return null;
        }
    }
}