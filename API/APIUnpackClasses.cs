using Newtonsoft.Json;
using MLApplication_frontend.API;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace MLApplication_frontend.API
{
    public class APIUnpackClasses
    {
            public List<CoordinatesDataClass> ConvertToCoordsList(List<List<int>>? baseData)
            {
                List<CoordinatesDataClass> ReturnData = [];

                if (baseData == null)
                {
                    return ReturnData;
                }

                foreach (var elm in baseData)
                {
                    CoordinatesDataClass new_item = new(newX: elm[0], newY: elm[1]);

                    ReturnData.Add(new_item);
                }
                return ReturnData;
            }

            public List<CoordinatesDataClass> ConvertToCoordsListUnNested(List<int>? baseData)
            {

                ///<summary>
                /// Funtion to convert list of coordinates to List<CoordinatesDataClass>
                ///<summary>
                /// <param name="baseData">List of coordiantes to be converted</param>


                List<CoordinatesDataClass> ReturnData = [];

                if (baseData == null)
                {
                    return ReturnData;
                }

                CoordinatesDataClass new_item = new(newX: baseData[0], newY: baseData[1]);
                ReturnData.Add(new_item);


                return ReturnData;
            }
    }

        
    //public class EnvironmentData : APIUnpackClasses
    //{
    //    public List<List<int>>? _environmentMap { get; set; }
    //    public int? _environmentMapDimensions { get; set; }
    //    public List<int>? _environmentStartCoordinates { get; set; }
    //    public int? _maximumActionCount { get; set; }

    //    [JsonProperty("environmentMap")]
    //    public string environmentMap
    //    {
    //        get { return JsonConvert.SerializeObject(_environmentMap); }
    //        set { _environmentMap = JsonConvert.DeserializeObject<List<List<int>>?>(value);}
    //    }

    //    [JsonProperty("environmentMapDimensions")]
    //    public string environmentMapDimensions
    //    {
    //        get { return JsonConvert.SerializeObject(_environmentMapDimensions); }
    //        set { _environmentMapDimensions = JsonConvert.DeserializeObject<int>(value); }
    //    }

    //    [JsonProperty("environmentStartCoordinates")]
    //    public string environmentStartCoordinates
    //    {
    //        get { return JsonConvert.SerializeObject(_environmentStartCoordinates); }
    //        set { _environmentStartCoordinates = JsonConvert.DeserializeObject<List<int>>(value); }
    //    }

    //    [JsonProperty("maximumActionCount")]
    //    public string maximumActionCount
    //    {
    //        get { return JsonConvert.SerializeObject(_maximumActionCount); }
    //        set { _maximumActionCount = JsonConvert.DeserializeObject<int>(value); }
    //    }
    //}

    //public class InstanceDataJson
    //{
    //    /// <summary>
    //    /// InstanceID not curently given by the API
    //    /// </summary>
    //    [JsonProperty("instanceId")]
    //    public string? InstanceId { get; set; }

    //    [JsonProperty("instanceEnvironment")]
    //    public EnvironmentData? EnvironmentData { get; set; }

    //    public List<double>? _generationAverageFitnessResults { get; set; }

    //    [JsonProperty("generationAverageFitnessResults")]
    //    public string? generationAverageFitnessResults
    //    {
    //        get { return JsonConvert.SerializeObject(_generationAverageFitnessResults); }
    //        set { _generationAverageFitnessResults = JsonConvert.DeserializeObject<List<double>>(value); }
    //    }

    //    [JsonProperty("instanceAlpha")]
    //    public Agent? AlphaAgentData { get; set; }

    //    [JsonProperty("numberOfSucessfulGenerations")]
    //    public string? numberOfSucessfulGenerations { get; set; }
    //}

    //public class NestedInstaceDataJson
    //{
    //    [JsonProperty("getInstanceBaseDataById")]
    //    public InstanceDataJson? InstanceData { get; set; }
    //}

    //public class RootInstanceDataJson
    //{
        
    //    [JsonProperty("data")]
    //    public NestedInstaceDataJson? data { get; set; }
    //}


    /// <summary>
    /// THIS IS THE TEST UNPACKING CLASS 
    /// </summary>
    /// 
    public class InstanceDataRoot
    {
        [JsonProperty("data")]
        public Data? Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("getInstanceBaseDataById")]
        public InstanceBaseData? InstanceBaseData { get; set; }
    }

    public class InstanceBaseData
    {
        [JsonProperty("instanceId")]
        public string? InstanceId { get; set; }

        [JsonProperty("numberOfSucessfulGenerations")]
        public int? NumberOfSuccessfulGenerations { get; set; }

        //[JsonProperty("generationAverageFitnessResults")]
        //public string? GenerationAverageFitnessResults { get; set; }

        public List<double>? _generationAverageFitnessResults { get; set; }

        [JsonProperty("generationAverageFitnessResults")]
        public string? GenerationAverageFitnessResults
        {
            get { return JsonConvert.SerializeObject(_generationAverageFitnessResults); }
            set { _generationAverageFitnessResults = JsonConvert.DeserializeObject<List<double>>(value); }
        }

        [JsonProperty("instanceEnvironment")]
        public InstanceEnvironment? InstanceEnvironment { get; set; }
    }

    public class InstanceEnvironment
    {
        public List<List<int>>? _environmentMap { get; set; }

        [JsonProperty("environmentMap")]
        public string EnvironmentMap
        {
            get { return JsonConvert.SerializeObject(_environmentMap); }
            set { _environmentMap = JsonConvert.DeserializeObject<List<List<int>>?>(value); }
        }

        [JsonProperty("environmentMapDimensions")]
        public string? EnvironmentMapDimensions { get; set; }

        public List<int>? _environmentStartCoordinates { get; set; }

        [JsonProperty("environmentStartCoordinates")]
        public string EnvironmentStartCoordinates
        {
            get { return JsonConvert.SerializeObject(_environmentStartCoordinates); }
            set { _environmentStartCoordinates = JsonConvert.DeserializeObject<List<int>>(value); }
        }


        [JsonProperty("environmentMaximumActionCount")]
        public int? EnvironmentMaximumActionCount { get; set; }
    }


    // This is for getting all the ID data 
    public class IdData
    {
        [JsonProperty("getAllInstanceIds")]
        public List<string>? InstanceIDList { get; set; }
    }

    public class RootForAllIDs
    {
        [JsonProperty("data")]
        public IdData? Data { get; set; }
    }


    // **** Generation IDS ****
    public class GenerationIDs
    {
        [JsonProperty("getAllGenerationIdsFromInstanceById")]
        public List<string>? GenerationIDList { get; set; }
    }

    public class RootForGenerationIDs
    {
        [JsonProperty("data")]
        public GenerationIDs? Data { get; set; }
    }

    // **** Unpacking for Agents Per Generation *****

    public class RootForGenerationWithAgents
    {
        [JsonProperty("data")]
        public NestedData? Data { get; set; }
    }

    public class NestedData
    {
        [JsonProperty("getGenerationAndAgents")]
        public Generation? Generation { get; set; }
    }

    /// ALPHA AGENTS UNPACKING CLASSES


    public class RootForAlphaAgents {
        [JsonProperty("data")]
        public AlphaAgents? Data { get; set; }
    
    }

    public class AlphaAgents
    {
        [JsonProperty("getAllAlphas")]
        public List<Agent>? alphaAgents { get; set; }
    }

    

    public class Generation : APIUnpackClasses
    {
        [JsonProperty("generationId")]
        public string? generationId { get; set; }

        [JsonProperty("numberOfAgents")]
        public string? numberOfAgents { get; set; }

        [JsonProperty("allAgentsFitnessResults")]
        public string? allAgentsFitnessResults { get; set;}


        public List<double>? _allAgentsFitnessResults { get; set; }
        [JsonProperty("brainFitnessByStep")]
        public string? fitnessByStep
        {
            get { return JsonConvert.SerializeObject(_allAgentsFitnessResults); }
            set { _allAgentsFitnessResults = JsonConvert.DeserializeObject<List<double>>(value); }
        }

        [JsonProperty("generationAverageFitness")]
        public string? generationAverageFitness { get; set; }

        [JsonProperty("brainInstance")]
        public List<Agent>? Agents { get; set; }
    }

    public class Agent : APIUnpackClasses
    {

        [JsonProperty("brainId")]
        public string? agentID { get; set; }
        [JsonProperty("brainFitness")]
        public string? agentFitness { get; set; }

        public List<List<int>>? _agentPath;

        [JsonProperty("brainPath")]
        public string? agentPath
        {
            get { return JsonConvert.SerializeObject(_agentPath); }
            set { _agentPath = JsonConvert.DeserializeObject<List<List<int>>>(value); }
        }


        public List<double>? _fitnessByStep { get; set; }
        [JsonProperty("brainFitnessByStep")]
        public string? fitnessByStep
        {
            get { return JsonConvert.SerializeObject(_fitnessByStep); }
            set { _fitnessByStep = JsonConvert.DeserializeObject<List<double>>(value); }
        }
    }


    }

