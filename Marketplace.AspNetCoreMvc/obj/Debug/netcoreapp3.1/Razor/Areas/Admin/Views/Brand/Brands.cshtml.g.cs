#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "954f86705322d8a5d2c3d0ee2fc8ba9148c049d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Brand_Brands), @"mvc.1.0.view", @"/Areas/Admin/Views/Brand/Brands.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"954f86705322d8a5d2c3d0ee2fc8ba9148c049d5", @"/Areas/Admin/Views/Brand/Brands.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82fefe4ec968938c238f85024a00559398d46cdf", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Brand_Brands : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BrandDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/admin/brand.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
  
    ViewData["Title"] = "Brand List";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card card-custom\">\r\n    <div class=\"card-header flex-wrap border-0 pt-6 pb-0\">\r\n        <div class=\"card-title\">\r\n            <h3 class=\"card-label\">\r\n                ");
#nullable restore
#line 10 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
           Write(Localizer["Markalar"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n        </div>\r\n        <div class=\"card-toolbar\">\r\n            <div class=\"input-icon mr-3 mb-3 mb-lg-0 w-100 w-lg-auto\">\r\n                <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 522, "\"", 553, 1);
#nullable restore
#line 15 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 536, Localizer["Ara"], 536, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"kt_datatable_search_query\" />\r\n                <span>\r\n                    <i class=\"flaticon2-search-1 text-muted\"></i>\r\n                </span>\r\n            </div>\r\n            <!--begin::Button-->\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 774, "\"", 813, 1);
#nullable restore
#line 21 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 781, Url.Action("AddBrand", "Brand"), 781, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary font-weight-bolder w-100 w-lg-auto"">
                <span class=""svg-icon svg-icon-md"">
                    <!--begin::Svg Icon | path:assets/media/svg/icons/Design/Flatten.svg-->
                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                            <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                            <circle fill=""#000000"" cx=""9"" cy=""15"" r=""6"" />
                            <path d=""M8.8012943,7.00241953 C9.83837775,5.20768121 11.7781543,4 14,4 C17.3137085,4 20,6.6862915 20,10 C20,12.2218457 18.7923188,14.1616223 16.9975805,15.1987057 C16.9991904,15.1326658 17,15.0664274 17,15 C17,10.581722 13.418278,7 9,7 C8.93357256,7 8.86733422,7.00080962 8.8012943,7.00241953 Z"" fill=""#000000"" opacity=""0.3"" />
                        </g>
                    <");
            WriteLiteral("/svg>\r\n                    <!--end::Svg Icon-->\r\n                </span>");
#nullable restore
#line 32 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                  Write(Localizer["YeniKayit"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </a>
            <!--end::Button-->
        </div>
    </div>
    <div class=""card-body"">
        <!--begin: Datatable-->
        <table class=""datatable datatable-bordered datatable-head-custom"" id=""kt_datatable"">
            <thead>
                <tr>
");
#nullable restore
#line 42 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                     foreach (var language in ViewBag.Languages as List<LanguageDto>)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th scope=\"col\">");
#nullable restore
#line 44 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                                   Write(Localizer[language.Name]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 45 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th title=\"Islemler\">");
#nullable restore
#line 46 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                                    Write(Localizer["Aksiyonlar"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody id=\"tableBody\">\r\n\r\n");
#nullable restore
#line 52 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                 if (Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                     foreach (var mod in @Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n");
#nullable restore
#line 57 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                             for (int i = 0; i < @mod.BrandNames.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>  ");
#nullable restore
#line 59 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                                 Write(mod.BrandNames[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n");
#nullable restore
#line 60 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3012, "\"", 3080, 1);
#nullable restore
#line 63 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 3019, Url.Action("UpdateBrand", "Brand", new { brandId = mod.Id }), 3019, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-icon  btn-light btn-hover-primary float-right mx-2\"");
            BeginWriteAttribute("title", " title=\"", 3155, "\"", 3185, 1);
#nullable restore
#line 63 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 3163, Localizer["Guncelle"], 3163, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"far fa-edit\"></i>\r\n                                </a>\r\n                                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 3331, "\"", 3361, 3);
            WriteAttributeValue("", 3341, "deleteBrand(", 3341, 12, true);
#nullable restore
#line 66 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 3353, mod.Id, 3353, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3360, ")", 3360, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-icon btn-light btn-hover-danger float-right mx-2\"");
            BeginWriteAttribute("title", " title=\"", 3434, "\"", 3459, 1);
#nullable restore
#line 66 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
WriteAttributeValue("", 3442, Localizer["Sil"], 3442, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"far fa-trash-alt\"></i>\r\n                                </button>\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 72 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Admin\Views\Brand\Brands.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n        <!--end: Datatable-->\r\n    </div>\r\n</div>\r\n<!--end::Card-->\r\n\r\n\r\n\r\n");
            DefineSection("JavaScript", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "954f86705322d8a5d2c3d0ee2fc8ba9148c049d514008", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BrandDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591