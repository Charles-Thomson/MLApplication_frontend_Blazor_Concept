using Microsoft.AspNetCore.Components;

namespace MLApplication_frontend.Components.Buttons
{
    public class ButtonDataClass
    {

        public string? ButtonID { get; set; }
        public ButtonState State { get; set; }
        public string? ButtonColor { get; set; }
        public string? Opactity { get; set; }
        [Parameter] public RenderFragment? ButtonSVG { get; set; }

        public ButtonDataClass(string buttonID, RenderFragment buttonSVG)
        {
            ButtonID = buttonID;
            State = ButtonState.Unselected;
            ButtonColor = "black";
            Opactity = null;
            ButtonSVG = buttonSVG;
        }


        public void UpdateAttributes()
        {
            if (State == ButtonState.Selected)
            {
                ButtonColor = "grey";
                Opactity = "0.5";

            }
            else
            {
                ButtonColor = "black";
                Opactity = null;
            }
        }
    }

    public enum ButtonState
    {
        Unselected,
        Selected
    }
}
