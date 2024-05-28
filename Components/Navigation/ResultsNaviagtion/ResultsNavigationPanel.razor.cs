using Microsoft.AspNetCore.Components;
using MLApplication_frontend.API;
using MLApplication_frontend.Components.Navigation.ResultsNaviagtion.ResultsPanelContent;
using Serilog;
using MLApplication_frontend.GraphPlotting;
using Microsoft.JSInterop;



namespace MLApplication_frontend.Components.Navigation.ResultsNaviagtion
{
    public partial class ResultsNavigationPanel : ComponentBase
    {
        ///  JS Interlop runtime
        [Inject] protected IJSRuntime JSRuntime { get; set; }

        /// GraphPlotting Functions
        public GraphPlottingFunctionCalls GraphPlottingFunctions { get; set; }
        
        /// HTTP Client
        static readonly HttpClient newClient = new() { BaseAddress = new Uri("http://127.0.0.1:8000") };

        ///  API handler
        public APIHandler apiHandler { get; set; } = new APIHandler(newClient: newClient);
        
        
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


        private string _SelectedInstanceID { get; set; } = string.Empty;
        public string SelectedInstanceID
        {
            get => _SelectedInstanceID;
            set
            {
                _SelectedInstanceID = value;
                SelectedInstanceIdUpdated(value);
            }
        }

        public void SelectedInstanceIdUpdated(string instanceID)
        {
            if (IsStringNull(instanceID)) return;
            GetInstanceData(instanceID);
            GetGenerationIDs(instanceID);
            GetAlphaAgents(instanceID);
        }

        private List<string?>? GetAgentIDsFromAgentList(List<Agent>? Agents) {
            return Agents?.Select(obj => obj.agentID).ToList();
        }

        public void UpdateCurrentlySelectedAgent(string newAgentId) {
            if (IsStringNull(newAgentId)) return;
            var ConcatAgentData = SelectedInstance_AlphaAgentsData.Concat(SelectedGeneration_AgentData);
            CurrentlySelectedAgent = ConcatAgentData.First(obj => obj.agentID == newAgentId);
        }


        public async Task GetInstanceData(string instanceID) {
            if (IsStringNull(instanceID)) return;
            (CurrentInstanceData, CurrentEnvironmentData) = await apiHandler.API_GetInstanceData(instanceID);
            PlotInstanceEnvironment();
        }
        public async void GetAlphaAgents(string instanceID)
        {
            
            if(IsStringNull(instanceID)) return;
            SelectedInstance_AlphaAgentsData = await apiHandler.API_AlphaAgents(instanceID);

            if (IsObjectNull(SelectedInstance_AlphaAgentsData)) return;
            AlphaAgentIDs = GetAgentIDsFromAgentList(SelectedInstance_AlphaAgentsData);

            StateHasChanged();
        }

        public async void GetAgentData(string generationID)
        {
            Console.WriteLine($"SYSTEM - GetAgentData -Call To Get Agents for Generation {generationID}");
            if (IsStringNull(generationID)) return;
            SelectedGeneration_AgentData = await apiHandler.API_GetAgentData(generationId: generationID, instanceId: SelectedInstanceID);

            if (IsObjectNull(SelectedGeneration_AgentData)) return;
            AgentIDs = GetAgentIDsFromAgentList(SelectedGeneration_AgentData);
            StateHasChanged();
        }

        public async void GetGenerationIDs(string newValue)
        {
            if (IsStringNull(newValue)) return;
            GenereationIDs = await apiHandler.API_GetGenerationIDs(newValue);
            StateHasChanged();
        }
        
        public async void GetGenerationData(string generationID)
        {
            if (IsStringNull(generationID)) return;
            SelectedGeneration_GenerationData = await apiHandler.API_GetGenerationData(generationId: generationID, instanceId: SelectedInstanceID);
            StateHasChanged();
        }

        public void PlotCurrentlySelectedAgentPath() {
            if (IsObjectNull(CurrentlySelectedAgent)) return;
            GraphPlottingFunctions.PlotAgentPath(CurrentlySelectedAgent);
        }

        public void PlotCurrentlySelectedAgentFitnessProgression()
        {
            if (IsObjectNull(CurrentlySelectedAgent)) return;
            GraphPlottingFunctions.PlotAgentFitnessProgression(CurrentlySelectedAgent);
        }

