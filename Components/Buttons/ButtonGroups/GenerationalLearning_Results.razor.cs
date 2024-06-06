using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MLApplication_frontend.Components.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Buttons.ButtonGroups
{
    public partial class GenerationalLearning_Results
    {
        [Parameter] public EventCallback<string> ChangeVisablePanelContent { get; set; }



        public static NavigationButtonSVGs SVGFile = new NavigationButtonSVGs();

        public List<ButtonDataClass> ButtonDataInstances = new List<ButtonDataClass>
        {
            new("AlphaAgentsContent", SVGFile.AlphasSVG),
            new("GenerationsContent", SVGFile.GenerationSVG),
            new("AllAgentsContent", SVGFile.AllAgentsSVG),
        };

        public void UpdateButtonState(string givenButtonID)
        {

            foreach (ButtonDataClass buttonData in ButtonDataInstances)
            {

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
