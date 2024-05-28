using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Pages.GenerationalLearningPages
{
    public partial class ApplicationPage
    {

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

        public int CurrentEnvironemntDimension_X { get; set; } = 5;
        public int CurrentEnvironemntDimension_Y { get; set; } = 5;
    }
}
