#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c76b9c2870eb2e059bf9caf72241d88a38e4343a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Trader_SellerDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/Trader/SellerDetails.cshtml")]
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
#line 1 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\_ViewImports.cshtml"
using Marketplace.AspNetCoreMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\_ViewImports.cshtml"
using Marketplace.Model.Concrete.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\_ViewImports.cshtml"
using Marketplace.Model.Concrete.Vm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c76b9c2870eb2e059bf9caf72241d88a38e4343a", @"/Areas/Admin/Views/Trader/SellerDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82fefe4ec968938c238f85024a00559398d46cdf", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Trader_SellerDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SellerDetailVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"alert alert-custom alert-light alert-shadow gutter-b mt-5\">\r\n    <div class=\"alert-icon\">\r\n        <span class=\"flaticon2-sheet text-primary icon-xl\">\r\n        </span>\r\n    </div>\r\n    <div class=\"alert-text text-primary\">\r\n        <p>");
#nullable restore
#line 12 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
      Write(Localizer["Alert"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n<div class=\"card p-3 border secondary mt-5\">\r\n    <div class=\"card-header border-secondary\">\r\n        <h5 class=\"h4 font-weight-bolder\">\r\n            ");
#nullable restore
#line 18 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
       Write(Localizer["Baslik"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </h5>
    </div>
    <div class=""card-body"">
        <div class=""overflow-auto"">
            <table class=""table table-hover table-bordered mb-2"">
                <thead class=""bg-light-dark"">
                    <tr>
                        <th scope=""col"" class=""text-center"">");
#nullable restore
#line 26 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["SaticiKodu"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 27 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["MagazaAdi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 28 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["Lokasyon"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 29 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["Kullanici"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 30 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["HesapTuru"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 31 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["TicaretciTuru"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 32 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                       Write(Localizer["HesapDurumu"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr>\r\n");
#nullable restore
#line 37 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                         if (Model.StoreType == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center bg-light-warning font-weight-bold\">");
#nullable restore
#line 39 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                 Write(Model.UserCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 40 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center bg-light-warning font-weight-bold\"><a");
            BeginWriteAttribute("href", " href=\"", 1883, "\"", 1929, 2);
            WriteAttributeValue("", 1890, "/Admin/Trader/StoreDetails?id=", 1890, 30, true);
#nullable restore
#line 43 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
WriteAttributeValue("", 1920, Model.Id, 1920, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                                                                   Write(Model.UserCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n");
#nullable restore
#line 44 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center\">");
#nullable restore
#line 45 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                           Write(Model.StoreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                         if (Model.District != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center\">");
#nullable restore
#line 48 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                               Write(Model.Country.CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 48 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                     Write(Model.City.CityNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 48 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                                                     Write(Model.District.DistrictNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 49 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center\">");
#nullable restore
#line 52 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                               Write(Model.Country.CountryNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 52 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                     Write(Model.City.CityNames[1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 53 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center\">");
#nullable restore
#line 54 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 55 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                         if (Model.MembershipPackage.Id == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-light-primary font-weight-boldest text-center\">");
#nullable restore
#line 57 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                    Write(Localizer["Standart"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-light-warning font-weight-boldest text-center\">");
#nullable restore
#line 61 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                    Write(Localizer["Premium"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 62 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                         if (Model.StoreType != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center\">");
#nullable restore
#line 65 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                               Write(Localizer[Model.StoreType.StoreTypeNames[1].Name]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 66 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text-center\"></td>\r\n");
#nullable restore
#line 70 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                         if (Model.IsAccountConfirmed == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-light-success font-weight-boldest text-center\">");
#nullable restore
#line 73 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                    Write(Localizer["Onayli"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 74 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"bg-light-danger font-weight-boldest text-center\">");
#nullable restore
#line 77 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                                                                                   Write(Localizer["Onaylanmadi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 78 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Trader\SellerDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SellerDetailVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
