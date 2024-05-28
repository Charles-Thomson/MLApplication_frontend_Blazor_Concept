using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Navigation.HomePageNavigationGrid
{
    public partial class NavigationGrid
    {
        public NavigationGrid()
        {

        }

        public class NavigationItemData
        {
            public string? Title { get; set; }
            public string? BodyText { get; set; }
            public string? ElementColor { get; set; }
            public string? NavigatesTo { get; set; }
        }

        public Array NavigationItems = new[]
        {
            new NavigationItemData(){Title = "Here Lizzie", BodyText = "Place holder text", ElementColor = "#f9b234", NavigatesTo = "/generational_learning_introduction_page"},
            new NavigationItemData(){Title = "Element 2", BodyText = "Place holder text", ElementColor = "#e44002", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 3", BodyText = "Place holder text", ElementColor = "#ede4f3", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 4", BodyText = "Place holder text", ElementColor = "#2990a6", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 5", BodyText = "Place holder text", ElementColor = "#3ecd5e", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 6", BodyText = "Place holder text", ElementColor = "#e44002", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 7", BodyText = "Place holder text", ElementColor = "#952aff", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 8", BodyText = "Place holder text", ElementColor = "#cd3e94", NavigatesTo = "/"},
            new NavigationItemData(){Title = "Element 9", BodyText = "Place holder text", ElementColor = "#cd3e94", NavigatesTo = "/"},
        };
    }
}
