using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Widgets.QuickFilter.ActionFilters
{
    public class CustomActionFilters : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // i'm going to replace custom name of controller to real controller name
            //var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            //if(descriptor != null && descriptor.ControllerTypeInfo)
            base.OnActionExecuted(context);
        }
    }
}
