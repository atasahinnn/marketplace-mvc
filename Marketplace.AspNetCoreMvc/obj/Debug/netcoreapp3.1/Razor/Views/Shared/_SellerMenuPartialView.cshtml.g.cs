#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\Shared\_SellerMenuPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "286b61ca6a56d791091c1fce7d7da991c0fa3e44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SellerMenuPartialView), @"mvc.1.0.view", @"/Views/Shared/_SellerMenuPartialView.cshtml")]
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
#line 1 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\_ViewImports.cshtml"
using Marketplace.AspNetCoreMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\_ViewImports.cshtml"
using Marketplace.Business.Concrete.Utilies.Security;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"286b61ca6a56d791091c1fce7d7da991c0fa3e44", @"/Views/Shared/_SellerMenuPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcca91e806fe570483bf5b50f67cf23432abe38f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SellerMenuPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<ul class=""menu-nav"">
    <li class=""menu-item menu-item-active"" aria-haspopup=""true"">
        <a href=""/Seller/Dashboard"" class=""menu-link"">
            <span class=""svg-icon menu-icon"">
                <!--begin::Svg Icon | path:assets/media/svg/icons/Design/Layers.svg-->
                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                    <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                        <polygon points=""0 0 24 0 24 24 0 24"" />
                        <path d=""M12.9336061,16.072447 L19.36,10.9564761 L19.5181585,10.8312381 C20.1676248,10.3169571 20.2772143,9.3735535 19.7629333,8.72408713 C19.6917232,8.63415859 19.6104327,8.55269514 19.5206557,8.48129411 L12.9336854,3.24257445 C12.3871201,2.80788259 11.6128799,2.80788259 11.0663146,3.24257445 L4.47482784,8.48488609 C3.82645598,9.00054628 3.71887192,9.94418071 4.23453211,10.5925526 C4.30500305,10.6811");
            WriteLiteral(@"601 4.38527899,10.7615046 4.47382636,10.8320511 L4.63,10.9564761 L11.0659024,16.0730648 C11.6126744,16.5077525 12.3871218,16.5074963 12.9336061,16.072447 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                        <path d=""M11.0563554,18.6706981 L5.33593024,14.122919 C4.94553994,13.8125559 4.37746707,13.8774308 4.06710397,14.2678211 C4.06471678,14.2708238 4.06234874,14.2738418 4.06,14.2768747 L4.06,14.2768747 C3.75257288,14.6738539 3.82516916,15.244888 4.22214834,15.5523151 C4.22358765,15.5534297 4.2250303,15.55454 4.22647627,15.555646 L11.0872776,20.8031356 C11.6250734,21.2144692 12.371757,21.2145375 12.909628,20.8033023 L19.7677785,15.559828 C20.1693192,15.2528257 20.2459576,14.6784381 19.9389553,14.2768974 C19.9376429,14.2751809 19.9363245,14.2734691 19.935,14.2717619 L19.935,14.2717619 C19.6266937,13.8743807 19.0546209,13.8021712 18.6572397,14.1104775 C18.654352,14.112718 18.6514778,14.1149757 18.6486172,14.1172508 L12.9235044,18.6705218 C12.377022,19.1051477 11.6029199,19.1052208 11.0563554,18.6706");
            WriteLiteral("981 Z\" fill=\"#000000\" opacity=\"0.3\" />\r\n                    </g>\r\n                </svg>\r\n                <!--end::Svg Icon-->\r\n            </span>\r\n            <span class=\"menu-text\">");
#nullable restore
#line 15 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\Shared\_SellerMenuPartialView.cshtml"
                               Write(Localizer["Dashboard"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </a>\r\n    </li>\r\n    <li class=\"menu-section\">\r\n        <h4 class=\"menu-text\">");
#nullable restore
#line 19 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\Shared\_SellerMenuPartialView.cshtml"
                         Write(Localizer["KatalogYonetimi"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <i class=\"menu-icon ki ki-bold-more-hor icon-md\"></i>\r\n    </li>\r\n    <li class=\"menu-item\" aria-haspopup=\"true\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 2520, "\"", 2563, 1);
#nullable restore
#line 23 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\Shared\_SellerMenuPartialView.cshtml"
WriteAttributeValue("", 2527, Url.Action("AddProduct", "Product"), 2527, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"menu-link \">\r\n            <i class=\"menu-bullet menu-bullet-dot\">\r\n                <span></span>\r\n            </i>\r\n            <span class=\"menu-text\">");
#nullable restore
#line 27 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Views\Shared\_SellerMenuPartialView.cshtml"
                               Write(Localizer["UrunEkle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </a>\r\n    </li>\r\n</ul>\r\n");
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
