using System.Threading.Tasks;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Helper;
using Application.Interfaces.Helper;

namespace Web.Pages.Components.SeoContent
{
    [ViewComponent]
    public class Post : ViewComponent
    {
        public IViewComponentResult Invoke(int productId)
        {
            return View();
        }
    }

}