using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public abstract event EventHandler Update;
        public abstract int Width { get; }
        public abstract int Height { get; }
        internal abstract List<Ball> Balls { get; }
        public abstract void CreateBallsList(int counter);
        public abstract void UpdateBalls();
        public abstract void Start();
        public abstract void Stop();
        public abstract void SetInterval(int ms);
        public abstract int GetX(int i);
        public abstract int GetY(int i);
        public abstract int GetSize(int i);
        public abstract int GetCounter { get; }

        public static LogicAbstractAPI CreateApi(int width, int height, TimerApi timer = default(TimerApi))
        {
            return new LogicAPI(width, height, timer ?? TimerApi.CreateBallTimer());
        }

    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly TimerApi timer;
        public override int Width { get; }
        public override int Height { get; }
        internal override List<Ball> Balls { get; }
        private DataAPI dataLayer;
        public LogicAPI(int width, int height, TimerApi AppTimer)
        {
            dataLayer = DataAPI.CreateApi();
            Width = width;
            Height = height;
            timer = AppTimer;
            Balls = new List<Ball>();
            SetInterval(30);
            timer.Tick += (sender, args) => UpdateBalls();

        }
        public override void CreateBallsList(int counter)
        {
            Random random = new Random();
            if (counter > 0)
            {
                for(int i = 0; i <counter ; i++)
                {
                    int radius = 20;
                    int x = random.Next(radius, Width - radius);
                    int y = random.Next(radius, Height - radius);
                    int newX = random.Next(radius);
                    int newY = random.Next(radius);
                    Ball ball = new Ball(radius,x, y, newX, newY);
                    Balls.Add(ball);
                }
            }
            if(counter < 0)
            {
                for(int i = counter; i < 0; i++)
                {
                    if(Balls.Count > 0)
                    {
                        Balls.Remove(Balls[Balls.Count - 1]);
                    }
                }
            }
        }
        public override event EventHandler Update { add => timer.Tick += value; remove => timer.Tick -= value; }
        public override int GetX(int i)
        {
            return Balls[i].X;
        }
        public override int GetY(int i)
        {
            return Balls[i].Y;
        }
        public override int GetCounter { get => Balls.Count; }
        public override int GetSize(int i)
        {
            return Balls[i].Size;
        }
        public override void UpdateBalls()
        {
            foreach(Ball ball in Balls)
            {
                ball.positioning(600, 480);
            }
        }
        public override void Start()
        {
            timer.Start();
        }
        public override void Stop()
        {
            timer.Stop();
        }
        public override void SetInterval(int ms)
        {
            timer.Interval = TimeSpan.FromMilliseconds(ms);
        }

    }
}
