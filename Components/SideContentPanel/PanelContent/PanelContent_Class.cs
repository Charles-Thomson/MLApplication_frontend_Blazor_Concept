using Microsoft.AspNetCore.Components;

namespace MLApplication_frontend.Components.SideContentPanel.PanelContent
{
    public class PanelContent_Class
    {
        public string PanelName { get; set; }
        public RenderFragment PanelContent { get; set; }
        public PanelContent_Class(string panelName, RenderFragment panelContent)
        {
            PanelName = panelName;
            PanelContent = panelContent;
        }

    }
   
}
