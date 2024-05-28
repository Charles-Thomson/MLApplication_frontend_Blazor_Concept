using System;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using MLApplication_frontend.Components;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Serilog;

namespace MLApplication_frontend.Components.Environment
{
    public class EnvironmentNode
    {
        public int Index { get; set; }
        public string BackgroundColor = "whitesmoke";
        private Action<int, int> updateEnvironmentNodeStateData;
        

        public EnvironmentNode(int index, Action<int, int> updateEnvironmentNodeStateData)
        {
            this.Index = index;
            this.updateEnvironmentNodeStateData = updateEnvironmentNodeStateData;
        }

        public void inc(int selectionValue)
        {
            updateEnvironmentNodeStateData(Index, selectionValue);
        }
    }

}

