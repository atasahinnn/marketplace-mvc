#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9f1c0c9c8f1433fa824219955110cb36aa99252"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Seller_Views_Account_CurrentLocation), @"mvc.1.0.view", @"/Areas/Seller/Views/Account/CurrentLocation.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\_ViewImports.cshtml"
using Marketplace.AspNetCoreMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\_ViewImports.cshtml"
using Marketplace.Model.Concrete.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\_ViewImports.cshtml"
using Marketplace.AspNetCoreMvc.Areas.Seller.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9f1c0c9c8f1433fa824219955110cb36aa99252", @"/Areas/Seller/Views/Account/CurrentLocation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7cdf99c27098c01a4f5c09917d03cbcca782ed5", @"/Areas/Seller/Views/_ViewImports.cshtml")]
    public class Areas_Seller_Views_Account_CurrentLocation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
  
    ViewData["Title"] = "CurrentLocation";
    Layout = "~/Views/Shared/_SellerRegisterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-10 ml-auto mr-auto\">\r\n            <div class=\"card p-5\">\r\n");
#nullable restore
#line 10 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                 if (ViewBag.Location != null)
                {
                    var currentLocationColor = ViewBag.Location.Id == 2 ? "primary" : "success";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div");
            BeginWriteAttribute("class", " class=\"", 454, "\"", 501, 3);
            WriteAttributeValue("", 462, "alert-", 462, 6, true);
#nullable restore
#line 13 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 468, currentLocationColor, 468, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 489, "text-center", 490, 12, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <p class=\"h2\">");
#nullable restore
#line 14 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                 Write(Localizer["MevcutLokasyon"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 15 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                         if (ViewBag.Location.Id == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p class=\"text-bold h1 mt-3\">");
#nullable restore
#line 16 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                  Write(ViewBag.Location.CountryNames[0].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> ");
#nullable restore
#line 16 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                                                                  }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p class=\"text-bold h1 mt-3\">");
#nullable restore
#line 18 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                  Write(ViewBag.Location.CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> ");
#nullable restore
#line 18 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                                                                  } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 20 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                }
                else
                { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert-success text-center\">\r\n                        <p class=\"h2\">");
#nullable restore
#line 24 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                 Write(Localizer["Lokasyonunuzun"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"text-bold h2 mt-3\">");
#nullable restore
#line 25 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                Write(Localizer["SecilmesiGerekiyor"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 27 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"text-center\" style=\"margin-top:30px\">\r\n                    <p class=\"h3\">");
#nullable restore
#line 29 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                             Write(Localizer["LokasyonSecin"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"row\" style=\"margin-top:30px\" id=\"Countries\">\r\n");
#nullable restore
#line 32 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                     if (ViewBag.Location != null)
                    {
                        var buttonColorCountry1 = ViewBag.Location.Id == 1 ? "success" : "primary";
                        var buttonColorCountry2 = ViewBag.Countries[0].Id == 1 ? "success" : "primary";

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-6\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1817, "\"", 1872, 2);
            WriteAttributeValue("", 1824, "/Seller/Account/Register?id=", 1824, 28, true);
#nullable restore
#line 37 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 1852, ViewBag.Location.Id, 1852, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1873, "\"", 1939, 6);
            WriteAttributeValue("", 1881, "btn", 1881, 3, true);
            WriteAttributeValue(" ", 1884, "btn-outline-", 1885, 13, true);
#nullable restore
#line 37 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 1897, buttonColorCountry1, 1897, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1917, "btn-lg", 1918, 7, true);
            WriteAttributeValue(" ", 1924, "btn-block", 1925, 10, true);
            WriteAttributeValue(" ", 1934, "mt-3", 1935, 5, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 37 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                                                                                                                     Write(ViewBag.Location.CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n                        <div class=\"col-md-6\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2095, "\"", 2154, 2);
            WriteAttributeValue("", 2102, "/Seller/Account/Register?id=", 2102, 28, true);
#nullable restore
#line 40 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 2130, ViewBag.Countries[0].Id, 2130, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2155, "\"", 2221, 6);
            WriteAttributeValue("", 2163, "btn", 2163, 3, true);
            WriteAttributeValue(" ", 2166, "btn-outline-", 2167, 13, true);
#nullable restore
#line 40 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 2179, buttonColorCountry2, 2179, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2199, "btn-lg", 2200, 7, true);
            WriteAttributeValue(" ", 2206, "btn-block", 2207, 10, true);
            WriteAttributeValue(" ", 2216, "mt-3", 2217, 5, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                                                                                                                         Write(ViewBag.Countries[0].CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n");
#nullable restore
#line 42 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                         foreach (var item in ViewBag.Countries)
                        {
                            var buttonColorCountry = item.Id == 1 ? "success" : "primary";

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-6\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2646, "\"", 2689, 2);
            WriteAttributeValue("", 2653, "/Seller/Account/Register?id=", 2653, 28, true);
#nullable restore
#line 49 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 2681, item.Id, 2681, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2690, "\"", 2755, 6);
            WriteAttributeValue("", 2698, "btn", 2698, 3, true);
            WriteAttributeValue(" ", 2701, "btn-outline-", 2702, 13, true);
#nullable restore
#line 49 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
WriteAttributeValue("", 2714, buttonColorCountry, 2714, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2733, "btn-lg", 2734, 7, true);
            WriteAttributeValue(" ", 2740, "btn-block", 2741, 10, true);
            WriteAttributeValue(" ", 2750, "mt-3", 2751, 5, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 49 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                                                                                                                                            Write(item.CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </div>\r\n");
#nullable restore
#line 51 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CurrentLocation.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591