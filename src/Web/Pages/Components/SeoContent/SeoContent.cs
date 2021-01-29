using System.Threading.Tasks;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Helper;
using Application.Interfaces.Helper;

namespace Web.Pages.Components.SeoContent
{
    [ViewComponent]
    public class SeoContent : ViewComponent
    {
        public IViewComponentResult Invoke(SeoType Type, int Id, string Title = null, string Des = null, string Img = null)
        {
            var model = new SeoModel();
            ISeoDomain seo = null;
            if (Id == 0)
                return View(new SeoModel() { TitleSEO = Title, DescriptionSEO = Des, ImageSEO = Img });
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
                var service = (ISeoService)HttpContext.RequestServices.GetService(typeSer);
                seo = service.GetSeo(Id);
            }
            if (seo != null)
            {
                model.TitleSEO = Title ?? seo.SeoTitle;
                model.DescriptionSEO = Des ?? seo.SeoDescription;
                model.ImageSEO = Img ?? seo.SeoImage;
            }
            return View(model);
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