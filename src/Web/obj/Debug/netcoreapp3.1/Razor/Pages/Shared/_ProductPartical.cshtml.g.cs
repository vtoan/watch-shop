#pragma checksum "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7ac53a5270781b3708bc5371f13f8b78ea75cf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Shared.Pages_Shared__ProductPartical), @"mvc.1.0.view", @"/Pages/Shared/_ProductPartical.cshtml")]
namespace Web.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/_ViewImports.cshtml"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7ac53a5270781b3708bc5371f13f8b78ea75cf4", @"/Pages/Shared/_ProductPartical.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa38aebda82e56481e5d8ce57c87ccbb709bbb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__ProductPartical : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Web.Models.ProductDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
  
    string _renderCurrency(double num){
        int val = (int) num;
        return val.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
    }
    string _renderDiscount(double discount) => (discount % 1 == 0) ? _renderCurrency(discount) : (discount * 100).ToString()  + " %";
    //
    IHtmlContent _checkDiscount(double discount, ProductDTO product, Func<ProductDTO, IHtmlContent> template){
        if(discount>=0) return template(product);
        return null;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(" <div id=\"product-container\" class=\"row row-contents\" style=\"min-height: 300px;\">\n");
#nullable restore
#line 16 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
     if (Model?.Count >0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
         foreach (var item in Model)
        {
            double price = (double)item?.Price;
            double priceRoot = price;
            double discount = item.Discount;
            if (discount != 0) { price = (discount % 1 == 0) ? (price - discount) : (price - (price * discount));}
            //template        

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-6 col-lg-3\">\n                <div");
            BeginWriteAttribute("class", " class=\"", 1050, "\"", 1105, 2);
            WriteAttributeValue("", 1058, "product", 1058, 7, true);
            WriteAttributeValue(" ", 1065, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 26 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                     if (discount != 0){

#line default
#line hidden
#nullable disable
                WriteLiteral("sale");
#nullable restore
#line 26 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                         ;}

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 1066, 39, false);
            EndWriteAttribute();
            WriteLiteral(">\n                    <div class=\"product-img img-anim\">\n                        ");
#nullable restore
#line 28 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                    Write(_checkDiscount(discount,item,item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("<span class=\"product-sale\">-");
#nullable restore
#line 28 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                               Write(_renderDiscount(discount));

#line default
#line hidden
#nullable disable
    WriteLiteral("</span>");
    PopWriter();
}
)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"img\">\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1357, "\"", 1392, 2);
            WriteAttributeValue("", 1363, "./images/products/", 1363, 18, true);
#nullable restore
#line 30 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
WriteAttributeValue("", 1381, item.Image, 1381, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\">\n                        </div>\n                    </div>\n                    <a class=\"add-cart mb-3\" href=\"#!\">Thêm vào giỏ hàng</a>\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1567, "\"", 1574, 0);
            EndWriteAttribute();
            BeginWriteAttribute("item-id", " item-id=\"", 1575, "\"", 1593, 1);
#nullable restore
#line 34 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
WriteAttributeValue("", 1585, item.Id, 1585, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-content\">\n                        <h4 class=\"pb-2 normal\">");
#nullable restore
#line 35 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 35 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                        Write(item.BandName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 35 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                         Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 35 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                                              Write(item.WireName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                        <div class=\"text-center\">\n                            <p class=\"text-4 red bold d-block d-lg-inline-block m-0\">\n                                ");
#nullable restore
#line 38 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                           Write(_renderCurrency(price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </p>\n                            ");
#nullable restore
#line 40 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                        Write(_checkDiscount(discount,item,item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("<del class=\"normal\">");
#nullable restore
#line 40 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                           Write(_renderCurrency(priceRoot));

#line default
#line hidden
#nullable disable
    WriteLiteral("</del>");
    PopWriter();
}
)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </a>\n                </div>\n            </div>\n");
#nullable restore
#line 45 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
         
    } else{

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p class=\"text-center flex-grow-1 mb-5\" style=\"line-height: 300px;\">Chưa có sản phẩm</p> ");
#nullable restore
#line 46 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Shared/_ProductPartical.cshtml"
                                                                                                     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Web.Models.ProductDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
