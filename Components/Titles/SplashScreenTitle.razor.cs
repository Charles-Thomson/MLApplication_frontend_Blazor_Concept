using Microsoft.AspNetCore.Components;

namespace MLApplication_frontend.Components.Titles
{
    public partial class SplashScreenTitle
    {
        [Parameter] public string? TitleText { get; set; }
        [Parameter] public bool StartAnimationsFlag { get; set; }
    }
}
