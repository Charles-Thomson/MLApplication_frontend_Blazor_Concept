using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Navigation.HomePageNavigationGrid
{
    public partial class NavigationGridItem
    {
        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        [Parameter] public string? GridItemTitle { get; set; }
        [Parameter] public string? GridItemBodyText { get; set; }
        [Parameter] public string? ElementColor { get; set; }
        [Parameter] public string GridItemNavigatesTo { get; set; } = string.Empty;


        public void HandleOnClick() {
            Logger.LogInformation($"Navigation Grid Item - navigated to {GridItemNavigatesTo}");
            NavigationManager.NavigateTo(GridItemNavigatesTo);
        }

    }
}
