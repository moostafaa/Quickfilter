using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Plugin.Widgets.QuickFilter.ActionFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Widgets.QuickFilter
{
    public class NopStartup : INopStartup
    {
        public int Order => 0;
        public void Configure(IApplicationBuilder application)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MvcOptions>(o => {
                o.Filters.Add<CustomActionFilters>();
            });
        }
    }
}
