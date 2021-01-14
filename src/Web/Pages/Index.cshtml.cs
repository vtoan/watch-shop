﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IProductService _service;

        public IndexModel(ILogger<IndexModel> logger, IProductService service)
        {
            _logger = logger;
            _service = service;

            // db.AddItem(null);
        }

        public void OnGet()
        {
            var s = _service.GetListItems();
        }
    }
}