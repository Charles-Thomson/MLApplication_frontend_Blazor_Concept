using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLApplication_frontend.Components.SideContentPanel.PanelContent;
using Microsoft.AspNetCore.Components.Web;
using MLApplication_frontend.Components.Buttons.ButtonGroups;

namespace MLApplication_frontend.Components.SideContentPanel
{
    public partial class SideContentPanelTemplate
    {


        [Parameter] public RenderFragment ContentHeader { get; set; }
        [Parameter] public string? ButtonGroupType { get; set; }

        public RenderFragment? ButtonGroup { get; set; }

        private void BuildButtonGroup()
        {
            switch (ButtonGroupType)
            {
                case "ApplicationButtonGroup":
                    
                    ButtonGroup = builder =>
                    {
                        builder.OpenComponent(0, typeof(GenerationLearning_Application));
                        builder.AddAttribute(1, "ChangeVisablePanelContent", EventCallback.Factory.Create<string>(this, ChangeVisablePanelContent));
                        builder.CloseComponent();
                    };
                    StateHasChanged();
                    break;

                case "ResultsButtonGroup":
                    
                    ButtonGroup = builder => {
                        builder.OpenComponent(0, typeof(GenerationalLearning_Results));
                        builder.AddAttribute(1, "ChangeVisablePanelContent", EventCallback.Factory.Create<string>(this, ChangeVisablePanelContent));
                        builder.CloseComponent();
                    };
                    StateHasChanged();
                    break;
            }
        }

        [Parameter] public List<PanelContent_Class>? PanelContent { get; set; }

        public PanelContent_Class? VisablePanelContent { get; set; }

        public SideContentPanelTemplate()
        {
            Log.Information($"SYSTEM - In side panel layout constructor - {ButtonGroupType}");
            if (PanelContent != null)
            {
                VisablePanelContent = PanelContent[0];
            }
            else
            {
                /// Add in an empty panel content 
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            
            if (firstRender) {
                Log.Information($"SYSTEM - Building the Following  - {ButtonGroupType}");

                BuildButtonGroup();
            }
        }


        public void ChangeVisablePanelContent(string panelNameToBeVisable)
        {

            if (VisablePanelContent?.PanelName == panelNameToBeVisable)
            {
                Log.Information($"Panel already visable: {panelNameToBeVisable}");
                return;
            }

            PanelContent_Class? selectedPanel = PanelContent?.FirstOrDefault(Panel => Panel.PanelName == panelNameToBeVisable);

            if (selectedPanel != null)
            {
                VisablePanelContent = selectedPanel;
                Log.Information($"Panel content updated with: {panelNameToBeVisable}");
            }
        }
    }
}
