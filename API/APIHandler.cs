using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using MLApplication_frontend.API;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MLApplication_frontend.API
{
    public class APIHandler
    {

        private readonly HttpClient _client;

        public APIPostFunctions PostFunctions { get; set; }
        public APIGetRequestFunctions GetFunctions { get; set; }

        public APIHandler(HttpClient newClient)
        {
            _client = newClient ?? throw new ArgumentNullException(nameof(newClient));
            // Configure request headers for 'no-cors' mode
            _client.DefaultRequestHeaders.Add("mode", "no-cors");


            PostFunctions = new APIPostFunctions(newClient: _client);
            GetFunctions = new APIGetRequestFunctions(newClient: _client);   
        }


        public async Task<List<string>?> API_GetAllInstanceIDs() {
            List<string>? InstanceIDsAsList = new();

            string allInstanceIdData = await GetFunctions.GetAllInstanceIDs();
            

            if (allInstanceIdData == null) {
                return InstanceIDsAsList;
            }
            
            RootForAllIDs? UnpackedData = JsonConvert.DeserializeObject<RootForAllIDs>(allInstanceIdData);

            InstanceIDsAsList = UnpackedData?.Data?.InstanceIDList;

            return InstanceIDsAsList;
        }


        public async Task<List<string>?> API_GetGenerationIDs(string instanceId) {
            string responceString = await GetFunctions.GetGenerationIds(instanceId);

            RootForGenerationIDs? responce = JsonConvert.DeserializeObject<RootForGenerationIDs>(responceString);

            List<string>? AllGenerationIdsAsList = new List<string>();
            if (responce != null)
            {
                AllGenerationIdsAsList = responce?.Data?.GenerationIDList;
            }

            AllGenerationIdsAsList?.Insert(0, "");


            return AllGenerationIdsAsList;
        }

        public async Task<List<Agent>?> API_GetAgentData(string generationId, string instanceId) {
            Console.WriteLine($"SYSTEM - API_GetAgentData -Call To Get Agents for Generation {generationId}");

            string responceString = await GetFunctions.GetAgentData(generationId, instanceId);

            Console.WriteLine($"SYSTEM - API_GetAgentData - Responce string -  {responceString}");

            RootForGenerationWithAgents? data = JsonConvert.DeserializeObject<RootForGenerationWithAgents>(responceString);

            Console.WriteLine($"SYSTEM - API_GetAgentData - Data Unpacked");

            if (IsPropertyNull(data, r => r?.Data, r => r?.Data?.Generation))
            {
                Console.WriteLine($"SYSTEM - API_GetAgentData - Returning - Null");
                return null;
            }
            List<Agent>? SelectedGenerationAgents = data?.Data?.Generation?.Agents;

            Console.WriteLine($"SYSTEM - API_GetAgentData - Returning - {SelectedGenerationAgents}");

            Agent agent = SelectedGenerationAgents[0];

            Console.WriteLine($"Agent Id {agent.agentID}");

            return SelectedGenerationAgents;
        }

        public async Task<Generation?> API_GetGenerationData(string generationId, string instanceId) {

            Console.WriteLine($"API HANDLER - GET - Gneeration Data of: {generationId}");

            string responceString = await GetFunctions.GetGenerationData(generationId, instanceId);

            RootForGenerationWithAgents? data = JsonConvert.DeserializeObject<RootForGenerationWithAgents>(responceString);

            if (IsPropertyNull(data, r => r?.Data, r => r?.Data?.Generation))
            {
                return null;
            }

            Generation? SelectedGeneration = data?.Data?.Generation;

            return SelectedGeneration;
        }

        
        public async Task<(InstanceBaseData?, InstanceEnvironment?)> API_GetInstanceData(string instance_id) {

            string responce = await GetFunctions.GetInstanceDataByID(instance_id);
            Console.WriteLine($"GET INSTANCE ID DATA RESPONCE : {responce}");
           
            InstanceDataRoot? root = JsonConvert.DeserializeObject<InstanceDataRoot>(responce);

            if (IsPropertyNull(root, r => r?.Data, r => r?.Data?.InstanceBaseData))
            {
                Console.WriteLine("Returning null");
                return (null, null);
            }

            var InstanceData = root?.Data?.InstanceBaseData;
            var EnvironmentData = InstanceData?.InstanceEnvironment;
            
            

            Console.WriteLine("Returning from GetInstanceDataFunc");
            return (InstanceData, EnvironmentData);
        }

        public async Task<List<Agent>?> API_AlphaAgents(string instance_id) {
            string responce = await GetFunctions.GetAlphaAgents(instance_id);
            Console.WriteLine($"{responce}");               
            

            RootForAlphaAgents? root = JsonConvert.DeserializeObject<RootForAlphaAgents>(responce);


            if (IsPropertyNull(root, r => r?.Data, r => r?.Data?.alphaAgents))
            {
                return null;
            }

            var AlphaAgents = root?.Data?.alphaAgents;

            return AlphaAgents;


        }


        public static bool IsPropertyNull<T>(T obj, params Func<T, object?>[] propertySelector) {
            
            foreach (var selector in propertySelector) {
                if (selector(obj) == null) {
                    return true;
                }
            
            }
            return false;
        }

    }
}
