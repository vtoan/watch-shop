#pragma checksum "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3d1cab20058dc454b9d390a41d8b357115b0ef1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.ListProduct.Pages_ListProduct_Index), @"mvc.1.0.razor-page", @"/Pages/ListProduct/Index.cshtml")]
namespace Web.Pages.ListProduct
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{category?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d1cab20058dc454b9d390a41d8b357115b0ef1", @"/Pages/ListProduct/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa38aebda82e56481e5d8ce57c87ccbb709bbb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ListProduct_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            DefineSection("seo", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 4 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
Write(await Component.InvokeAsync("SeoContent", new {Type =@Model.TypeSeo, Id=@Model.ItemSeoId}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            DefineSection("css", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"./css/dropdown.css\" />\n    <link rel=\"stylesheet\" href=\"./css/loader.css\" />\n");
            }
            );
            DefineSection("scripts", async() => {
                WriteLiteral("\n    <script src=\"./js/dropdown.js\"></script>\n    <script src=\"./js/list-product.js\"></script>\n");
            }
            );
#nullable restore
#line 14 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
 if (Model.isSearchResult)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"banner-sm section\" >\n        <p");
            BeginWriteAttribute("class", " class=\"", 468, "\"", 476, 0);
            EndWriteAttribute();
            WriteLiteral(">Kết quả tìm kiếm</p>\n    </div>\n");
#nullable restore
#line 19 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
}
else{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"banner-lg section\" >\n        <p");
            BeginWriteAttribute("class", " class=\"", 565, "\"", 573, 0);
            EndWriteAttribute();
            WriteLiteral(">banner category </p>\n    </div>\n");
#nullable restore
#line 24 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
Write(await Component.InvokeAsync("Breadcrumb"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("<div class=\"container mb-3 section\">\n");
            WriteLiteral("        ");
#nullable restore
#line 29 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
   Write(await Component.InvokeAsync("ListBand",new {path= @Model.PathRequest,w= @Model.WireId, b= @Model.BandId}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral(@"    <div class=""row row-contents align-items-center mb-3"">
        <div class=""orderby mb-3"">
            <div class=""row"">
                <div class=""col-4"">
                    <a class=""order-item"" index=""1"" title=""Phổ biến"" >phổ biển</a>
                </div>
                <div class=""col-4"">
                    <a class=""order-item"" index=""2"" title=""Giá cao"">giá thấp</a>
                </div>
                <div class=""col-4"">
                    <a class=""order-item"" index=""3"" title=""Giá thấp"">giá cao</a>
                </div>
            </div>
        </div>
        <div class=""px-3 ml-auto mb-3"">
            ");
#nullable restore
#line 47 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
       Write(await Component.InvokeAsync("ListWire",new {path= @Model.PathRequest,w= @Model.WireId, b= @Model.BandId}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>  \n    </div>\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a3d1cab20058dc454b9d390a41d8b357115b0ef17590", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 51 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
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
#line 52 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
     if(Model.PageNumber>1){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"pagnation contents\">\n            <a class=\"page-item active\" >1</a>\n");
#nullable restore
#line 55 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
             for (int i = 2; i <= Model.PageNumber; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"page-item\" > ");
#nullable restore
#line 57 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 58 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
            }        

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 60 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/ListProduct/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("cache", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3d1cab20058dc454b9d390a41d8b357115b0ef110412", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a3d1cab20058dc454b9d390a41d8b357115b0ef110672", async() => {
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
            WriteLiteral("\n");
            WriteLiteral("<div id=\"loader\">\n    <div class=\"loader-container\">\n        <div class=\"dash uno\"></div>\n        <div class=\"dash dos\"></div>\n        <div class=\"dash tres\"></div>\n        <div class=\"dash cuatro\"></div>\n    </div>\n</div>");
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
