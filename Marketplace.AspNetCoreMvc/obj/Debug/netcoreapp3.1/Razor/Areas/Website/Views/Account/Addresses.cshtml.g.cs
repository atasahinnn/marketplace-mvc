#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Website\Views\Account\Addresses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7041e3eba7da1391a16277f6caa49679b7bb3a4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Website_Views_Account_Addresses), @"mvc.1.0.view", @"/Areas/Website/Views/Account/Addresses.cshtml")]
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
#line 1 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Website\Views\_ViewImports.cshtml"
using Marketplace.AspNetCoreMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Website\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7041e3eba7da1391a16277f6caa49679b7bb3a4d", @"/Areas/Website/Views/Account/Addresses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed8d92b1261e919cf10ab26422ae7f5472a62e71", @"/Areas/Website/Views/_ViewImports.cshtml")]
    public class Areas_Website_Views_Account_Addresses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Website\Views\Account\Addresses.cshtml"
  
    ViewData["Title"] = "Addresses";
    Layout = "~/Views/Shared/_AccountLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-md-8 col-lg-9 order-1 order-md-2 mb-5"">
    <div class=""row mb-3"">
        <div class=""col"">
            <ul class=""nav nav-pills border-bottom"">
                <li class=""nav-item"">
                    <a class=""nav-link active"" href=""#"">Teslimat Adreslerim</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""#"">Fatura Bilgilerim</a>
                </li>
            </ul>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-12"">
            <p class=""text-muted mb-3"">
                9 teslimat adresiniz bulunmaktad??r. Bu sayfadan yeni adres olu??turabilir, mevcut adreslerinizi d??zenleyebilir ya da silebilirsiniz. Bu sayfada yapaca????n??z adres de??i??iklikleri daha ??nce vermi?? oldu??unuz sipari??leri etkilemez. Vermi?? oldu??unuz sipari??in adres de??i??ikli??ini 'Sipari??lerim' alan??ndan ger??ekle??tirebilirsiniz.
            </p>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-3 ");
            WriteLiteral(@"mb-3"">
            <a class=""adres-card-ekle card bg-light h-100 shadow-sm"" href=""#adresEkleModal"" data-fancybox>
                <div class=""card-body"">
                    <h3>Yeni Ekle</h3>
                    <i class=""fas fa-plus""></i>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 mb-3"">
            <div class=""adres-card card bg-light h-100 shadow-sm"" href=""#"">
                <div class=""card-body"">
                    <h5>???? Adresi</h5>
                    <p><strong><small>Zuhuratbaba Mh. ??ncirli Caddesi Santral ????kmaz?? Sk. Ap No: 5 D: 6</small></strong></p>
                    <p><small>Bak??rk??y, ??ST.</small></p>
                    <p><small>0532 700 12 34</small></p>
                    <a href=""#"" class=""text-right text-primary""><small>D??zenle</small></a>
                </div>
            </div>
        </div>

    </div>
</div>

");
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
