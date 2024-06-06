using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application
{
    
    public partial class NeuralNetworkPanelContent
    {   
        public bool _UsingDefaults = false;
        private bool UsingDefaults {
            get => _UsingDefaults;
            set => SetUsingDefaults(value);}

        private void SetUsingDefaults(bool value) {
            _UsingDefaults = value;
            Log.Information($"Using defaults: {value}");
            if (value) SetDefaultValues();
        }

        private void SetDefaultValues() {
            Log.Information($"Setting the default values");
            stateContainer.SetNeuralNetworkSettingsDefaults();
        }

        public NeuralNetworkPanelContent()
        {

        }
    }
}
