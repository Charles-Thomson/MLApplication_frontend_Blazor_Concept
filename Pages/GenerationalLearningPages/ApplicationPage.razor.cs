using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using MLApplication_frontend.Components.SideContentPanel.PanelContent;
using MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MLApplication_frontend.Components.Environment.NodeEnums;


namespace MLApplication_frontend.Pages.GenerationalLearningPages
{
    public partial class ApplicationPage
    {
        public List<PanelContent_Class>? PanelContent { get; set; }

        

        public string ButtonGroupType = "ApplicationButtonGroup";

        public ApplicationPage(){

            PanelContent = new List<PanelContent_Class> {
            new PanelContent_Class("HyperParameterSettings", builder =>
                {
                    builder.OpenComponent(0, typeof(HyperParameterPanelContent));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("NeuralNetworkSettings", builder =>
                {
                    builder.OpenComponent(0, typeof(NeuralNetworkPanelContent));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("EnvironmentSettings", builder =>
                {
                    builder.OpenComponent(0, typeof(EnvironmentPanelContent));
                    builder.AddAttribute(1, "UpdateEnvironmentDimension_X_CallBack", EventCallback.Factory.Create<string> (this,UpdateEnvironmentDimension_X));
                    builder.AddAttribute(2, "UpdateEnvironmentDimension_Y_CallBack",EventCallback.Factory.Create<string>(this, UpdateEnvironmentDimension_Y));
                    builder.AddAttribute(3, "UpdateEnvironmentNodeTypeSelector", EventCallback.Factory.Create<NodeStates>(this,UpdateEnvironmentNodeTypeSelector ));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("InstanceInformation", builder =>
                {
                    builder.OpenComponent(0, typeof(InstanceInformationPanelContent));
                    builder.CloseComponent();
                }),

            new PanelContent_Class("SubmitInstance", builder =>
                {
                    builder.OpenComponent(0, typeof(SubmitInstancePanelContent));
                    builder.CloseComponent();
                })
            };

        }
        public void UpdateEnvironmentDimension_X(string newDimension_X) {
            Console.WriteLine($"Updating Environment Dimension X with value: {newDimension_X}");
            CurrentEnvironemntDimension_X = Int32.Parse(newDimension_X);
            stateContainer.EnvironmentDimension_X = newDimension_X;
        }

        public void UpdateEnvironmentDimension_Y(string newDimension_Y)
        {
            Console.WriteLine($"Updating Environment Dimension Y with value: {newDimension_Y}");
            CurrentEnvironemntDimension_Y = Int32.Parse(newDimension_Y);
            stateContainer.EnvironmentDimension_Y = newDimension_Y;
        }

        public void UpdateEnvironmentNodeTypeSelector(NodeStates newValue) {
            stateContainer.NodeSelectionValue = newValue;
            Log.Information($"ApplicationPage - Updating Selection Value ;  {newValue}");   
        }



        public int CurrentEnvironemntDimension_X { get; set; } = 5;
        public int CurrentEnvironemntDimension_Y { get; set; } = 5;
        public int NodeTypeSelectionValue { get; set; } 


    }
}
