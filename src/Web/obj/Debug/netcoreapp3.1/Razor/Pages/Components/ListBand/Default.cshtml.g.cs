#pragma checksum "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d4ec671c5b18b94f84af6e81f0c61f3a4c72b87"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4ec671c5b18b94f84af6e81f0c61f3a4c72b87", @"/Pages/Components/ListBand/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaa38aebda82e56481e5d8ce57c87ccbb709bbb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Components_ListBand_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Application.Domains.Band>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
  
    int active = (int)ViewData["active"];
    string link = ViewData["link"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row filter row-contents\">\n");
#nullable restore
#line 7 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-4 col-lg-2 mb-4\">\n            <a");
            BeginWriteAttribute("class", " class=\"", 266, "\"", 319, 2);
            WriteAttributeValue("", 274, "filter-item", 274, 11, true);
#nullable restore
#line 10 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue(" ", 285, item.Id == active ?"active":"", 286, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 320, "\"", 351, 1);
#nullable restore
#line 10 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue("", 327, link + "b=" + item.Id, 327, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"img\">\n                    <img src=\"./images/band-logo/g-shock-logo.png\"");
            BeginWriteAttribute("alt", " alt=\"", 454, "\"", 470, 1);
#nullable restore
#line 12 "/home/toan/Documents/Sources/watch-shop/src/Web/Pages/Components/ListBand/Default.cshtml"
WriteAttributeValue("", 460, item.Name, 460, 10, false);

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
