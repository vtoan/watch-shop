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
    public class ListBand : ViewComponent
    {
        private readonly IBandService _bandSer;

        public List<Band> Bands { get; set; }

        public ListBand(IBandService bandSer)
        {
            _bandSer = bandSer;
        }

        public async Task<IViewComponentResult> InvokeAsync(int c, int w, int b)
        {
            Func<List<Band>> func = () =>
            {
                return (List<Band>)_bandSer.GetListItems();
            };
            Task<List<Band>> task = new Task<List<Band>>(func);
            task.Start();
            await task;
            string link = RouteHelper.CreateRouter(c, 0, w);
            ViewData["link"] = link.Contains("?") ? link += "&&" : link += "?";
            ViewData["active"] = b;
            return View(task.Result);
        }
    }
}