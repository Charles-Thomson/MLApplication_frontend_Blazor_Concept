using Newtonsoft.Json;
using System.CodeDom.Compiler;
namespace MLApplication_frontend.API
{
    public class APIHandlerOLD
    {
        private readonly HttpClient _client;

        public APIHandlerOLD(HttpClient newClient)
        {
            _client = newClient ?? throw new ArgumentNullException(nameof(newClient));
            
        }


        public async Task<string> GetRequest(string query)
        {

            try
            {
                HttpResponseMessage response = await _client.GetAsync(query);
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
        /// Get all agents from given generation
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>Agents in string form</returns>
        //public async Task<string> GetAgents(string genID, string instanceID) {
        //    string query = $"/test?query={{getAllAgentsFromGenerationById(instanceId: \"{instanceID}\", generationId: \"{genID}\"){{agentId}} }}";
        //    return await GetRequest(query);
        //}

        /// <summary>
        /// Get the generation based on given ID along with Associated agents
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public async Task<string> GetGenerationAndAgents(string genID, string instanceID)
        {
            string query = $"/MLAPI?query={{getGenerationAndAgents(instanceId: \"{instanceID}\", generationId: \"{genID}\"){{generationId,numberOfAgents,agentInstance{{agentId,,agentPath,agentFitnessByStep,agentFitness}}}}}}";
            return await GetRequest(query);
        }

        /// <summary>
        /// Get the Environment and Alpha Agent data from the instance
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>String - JSon of the Environment and Alpha Agent</returns>
        public async Task<String> GetInstanceDataByID(string instanceId)
        {

            string query = $"/MLAPI?query={{getInstanceBaseDataById(instanceId:\"{instanceId}\"){{instanceAlpha{{agentId,agentPath,agentFitness,agentFitnessByStep}},instanceEnvironment{{obsticals,goals,start,environmentSize}}}}}}";

            return await GetRequest(query);
        }

        /// <summary>
        /// New post request to the Backend API - Submitting a new work item
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>String - JSon of the Environment and Alpha Agent</returns>
        public async Task PostNewWorkItem(string formattedInstanceStateData)
        {
             await GetRequest(formattedInstanceStateData);
        }


        //public (InstanceDataJson?, AlphaAgentDataAsJson?, EnvironmentDataAsJson?) ParseToNewObjects(string jsonData)
        //{

        //    RootInstanceDataJson? root = JsonConvert.DeserializeObject<RootInstanceDataJson?>(jsonData);

        //    if (root == null || root.data == null || root.data.InstanceData == null)
        //    {
        //        return (null, null, null);
        //    }

        //    var InstanceData = root.data.InstanceData;
        //    var EnvironmentData = InstanceData.EnvironmentDataJson;
        //    var AlphaAgentData = InstanceData.AlphaAgentDataJson;

        //    return (InstanceData, AlphaAgentData, EnvironmentData);
        //}
    }
}
