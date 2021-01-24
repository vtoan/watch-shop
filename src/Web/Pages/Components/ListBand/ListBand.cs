using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domains;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Func<List<Band>> func = () =>
            {
                return (List<Band>)_bandSer.GetListItems();
            };
            Task<List<Band>> task = new Task<List<Band>>(func);
            task.Start();
            await task;
            return View(task.Result);
        }
    }


}