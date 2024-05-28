using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;using MLApplication_frontend.GraphPlotting;



namespace MLApplication_frontend.Pages.GenerationalLearningPages
{
    public partial class ResultsPage
    {
        

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public GraphPlottingFunctionCalls? GraphPlotter { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                GraphPlotter = new(jsRuntime: JSRuntime);
                await GraphPlotter.PlotEnvironmentGraph();
            }
        }

        public async void JSTestCall()
        {
            Console.Write($"Button Pressed");


            await JSRuntime.InvokeVoidAsync("TestPrint");

        }


    }


}
