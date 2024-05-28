using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Titles
{
    public partial class HomePageTitle
    {
        [Parameter] public string? TitleText { get; set; }
        
    }
}
