using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Helper;

namespace Web.Pages.Components.Breadcrumb
{
    [ViewComponent]
    public class Breadcrumb : ViewComponent
    {
        public string MyProperty { get; set; }
        public IViewComponentResult Invoke()
        {
            var handler = HttpContext.Request.Query["handler"];
            if (!String.IsNullOrEmpty(handler))
            {
                var result = RouteHelper.SeoRoute.Find(item => item.Hander == handler);
                if (result != null)
                {
                    string page = result.Name;
                    if (result.Id == 5) page += " '" + HttpContext.Request.Query["query"].ToString() + " '";
                    ViewData["page"] = page;
                }
                return View();
            }
            var cate = HttpContext.Request.RouteValues["category"];
            if (cate != null)
            {
                int cateId = Int32.Parse(cate.ToString());
                var result = RouteHelper.SeoRoute.Find(item => item.Id == cateId);
                if (result != null) ViewData["page"] = result.Name;
                return View();
            }
            return View();
        }
    }


}