using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using System.Data;
using MLApplication_frontend.Components.Buttons;

namespace MLApplication_frontend.Components.Navigation.ApplicationSideNavigationPanel
{
    public partial class ApplicationNavigationButtonGroup
    {
        [Parameter] public EventCallback<string> ChangeVisablePanelContent { get; set; }

        public static NavigationButtonSVGs SVGFile = new NavigationButtonSVGs();

        public List<ButtonDataClass> ButtonDataInstances = new List<ButtonDataClass>
        {
            new("HyperParameterSettings", SVGFile.HyperParameterSettingsSVG),
            new("NeuralNetworkSettings", SVGFile.NeuralNetworkSVG),
            new("EnvironmentSettings", SVGFile.EnvironmentSettingsSVG),
            new("InstanceInformation", SVGFile.InstanceInformationSVG),
            new("SubmitInstance", SVGFile.SubmitInstanceSVG)
        };

        public void UpdateButtonState(string givenButtonID) {

            foreach (ButtonDataClass buttonData in ButtonDataInstances) {

                if (buttonData.ButtonID == givenButtonID)
                {
                 
                    buttonData.State = ButtonState.Selected;
                    ChangeVisablePanelContent.InvokeAsync(buttonData.ButtonID);
                }
                else
                {
                    buttonData.State = ButtonState.Unselected;
                }
                
                buttonData.UpdateAttributes();
            }
        }
    }
}
