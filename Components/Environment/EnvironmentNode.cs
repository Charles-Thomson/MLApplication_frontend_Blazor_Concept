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
        
        public EnvironmentNode(int index)
        {
            this.Index = index; 
        }
    }
}

