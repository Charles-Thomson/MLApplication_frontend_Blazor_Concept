using MLApplication_frontend.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace MLApplication_frontend.GraphPlotting
{
    public class DataFormatting
    {
        static List<int> ParseStringToIntList(string str) {
            string sanitisedStr = str.Replace("[", "").Replace("]", "");
            string[] strArray = sanitisedStr.Split(',');
            List<int> intList = strArray.Select(s => int.Parse(s)).ToList();
            return intList;
        }

        

        static List<double> ParseStringToDoubleList(string str)
        {
            string[] strArray = str.Trim('[', ']').Split(',');
            List<double> doubleList = strArray.Select(s => double.Parse(s)).ToList();
            return doubleList;
        }

        public CoordinatesDataClass ConvertToCoordianteDataClass(int value, int dimension) {
            int CoordinateY = 0;
            int CoordinateX = 0;
            try
            {
                CoordinateY = (value / dimension);
                CoordinateX = (value % dimension);
                
                return new CoordinatesDataClass(CoordinateX, CoordinateY);
            }
            catch
            {
                Console.WriteLine($"Tried converting the index {value} by dimension {dimension}");
            }
            

            return new CoordinatesDataClass(CoordinateX, CoordinateY);
        }


        public CoordinatesDataClass ConvertToCoordianteDataClass_ForAgentPath(int value, int dimension)
        {
            int CoordinateY = 0;
            int CoordinateX = 0;
            try
            {
                CoordinateY = (value % dimension);
                CoordinateX = (value / dimension);

                return new CoordinatesDataClass(CoordinateX, CoordinateY);
            }
            catch
            {
                Console.WriteLine($"Tried converting the index {value} by dimension {dimension}");
            }


            return new CoordinatesDataClass(CoordinateX, CoordinateY);
        }


        /// <summary>
        /// Following two functions can be refactored down into one
        /// </summary>

        public List<double> FormatAgentDataFitnessByStep(string fitnessByStepAsStr)
        {
            List<double> fittnessByStepList = ParseStringToDoubleList(fitnessByStepAsStr);

            return fittnessByStepList;

        }

        public List<double> FormatAllAgentFitnessData(string fitnessByStepAsStr) {
            
            List<double> fittnessByStepList = ParseStringToDoubleList(fitnessByStepAsStr);
            
            return fittnessByStepList;
        }



        public List<CoordinatesDataClass> FormatAgentData(Agent agent, int environmentDimensions) {

            List<int> AgentPathAsElements = new();
            List<CoordinatesDataClass> AgentPathAsCoordinates = new();

            if (agent.agentPath != null) {
                AgentPathAsElements = ParseStringToIntList(agent.agentPath);
            }

            foreach (int element in AgentPathAsElements) {
                AgentPathAsCoordinates.Add(ConvertToCoordianteDataClass_ForAgentPath(element, environmentDimensions));
            }
            return AgentPathAsCoordinates;
        }
        public EnvironmentPlottingData FormatEnvironmentData(string EnvironmentMap, string environmentDimensions, string EnvironmentStartCoordinmates) {

            Console.WriteLine("In the env map formatting");
            Console.WriteLine(EnvironmentMap);


           
            List<CoordinatesDataClass> startIndex = new(); // Need to fix later

            List<int> startLoctionCoordintes = ParseStringToIntList(EnvironmentStartCoordinmates);
            startIndex.Add(new CoordinatesDataClass(newX: startLoctionCoordintes[0],newY: startLoctionCoordintes[1]));

            List<CoordinatesDataClass> goalIndexs = new();
            
            List<CoordinatesDataClass> obsticalIndexs = new();

            List<int> EnvironmnetAsElements = ParseStringToIntList(EnvironmentMap);
            List<int> EnvironmnetDimensions = ParseStringToIntList(environmentDimensions);
            Console.WriteLine($"****** ENV FDIMENSION **** {environmentDimensions}");

            

            int EnvironmentDimension = EnvironmnetDimensions[0];

            for (int index = 0; index < EnvironmnetAsElements.Count; index++)
            {
                switch (EnvironmnetAsElements[index])
                {
                    case 0:
                        break;
                    case 1:
                        goalIndexs.Add(ConvertToCoordianteDataClass(index, EnvironmentDimension));
                        break;
                    case 2:
                        obsticalIndexs.Add(ConvertToCoordianteDataClass(index, EnvironmentDimension));
                        break;
                }
            }
            
            return new EnvironmentPlottingData(StartLocation: startIndex, GoalLocations: goalIndexs, ObsticalLocations: obsticalIndexs, environmentDimensions: EnvironmnetDimensions);
        }
    }

    public class CoordinatesDataClass
    {
        // These values must be kept as lower case singe char as requiered  by char.js
        public double x { get; set; }
        public double y { get; set; }
        public CoordinatesDataClass(int newX, int newY)
        {
            x = newX + 0.5;
            y = newY + 0.5;
        }
        
    }

    public class EnvironmentPlottingData
    {
        public List<CoordinatesDataClass> EnvironmentGoalLocations { get; set; }
        public List<CoordinatesDataClass> EnvironmentObsticalLocations { get; set; }
        public List<CoordinatesDataClass> EnvironmentStartLocation { get; set; }

        public List<int> EnvironmentDimensions { get; set; }

        public EnvironmentPlottingData(
             List<CoordinatesDataClass> GoalLocations,
             List<CoordinatesDataClass> ObsticalLocations,
             List<CoordinatesDataClass> StartLocation,
             List<int> environmentDimensions

            )
        {
            EnvironmentGoalLocations = GoalLocations;
            EnvironmentObsticalLocations = ObsticalLocations;
            EnvironmentStartLocation = StartLocation;
            EnvironmentDimensions = environmentDimensions;
        }
    }
}
