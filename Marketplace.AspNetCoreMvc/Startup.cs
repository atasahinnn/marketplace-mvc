using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Marketplace.AspNetCoreMvc.Middlewares;
using Marketplace.Business.Concrete.Utilies.Validation.FluentValidation.Rules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Marketplace.AspNetCoreMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("tr-TR"),
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-LY"),
                };

                var provider = new CookieRequestCultureProvider()
                {
                    CookieName = "Localzation"
                };

                var providerAdmin = new CookieRequestCultureProvider()
                {
                    CookieName = "LocalzationAdmin"
                };

                options.DefaultRequestCulture = new RequestCulture("ar-LY");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(provider);
                options.RequestCultureProviders.Add(providerAdmin);
                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                {
                    await Task.Yield();

                    string routePath = context.Request.Path.Value;

                    if ((routePath.ToLower().StartsWith("/website/") || routePath.ToLower().StartsWith("/seller/") || routePath == "/") && context.Request.Cookies["Localization"] != null)
                    {

                        var uiCulture = context.Request.Cookies["Localization"].Split('|')[0];

                        uiCulture = uiCulture.Substring(uiCulture.IndexOf('=') + 1, uiCulture.Length - uiCulture.IndexOf('=') - 1);

                        return new ProviderCultureResult(uiCulture);

                    }
                    else if (routePath.ToLower().StartsWith("/admin/") && context.Request.Cookies["LocalizationAdmin"] != null)
                    {

                        var uiCulture = context.Request.Cookies["LocalizationAdmin"].Split('|')[0];

                        uiCulture = uiCulture.Substring(uiCulture.IndexOf('=') + 1, uiCulture.Length - uiCulture.IndexOf('=') - 1);

                        return new ProviderCultureResult(uiCulture);

                    }

                    return new ProviderCultureResult("ar-LY");

                }));
            });


            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<FvUserDtoValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<FvLoginDtoValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<FvBrandDtoValidation>();
                    fv.RegisterValidatorsFromAssemblyContaining<FvPropertyDtoValidation>();
                });

            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler(errorApp=> {
                //    errorApp.Run(async context =>
                //    {
                //        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                //        {

                //        }

                //    });
                //});

                app.UseHsts();
            }

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseHeaderCheckMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area=Website}/{controller=Home}/{action=Index}");
            });
        }
    }
}
