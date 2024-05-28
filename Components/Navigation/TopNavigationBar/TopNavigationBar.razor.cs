using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Navigation.TopNavigationBar
{
    public partial class TopNavigationBar
    {

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        public void NavigateTo(string path) {

            NavigationManager.NavigateTo(path);
        }

        

    }
}
