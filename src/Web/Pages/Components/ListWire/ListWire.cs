using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domains;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Func<List<Wire>> func = () =>
            {
                return (List<Wire>)_wireSer.GetListItems();
            };
            Task<List<Wire>> task = new Task<List<Wire>>(func);
            task.Start();
            await task;
            return View(task.Result);
        }
    }


}