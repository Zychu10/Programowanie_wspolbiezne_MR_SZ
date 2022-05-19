using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Data
{
    public abstract class DataAPI
    {
        public abstract int CountBalls { get; }
        public abstract IList CreateBallsList(int count);
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract IBall GetBall(int index);
        public static DataAPI CreateApi(int width, int height)
        {
            return new DataAPIBase(width,height);
        }
    }

    internal class DataAPIBase : DataAPI
    {
        private ObservableCollection<IBall> _balls { get;}
        private readonly Mutex _mutex = new Mutex();
        private readonly Random _random = new Random();
        public override int Width { get; }
        public override int Height { get; }

        public DataAPIBase(int width, int height)
        {
            _balls = new ObservableCollection<IBall>();
            Width = width;
            Height = height;
        }
        public ObservableCollection<IBall> Balls { get { return _balls; } }
        public override IList CreateBallsList(int count)
        {
           if(count > 0)
            {
                int ballsCounter = _balls.Count;
                for(int i = 0; i < count; i++)
                {
                    _mutex.WaitOne();
                    int radius = 20;
                    double weight = 30;
                    double x = _random.Next(radius, Width - radius);
                    double y = _random.Next(radius, Height - radius);
                    double newX = _random.Next(-10, 10);
                    double newY = _random.Next(-10, 10);
                    Ball ball = new Ball(i + 1 + ballsCounter, radius, x, y, newX, newY, weight);
                    _balls.Add(ball);
                    _mutex.ReleaseMutex();
                }
            }
           if (count < 0)
            {
                for(int i = 0; i < 0; i++)
                {
                    if(_balls.Count > 0)
                    {
                        _mutex.WaitOne();
                        _balls.Remove(_balls[_balls.Count - 1]);
                        _mutex.ReleaseMutex();
                    };
                }
            }
           return _balls;
        }
        public override int CountBalls { get { return _balls.Count; } }
        public override IBall GetBall(int index)
        {
            return _balls[index];
        }
    }
}
