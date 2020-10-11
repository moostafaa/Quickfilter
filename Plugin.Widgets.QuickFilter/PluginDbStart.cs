using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Plugin.Widgets.QuickFilter.Validators;
using System;

namespace Plugin.Widgets.QuickFilter
{
    public class PluginDbStart : INopStartup
    {
        public int Order => 1;

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //for custom theme support i'll add a new Viewengine that derived from base view engine
            services.Configure<RazorViewEngineOptions>(o => o.ViewLocationExpanders.Add(new CustomCatalogViewEngine()));

            //let create all base needed codes
            services.AddTransient<IValidator<QuickfilterSettings>, QuickfilterSettingValidator>();
        }
    }
}
