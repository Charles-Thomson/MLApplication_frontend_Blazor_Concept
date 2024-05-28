using Microsoft.AspNetCore.Components;
using Serilog;


namespace MLApplication_frontend.Pages
{
    public partial class SplashScreen
    {
        public bool StartAnimationsFlag = false;

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        private async void OnSplashScreenButtonPresssed() {
            
            StartAnimations();
            await Task.Delay(2000);
            NavigateToHomePage();
        }

        private void NavigateToHomePage()
        {

            Log.Information("Navigating to Home page");

            NavigationManager.NavigateTo("/home_page");
            
        }

        private void StartAnimations() {
            StartAnimationsFlag = true;
            Log.Information("Starting Splash Screen Animations");
        }


    }
}
