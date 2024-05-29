namespace MLApplication_frontend.Components.Navigation.ApplicationSideNavigationPanel.NavigationPanelContent
{
    public class NeuralNetworkAttributes
    {

        public List<KeyValuePair<string, string>> HiddenLayerWeightInit_KVP = [
            new ("he_weight" , "he weight"),
            new ("xavier_weight" , "xavier weight"),
            new ("normalized_xavier_weight" , "normalized xavier weight"),
            ];

        public List<KeyValuePair<string, string>> OutputLayerWeightInit_KVP = [
                new ("he_weight" , "he weight"),
                new ("xavier_weight" , "xavier weight"),
                new ("normalized_xavier_weight" , "normalized xavier weight"),
            ];


        public List<KeyValuePair<string, string>> OutputLayerActivationFunction_KVP = [
                new ("argmax_activation" , "argmax activation"),
                new ("soft_argmax_activation" , "soft argmax activation"),
            ];

        public List<KeyValuePair<string, string>> HiddenLayerActivationFunction_KVP = [
                new("linear_activation_function", "linear activation function"),
                new("rectified_linear_activation_function","rectified linear activation function"),
                new("leaky_rectified_linear_function","leaky rectified linear function"),
                new("sigmoid_activation_fucntion", "sigmoid activation fucntion"),
                new("hyperbolic_tangent_activation_function", "hyperbolic_tangent_activation_function")
            ];

        public List<KeyValuePair<string, string>> NewGenerationCreationFunctions_KVP = [
                new("crossover_weights_average","crossover weights average"),
                new("crossover_weights_mergining", "crossover_weights_mergining")
            ];
    }
}
