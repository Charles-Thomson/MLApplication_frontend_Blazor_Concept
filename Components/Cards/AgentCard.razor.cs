using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLApplication_frontend.API;


namespace MLApplication_frontend.Components.Cards
{
    public partial class AgentCard
    {
        [CascadingParameter(Name = "agentData")] public Agent? agentData { get; set; } = new();
        [Parameter] public  EventCallback ShowCurrentlySelectedAgentPath { get; set; }

        [Parameter] public EventCallback ShowCurrentlySelectedAgentFitnessByStep { get; set; }

        public void HandleShowCurrentlySelectedAgentPath() {
            Console.WriteLine("SENT CALL  - AgentCard - SHow AGent Path Call");
            ShowCurrentlySelectedAgentPath.InvokeAsync();
        }

        public void HandleShowCurrentlySelectedAgentFitnessByStep()
        {
            Console.WriteLine("SENT CALL  - AgentCard - Show agent Fitness by step");



            ShowCurrentlySelectedAgentFitnessByStep.InvokeAsync();
        }
    }
}
