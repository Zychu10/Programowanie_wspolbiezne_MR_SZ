using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Data
{
    public abstract class DataAbstractApi
    {

        public abstract int GetCount { get; }
        public abstract IList CreateBallsList(int count);
        public abstract int Width { get; }
        public abstract int Height { get; }


        public abstract IBall GetBall(int index);

        public static DataAbstractApi CreateApi(int width, int height)
        {
            return new DataApi(width, height);
        }
    }

    internal class DataApi : DataAbstractApi
    {
        private ObservableCollection<IBall> balls { get; }
        private readonly Mutex _mutex = new Mutex();

        private readonly Random random = new Random();

        public override int Width { get; }
        public override int Height { get; }



        public DataApi(int width, int height)
        {
            balls = new ObservableCollection<IBall>();
            Width = width;
            Height = height;

        }

        public ObservableCollection<IBall> Balls => balls;

        public override IList CreateBallsList(int count)
        {

            if (count > 0)
            {
                int ballsCount = balls.Count;
                for (int i = 0; i < count; i++)
                {
                    _mutex.WaitOne();
                    int radius = 35;
                    double weight = 30;
                    double x = random.Next(1, Width - radius);
                    double y = random.Next(1, Height - radius);
                    double newX = random.Next(-10, 10) + random.NextDouble();
                    double newY = random.Next(-10, 10) + random.NextDouble();
                    Ball ball = new Ball(i + 1 + ballsCount, radius, x, y, newX, newY, weight);

                    balls.Add(ball);
                    _mutex.ReleaseMutex();

                }
            }
            if (count < 0)
            {
                for (int i = count; i < 0; i++)
                {

                    if (balls.Count > 0)
                    {
                        _mutex.WaitOne();
                        balls.Remove(balls[balls.Count - 1]);
                        _mutex.ReleaseMutex();
                    };

                }
            }
            return balls;
        }

        public override int GetCount { get => balls.Count; }



        public override IBall GetBall(int index)
        {
            return balls[index];
        }


    }
}
