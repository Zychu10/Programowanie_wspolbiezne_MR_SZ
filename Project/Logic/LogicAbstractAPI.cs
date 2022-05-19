using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {

        public abstract int CountBalls { get; }
        public abstract IList CreateBalls(int count);
        public abstract void Start();
        public abstract void Stop();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract IBall GetBall(int index);
        public abstract void BoundariesCollision(IBall ball);
        public abstract void BouncingBalls(IBall ball);
        public abstract void ChangePosition(object sender, PropertyChangedEventArgs args);



        public static LogicAbstractAPI CreateApi(int width, int height)
        {
            return new LogicAPI(width, height);
        }

    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private readonly DataAPI _dataAPI;
        private readonly Mutex _mutex = new Mutex();

        public LogicAPI(int width, int height)
        {
            _dataAPI = DataAPI.CreateApi(width, height);
            Width = width;
            Height = height;
        }
        public override int Width { get; set; }
        public override int Height { get; set; }

        public override void Start()
        {
            for(int i = 0; i <_dataAPI.CountBalls; i++)
            {
                _dataAPI.GetBall(i).CreateTask(30);
            }
        }
        public override void Stop()
        {
            for(int i = 0; i < _dataAPI.CountBalls; i++)
            {
                _dataAPI.GetBall(i).Stop();
            }
        }
        public override void BoundariesCollision(IBall ball)
        {
            double diameter = ball.size;
            double right = Width - diameter;
            double down = Height - diameter;
            if(ball.x <= 0)
            {
                ball.x = -ball.x;
                ball.newX = -ball.newX;
            }
            else if(ball.x >= right)
            {
                ball.x = right - (ball.x - right);
                ball.newX = -ball.newX;
            }
            if(ball.y <= 0)
            {
                ball.y = -ball.y;
                ball.newY = -ball.newY;
            }
            else if(ball.y >= down)
            {
                ball.y = down - (ball.y - down);
                ball.newY = -ball.newY;
            }
        }
        public override void BouncingBalls(IBall ball)
        {
            for(int i = 0; i < _dataAPI.CountBalls; i++)
            {
                IBall ball2 = _dataAPI.GetBall(i);
                if(ball.id == ball2.id)
                {
                    continue;
                }
                if (Collision(ball, ball2))
                {
                    double mass1 = ball.weight;
                    double mass2 = ball2.weight;
                    double velocity1x = ball.newX;
                    double velocity1y = ball.newY;
                    double velocity2x = ball2.newX;
                    double velocity2y = ball2.newY;

                    double ball_v_x = (mass1 - mass2) * velocity1x / (mass1 + mass2) + (2 * mass2) * velocity2x / (mass1 + mass2);
                    double ball_v_y = (mass1 - mass2) * velocity1y / (mass1 - mass2) + (2 * mass2) * velocity2y / (mass1 + mass2);
                    double ball2_v_x = 2 * mass1 * velocity1x / (mass1 + mass2) + (mass2 - mass1) * velocity2x / (mass1 + mass2);
                    double ball2_v_y = 2 * mass1 * velocity1y / (mass1 + mass2) + (mass2 - mass1) * velocity2y/ (mass1 + mass2);

                    ball.newX = velocity1x;
                    ball.newY = velocity1y;
                    ball2.newX = velocity2x;
                    ball2.newY = velocity2y;
                    return;

                }
            }
        }
        internal bool Collision(IBall ball, IBall ball2)
        {
            if (ball == null || ball2 == null)
            {
                return false;
            }

            return Distance(ball, ball2) <= (ball.size / 2 + ball2.size / 2);
        }

        internal double Distance(IBall ball, IBall ball2)
        {
            double x1 = ball.x + ball.size / 2 + ball.newX;
            double y1 = ball.y + ball.size / 2 + ball.newY;
            double x2 = ball2.x + ball2.size / 2 + ball2.newY;
            double y2 = ball2.y + ball2.size / 2 + ball2.newY;

            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = _dataAPI.CountBalls;
            IList temp = _dataAPI.CreateBallsList(count);
            for (int i = 0; i < _dataAPI.CountBalls - previousCount; i++)
            {
                _dataAPI.GetBall(previousCount + i).PropertyChanged += ChangePosition;
            }
            return temp;
        }
        public override IBall GetBall(int index)
        {
            return _dataAPI.GetBall(index);
        }


        public override int CountBalls { get => _dataAPI.CountBalls; }

        public override void ChangePosition(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            _mutex.WaitOne();
            BoundariesCollision(ball);
            BouncingBalls(ball);
            _mutex.ReleaseMutex();
        }
    }
}
