using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Widgets.QuickFilter
{
    //we need to support multi store
    //so firstly complete this setting classs
    public class QuickfilterSettings : ISettings
    {
        public bool RestartApplicationForChange { get; set; }
        public int ActiveStoreScopeConfiguration { get; set; }



        public string WidgetZone { get; set; }
        public bool EnablePriceRange { get; set; }
        public bool EnablePriceRange_OverrideForstore { get; set; }
        public bool EnableManufacturers { get; set; }
        public bool EnableManufacturers_OverrideForstore { get; set; }
        public bool EnableVendors { get; set; }
        public bool EnableVendors_OverrideForstore { get; set; }
        public bool EnableSpecification { get; set; }
        public bool EnableSpecification_OverrideForstore { get; set; }
        public bool EnableAttributes { get; set; }
        public bool EnableAttributes_OverrideForstore { get; set; }


        //I'm going to support infinite scroll in search product for first phase
        public bool CategoryInfiniteScrolling { get; set; }
        public bool CategoryInfiniteScrolling_OverrideForstore { get; set; }
        /*****/

        public bool CategoryShowNumberOfProductsFound { get; set; }
        public bool CategoryShowNumberOfProductsFound_OverrideForstore { get; set; }
        //it is good if I add this functionality for vendors and manufacturer
        public bool EnabledSearchInCategoryList { get; set; }
        public bool EnabledSearchInCategoryList_OverrideForstore { get; set; }



        public bool EnableDisplayOrder { get; set; }
        public bool EnableDisplayOrder_OverrideForstore { get; set; }

        public int DefaultPageSize { get; set; }
    }
}