        public void PlotAllAgentsFitnessProgression() {
            if (IsObjectNull(SelectedGeneration_GenerationData)) return;
            GraphPlottingFunctions.PlotGenerationAllAgentsFitnessResults(SelectedGeneration_GenerationData);
        }
        public void PlotGenerationAverageFitness() {
            if (IsObjectNull(CurrentInstanceData)) return;
            GraphPlottingFunctions.PlotInstanceGenerationAvergaeFitnessProgression(CurrentInstanceData);

        }
        public void PlotInstanceEnvironment()
        {
            if (IsObjectNull(CurrentEnvironmentData?.EnvironmentMap) || IsObjectNull(CurrentEnvironmentData?.EnvironmentMapDimensions)) return;
            GraphPlottingFunctions.PopulateEnvironmentGraph(CurrentEnvironmentData.EnvironmentMap, CurrentEnvironmentData.EnvironmentMapDimensions, CurrentEnvironmentData.EnvironmentStartCoordinates);
        }


        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                GraphPlottingFunctions = new(jsRuntime: JSRuntime);
            }
        }

        /// <summary>
        ///  Used to populate the list of available Instances - via GetRequest to API
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            List<string>? ReturnedIds = await apiHandler.API_GetAllInstanceIDs();

            if (ReturnedIds != null)
            {
                InstanceIDS = ReturnedIds;
                InstanceIDS.Insert(0, "");
            }
        }

        public ResultsNavigationPanel()
        {
            GraphPlottingFunctions = new(jsRuntime: JSRuntime);

            PanelDataInstances = new List<PanelData> {
            new PanelData("AlphaAgentsContent", builder =>
                {
                    builder.OpenComponent(0, typeof(AlphaAgentsContent));
                    builder.AddAttribute(1, "AlphaAgentIDs", AlphaAgentIDs);
                    builder.AddAttribute(1, "CurrentlySelectedAgent", CurrentlySelectedAgent);
                    builder.AddAttribute(2, "UpdateCurrentlySelectedAgent", EventCallback.Factory.Create<string>(this, UpdateCurrentlySelectedAgent));
                    builder.AddAttribute(3, "PlotCurrentlySelectedAgentPath", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentPath));
                    builder.AddAttribute(4, "PlotCurrentlySelectedAgentFitnessProgression", EventCallback.Factory.Create(this, PlotCurrentlySelectedAgentFitnessProgression));
                    builder.CloseComponent();
                }),
            new PanelData("GenerationsContent", builder =>
                {
                    builder.OpenComponent(1, typeof(GenerationsContent));
                    builder.AddAttribute(2, "GenereationIDs", GenereationIDs);
                    builder.AddAttribute(3, "GetGenerationData", EventCallback.Factory.Create<string>(this, GetGenerationData));
                    builder.AddAttribute(4, "GenerationData", SelectedGeneration_GenerationData);
                    builder.AddAttribute(6, "ShowGenerationAllAgentsFitnessProgression", EventCallback.Factory.Create(this, PlotAllAgentsFitnessProgression));
                    builder.CloseComponent();
                }),
            new PanelData("AllAgentsContent", builder =>
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

            VisablePanelContent = PanelDataInstances[0];

            SelectedInstanceID = string.Empty;
        }

        private bool IsStringNull(string value) => string.IsNullOrWhiteSpace(value);
        private bool IsObjectNull(object? obj) => obj == null;

        /// Component visability 
        public PanelData VisablePanelContent { get; set; }
        public List<PanelData> PanelDataInstances { get; set; }

        bool isInstanceInformationVisible = false;
        string InsatnceInformationVisibleStyle => isInstanceInformationVisible ? "" : "display: none;";
        void ToggleInstanceInformationVisibility() => isInstanceInformationVisible = !isInstanceInformationVisible;

        /// <summary>
        /// Change the content that is shown in the content panel
        /// </summary>
        /// <param name="panelNameToBeVisable">
        /// str - name of the content to be made visable
        public void ChangeVisablePanelContent(string panelNameToBeVisable)
        {
            if (VisablePanelContent.PanelName == panelNameToBeVisable)
            {
                Log.Information($"Panel already visable: {panelNameToBeVisable}");
                return;
            }
            PanelData? selectedPanel = PanelDataInstances.FirstOrDefault(Panel => Panel.PanelName == panelNameToBeVisable);

            if (selectedPanel != null)
            {
                VisablePanelContent = selectedPanel;
                Log.Information($"Panel content updated with: {panelNameToBeVisable}");
            }
        }

        /// <summary>
        /// Class to store data of a viewable panel
        /// </summary>
        public class PanelData
        {
            public string PanelName { get; set; }
            public RenderFragment PanelContent { get; set; }
            public PanelData(string panelName, RenderFragment panelContent)
            {
                PanelName = panelName;
                PanelContent = panelContent;
            }
        }
    }
}
