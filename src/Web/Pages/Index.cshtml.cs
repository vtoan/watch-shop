using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        private readonly WatchContext _context;

        public IndexModel(ILogger<IndexModel> logger, WatchContext context)
        {
            _logger = logger;
            _context =context;
        }

        public void OnGet()
        {
            var s = _context.Products.ToList();
        }
    }
}
