#pragma checksum "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d10dd54ced374f36e2ac98d7ec39c69833dfa1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Seller_Views_Account_CompanyDocumentManagement), @"mvc.1.0.view", @"/Areas/Seller/Views/Account/CompanyDocumentManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d10dd54ced374f36e2ac98d7ec39c69833dfa1f", @"/Areas/Seller/Views/Account/CompanyDocumentManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7cdf99c27098c01a4f5c09917d03cbcca782ed5", @"/Areas/Seller/Views/_ViewImports.cshtml")]
    public class Areas_Seller_Views_Account_CompanyDocumentManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CompanyStoreDocumentsDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "/Seller/Account/CompanyDocumentManagement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/seller/document-management.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
  
    ViewData["Title"] = "CompanyDocumentManagement";
    Layout = "~/Views/Shared/_SellerLayout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d10dd54ced374f36e2ac98d7ec39c69833dfa1f5881", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"card p-3 border-secondary\">\r\n        <div class=\"card-header border-secondary\">\r\n            <h5>");
#nullable restore
#line 10 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["SatisKategorisi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n        </div>\r\n        <div class=\"card-body\">\r\n");
#nullable restore
#line 13 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
             foreach (var category in ViewBag.StoreCategories.Categories)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"row mt-2\">\r\n                    <label class=\"label label-lg font-weight-bold label-light-primary label-inline font-size-h5\">");
