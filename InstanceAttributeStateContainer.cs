using MLApplication_frontend.Pages.GenerationalLearningPages;
using System.Dynamic;
using System.Text.Json;

namespace MLApplication_frontend
{
    public class InstanceAttributeStateContainer
    {
        public string? InstanceName { get; set; } = "Place holder";


        /// <summary>
        /// Hyper Perameter Data
        /// </summary>
        /// 
        public int NodeSelectionValue { get; set; } = 0;

        public string? NumberOfGenerations { get; set; } = string.Empty;

        public string? AgentsPerGeneration { get; set; } = string.Empty;

        public string? StartingFitnessThreshold { get; set; } = string.Empty;

        public string? StartNewGenerationThreshold { get; set; } = string.Empty;

        public string? GenerationFailureThreshold { get; set; } = string.Empty;

        public string? EnvironmentMaxActionCount { get; set; } = string.Empty;

        public string? NewGenerationCreationFunction { get; set; } = string.Empty;

        /// <summary>
        /// Neural Network Data
        /// </summary>

        public string? HiddenLayerWeightInit { get; set; } = string.Empty;

        public string? OutputLayerWeightInit { get; set; } = string.Empty;

        public string? HiddenLayerActivationFunction { get; set; } = string.Empty;

        public string? OutputLayerActivationFunction { get; set; } = string.Empty;


        /// <summary>
        ///  Currently hard coded into the JSON conversion 
        /// </summary>
        public List<int>? InputToHiddenConnections { get; set; }

        public List<int>? HiddenToOutputConnections { get; set; }



        /// <summary>
        /// Environment Data
        /// </summary>

        public string? EnvironmentDimension_X { get; set; }
        public string? EnvironmentDimension_Y { get; set; }

        public int EnvironmentStartState { get; set; }
        
        public List<int>? EnvironmentNodeStateData { get; set; } 

        /// <summary>
        /// Convert Data to Json for API use
        /// </summary>
        /// 
        public string? DataAsJson { get; set; }

        public void SetNeuralNetworkSettingsDefaults() {
            Console.WriteLine("Setting defaults");
            HiddenLayerWeightInit = "he_weight";
            OutputLayerWeightInit = "he_weight";
            HiddenLayerActivationFunction = "rectified_linear_activation_function";
            OutputLayerActivationFunction = "soft_argmax_activation";

            NewGenerationCreationFunction = "crossover_weights_average";
        }

        public void ToJsonString() {

            var data = new
            {
                instance_id = InstanceName,
                environment_configuration = new
                {
                    _environment_map = EnvironmentNodeStateData,
                    _environment_map_dimensions = EnvironmentDimension_X,
                    _environment_start_coordinates = EnvironmentStartState,
                    _environment_maximum_action_count = EnvironmentMaxActionCount,
                },
                hyper_parameter_configuration = new
                {
                    _maximum_number_of_genrations = NumberOfGenerations,
                    _maximum_generation_size = AgentsPerGeneration,
                    _starting_fitness_threshold = StartingFitnessThreshold,
                    _start_new_generation_threshold = StartNewGenerationThreshold,
                    _generation_failure_threshold = GenerationFailureThreshold
                },
                neural_network_configuration = new
                {
                    _weight_init_huristic = HiddenLayerWeightInit,
                    _hidden_activation_function_ref = HiddenLayerActivationFunction,
                    _output_activation_function_ref = OutputLayerActivationFunction,
                    _new_generation_creation_function_ref = NewGenerationCreationFunction,

                    // These need to be checked
                    _input_to_hidden_connections = new List<int> { 24, 9 },
                    _hidden_to_output_connections = new List<int> { 9, 9 }
                }
            };

            DataAsJson =  JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        }

        public string ConvertToAPIQUery() {
            return $"/MLAPI?query={{newWorkItem(inputConfig:\"\"\"{DataAsJson}\"\"\")}}";
        }

    }
}


