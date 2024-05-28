using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Serilog;
using static MLApplication_frontend.Components.Environment.NodeEnums;

namespace MLApplication_frontend.Components.Environment
{
    public partial class ConstructedEnvironment
    {

        public List<EnvironmentNode> EnvioronmentNodeList = new List<EnvironmentNode>();
        public int TotalNumberOfNodesInEnvironment { get; set; }
        public int SelectionValue { get; set; } = 0;
        public int DefaultEnvironmentDimensions { get; set; } = 5;

        public int _CurrentEnvironemntDimension_X { get; set; }
        [CascadingParameter(Name = "CurrentEnvironmentDimension_X")] public int CurrentEnvironemntDimension_X
        {
            get => _CurrentEnvironemntDimension_X;
            set
            {
                _CurrentEnvironemntDimension_X = value;
                UpdateEnvironmentDimensions(value, CurrentEnvironemntDimension_Y);
            }
        }
        public int _CurrentEnvironemntDimension_Y { get; set; }
        [CascadingParameter(Name = "CurrentEnvironmentDimension_Y")] public int CurrentEnvironemntDimension_Y { 
            get => _CurrentEnvironemntDimension_Y;
            set {
                _CurrentEnvironemntDimension_Y = value;
                UpdateEnvironmentDimensions(CurrentEnvironemntDimension_X, value);
            } 
        }
        public void UpdateEnvironmentDimensions(int currentEnvironemntDimension_X, int currentEnvironemntDimension_Y)
        {
            Log.Information($"Environment Dimensions being updated with values {currentEnvironemntDimension_X} - {currentEnvironemntDimension_Y}");
            TotalNumberOfNodesInEnvironment = currentEnvironemntDimension_X * currentEnvironemntDimension_Y;

            stateContainer.EnvironmentNodeStateData = new List<int>(new int[TotalNumberOfNodesInEnvironment]);
            EnvioronmentNodeList = GenerateEnvironmentNodes(TotalNumberOfNodesInEnvironment);
        }

        public List<EnvironmentNode> GenerateEnvironmentNodes(int environmentSizeAsInt) {

            if (environmentSizeAsInt < 0) throw new ArgumentException("Environment size must be a positive integer.");
            
            var generateNodes = Enumerable.Range(0, environmentSizeAsInt)
                .Select(index => new EnvironmentNode(index, updateEnvironmentNodeStateData))
                .ToList();

            return generateNodes;
        }

        public void ChangeSelectionValue(int newValue) {
            Log.Information($"ChangeSelectionValue updated to {newValue}");
            SelectionValue = newValue;
        }
        public void SetNewStartNode(int Index) => stateContainer.EnvironmentStartState = Index;

        public void RemoveOldStartNodeFromEnvironment() {
            EnvironmentNode? Node = EnvioronmentNodeList.Find(obj => obj.BackgroundColor == NodeBackgroundColors.Start);
            if (Node == null) return;
            Node.BackgroundColor = NodeBackgroundColors.Empty;
        }
        public void updateEnvironmentNodeStateData(int Index, int newValue) {
            CheckEnvironmentNodeStateDataListSize();

            var SelectedNode = EnvioronmentNodeList[Index];
            switch (newValue)
            {
                case (int)NodeStates.Empty: 
                    SelectedNode.BackgroundColor = NodeBackgroundColors.Empty;
                    
                    break;
                case (int)NodeStates.Goal: 
                    SelectedNode.BackgroundColor = NodeBackgroundColors.Goal;
                    
                    break;
                case (int)NodeStates.Obstical: 
                    SelectedNode.BackgroundColor = NodeBackgroundColors.Obstical;
                    break;
                case (int)NodeStates.Start:
                    SetNewStartNode(Index);
                    RemoveOldStartNodeFromEnvironment();
                    SelectedNode.BackgroundColor = NodeBackgroundColors.Start;
                    return;
                default:
                    SelectedNode.BackgroundColor = NodeBackgroundColors.Empty;
                    break;
            }
            stateContainer.EnvironmentNodeStateData[Index] = newValue;
            StateHasChanged();
        }

        public void CheckEnvironmentNodeStateDataListSize() {
            if (stateContainer.EnvironmentNodeStateData?.Count == TotalNumberOfNodesInEnvironment) return;
            stateContainer.EnvironmentNodeStateData = new List<int>(new int[TotalNumberOfNodesInEnvironment]);
        }
    }
}
