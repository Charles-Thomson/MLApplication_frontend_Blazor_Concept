using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MLApplication_frontend.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Results
{
    public partial class GenerationsContent
    {
        [Parameter] public List<string>? GenereationIDs {  get; set; }
        
        [Parameter] public EventCallback<string> GetGenerationData { get; set; }

        [Parameter] public EventCallback ShowGenerationAllAgentsFitnessProgression { get; set; }
        [Parameter] public Generation? GenerationData { get; set; }

        public void HandleGetGenerationData(string newValue) {
            if (newValue != null) {
                GetGenerationData.InvokeAsync(newValue);
            }
        }

        public void HandleShowGenerationAllAgentsFitnessProgression()
        { 
            ShowGenerationAllAgentsFitnessProgression.InvokeAsync();  
        }

        private string? _selectedGenerationID;
        public string? selectedGenerationID { 
            
            get => _selectedGenerationID;

            set {
                _selectedGenerationID = value;
                HandleGetGenerationData(value);
            } }

    }
}
