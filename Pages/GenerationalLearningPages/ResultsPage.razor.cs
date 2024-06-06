using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using MLApplication_frontend.API;

using MLApplication_frontend.Components.SideContentPanel.PanelContent;
using MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Results;
using MLApplication_frontend.GraphPlotting;



namespace MLApplication_frontend.Pages.GenerationalLearningPages
{
    public partial class ResultsPage{

        ///  JS Interlop runtime
        [Inject] protected IJSRuntime JSRuntime { get; set; }

        /// GraphPlotting Functions
        public GraphPlottingFunctionCalls GraphPlottingFunctions { get; set; }

        /// HTTP Client
        static readonly HttpClient newClient = new() { BaseAddress = new Uri("http://127.0.0.1:8000") };

        ///  API handler
        public APIHandler apiHandler { get; set; } = new APIHandler(newClient: newClient);
        public List<PanelContent_Class>? PanelContent { get; set; }
        public RenderFragment PanelContent_Header { get; set; }

        public string ButtonGroupType = "ResultsButtonGroup";
        public List<string>? InstanceIDS { get; set; } = new() { "None Found" };
        public List<string>? GenereationIDs { get; set; } = new() { "None Found" };
        public List<string?>? AlphaAgentIDs { get; set; } = new() { "None Found" };
        public List<string?>? AgentIDs { get; set; } = new() { "None Found" };

        public List<Agent>? SelectedInstance_AlphaAgentsData { get; set; } = new();
        public List<Agent>? SelectedGeneration_AgentData { get; set; } = new();
        public Generation? SelectedGeneration_GenerationData { get; set; } = new();


        public Agent? CurrentlySelectedAgent { get; set; } = new();
        public InstanceBaseData? CurrentInstanceData { get; set; } = new();
        public InstanceEnvironment? CurrentEnvironmentData { get; set; } = new();

        //private string _SelectedInstanceID { get; set; } = string.Empty;
        //public string SelectedInstanceID
        //{
        //    get => _SelectedInstanceID;
        //    set
        //    {
        //        _SelectedInstanceID = value;
        //        SelectedInstanceIdUpdated(value);
        //    }
        //}

        public string SelectedInstanceID { get; set; }

        /// <summary>
        /// On SelectedInstanceID updated - call the following functions
        /// </summary>
        /// <param name="value">The value SelectedInstanceID is update with</param>
        public void SelectedInstanceIdUpdated(string value)
        {
            if (IsStringNull(value)) return;
            SelectedInstanceID = value;
            GetInstanceData(value);
            GetGenerationIDs(value);
            GetAlphaAgents(value);
        }
        /// <summary>
        /// Get the ID attribute for each agent in a list
        /// </summary>
        /// <param name="Agents"></param>
        /// <returns>List of agent ID's</returns>
        private List<string?>? GetAgentIDsFromAgentList(List<Agent>? Agents)
        {
            return Agents?.Select(obj => obj.agentID).ToList();
        }

        /// <summary>
        /// Update the CurrentlySelectedAgent variable
        /// </summary>
        /// <param name="newAgentId">New Value</param>
        public void UpdateCurrentlySelectedAgent(string newAgentId)
        {
            if (IsStringNull(newAgentId)) return;
            var ConcatAgentData = SelectedInstance_AlphaAgentsData.Concat(SelectedGeneration_AgentData);
            CurrentlySelectedAgent = ConcatAgentData.First(obj => obj.agentID == newAgentId);
        }

        /// <summary>
        /// Get Request via API - Get data of the given instance(ID)
        /// </summary>
        /// <param name="instanceID">ID of the desiered instance</param>
        /// <PlotInstanceEnvironment()> Call to plot the Instance Data</>
        public async Task GetInstanceData(string instanceID)
        {
            if (IsStringNull(instanceID)) return;
            (CurrentInstanceData, CurrentEnvironmentData) = await apiHandler.API_GetInstanceData(instanceID);
            PlotInstanceEnvironment();
        }

        /// <summary>
        /// Get Request via API - Get alphe agents with relation to the given instance(ID)
        /// </summary>
        /// <param name="instanceID">ID of the Instance AlphaAgents share a relation to</param>
        public async void GetAlphaAgents(string instanceID)
        {
            if (IsStringNull(instanceID)) return;
            SelectedInstance_AlphaAgentsData = await apiHandler.API_AlphaAgents(instanceID);

            if (IsObjectNull(SelectedInstance_AlphaAgentsData)) return;
            AlphaAgentIDs = GetAgentIDsFromAgentList(SelectedInstance_AlphaAgentsData);

            StateHasChanged();
        }

        /// <summary>
        /// Get Request via API - Get agents with relation to the given generation(ID)
        /// </summary>
        /// <param name="generationID">ID of the Generation relation</param>
        public async void GetAgentData(string generationID)
        {
            if (IsStringNull(generationID)) return;
            SelectedGeneration_AgentData = await apiHandler.API_GetAgentData(generationId: generationID, instanceId: SelectedInstanceID);

            if (IsObjectNull(SelectedGeneration_AgentData)) return;
            AgentIDs = GetAgentIDsFromAgentList(SelectedGeneration_AgentData);
            StateHasChanged();
        }

        /// <summary>
        /// Get Requets - Get the ID's of all Generations relating to a instance(ID)
        /// </summary>
        /// <param name="instanceID">ID of the Instance relation</param>
        public async void GetGenerationIDs(string instanceID)
        {
            if (IsStringNull(instanceID)) return;
            GenereationIDs = await apiHandler.API_GetGenerationIDs(instanceID);
            StateHasChanged();
        }


