using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using MLApplication_frontend.Components.SideContentPanel.PanelContent;
using MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MLApplication_frontend.Enums.EnvironmentNodeEnums;


namespace MLApplication_frontend.Pages.GenerationalLearningPages
{
    public partial class ApplicationPage
    {
        public List<PanelContent_Class>? PanelContent { get; set; }

        public string ButtonGroupType { get; set; } = "ApplicationButtonGroup";

        public ApplicationPage()
        {
            InitalizePanelConent();
        }

        /// <summary>
        /// Init panel content
        /// - Builds each panel as a PanelContent_Class
        /// - Stores in List -> PanelContent
        /// </summary>
        private void InitalizePanelConent() 
        {
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
                    builder.AddAttribute(3, "UpdateEnvironmentNodeTypeSelector", EventCallback.Factory.Create<NodeStateEnums>(this,UpdateEnvironmentNodeTypeSelector ));
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

        public int CurrentEnvironmentDimension_X { get; set; } = 5;
        public int CurrentEnvironmentDimension_Y { get; set; } = 5;
        public int NodeTypeSelectionValue { get; set; }


        /// <summary>
        /// Update Environment dimension X
        /// </summary>
        /// <param name="newDimension_X"></param>
        public void UpdateEnvironmentDimension_X(string newDimension_X) 
        {
            if (int.TryParse(newDimension_X, out var dimension_X)) 
            {
                CurrentEnvironmentDimension_X = dimension_X;
                stateContainer.EnvironmentDimension_X = newDimension_X;
                Console.WriteLine($"Updating Environment Dimension X with value: {newDimension_X}");
            }
        }

        /// <summary>
        /// Update Environment dimension Y
        /// </summary>
        /// <param name="newDimension_Y"></param>
        public void UpdateEnvironmentDimension_Y(string newDimension_Y)
        {
           if (int.TryParse(newDimension_Y, out var dimension_Y)) 
            {
                CurrentEnvironmentDimension_Y = dimension_Y;
                stateContainer.EnvironmentDimension_Y = newDimension_Y;
                Console.WriteLine($"Updating Environment Dimension Y with value: {newDimension_Y}");
            }
        }


        /// <summary>
        /// Update Selected node type 
        /// </summary>
        /// <param name="newNodeType"></param>
        public void UpdateEnvironmentNodeTypeSelector(NodeStateEnums newNodeType) 
        {
            stateContainer.NodeSelectionValue = newNodeType;
            Log.Information($"ApplicationPage - Updating Selection Value ;  {newNodeType}");   
        }
    }
}
