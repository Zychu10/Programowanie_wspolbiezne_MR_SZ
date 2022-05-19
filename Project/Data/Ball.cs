using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Data
{
   public interface IBall : INotifyPropertyChanged
    {
        int id { get; }
        int size { get; }
        double weight { get; }
        double x { get; set; }
        double y { get; set; }
        double newX{ get; set; }
        double newY{ get; set; }
        void Move();
        void CreateTask(int interval);
        void Stop();
    }
    
    internal class Ball : IBall
    {
        private readonly int _id;
        private readonly int _size;
        private double _x;
        private double _y;
        private double _newX;
        private double _newY;
        private readonly double _weight;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Task task;
        private bool _stop = false;

        public Ball(int id, int size, double x, double y, double newX, double newY, double weight)
        {
            _id = id;
            _size = size;
            _x = x;
            _y = y;
            _newX = newX;
            _newY = newY;
            _weight = weight;
        }

        public int size { get { return _size; } }
        public int id { get { return _id; } }
        public double newX
        {
            get { return _newX; }
            set
            {
                if (!value.Equals(_newX))
                {
                    _newX = value;
                }
                return;
            }
            
        }
        public double newY
        {
            get { return _newY; }
            set
            {
                if (!value.Equals(_newY))
                {
                    _newY= value;
                }
                return;
            }
        }
        public double x
        {
            get { return _x; }
            set
            {
                if (!value.Equals(_x))
                {
                    _x = value;
                    RaisePropertyChanged();
                }
                return;
            }
        }
        public double y
        {
            get { return _y; }
            set
            {
                if (!value.Equals(_y))
                {
                    _y = value;
                    RaisePropertyChanged();
                }
            }
        }
        public void Move()
        {
            x += newX;
            y += newY;
        }
        public double weight { get { return _weight; } }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void CreateTask(int interval)
        {
            task = Go(interval);
            _stop = false;
        }
        private async Task Go(int interval)
        {
            while(_stop == false)
            {
                stopwatch.Reset();
                stopwatch.Start();
                if(_stop == false)
                {
                    Move();
                }
                stopwatch.Stop();
                await Task.Delay((int)(interval - stopwatch.ElapsedMilliseconds));
            }
        }
        public void Stop()
        {
            _stop = true;
        }
    }
}
