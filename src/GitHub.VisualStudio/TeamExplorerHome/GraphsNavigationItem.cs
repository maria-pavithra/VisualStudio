﻿using System;
using System.ComponentModel.Composition;
using GitHub.Api;
using GitHub.Services;
using GitHub.VisualStudio.Base;
using GitHub.VisualStudio.Helpers;
using Microsoft.TeamFoundation.Controls;
using GitHub.UI;

namespace GitHub.VisualStudio.TeamExplorerHome
{
    [TeamExplorerNavigationItem(GraphsNavigationItemId, NavigationItemPriority.Graphs)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GraphsNavigationItem : TeamExplorerNavigationItemBase
    {
        public const string GraphsNavigationItemId = "5245767A-B657-4F8E-BFEE-F04159F1DDA5";

        readonly Lazy<IVisualStudioBrowser> browser;

        [ImportingConstructor]
        public GraphsNavigationItem(ISimpleApiClientFactory apiFactory, Lazy<IVisualStudioBrowser> browser,
                                    ITeamExplorerServiceHolder holder)
            : base(apiFactory, holder, Octicon.graph)
        {
            this.browser = browser;
            Text = "Graphs";
            ArgbColor = Colors.LightBlueNavigationItem.ToInt32();
        }

        public override void Execute()
        {
            OpenInBrowser(browser, "graphs");
            base.Execute();
        }
    }
}
