using System.Threading.Tasks;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Enums;
using Application.Interfaces.Helper;

namespace Web.Pages.Components.SeoContent
{
    [ViewComponent]
    public class SeoContent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SeoType Type, int Id, string Title = null, string Des = null, string Img = null)
        {
            ISeoDomain seo = null;
            if (Id == 0)
                return View(new SeoModel() { TitleSEO = Title, DescriptionSEO = Des, ImageSEO = Img });
            Action act = () =>
            {
                Type typeSer = null;
                switch (Type)
                {
                    case SeoType.Home:
                        typeSer = typeof(IInfoService);
                        break;
                    case SeoType.Category:
                        typeSer = typeof(ICateService);
                        break;
                    case SeoType.Detail:
                        typeSer = typeof(IProductService);
                        break;
                    case SeoType.Discount:
                        {
                            Title = "Sản phẩm khuyến mãi";
                            typeSer = typeof(IInfoService);
                            break;
                        }

                    case SeoType.Search:
                        {
                            Title = "Kết quả tìm kiếm";
                            typeSer = typeof(IInfoService);
                            break;
                        }
                }
                if (typeSer != null)
                {
                    var item = (ISeoService)HttpContext.RequestServices.GetService(typeSer);
                    seo = item.GetSeo(Id);
                }
            };
            Task task = new Task(act);
            task.Start();
            await task;
            var item = new SeoModel();
            if (seo != null)
            {
                item.TitleSEO = Title ?? seo.SeoTitle;
                item.DescriptionSEO = Des ?? seo.SeoDescription;
                item.ImageSEO = Img ?? seo.SeoImage;
            }
            return View(item);
        }

        public class SeoModel
        {
            //SEO
            public string TitleSEO { get; set; } = "";
            public string DescriptionSEO { get; set; } = "";
            public string ImageSEO { get; set; } = "";
        }
    }

}