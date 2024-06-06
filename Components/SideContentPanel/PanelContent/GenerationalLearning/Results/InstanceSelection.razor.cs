using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MLApplication_frontend.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Results
{
    public partial class InstanceSelection
    {
        [Parameter]
        public InstanceBaseData? CurrentInstanceData { get; set; }
        [Parameter]
        public List<string>? InstanceIDS { get; set; }

        [Parameter] public EventCallback<string> UpdateSelectedInstanceID { get; set; }

        bool isInstanceInformationVisible = false;
        string InsatnceInformationVisibleStyle => isInstanceInformationVisible ? "" : "display: none;";
        string InstanceSelectionMenuVisableStyle => isInstanceInformationVisible ? "display: none;" : "";


        void ToggleInstanceInformationVisibility() => isInstanceInformationVisible = !isInstanceInformationVisible;

        private string _SelectedInstanceID { get; set; } = string.Empty;
        public string SelectedInstanceID
        {
            get => _SelectedInstanceID;
            set
            {
                _SelectedInstanceID = value;
                SelectedInstanceIDUpdated(value);
            }
        }

        private void SelectedInstanceIDUpdated(string value) {
            UpdateSelectedInstanceID.InvokeAsync(value);
            _SelectedInstanceID = value;
        }

    }
}
