using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Pages.Components.Breadcrumb
{
    [ViewComponent]
    public class ListBand : ViewComponent
    {

        private readonly IBandService _bandSer;
        public ListBand(IBandService bandSer)
        {
            _bandSer = bandSer;
        }

        public IViewComponentResult Invoke(string path, int w, int b)
        {
            var result = _bandSer.GetListItems();
            ViewData["link"] = RouteHelper.CurrentRouter(path, 0, w);
            ViewData["active"] = b;
            return View(result);
        }
    }
}