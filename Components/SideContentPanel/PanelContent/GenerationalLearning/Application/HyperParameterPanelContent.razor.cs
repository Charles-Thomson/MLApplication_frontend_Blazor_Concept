using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application
{
    
    public partial class HyperParameterPanelContent
    {
       
        //Move these into the Instance AttributesClass ?
        public Array HiddenLayerWeightInit = new[]
        {
            "he_weight",
            "xavier_weight",
            "normalized_xavier_weight"
        };

        public Array OutputLayerWeightInit = new[]
        {
            "he_weight",
            "xavier_weight",
            "normalized_xavier_weight"
        };

        public Array OutputLayerActivationFunction = new[]
        {
            "argmax_activation",
            "soft_argmax_activation",
            
        };

        public Array HiddenLayerActivationFunction = new[]
        {
            "linear_activation_function",
            "rectified_linear_activation_function",
            "leaky_rectified_linear_function",
            "sigmoid_activation_fucntion",
            "hyperbolic_tangent_activation_function"

        };

        public Array NewGenerationCreationFunctions = new[]
       {
            "crossover_weights_average",
            "crossover_weights_mergining",
            
        };

    }
}
