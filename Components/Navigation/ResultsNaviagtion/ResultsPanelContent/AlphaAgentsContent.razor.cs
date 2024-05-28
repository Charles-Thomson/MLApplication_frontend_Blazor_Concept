using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLApplication_frontend.API;
using Newtonsoft.Json.Linq;

namespace MLApplication_frontend.Components.Navigation.ResultsNaviagtion.ResultsPanelContent
{
    public partial class AlphaAgentsContent
    {
        [Parameter] public List<string>? AlphaAgentIDs { get; set; } 
        [Parameter] public Agent? CurrentlySelectedAgent { get; set; }
        [Parameter] public EventCallback<string> UpdateCurrentlySelectedAgent { get; set; }
        [Parameter] public EventCallback PlotCurrentlySelectedAgentPath { get; set; }
        [Parameter] public EventCallback PlotCurrentlySelectedAgentFitnessProgression { get; set; }


        public string? _SelectedAlphaID { get; set; }
        public string? SelectedAlphaID { 
            
            get => _SelectedAlphaID;
            set => SetSelectedAlphaIdAsync(value);
        }

        public async void SetSelectedAlphaIdAsync(string id) {
            _SelectedAlphaID = id;
            await handle_UpdateCurrentlySelectedAgent(id);
        }

        public async Task handle_UpdateCurrentlySelectedAgent(string agentID)
        {
            await UpdateCurrentlySelectedAgent.InvokeAsync(agentID);
        }
    }
}
