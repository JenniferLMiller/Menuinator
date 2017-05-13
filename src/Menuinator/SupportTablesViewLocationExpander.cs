using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menuinator
{
    public class SupportTablesViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
           // // we don't want to change layout pages & partials ...
           // if (context.IsPartial) return viewLocations;

            var descriptor = (context.ActionContext.ActionDescriptor as ControllerActionDescriptor);
            if (descriptor == null) { return viewLocations; }

            if (descriptor.ControllerName == "CookingMethods" ||
                descriptor.ControllerName == "CookingTime" ||
                descriptor.ControllerName == "PrepTime" ||
                descriptor.ControllerName == "WeatherType")
            {
                return viewLocations.Select(x => x.Replace("{0}", "Special/{0}"));
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // we add this to enable caching! 
            var contains = context.ActionContext.HttpContext.Request.Query.ContainsKey("apple");
            context.Values.Add("SupportTables", contains.ToString());
        }
    }
}
