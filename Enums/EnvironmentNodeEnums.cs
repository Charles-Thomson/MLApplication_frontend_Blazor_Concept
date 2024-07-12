namespace MLApplication_frontend.Enums
{
    public static class EnvironmentNodeEnums
    {
        public enum NodeStateEnums
        {
            Empty = 0,
            Goal = 1,
            Obstical = 2,
            Start = 3
        }

        public static class NodeBackgroundColorsEnums
        {
            public const string Empty = "whitesmoke";
            public const string Goal = "rgba(0, 255, 0, 1)";
            public const string Obstical = "rgba(255, 10, 0, 1)";
            public const string Start = "rgba(0, 201, 0, 0.8)";
        }

    }
}
