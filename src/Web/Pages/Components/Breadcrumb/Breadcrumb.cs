using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Pages.Components.Breadcrumb
{
    [ViewComponent]
    public class Breadcrumb : ViewComponent
    {
        public string MyProperty { get; set; }
        public IViewComponentResult Invoke()
        {
            var re = HttpContext.Request.Path;
            var listBread = new List<BreadModel>();
            listBread.Add(new BreadModel() { Name = "Trang chủ", Link = "/" });
            listBread.Add(new BreadModel()
            {
                Name = "Đồng hồ nam",
                Link = "#"
            });
            return View(listBread);
        }

        public class BreadModel
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }
    }


}