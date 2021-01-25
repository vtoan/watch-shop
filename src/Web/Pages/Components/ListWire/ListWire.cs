using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IViewComponentResult> InvokeAsync(string path, int b, int w)
        {
            Func<List<Wire>> func = () =>
            {
                return (List<Wire>)_wireSer.GetListItems();
            };
            Task<List<Wire>> task = new Task<List<Wire>>(func);
            task.Start();
            await task;
            ViewData["link"] = RouteHelper.CurrentRouter(path, b, 0);
            ViewData["active"] = task.Result.Find(item => item.Id == w)?.Name ?? "";
            return View(task.Result);
        }
    }


}