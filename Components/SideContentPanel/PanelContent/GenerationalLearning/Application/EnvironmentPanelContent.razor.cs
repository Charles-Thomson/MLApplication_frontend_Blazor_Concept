using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using MLApplication_frontend.Components.Buttons;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application
{
    public partial class EnvironmentPanelContent
    {

        public EnvironmentButtonsSVGs EnvironemntButtonSVGs = new EnvironmentButtonsSVGs();

        [Parameter]
        public EventCallback<string> UpdateEnvironmentDimension_X_CallBack { get; set; }
        [Parameter]
        public EventCallback<string> UpdateEnvironmentDimension_Y_CallBack { get; set; }

        [Parameter]
        public EventCallback<int> UpdateEnvironmentNodeTypeSelector { get; set; }


        public List<string> AvailableEnvironmentDimensions = new()
        {
        "0",
        "4",
        "5",
        "6",
        "20",
        };

        public EnvironmentPanelContent() {
            
            EnvironmentDimension_X = AvailableEnvironmentDimensions[0];
            EnvironmentDimension_Y = AvailableEnvironmentDimensions[0];
            _EnvironmentDimension_X = AvailableEnvironmentDimensions[0];
            _EnvironmentDimension_Y = AvailableEnvironmentDimensions[0];
            
        }

        /// <summary>
        /// Update the selection value for the setting of the node states
        /// 0 = Empty
        /// 1 = Goal
        /// 2 = Obstical
        /// 3 = Start Location
        /// </summary>
        /// <param name="newValue"></param>
        public void UpdateEnvironemntNodeSelectionType(int newSelectionValue) {
            Log.Information($"EnvironmentPanel - Updating Selection Value ;  {newSelectionValue}");
            UpdateEnvironmentNodeTypeSelector.InvokeAsync(newSelectionValue);
        }

        public string? _EnvironmentDimension_X { get; set; }
        public string? EnvironmentDimension_X
        {
            get => _EnvironmentDimension_X;
            set
            {
                _EnvironmentDimension_X = value;
                
                UpdateEnvironmentDimension_X_CallBack.InvokeAsync(EnvironmentDimension_X);
            }
        } 

        public string _EnvironmentDimension_Y { get; set; }
        public string EnvironmentDimension_Y
        {
            get => _EnvironmentDimension_Y;
            set
            {
                _EnvironmentDimension_Y = value;
                
                UpdateEnvironmentDimension_Y_CallBack.InvokeAsync(EnvironmentDimension_Y);
            }
        }

    }
}
