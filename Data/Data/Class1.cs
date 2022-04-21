namespace Data
{
    public class Ball
    {
        public int Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Ball(int r, int x, int y)
        {
            Radius = r;
            X = x;
            Y = y;
        }
    }
}