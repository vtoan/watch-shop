#pragma checksum "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82f02368ea59b0c9a2731435dd50874c10ce881a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Product.Pages_Product_Index), @"mvc.1.0.razor-page", @"/Pages/Product/Index.cshtml")]
namespace Web.Pages.Product
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{category}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82f02368ea59b0c9a2731435dd50874c10ce881a", @"/Pages/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa38aebda82e56481e5d8ce57c87ccbb709bbb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Product_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ProductPartical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PolicyPartical", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_CacheTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script src=\"./js/slider.js\"></script>\n    <script src=\"./js/dropdown.js\"></script>\n    <script src=\"./js/list-product.js\">   </script>\n");
            }
            );
            WriteLiteral(" <div class=\"banner-lg section\" >\n    <p");
            BeginWriteAttribute("class", " class=\"", 239, "\"", 247, 0);
            EndWriteAttribute();
            WriteLiteral(">banner</p>\n</div>\n");
#nullable restore
#line 11 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
Write(await Component.InvokeAsync("Breadcrumb"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            WriteLiteral("<div class=\"container mb-3 section\">\n");
            WriteLiteral("        ");
#nullable restore
#line 16 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
   Write(await Component.InvokeAsync("ListBand"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral(@"    <div class=""row row-contents align-items-center mb-3"">
        <div class=""orderby mb-3"">
            <a class=""order-item active"" data-index=""0"" title=""Phổ biến"" >phổ biển</a>
            <a class=""order-item"" data-index=""1"" title=""Giá cao"">giá cao</a>
            <a class=""order-item"" data-index=""2"" title=""Giá thấp"">giá thấp</a>
        </div>
        <div class=""px-3 ml-auto mb-3"">
            ");
#nullable restore
#line 26 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
       Write(await Component.InvokeAsync("ListWire"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>  \n    </div>\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "82f02368ea59b0c9a2731435dd50874c10ce881a5824", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 30 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.ListProducts;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</partial>\n");
#nullable restore
#line 31 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
     if(Model.PageNumber>1){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"pagnation contents\">\n            <a class=\"page-item active\" >1</a>\n");
#nullable restore
#line 34 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
             for (int i = 2; i <= Model.PageNumber; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"page-item\" > ");
#nullable restore
#line 36 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 37 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
            }        

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 39 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Product/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("cache", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82f02368ea59b0c9a2731435dd50874c10ce881a8622", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "82f02368ea59b0c9a2731435dd50874c10ce881a8881", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_CacheTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.CacheTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_CacheTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProductModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProductModel>)PageContext?.ViewData;
        public ProductModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
