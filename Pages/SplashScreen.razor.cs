using Microsoft.AspNetCore.Components;
using Serilog;


namespace MLApplication_frontend.Pages
{
    public partial class SplashScreen
    {

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        private bool _startAnimationsFlag = false;

        /// <summary>
        /// Indicates whether splash screen animations have started
        /// </summary>
        public bool StartAnimationsFlag
        {
            get => _startAnimationsFlag;
            private set => _startAnimationsFlag = value;
        }

        /// <summary>
        /// Provides a delay to allow animations to run before naviagting to HomePage
        /// </summary>
        private async Task OnSplashScreenButtonPresssed() 
        {
            StartAnimations();
            await Task.Delay(2000);
            NavigateToHomePage();
        }

        /// <summary>
        /// Navigate to application Home page
        /// </summary>
        private void NavigateToHomePage()
        {
            try {
                Log.Information("Navigating to /home_page");
                NavigationManager.NavigateTo("/home_page");
            }
            catch (Exception ex)
            {
                Log.Error("Failed to navigate to /home_page", ex);
            }
            
        }
        /// <summary>
        /// Start the splash screen animations
        /// </summary>
        private void StartAnimations() {
            StartAnimationsFlag = true;
            Log.Information("Starting Splash Screen Animations");
        }


    }
}
