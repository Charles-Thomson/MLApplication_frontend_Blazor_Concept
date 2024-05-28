using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Layout
{
    public partial class GenerationalLearning_ApplicationLayout
    {
        [Parameter] public RenderFragment? Content_Header { get; set; } 
        [Parameter] public RenderFragment? Content_NavigtionBar { get; set; }
        [Parameter] public RenderFragment? Content_LeftPanel { get; set; }

        [Parameter] public RenderFragment? Content_RightPanel { get; set; }

        [Parameter] public RenderFragment? Content_Main { get; set; }
        [Parameter] public RenderFragment? Content_Footer { get; set; }

        

    }
}
