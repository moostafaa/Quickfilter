using System;
using System.Collections.Generic;
using System.IO;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Localization;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;

namespace Plugin.Widgets.QuickFilter
{
    public class QuickFilterPlugin : BasePlugin, IMiscPlugin, IPlugin, IWidgetPlugin
    {
        private readonly QuickfilterSettings _quickfilterSettings;
        private readonly ISettingService _settingService;
        private readonly IDataProvider _dataProvider;
        private readonly IPermissionService _permissionService;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<Language> _repository;
        private readonly INopFileProvider _nopFileProvider;


        public QuickFilterPlugin(
            QuickfilterSettings quickfilterSettings,
            ISettingService settingService,
            IDataProvider dataProvider,
            IPermissionService permissionService,
            IWebHelper webHelper,
            ILocalizationService localizationService,
            IRepository<Language> repository,
            INopFileProvider nopFileProvider
            )
        {
            _quickfilterSettings = quickfilterSettings;
            _settingService = settingService;
            _dataProvider = dataProvider;
            _permissionService = permissionService;
            _webHelper = webHelper;
            _localizationService = localizationService;
            _repository = repository;
            _nopFileProvider = nopFileProvider;
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
            return _webHelper.GetStoreLocation() + "/someroutes";
        }

        public override void Install()
        {
            _settingService.SaveSetting(new QuickfilterSettings
            {
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

        protected virtual bool Authenticate()
        {
            //check if this user has access to manage plugin pages
            //use this method to set nodes visibility
            return _permissionService.Authorize(StandardPermissionProvider.ManagePlugins);
        }
        
    }
}
