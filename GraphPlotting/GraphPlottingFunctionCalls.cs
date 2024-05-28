using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using MLApplication_frontend.API;

namespace MLApplication_frontend.GraphPlotting
{


    public class GraphPlottingFunctionCalls
    {
        private readonly IJSRuntime _jsRuntime;
        public DataFormatting dataFormatter { get; private set; }

        public EnvironmentPlottingData? environmentPlottingData { get; set; }

        public GraphPlottingFunctionCalls(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            dataFormatter = new DataFormatting();
            
        }

        public async Task PlotEnvironmentGraph()
        {
            await _jsRuntime.InvokeVoidAsync("drawEnvironment");
        }

        public async void PopulateEnvironmentGraph(string environmentMapAsString, string environmentDimensionsAsString, string EnvironmentStartCoordinmates) {
           
            environmentPlottingData = dataFormatter.FormatEnvironmentData(environmentMapAsString, environmentDimensionsAsString, EnvironmentStartCoordinmates);
            
            List<int> environmentDimensions = environmentPlottingData.EnvironmentDimensions;
            
            int dimension = environmentDimensions[0];
            await _jsRuntime.InvokeVoidAsync("drawMazeEnvironment", dimension, environmentPlottingData.EnvironmentStartLocation, environmentPlottingData.EnvironmentGoalLocations, environmentPlottingData.EnvironmentObsticalLocations);

        }

        public async void PlotAgentPath(Agent selectedAgent) {

            Console.WriteLine("RECIEVED CALL - GraphPlottingFunctions - Plot agent Path");
            Console.WriteLine($"Agent Path - {selectedAgent.agentPath}");

            
            int dimensionsHardCoded = environmentPlottingData.EnvironmentDimensions[0];
            Console.WriteLine($"Env Dimension - {dimensionsHardCoded}");
            List<CoordinatesDataClass> AgentPathAsCoordinates = dataFormatter.FormatAgentData(selectedAgent, dimensionsHardCoded);
            Console.WriteLine($"Agent Path as coords - {AgentPathAsCoordinates}");


            

            foreach (var coords in AgentPathAsCoordinates) {
                Console.WriteLine($"Path coords - x: {coords.x} - y: {coords.y}");
            }
            Console.WriteLine(environmentPlottingData.EnvironmentGoalLocations);
            Console.WriteLine(environmentPlottingData.EnvironmentGoalLocations.Count);

            foreach (var coords in environmentPlottingData.EnvironmentGoalLocations)
            {
                Console.WriteLine($" Environemnt coords - x: {coords.x} - y: {coords.y}");
            }
            await _jsRuntime.InvokeVoidAsync("DrawAgentPath", AgentPathAsCoordinates, environmentPlottingData.EnvironmentStartLocation, environmentPlottingData.EnvironmentGoalLocations, environmentPlottingData.EnvironmentObsticalLocations, dimensionsHardCoded);


        }

        public async void PlotAgentFitnessProgression(Agent selectedAgent)
        {
            Console.WriteLine("RECIEVED CALL - GraphPlottingFunctions - Plot agent fitness by step");
            Console.WriteLine($"Agent Path - {selectedAgent.fitnessByStep}");
            Console.WriteLine(selectedAgent.fitnessByStep.GetType());
            // Formatting call for the fitnessbystep data then pass it along to the js interloep
            List<double> FitnessByStepData = dataFormatter.FormatAgentDataFitnessByStep(selectedAgent.fitnessByStep);

            await _jsRuntime.InvokeVoidAsync("DrawFitnessByStep", FitnessByStepData);
        }


        /// CLEN EVERYTHING UP TO DO WITH THE GRAPH PLOT OF FITNESS OF ALL  <summary>
        /// DO THE GRAPH FOR THE INSTANCE AND GRAPHS AVG 

        public async void PlotGenerationAllAgentsFitnessResults(Generation SelectedGeneration) {
           
            
            string PlottingData_str = SelectedGeneration.allAgentsFitnessResults;
            

            List<double> PlottingData_List = dataFormatter.FormatAllAgentFitnessData(PlottingData_str);

            await _jsRuntime.InvokeVoidAsync("DrawGenerationAllAgentsFitnessResults", PlottingData_List);

        }

        public async void PlotInstanceGenerationAvergaeFitnessProgression(InstanceBaseData InstanceData) {


            /// Need to update the API side to get the data 
            //string PlottingData_str = InstanceData.generationAverageFitnessResults;
            string PlottingData_str = "";

            List<double> PlottingData_List = dataFormatter.FormatAllAgentFitnessData(PlottingData_str);

            await _jsRuntime.InvokeVoidAsync("DrawInstanceGenerationsAverageFitnessProgression", PlottingData_List);
        }
    }
}
