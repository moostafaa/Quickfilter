using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Widgets.QuickFilter
{
    public class QuickfilterSettings : ISettings
    {
        public string WidgetZone { get; set; }
        public bool EnablePriceRange { get; set; }
        public bool EnableManufacturers { get; set; }
        public bool EnableVendors { get; set; }
        public bool EnableSpecification { get; set; }
        public bool EnableAttributes { get; set; }

        public int DefaultPageSize { get; set; }
    }
}
