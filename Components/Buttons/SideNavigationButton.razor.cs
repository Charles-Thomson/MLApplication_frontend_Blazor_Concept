using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLApplication_frontend.Components.Buttons
{
    public partial class SideNavigationButton
    {
        [CascadingParameter(Name = "ButtonData")] public ButtonDataClass? ButtonData { get; set; }
        [Parameter] public EventCallback<string> UpdatedSelectedButtons { get; set; }
        public void UpdateButtonData()
        {
            if (ButtonData != null)
            {
                UpdatedSelectedButtons.InvokeAsync(ButtonData.ButtonID);

            }

        }
       
    }
}
