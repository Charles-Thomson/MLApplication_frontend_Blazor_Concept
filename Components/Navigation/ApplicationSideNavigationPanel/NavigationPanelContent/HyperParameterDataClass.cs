namespace MLApplication_frontend.Components.Navigation.SideNavigationPanel.NavigationPanelContent
{
    public class HyperParameterDataClass
    {

        static Random rnd = new Random();
        static int value = rnd.Next(300);
        // Need to set Defaults 
        public string? InstanceName { get; set; } = $"Instance - {value}";
        public string? NumGenerations { get; set; } = "10";
        public string? AgentsPerGeneration { get; set; } = "20";
        public string? FitnessThreshold { get; set; } = "2.0";
        public string? FitnessThresholdGain { get; set; } = "Default Gain";
        public string? HiddenLayerWeightInit { get; set; } = "Default Init";
        public string? OutputLayerWeightInit { get; set; } = "Default Init";
        public string? OutputLayerActivationFunction { get; set; } = "Default Func";
        public string? HiddenLayerActivationFunction { get; set; } = "Default Func";

    }
}