        /// <summary>
        /// Get Requets - Get the data of a generation
        /// </summary>
        /// <param name="generationID">ID of a generation</param>
        public async void GetGenerationData(string generationID)
        {
            if (IsStringNull(generationID)) return;
            SelectedGeneration_GenerationData = await apiHandler.API_GetGenerationData(generationId: generationID, instanceId: SelectedInstanceID);
            StateHasChanged();
        }


        /// <summary>
        /// Ploting Functions
        /// </summary>

        public void PlotCurrentlySelectedAgentPath()
        {
            if (IsObjectNull(CurrentlySelectedAgent)) return;
            GraphPlottingFunctions.PlotAgentPath(CurrentlySelectedAgent);
        }

        public void PlotCurrentlySelectedAgentFitnessProgression()
        {
            if (IsObjectNull(CurrentlySelectedAgent)) return;
            GraphPlottingFunctions.PlotAgentFitnessProgression(CurrentlySelectedAgent);
        }

        public void PlotAllAgentsFitnessProgression()
        {
            if (IsObjectNull(SelectedGeneration_GenerationData)) return;
            GraphPlottingFunctions.PlotGenerationAllAgentsFitnessResults(SelectedGeneration_GenerationData);
        }
        public void PlotGenerationAverageFitness()
        {
            if (IsObjectNull(CurrentInstanceData)) return;
            GraphPlottingFunctions.PlotInstanceGenerationAvergaeFitnessProgression(CurrentInstanceData);

        }
        public void PlotInstanceEnvironment()
        {
            if (IsObjectNull(CurrentEnvironmentData?.EnvironmentMap) || IsObjectNull(CurrentEnvironmentData?.EnvironmentMapDimensions)) return;
            GraphPlottingFunctions.PopulateEnvironmentGraph(CurrentEnvironmentData.EnvironmentMap, CurrentEnvironmentData.EnvironmentMapDimensions, CurrentEnvironmentData.EnvironmentStartCoordinates);
        }

        /// <summary>
        /// Helper functions for null checks
        /// </summary>
        private bool IsStringNull(string value) => string.IsNullOrWhiteSpace(value);
        private bool IsObjectNull(object? obj) => obj == null;


        /// Component visability 
      
        bool isInstanceInformationVisible = false;
        string InsatnceInformationVisibleStyle => isInstanceInformationVisible ? "" : "display: none;";
        void ToggleInstanceInformationVisibility() => isInstanceInformationVisible = !isInstanceInformationVisible;



        public ResultsPage() {
            PanelContent_Header = builder =>
            {
                builder.OpenComponent(0, typeof(InstanceSelection));
                builder.AddAttribute(1, "CurrentInstanceData", CurrentInstanceData);
                builder.AddAttribute(2, "InstanceIDS", InstanceIDS);
                builder.AddAttribute(3, "UpdateSelectedInstanceID", EventCallback.Factory.Create<string>(this, SelectedInstanceIdUpdated));
                builder.CloseComponent();
            };

            PanelContent = new List<PanelContent_Class> {
                new PanelContent_Class("AlphaAgentsContent", builder =>
                {
                    builder.OpenComponent(0, typeof(AlphaAgentsContent));
                    builder.AddAttribute(1, "AlphaAgentIDs", AlphaAgentIDs);
                    builder.AddAttribute(1, "CurrentlySelectedAgent", CurrentlySelectedAgent);
                    builder.AddAttribute(2, "UpdateCurrentlySelectedAgent", EventCallback.Factory.Create<string>(this, UpdateCurrentlySelectedAgent));
                    builder.AddAttribute(3, "PlotCurrentlySelectedAgentPath", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentPath));
                    builder.AddAttribute(4, "PlotCurrentlySelectedAgentFitnessProgression", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentFitnessProgression));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("GenerationsContent", builder =>
                {
                    builder.OpenComponent(1, typeof(GenerationsContent));
                    builder.AddAttribute(2, "GenereationIDs", GenereationIDs);
                    builder.AddAttribute(3, "GetGenerationData", EventCallback.Factory.Create<string>(this, GetGenerationData));
                    builder.AddAttribute(4, "GenerationData", SelectedGeneration_GenerationData);
                    builder.AddAttribute(6, "ShowGenerationAllAgentsFitnessProgression", EventCallback.Factory.Create(this, PlotAllAgentsFitnessProgression));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("AllAgentsContent", builder =>
                {
                    builder.OpenComponent(1, typeof(AllAgentsContent));
                    builder.AddAttribute(1, "CurrentlySelectedAgent", CurrentlySelectedAgent);
                    builder.AddAttribute(2, "GenereationIDs", GenereationIDs);
                    builder.AddAttribute(3, "AgentIDs", AgentIDs);
                    builder.AddAttribute(4, "GetAgentData", EventCallback.Factory.Create<string>(this, GetAgentData));
                    builder.AddAttribute(5, "UpdateCurrentlySelectedAgent", EventCallback.Factory.Create<string>(this, UpdateCurrentlySelectedAgent));
                    builder.AddAttribute(6, "PlotCurrentlySelectedAgentPath", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentPath));
                    builder.AddAttribute(7, "PlotCurrentlySelectedAgentFitnessProgression", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentFitnessProgression));
                    builder.CloseComponent();
                })
            };
        }

        protected override async Task OnInitializedAsync()
        {
            List<string>? ReturnedIds = await apiHandler.API_GetAllInstanceIDs();

            if (ReturnedIds != null)
            {
                InstanceIDS = ReturnedIds;
                InstanceIDS.Insert(0, "");
                StateHasChanged();
            }
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                GraphPlottingFunctions = new(jsRuntime: JSRuntime);
                await GraphPlottingFunctions.PlotEnvironmentGraph();
            }
        }
    }


}
