#pragma checksum "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "904ae7763dfb72f5d6efcd5d46cec2bb7d22f4a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Web.Pages.Components.ListBand.Pages_Components_ListBand_Default), @"mvc.1.0.view", @"/Pages/Components/ListBand/Default.cshtml")]
namespace Web.Pages.Components.ListBand
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"904ae7763dfb72f5d6efcd5d46cec2bb7d22f4a0", @"/Pages/Components/ListBand/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa38aebda82e56481e5d8ce57c87ccbb709bbb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Components_ListBand_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Application.Domains.Band>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row filter row-contents\">\n");
#nullable restore
#line 3 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
      
        int active = (int)ViewData["active"];
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
     foreach (var item in Model)
    {
        string link = ViewData["link"].ToString() + "b=" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-4 col-lg-2 mb-4\">\n            <a");
            BeginWriteAttribute("class", " class=\"", 299, "\"", 352, 2);
            WriteAttributeValue("", 307, "filter-item", 307, 11, true);
#nullable restore
#line 10 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue(" ", 318, item.Id == active ?"active":"", 319, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 353, "\"", 365, 1);
#nullable restore
#line 10 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue("", 360, link, 360, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"img\">\n                    <img src=\"./images/band-logo/g-shock-logo.png\"");
            BeginWriteAttribute("alt", " alt=\"", 468, "\"", 484, 1);
#nullable restore
#line 12 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue("", 474, item.Name, 474, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                </div>\n            </a>\n        </div>\n");
#nullable restore
#line 16 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Application.Domains.Band>> Html { get; private set; }
    }
}
#pragma warning restore 1591