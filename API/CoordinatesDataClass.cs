namespace MLApplication_frontend.API
{
    public class CoordinatesDataClass
    {
        public CoordinatesDataClass(int newX, int newY)
        {
            x = newX + 0.5;
            y = newY + 0.5;
        }
        public double x { get; set; }
        public double y { get; set; }
    }
}


