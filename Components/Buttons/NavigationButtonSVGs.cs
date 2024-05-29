using Microsoft.AspNetCore.Components;

namespace MLApplication_frontend.Components.Buttons
{
    public class NavigationButtonSVGs
    {
        public string HyperParameterSettingsSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-gear\" viewBox=\"0 0 20 20\">\r\n       <path d=\"M7.068.727c.243-.97 1.62-.97 1.864 0l.071.286a.96.96 0 0 0 1.622.434l.205-.211c.695-.719 1.888-.03 1.613.931l-.08.284a.96.96 0 0 0 1.187 1.187l.283-.081c.96-.275 1.65.918.931 1.613l-.211.205a.96.96 0 0 0 .434 1.622l.286.071c.97.243.97 1.62 0 1.864l-.286.071a.96.96 0 0 0-.434 1.622l.211.205c.719.695.03 1.888-.931 1.613l-.284-.08a.96.96 0 0 0-1.187 1.187l.081.283c.275.96-.918 1.65-1.613.931l-.205-.211a.96.96 0 0 0-1.622.434l-.071.286c-.243.97-1.62.97-1.864 0l-.071-.286a.96.96 0 0 0-1.622-.434l-.205.211c-.695.719-1.888.03-1.613-.931l.08-.284a.96.96 0 0 0-1.186-1.187l-.284.081c-.96.275-1.65-.918-.931-1.613l.211-.205a.96.96 0 0 0-.434-1.622l-.286-.071c-.97-.243-.97-1.62 0-1.864l.286-.071a.96.96 0 0 0 .434-1.622l-.211-.205c-.719-.695-.03-1.888.931-1.613l.284.08a.96.96 0 0 0 1.187-1.186l-.081-.284c-.275-.96.918-1.65 1.613-.931l.205.211a.96.96 0 0 0 1.622-.434zM12.973 8.5H8.25l-2.834 3.779A4.998 4.998 0 0 0 12.973 8.5m0-1a4.998 4.998 0 0 0-7.557-3.779l2.834 3.78zM5.048 3.967l-.087.065zm-.431.355A4.98 4.98 0 0 0 3.002 8c0 1.455.622 2.765 1.615 3.678L7.375 8zm.344 7.646.087.065z\"/>";

        public string NeuralNetworkSVG_String = "<svg  width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-share-fill\" viewBox=\"0 0 20 20\">\r\n  <path d=\"M11 2.5a2.5 2.5 0 1 1 .603 1.628l-6.718 3.12a2.5 2.5 0 0 1 0 1.504l6.718 3.12a2.5 2.5 0 1 1-.488.876l-6.718-3.12a2.5 2.5 0 1 1 0-3.256l6.718-3.12A2.5 2.5 0 0 1 11 2.5\"/>\r\n</svg>";

        public string? EnvironmentSettingsSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-bounding-box\" viewBox=\"0 0 20 20\">\r\n        <path fill-rule=\"evenodd\" d=\"M3.1 11.2a.5.5 0 0 1 .4-.2H6a.5.5 0 0 1 0 1H3.75L1.5 15h13l-2.25-3H10a.5.5 0 0 1 0-1h2.5a.5.5 0 0 1 .4.2l3 4a.5.5 0 0 1-.4.8H.5a.5.5 0 0 1-.4-.8z\"/>\r\n  <path fill-rule=\"evenodd\" d=\"M4 4a4 4 0 1 1 4.5 3.969V13.5a.5.5 0 0 1-1 0V7.97A4 4 0 0 1 4 3.999z\"/>";

        public string InstanceInformationSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-clipboard-data\" viewBox=\"0 0 20 20\">\r\n        <path d=\"M4 11a1 1 0 1 1 2 0v1a1 1 0 1 1-2 0zm6-4a1 1 0 1 1 2 0v5a1 1 0 1 1-2 0zM7 9a1 1 0 0 1 2 0v3a1 1 0 1 1-2 0z\" />\r\n        <path d=\"M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1h1a1 1 0 0 1 1 1V14a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V3.5a1 1 0 0 1 1-1h1z\" />\r\n        <path d=\"M9.5 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5zm-3-1A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0z\" />\r\n    </svg>";

