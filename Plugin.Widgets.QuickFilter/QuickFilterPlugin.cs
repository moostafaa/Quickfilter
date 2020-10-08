using System;
using System.Collections.Generic;
using System.IO;
using Nop.Core.Data;
using Nop.Data;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Plugins;

namespace Plugin.Widgets.QuickFilter
{
    public class QuickFilterPlugin : BasePlugin, IMiscPlugin, IPlugin, IWidgetPlugin
    {
        private readonly QuickfilterSettings _quickfilterSettings;
        private readonly ISettingService _settingService;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;

        public QuickFilterPlugin(QuickfilterSettings quickfilterSettings, ISettingService settingService, IDataProvider dataProvider, IDbContext dbContext)
        {
            _quickfilterSettings = quickfilterSettings;
            _settingService = settingService;
            _dataProvider = dataProvider;
            _dbContext = dbContext;
        }

        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetWidgetZones()
        {
            if (string.IsNullOrEmpty(_quickfilterSettings?.WidgetZone))
                return new List<string> {
                    "left_side_column_before"
                };
            return new List<string>
            {
                _quickfilterSettings.WidgetZone
            };
        }

        public override string GetConfigurationPageUrl()
        {
            return base.GetConfigurationPageUrl();
        }

        public override void Install()
        {
            _settingService.SaveSetting(new QuickfilterSettings {
                WidgetZone = "left_side_column_before",
                EnablePriceRange = true,
                EnableAttributes = true,
                EnableManufacturers = true,
                EnableSpecification = true,
                EnableVendors = true,
                DefaultPageSize = 12
            });
            //try to install scripts
            //InstallScripts("");
            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<QuickfilterSettings>();
            //roleback all script installation
            //_dbContext.ExecuteSqlCommand("DROP PROCEDURE @@@@");
            base.Uninstall();
        }


        protected virtual void InstallScripts(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    _dbContext.ExecuteSqlCommand(reader.ReadToEnd());
                }
            }

        }
    }
}
