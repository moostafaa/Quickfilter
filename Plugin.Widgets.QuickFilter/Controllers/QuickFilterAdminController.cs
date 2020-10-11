using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Plugin.Widgets.QuickFilter.Controllers
{
    public class QuickFilterAdminController : BaseAdminController
    {
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly IPluginService _pluginService;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;
        private readonly int ActiveStoreId;


        private string pluginSystemName = "Plugin.Widgets.QuickFilter";

        public QuickFilterAdminController(
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            ILocalizationService localizationService,
            IWebHelper webHelper,
            IPluginService pluginService,
            INotificationService notificationService,
            ILogger logger)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _localizationService = localizationService;
            _webHelper = webHelper;
            _pluginService = pluginService;
            _notificationService = notificationService;
            _logger = logger;

            ActiveStoreId = storeContext.ActiveStoreScopeConfiguration;
        }

        [HttpGet]
        public IActionResult Configure()
        {
            if (_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return this.AccessDeniedView();

            var model = new QuickfilterSettings();
            PluginDescriptor pluginDescriptorBySystemName = _pluginService.GetPluginDescriptorBySystemName(pluginSystemName);
            var currentsettings = _settingService.LoadSetting<QuickfilterSettings>();
            model.RestartApplicationForChange = currentsettings.RestartApplicationForChange;
            if(currentsettings.RestartApplicationForChange)
            {
                currentsettings.RestartApplicationForChange = false;
                _settingService.SaveSetting<QuickfilterSettings>(currentsettings);
            }
            if (ActiveStoreId > 0)
            {
                QuickfilterSettings storeSpecifiedSettings = currentsettings;

            }
        }

        [HttpPost]
        public IActionResult Configure(QuickfilterSettings model)
        {
            if (_permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
                return this.AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            var currentsettings = _settingService.LoadSetting<QuickfilterSettings>();


        }
    }
}
