using Microsoft.AspNetCore.Components;

namespace MLApplication_frontend.Components.Buttons
{
    public partial class SplashScreenButton
    {
        [Parameter] public bool StartAnimationsFlag { get; set; }
        [Parameter] public EventCallback OnButtonPressed { get; set; }

        public void HandleOnButtonPressed()
        {
            OnButtonPressed.InvokeAsync();
        }


    }
}

