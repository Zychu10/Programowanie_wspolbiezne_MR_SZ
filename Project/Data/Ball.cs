using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Data
{
   public interface IBall : INotifyPropertyChanged
    {
        int Size { get; }
        double Weight { get; }
        double X { get; set; }
        double Y { get; set; }
        double NewX { get; set; }
        double NewY { get; set; }
        void Move();
        void CreateTask(int interval);
        void Stop();
    }
    
    internal class Ball : IBall
    {
        private readonly int _size;
        private double _x;
        private double _y;
        private double _newX;
        private double _newY;
        private readonly double _weight;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Task task;
        private bool _stop = false;

        public Ball(int size, double x, double y, double newX, double newY, double weight)
        {
            _size = size;
            _x = x;
            _y = y;
            _newX = newX;
            _newY = newY;
            _weight = weight;
        }

        public int Size { get { return _size; } }

    }
}
