using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Runtime.InteropServices;
using static MLApplication_frontend.Enums.EnvironmentNodeEnums;

namespace MLApplication_frontend.Components.Environment
{
    public partial class ConstructedEnvironment
    {

        private List<EnvironmentNode> EnvioronmentNodeList = new List<EnvironmentNode>();
        private int TotalNumberOfNodesInEnvironment { get; set; }
       
        private int _currentEnvironmentDimension_X { get; set; }
        private int _currentEnvironmentDimension_Y { get; set; }

        [CascadingParameter(Name = "CurrentEnvironmentDimension_X")] public int CurrentEnvironmentDimension_X
        {
            get => _currentEnvironmentDimension_X;
            set
            {
                _currentEnvironmentDimension_X = value;
                UpdateEnvironmentDimensions(value, CurrentEnvironmentDimension_Y);
            }
        }
        
        [CascadingParameter(Name = "CurrentEnvironmentDimension_Y")] public int CurrentEnvironmentDimension_Y { 
            get => _currentEnvironmentDimension_Y;
            set {
                _currentEnvironmentDimension_Y = value;
                UpdateEnvironmentDimensions(CurrentEnvironmentDimension_X, value);
            } 
        }

        public void UpdateEnvironmentDimensions(int CurrentEnvironmentDimension_X, int CurrentEnvironmentDimension_Y)
        {
            Log.Information($"Environment Dimensions being updated with values {CurrentEnvironmentDimension_X} - {CurrentEnvironmentDimension_Y}");
            TotalNumberOfNodesInEnvironment = CurrentEnvironmentDimension_X * CurrentEnvironmentDimension_Y;

            stateContainer.EnvironmentNodeStateData = new List<int>(new int[TotalNumberOfNodesInEnvironment]);
            EnvioronmentNodeList = GenerateEnvironmentNodes(TotalNumberOfNodesInEnvironment);
        }

        public List<EnvironmentNode> GenerateEnvironmentNodes(int environmentSizeAsInt) {

            if (environmentSizeAsInt < 0) throw new ArgumentException("Environment size must be a positive integer.");
            
            var generateNodes = Enumerable.Range(0, environmentSizeAsInt)
                .Select(index => new EnvironmentNode(index))
                .ToList();

            return generateNodes;
        }

        public void SetNewStartNode(int Index) => stateContainer.EnvironmentStartState = Index;

        public void RemoveOldStartNodeFromEnvironment() {
            var Node = EnvioronmentNodeList[stateContainer.EnvironmentStartState];
            if (Node == null) return;
            
            Node.BackgroundColor = NodeBackgroundColorsEnums.Empty;
            stateContainer.EnvironmentNodeStateData[stateContainer.EnvironmentStartState] = 0;
        }

        public void updateEnvironmentNodeStateData(int Index) {
            CheckEnvironmentNodeStateDataListSize();

            var SelectedNode = EnvioronmentNodeList[Index];
            NodeStateEnums CurrentSelectionNode = stateContainer.NodeSelectionValue;

            SelectedNode.BackgroundColor = CurrentSelectionNode switch
            {
                NodeStateEnums.Empty => NodeBackgroundColorsEnums.Empty,
                NodeStateEnums.Start => NodeBackgroundColorsEnums.Start,
                NodeStateEnums.Obstical => NodeBackgroundColorsEnums.Obstical,
                NodeStateEnums.Goal => NodeBackgroundColorsEnums.Goal,
                _ => NodeBackgroundColorsEnums.Empty    
            };

            if (stateContainer.NodeSelectionValue == NodeStateEnums.Start)
            {
                RemoveOldStartNodeFromEnvironment();
                SetNewStartNode(Index);
                return;
            }

            stateContainer.EnvironmentNodeStateData[Index] = (int)CurrentSelectionNode;
            StateHasChanged();
        }

        private void CheckEnvironmentNodeStateDataListSize() {
            if (stateContainer.EnvironmentNodeStateData?.Count == TotalNumberOfNodesInEnvironment) return;
            stateContainer.EnvironmentNodeStateData = new List<int>(new int[TotalNumberOfNodesInEnvironment]);
        }
    }
}
