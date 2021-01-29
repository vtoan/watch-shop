using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Pages.Components.Breadcrumb
{
    [ViewComponent]
    public class ListWire : ViewComponent
    {
        private readonly IWireService _wireSer;
        public ListWire(IWireService wireSer)
        {
            _wireSer = wireSer;
        }
        public IViewComponentResult Invoke(string path, int b, int w)
        {
            var result = (List<Wire>)_wireSer.GetListItems();
            ViewData["link"] = RouteHelper.CurrentRouter(path, b, 0);
            ViewData["active"] = result.Find(item => item.Id == w)?.Name ?? "";
            return View(result);
        }
    }
}