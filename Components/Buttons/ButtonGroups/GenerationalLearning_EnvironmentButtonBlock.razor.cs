using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLApplication_frontend.Components.Buttons;
using MLApplication_frontend.Components.Environment;
using static MLApplication_frontend.Components.Environment.NodeEnums;


namespace MLApplication_frontend.Components.Buttons.ButtonGroups
{
    public partial class GenerationalLearning_EnvironmentButtonBlock
    {
        public EnvironmentButtonsSVGs EnvironemntButtonSVGs = new EnvironmentButtonsSVGs();

        [Parameter] public EventCallback<NodeStates> ButtonPressed_callback { get; set; }


        public void Handle_ButtonPresed_Callback(NodeStates newNodeValue) {

            ButtonPressed_callback.InvokeAsync(newNodeValue);
            Log.Information($"Environment_button_block - Updating Selection Value ;  {newNodeValue}");

        }
        public GenerationalLearning_EnvironmentButtonBlock() 
        {
           
        }
    }

    
}