        public string SubmitInstanceSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-play-fill\" viewBox=\"0 0 20 20\">\r\n        <path d=\"m11.596 8.697-6.363 3.692c-.54.313-1.233-.066-1.233-.697V4.308c0-.63.692-1.01 1.233-.696l6.363 3.692a.802.802 0 0 1 0 1.393\" />\r\n    </svg>";

        public string AlphasSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-person-circle\" viewBox=\"0 0 20 20\">\r\n   <path d=\"M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0\"/>\r\n  <path fill-rule=\"evenodd\" d=\"M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1\"/>\r\n</svg>";

        public string GenerationSVG_String = "<svg  width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-diagram-3\" viewBox=\"0 0 20 20\">\r\n   <path fill-rule=\"evenodd\" d=\"M6 3.5A1.5 1.5 0 0 1 7.5 2h1A1.5 1.5 0 0 1 10 3.5v1A1.5 1.5 0 0 1 8.5 6v1H14a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0V8h-5v.5a.5.5 0 0 1-1 0v-1A.5.5 0 0 1 2 7h5.5V6A1.5 1.5 0 0 1 6 4.5zM8.5 5a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5zM0 11.5A1.5 1.5 0 0 1 1.5 10h1A1.5 1.5 0 0 1 4 11.5v1A1.5 1.5 0 0 1 2.5 14h-1A1.5 1.5 0 0 1 0 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5A1.5 1.5 0 0 1 7.5 10h1a1.5 1.5 0 0 1 1.5 1.5v1A1.5 1.5 0 0 1 8.5 14h-1A1.5 1.5 0 0 1 6 12.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5zm4.5.5a1.5 1.5 0 0 1 1.5-1.5h1a1.5 1.5 0 0 1 1.5 1.5v1a1.5 1.5 0 0 1-1.5 1.5h-1a1.5 1.5 0 0 1-1.5-1.5zm1.5-.5a.5.5 0 0 0-.5.5v1a.5.5 0 0 0 .5.5h1a.5.5 0 0 0 .5-.5v-1a.5.5 0 0 0-.5-.5z\"/>\r\n</svg>";

        public string AllAgentsSVG_String = "<svg width=\"30\" height=\"30\" fill=\"@ButtonData?.ButtonColor\" class=\"bi bi-people-fill\" viewBox=\"0 0 20 20\">\r\n   <path d=\"M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6m-5.784 6A2.24 2.24 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.3 6.3 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1zM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5\"/>\r\n</svg>";

        public RenderFragment HyperParameterSettingsSVG { get; set; }
        public RenderFragment NeuralNetworkSVG { get; set; }
        public RenderFragment EnvironmentSettingsSVG { get; set; }
        public RenderFragment InstanceInformationSVG { get; set; }
        public RenderFragment SubmitInstanceSVG { get; set; }
        public RenderFragment GenerationSVG { get; set; }
        public RenderFragment AllAgentsSVG { get; set; }
        public RenderFragment AlphasSVG { get; set; }



        public NavigationButtonSVGs() {
            HyperParameterSettingsSVG = builder =>
            {
                builder.AddMarkupContent(0, HyperParameterSettingsSVG_String);
            };

            NeuralNetworkSVG = builder =>
            {
                builder.AddMarkupContent(1, NeuralNetworkSVG_String);
            };

            EnvironmentSettingsSVG = builder =>
            {
                builder.AddMarkupContent(1, EnvironmentSettingsSVG_String);
            };
            InstanceInformationSVG = builder =>
            {
                builder.AddMarkupContent(2, InstanceInformationSVG_String);
            };
            SubmitInstanceSVG = builder =>
            {
                builder.AddMarkupContent(3, SubmitInstanceSVG_String);
            };
            GenerationSVG = builder =>
            {
                builder.AddMarkupContent(4, GenerationSVG_String);
            };

            AllAgentsSVG = builder =>
            {
                builder.AddMarkupContent(5, AllAgentsSVG_String);
            };

            AlphasSVG = builder =>
            {
                builder.AddMarkupContent(6, AlphasSVG_String);
            };


        }





    }
}
