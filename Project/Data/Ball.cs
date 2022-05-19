using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Data

{
    public interface IBall : INotifyPropertyChanged
    {
        int ID { get; }
        int Size { get; }
        double Weight { get; }
        double X { get; set; }
        double Y { get; set; }
        double VelocityX { get; set; }
        double VelocityY { get; set; }

        void Move();
        void MovementTask(int interval);

        void Stop();




    }

    internal class Ball : IBall
    {
        private readonly int _size;
        private readonly int _id;
        private double _x;
        private double _y;
        private double _velocityX;
        private double _velocityY;
        private readonly double _weight;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Task task;
        private bool stop = false;

        public Ball(int identyfikator, int size, double x, double y, double velocityX, double velocityY, double weight)
        {
            _id = identyfikator;
            _size = size;
            _x = x;
            _y = y;
            _velocityX = velocityX;
            _velocityY = velocityY;
            _weight = weight;
        }

        public int ID { get => _id; }
        public int Size { get => _size; }
        public double VelocityX
        {
            get => _velocityX;
            set
            {
                if (value.Equals(VelocityX))
                {
                    return;
                }

                _velocityX = value;

            }
        }
        public double VelocityY
        {
            get => _velocityY;
            set
            {
                if (value.Equals(_velocityY))
                {
                    return;
                }

                _velocityY = value;

            }
        }
        public double X
        {
            get => _x;
            set
            {
                if (value.Equals(_x))
                {
                    return;
                }

                _x = value;
                RaisePropertyChanged();
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                if (value.Equals(_y))
                {
                    return;
                }

                _y = value;
                RaisePropertyChanged();
            }
        }

        public void Move()
        {
            X += VelocityX;
            Y += VelocityY;
        }


        public double Weight { get => _weight; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void MovementTask(int interval)
        {
            stop = false;
            task = Run(interval);
        }

        private async Task Run(int interval)
        {
            while (!stop)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if (!stop)
                {
                    Move();

                }
                stopwatch.Stop();

                await Task.Delay((int)(interval - stopwatch.ElapsedMilliseconds));
            }
        }
        public void Stop()
        {
            stop = true;
        }

    }
}
