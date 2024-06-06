using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLApplication_frontend.API;
using MLApplication_frontend.GraphPlotting;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;


namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Results

{
    public partial class AllAgentsContent
    {

        [Parameter] public List<string>? AgentIDs { get; set; }
        [Parameter] public List<string>? GenereationIDs { get; set; }

        [Parameter] public Agent? CurrentlySelectedAgent { get; set; }
        [Parameter] public EventCallback<string> GetAgentData { get; set; }
        [Parameter] public EventCallback<String> UpdateCurrentlySelectedAgent {get; set;}

        [Parameter] public EventCallback PlotCurrentlySelectedAgentPath { get; set; }
        [Parameter] public EventCallback PlotCurrentlySelectedAgentFitnessProgression { get; set; }



       


        private string? _selectedGenerationID;
        public string? selectedGenerationID
        {
            get => _selectedGenerationID;
            set => SetSelectedGenerationID(value);
        }

        public async void SetSelectedGenerationID(string id)
        {
            _selectedGenerationID = id;
            await GetAgentData.InvokeAsync(id);
        }


        private string? _selectedAgentID;
        public string? selectedAgentID
        {
            get => _selectedAgentID;
            set => SetSelectedAgentIdAsync(value);
        }

        public async void SetSelectedAgentIdAsync(string id) {
            _selectedAgentID = id;
            await UpdateCurrentlySelectedAgent.InvokeAsync(id);
        }

    }
}

