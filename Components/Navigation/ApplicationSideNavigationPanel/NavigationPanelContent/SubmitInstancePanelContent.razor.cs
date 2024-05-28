using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using MLApplication_frontend.API;


namespace MLApplication_frontend.Components.Navigation.ApplicationSideNavigationPanel.NavigationPanelContent
{
    public partial class SubmitInstancePanelContent
    {
        static HttpClient newClient = new() { BaseAddress = new Uri("http://127.0.0.1:8000") };
        public APIHandlerOLD apiHandler = new APIHandlerOLD(newClient: newClient);

        public string? FormattedStateData { get; set; } = "No data";

        public void FormatStateData() {
            stateContainer.ToJsonString();
            string query = stateContainer.ConvertToAPIQUery();
            Log.Information("Formatting Taken Place");
            Submit(query);
        }

        public async void Submit(string query) {
            Log.Information("Passing Data to Back end"); 
            await apiHandler.PostNewWorkItem(query);
            Log.Information("Passed Data to back end");

        }
       
    }
}