#nullable restore
#line 16 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                            Write(category.CategoryNames[0].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 16 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                                                              Write(category.CategoryNames[1].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n");
#nullable restore
#line 18 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"card p-3 border-secondary mt-5\">\r\n        <div class=\"card-header border-secondary\">\r\n            <h5>");
#nullable restore
#line 24 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["EvrakDurumu"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n        </div>\r\n        <div class=\"card-body\">\r\n");
#nullable restore
#line 27 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
              
                var unapprovedDocuments = 0;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                 for (int i = 0; i < Model.Documents.Count; i++)
                {
                    if (Model.Documents[i].DocumentStatusId == 1 || Model.Documents[i].DocumentStatusId == 4)
                    {
                        unapprovedDocuments++;
                    }
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                 
                if (unapprovedDocuments > 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <span class=\"label label-lg font-weight-bold label-light-danger label-inline font-size-h1\">");
#nullable restore
#line 38 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                          Write(Localizer["YuklenmeyenEvrak"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 39 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <span class=\"label label-lg font-weight-bold label-light-success label-inline font-size-h1\">");
#nullable restore
#line 42 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                           Write(Localizer["EvraklarinizOnaylandi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 43 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                }
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"card-footer\">\r\n            <p>\r\n                ");
#nullable restore
#line 50 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["EvrakFooter"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <div class=\"card p-3 border-secondary mt-5\">\r\n        <div class=\"card-header border-secondary\">\r\n            <h5>");
#nullable restore
#line 56 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["EvrakYukleme"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <p>");
#nullable restore
#line 59 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
          Write(Localizer["SozlesmeInfo"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"card-footer\">\r\n            <h3>\r\n                ");
#nullable restore
#line 63 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["GerekliSozlesmeler"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </h3>\r\n            <div class=\"col-12 border border-secondary mt-5\">\r\n                <p class=\"mt-5\"><a href=\"#\">");
#nullable restore
#line 66 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                       Write(Localizer["MyshantaAnlasma"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></p>\r\n                <p><a href=\"#\">");
#nullable restore
#line 67 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                          Write(Localizer["KomisyonAnlasma"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"card p-3 border secondary mt-5\">\r\n        <div class=\"card-header border-secondary\">\r\n            <h5>\r\n                ");
#nullable restore
#line 74 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
           Write(Localizer["EvrakListesi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </h5>
        </div>
        <div class=""card-body"">
            <div class=""overflow-auto"">
                <table class=""table table-hover table-bordered mt-2"">
                    <thead class=""bg-light-dark"">
                        <tr>
                            <th scope=""col"" class=""text-center"">");
#nullable restore
#line 82 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                           Write(Localizer["EvrakAdi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 83 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                           Write(Localizer["YuklenmeTarihi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 84 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                           Write(Localizer["Durum"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 85 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                           Write(Localizer["Yorum"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            <th scope=\"col\" class=\"text-center\">");
#nullable restore
#line 86 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                           Write(Localizer["Evrak"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 90 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                         if (Model.Documents == null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td class=\"text-center\"><i class=\"ki ki-bold-close icon-md text-danger\"></i></td>\r\n                            </tr>\r\n");
#nullable restore
#line 95 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                        }
                        else
                        {
                            for (int i = 0; i < Model.Documents.Count; i++)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                           Write(Html.HiddenFor(x => x.Documents[i].Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                       ;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                           Write(Html.HiddenFor(x => x.Documents[i].Path));

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                         ;

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td class=\"text-center\"><a");
                BeginWriteAttribute("href", " href=\"", 4400, "\"", 4431, 1);
#nullable restore
#line 103 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
WriteAttributeValue("", 4407, Model.Documents[i].Path, 4407, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 103 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                          Write(Model.Documents[i].DocumentNames[1].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\r\n                                    <td class=\"text-center\">");
#nullable restore
#line 104 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                       Write(Model.Documents[i].UploadDate?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td class=\"text-center\">\r\n\r\n");
#nullable restore
#line 107 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                         foreach (var documentStatus in ViewBag.DocumentStatus)
                                        {
                                            string statusName = null;
                                            if (documentStatus.Id == Model.Documents[i].DocumentStatusId)
                                            {
                                                for (int j = 0; j < documentStatus.DocumentStatusNames.Count; j++)
                                                {
                                                    if (j != 0)
                                                    {
                                                        statusName += " -   ";
                                                    }
                                                    statusName += documentStatus.DocumentStatusNames[j].Name;
                                                }
                                            }
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                       Write(statusName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                       
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        &nbsp;&nbsp;\r\n");
#nullable restore
#line 124 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                         switch (Model.Documents[i].DocumentStatusId)
                                        {
                                            case 1:

#line default
#line hidden
#nullable disable
                WriteLiteral("<i class=\"ki ki-close icon-md text-danger\"></i>\r\n");
#nullable restore
#line 127 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                break;
                                            case 2:

#line default
#line hidden
#nullable disable
                WriteLiteral(" <i class=\"ki ki-outline-info icon-md text-warning\"></i>\r\n");
#nullable restore
#line 129 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                break;
                                            case 3:

#line default
#line hidden
#nullable disable
                WriteLiteral(" <i class=\"ki ki-bold-check icon-md text-success\"></i>\r\n");
#nullable restore
#line 131 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                break;
                                            case 4:

#line default
#line hidden
#nullable disable
                WriteLiteral("<i class=\"ki ki-bold-close icon-md text-danger\"></i>\r\n");
#nullable restore
#line 133 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                break;
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </td>\r\n                                    <td class=\"text-center\" id=\"descriptionRow\">");
#nullable restore
#line 136 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                           Write(Model.Documents[i].Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                                    <td class=\"text-center\">\r\n");
#nullable restore
#line 139 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                         if (Model.Documents[i].DocumentStatusId == 1 || Model.Documents[i].DocumentStatusId == 4)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <label id=\"inputLabel\"");
                BeginWriteAttribute("for", " for=\"", 7100, "\"", 7124, 3);
                WriteAttributeValue("", 7106, "Documents[", 7106, 10, true);
#nullable restore
#line 141 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
WriteAttributeValue("", 7116, i, 7116, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7118, "].File", 7118, 6, true);
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-light-danger font-weight-bold mr-2\" style=\"cursor:pointer\"><i id=\"inputIcon\" class=\"ki ki-solid-plus icon-md\"></i>");
#nullable restore
#line 141 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                                                                                                                                    Write(Localizer["Yukle"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                            <input");
                BeginWriteAttribute("name", " name=\"", 7334, "\"", 7359, 3);
                WriteAttributeValue("", 7341, "Documents[", 7341, 10, true);
#nullable restore
#line 142 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
WriteAttributeValue("", 7351, i, 7351, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7353, "].File", 7353, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 7360, "\"", 7383, 3);
                WriteAttributeValue("", 7365, "Documents[", 7365, 10, true);
#nullable restore
#line 142 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
WriteAttributeValue("", 7375, i, 7375, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 7377, "].File", 7377, 6, true);
                EndWriteAttribute();
                WriteLiteral(" type=\"file\" accept=\".pdf\" onchange=\"getFile(this);\" style=\"display:none\" />\r\n");
#nullable restore
#line 143 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span class=\"label label-xl font-weight-bold label-light-success label-inline\">");
#nullable restore
#line 146 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                                                                              Write(Localizer["Yuklendi"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 147 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 150 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <div class=""d-flex float-right mt-5"">
                <button type=""submit"" class=""btn btn-primary"">
                    <i class=""flaticon-download-1""></i>&nbsp;&nbsp;");
#nullable restore
#line 157 "C:\Users\aatas\Source\Repos\Marketplace.AspNetCoreMvc\Marketplace.AspNetCoreMvc\Areas\Seller\Views\Account\CompanyDocumentManagement.cshtml"
                                                              Write(Localizer["DokumanlariKaydet"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Route = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("JavaScript", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d10dd54ced374f36e2ac98d7ec39c69833dfa1f32691", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CompanyStoreDocumentsDto> Html { get; private set; }
    }
}
#pragma warning restore 1591