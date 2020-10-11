using Nop.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Widgets.QuickFilter.ViewEngine
{
    public class CustomCatalogViewEngine : IViewLocationExpander//I'm trying to change default search path of razor
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (context.AreaName?.Equals("Admin"))
            {
                IThemeContext theme = context.ActionContext.HttpContext.RequestServices.GetService(typeof(IThemeContext));
                context.Values["ThemeName"] = theme.WorkingThemeName;
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.TryGetValue("", out string Value) && context.ControllerName.Equals("QuickFilter"))
            {
                //put here view and theme location
                viewLocations = new string[2] {
                    "",
                    ""
                }.Concat(viewLocations);
            }
        }
    }
}
