using Microsoft.AspNetCore.Components;
using MLApplication_frontend.Components.Navigation.ApplicationSideNavigationPanel.NavigationPanelContent;
using Serilog;
using System.Runtime.CompilerServices;


namespace MLApplication_frontend.Components.Navigation.ApplicationSideNavigationPanel
{
    public partial class ApplicationNavigationPanel
    {
        
        

        [Parameter]
        public EventCallback<string> UpdateEnvironmentDimension_X_CallBack { get; set; }

        [Parameter]
        public EventCallback<string> UpdateEnvironmentDimension_Y_CallBack { get; set; }

        public PanelData VisablePanelContent { get; set; }
        public List<PanelData> PanelDataInstances { get; set; }
        public int EnvironmentDimension_X { get; set; }

        public int EnvironmentDimension_Y { get; set; }

        public ApplicationNavigationPanel() {

            PanelDataInstances = new List<PanelData> {
            new PanelData("HyperParameterSettings", builder =>
                {
                    builder.OpenComponent(0, typeof(HyperParameterPanelContent));
                    builder.CloseComponent();
                }),

            new PanelData("EnvironmentSettings", builder =>
                {
                    builder.OpenComponent(0, typeof(EnvironmentPanelContent));
                    builder.AddAttribute(1, nameof(EnvironmentPanelContent.UpdateEnvironmentDimension_X_CallBack), UpdateEnvironmentDimension_X_CallBack);
                    builder.AddAttribute(1, nameof(EnvironmentPanelContent.UpdateEnvironmentDimension_Y_CallBack), UpdateEnvironmentDimension_Y_CallBack);
                    builder.CloseComponent();
                }),

            new PanelData("InstanceInformation", builder =>
                {
                    builder.OpenComponent(0, typeof(InstanceInformationPanelContent));
                    builder.CloseComponent();
                }),

            new PanelData("SubmitInstance", builder =>
                {
                    builder.OpenComponent(0, typeof(SubmitInstancePanelContent));
                    builder.CloseComponent();
                })
            };

            VisablePanelContent = PanelDataInstances[0];
        }

        public void ChangeVisablePanelContent(string panelNameToBeVisable) {
            
            if (VisablePanelContent.PanelName == panelNameToBeVisable) {
                Log.Information($"Panel already visable: {panelNameToBeVisable}");
                return;
            }

            PanelData? selectedPanel = PanelDataInstances.FirstOrDefault(Panel => Panel.PanelName == panelNameToBeVisable);

            if (selectedPanel != null)
            {
                VisablePanelContent = selectedPanel;
                Log.Information($"Panel content updated with: {panelNameToBeVisable}");
            }
        }

        public class PanelData
        {
            public string PanelName { get; set; }
            public RenderFragment PanelContent { get; set; }
            public PanelData(string panelName, RenderFragment panelContent)
            {
                PanelName = panelName;
                PanelContent = panelContent;
            }
        }
    }
}
