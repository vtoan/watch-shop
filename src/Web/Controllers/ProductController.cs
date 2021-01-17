using System.Diagnostics;
using System.Collections.Generic;
using Application.Domains;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [DebuggerStepThrough]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            Demo();
            return Ok();
        }
        private void Demo()
        {
            throw new System.Exception("Loi roi dm");
        }
    }
}