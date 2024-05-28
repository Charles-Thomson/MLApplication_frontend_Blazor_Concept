using System.Net;

namespace MLApplication_frontend.API
{
    public class APIGetRequestFunctions
    {
        private readonly HttpClient _client;
        public APIGetRequestFunctions(HttpClient newClient) {
            _client = newClient ?? throw new ArgumentNullException(nameof(newClient));
        }

        public async Task<string> GetRequest(string query)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(query);
                string responceContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return string.Empty;
            }

        }

        /// <summary>
        /// GET request - Get all Instance ID's
        /// </summary>
        /// <returns>All instance id's in string form</returns>
        public async Task<string> GetAllInstanceIDs()
        {
            string query = $"/MLAPI?query={{getAllInstanceIds}}";
            return await GetRequest(query);
        }

        /// <summary>
        /// GET request - Get all generation ID's relating to a given instance
        /// </summary>
        /// <param name="instanceID"></param>
        /// <returns>Generation ID's in string form</returns>
        public async Task<string> GetGenerationIds(string instanceId)
        {
            string query = $"/MLAPI?query={{getAllGenerationIdsFromInstanceById(instanceId: \"{instanceId}\")}}";
            return await GetRequest(query);
        }

        /// <summary>
        /// GET requets - returns the Agents of a given Generation/instance 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public async Task<string> GetAgentData(string genID, string instanceID)
        {
            string query = $"/MLAPI?query={{getGenerationAndAgents(instanceId: \"{instanceID}\", generationId: \"{genID}\"){{generationId,numberOfAgents,brainInstance{{brainId,,brainPath,brainFitnessByStep,brainFitness}}}}}}";
            return await GetRequest(query);
        }


        /// <summary>
        /// GET requets - returns Data For a given Generation ID 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public async Task<string> GetGenerationData(string genID, string instanceID)
        {
            string query = $"/MLAPI?query={{getGenerationAndAgents(instanceId: \"{instanceID}\", generationId: \"{genID}\"){{generationId,numberOfAgents,allAgentsFitnessResults,generationAverageFitness}}}}";
            return await GetRequest(query);
        }


        /// <summary>
        /// Get the Environment and Alpha Agent data from the instance
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>String - JSon of the Environment and Alpha Agent</returns>
        public async Task<String> GetInstanceDataByID(string instanceId)
        {
            Console.WriteLine($"GET-INSTANCE_DATA_BY_ID -> InstanceId Used in Request: {instanceId}");
            string query = $"/MLAPI?query={{getInstanceBaseDataById(instanceId:\"{instanceId}\"){{ instanceId,numberOfSucessfulGenerations,generationAverageFitnessResults,instanceEnvironment{{environmentMap,environmentMapDimensions,environmentStartCoordinates,environmentMaximumActionCount}}}}}}";
            return await GetRequest(query);
        }

        public async Task<string> GetAlphaAgents(string instanceId) {
            Console.WriteLine($"Getting Alpha Agents for Instance: {instanceId}");

            string query = $"/MLAPI?query={{getAllAlphas(instanceId:\"{instanceId}\"){{brainId,brainPath,brainFitness,brainFitnessByStep}}}}";
            return await GetRequest(query);
        }
    }
}
