using Flyoobe; // for FeatureNode
using Settings.Ads;
using Settings.Edge;
using Settings.Gaming;
using Settings.Personalization;
using Settings.Privacy;
using Settings.System;
using Settings.UI;
using System.Collections.Generic;

namespace Features
{
    /// <summary>
    /// Loads all available feature categories and their corresponding tweak nodes.
    /// Each tweak inherits from FeatureBase and represents a system setting or cleanup action.
    /// </summary>
    public static class FeatureLoader
    {
        public static List<FeatureNode> Load()
        {
            return new List<FeatureNode>
            {

                new FeatureNode("System")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new BSODDetails()),
                        new FeatureNode(new VerboseStatus()),
                        new FeatureNode(new SpeedUpShutdown()),
                        new FeatureNode(new NetworkThrottling()),
                        new FeatureNode(new SystemResponsiveness()),
                        new FeatureNode(new MenuShowDelay()),
                        new FeatureNode(new TaskbarEndTask()),
                        new FeatureNode(new DisableHibernation())
                    }
                },

                new FeatureNode("MS Edge")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new BrowserSignin()),
                        new FeatureNode(new DefaultTopSites()),
                        new FeatureNode(new DefautBrowserSetting()),
                        new FeatureNode(new EdgeCollections()),
                        new FeatureNode(new EdgeShoppingAssistant()),
                        new FeatureNode(new FirstRunExperience()),
                        new FeatureNode(new GamerMode()),
                        new FeatureNode(new ImportOnEachLaunch()),
                        new FeatureNode(new StartupBoost()),
                        new FeatureNode(new TabPageQuickLinks()),
                        new FeatureNode(new UserFeedback())
                    }
                },

                new FeatureNode("UI")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new FullContextMenus()),
                        new FeatureNode(new WLockScreen()),
                        new FeatureNode(new SearchboxTaskbarMode()),
                        new FeatureNode(new ShowOrHideMostUsedApps()),
                        new FeatureNode(new ShowTaskViewButton()),
                        new FeatureNode(new DisableSearchBoxSuggestions()),
                        new FeatureNode(new DisableBingSearch()),
                        new FeatureNode(new StartLayout()),
                        new FeatureNode(new Transparency()),
                        new FeatureNode(new DisableSnapAssistFlyout())
                    }
                },

                new FeatureNode("Gaming")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new GameDVR()),
                        new FeatureNode(new PowerThrottling()),
                        new FeatureNode(new VisualFX())
                    }
                },

                new FeatureNode("Privacy")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new ActivityHistory()),
                        new FeatureNode(new LocationTracking()),
                        new FeatureNode(new PrivacyExperience()),
                        new FeatureNode(new Telemetry())
                    }
                },

                new FeatureNode("Ads")
                {
                    Children = new List<FeatureNode>
                    {
                        new FeatureNode(new FileExplorerAds()),
                        new FeatureNode(new FinishSetupAds()),
                        new FeatureNode(new LockScreenAds()),
                        new FeatureNode(new PersonalizedAds()),
                        new FeatureNode(new SettingsAds()),
                        new FeatureNode(new StartmenuAds()),
                        new FeatureNode(new TailoredExperiences()),
                        new FeatureNode(new TipsAndSuggestions()),
                        new FeatureNode(new WelcomeExperienceAds())
                    }
                },
            };
        }
    }
}