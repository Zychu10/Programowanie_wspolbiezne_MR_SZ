namespace Logic
{
    public class Ball
    {
        private double _positionX;
        private double _positionY;
        private double _radius;
        private double _velocityX;
        private double _velocityY;




        public Ball(int r, int x, int y)
        {
            _radius = r;
            _positionX = x;
            _positionY = y;
        }
    }
}