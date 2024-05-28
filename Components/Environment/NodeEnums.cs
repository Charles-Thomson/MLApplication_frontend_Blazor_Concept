namespace MLApplication_frontend.Components.Environment
{
    public static class NodeEnums
    {

        public enum NodeStates
        {
            Empty = 0,
            Goal = 1,
            Obstical = 2,
            Start = 3
        }

        public static class NodeBackgroundColors {
            public const string Empty = "whitesmoke";
            public const string Goal = "rgba(0, 255, 0, 1)";
            public const string Obstical = "rgba(255, 10, 0, 1)";
            public const string Start = "rgba(0, 201, 0, 0.8)";
        }

    }
}
