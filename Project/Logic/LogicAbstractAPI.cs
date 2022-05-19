using Data;
using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;


namespace Logic
{
    public abstract class LogicAbstractApi
    {

        public abstract int GetCount { get; }
        public abstract IList CreateBalls(int count);
        public abstract void Start();
        public abstract void Stop();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract IBall GetBall(int index);
        public abstract void WallCollision(IBall ball);
        public abstract void BallBounce(IBall ball);
        public abstract void BallPositionChanged(object sender, PropertyChangedEventArgs args);



        public static LogicAbstractApi CreateApi(int width, int height)
        {
            return new LogicApi(width, height);
        }

    }
    internal class LogicApi : LogicAbstractApi
    {
        private readonly DataAbstractApi dataLayer;
        private readonly Mutex mutex = new Mutex();


        public LogicApi(int width, int height)
        {
            dataLayer = DataAbstractApi.CreateApi(width, height);
            Width = width;
            Height = height;

        }

        public override int Width { get; set; }
        public override int Height { get; set; }

        public override void Start()
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                dataLayer.GetBall(i).MovementTask(30);

            }
        }

        public override void Stop()
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                dataLayer.GetBall(i).Stop();

            }
        }


        public override void WallCollision(IBall ball)
        {

            double diameter = ball.Size;

            double right = Width - diameter;

            double down = Height - diameter;


            if (ball.X <= 0)
            {
                ball.X = -ball.X;
                ball.VelocityX = -ball.VelocityX;
            }

            else if (ball.X >= right)
            {
                ball.X = right - (ball.X - right);
                ball.VelocityX = -ball.VelocityX;
            }
            if (ball.Y <= 0)
            {
                ball.Y = -ball.Y;
                ball.VelocityY = -ball.VelocityY;
            }

            else if (ball.Y >= down)
            {
                ball.Y = down - (ball.Y - down);
                ball.VelocityY = -ball.VelocityY;
            }
        }

        public override void BallBounce(IBall ball)
        {
            for (int i = 0; i < dataLayer.GetCount; i++)
            {
                IBall ball2 = dataLayer.GetBall(i);
                if (ball.ID == ball2.ID)
                {
                    continue;
                }

                if (Collision(ball, ball2))
                {

                    double mass1 = ball.Weight;
                    double mass2 = ball2.Weight;
                    double velocity1x = ball.VelocityX;
                    double velocity1y = ball.VelocityY;
                    double velocity2x = ball2.VelocityX;
                    double velocity2y = ball2.VelocityY;



                    double ball1x = (mass1 - mass2) * velocity1x / (mass1 + mass2) + (2 * mass2) * velocity2x / (mass1 + mass2);
                    double ball1y = (mass1 - mass2) * velocity1y / (mass1 + mass2) + (2 * mass2) * velocity2y / (mass1 + mass2);

                    double ball2x = 2 * mass1 * velocity1x / (mass1 + mass2) + (mass2 - mass1) * velocity2x / (mass1 + mass2);
                    double ball2y = 2 * mass1 * velocity1y / (mass1 + mass2) + (mass2 - mass1) * velocity2y / (mass1 + mass2);

                    ball.VelocityX = ball1x;
                    ball.VelocityY = ball1y;
                    ball2.VelocityX = ball2x;
                    ball2.VelocityY = ball2y;
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

            return Distance(ball, ball2) <= (ball.Size / 2 + ball2.Size / 2);
        }

        internal double Distance(IBall ball, IBall ball2)
        {
            double x1 = ball.X + ball.Size / 2 + ball.VelocityX;
            double y1 = ball.Y + ball.Size / 2 + ball.VelocityY;
            double x2 = ball2.X + ball2.Size / 2 + ball2.VelocityY;
            double y2 = ball2.Y + ball2.Size / 2 + ball2.VelocityY;

            return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        }


        public override IList CreateBalls(int count)
        {
            int previousCount = dataLayer.GetCount;
            IList temp = dataLayer.CreateBallsList(count);
            for (int i = 0; i < dataLayer.GetCount - previousCount; i++)
            {
                dataLayer.GetBall(previousCount + i).PropertyChanged += BallPositionChanged;
            }
            return temp;
        }
        public override IBall GetBall(int index)
        {
            return dataLayer.GetBall(index);
        }


        public override int GetCount { get => dataLayer.GetCount; }

        public override void BallPositionChanged(object sender, PropertyChangedEventArgs args)
        {
            IBall ball = (IBall)sender;
            mutex.WaitOne();
            WallCollision(ball);
            BallBounce(ball);
            mutex.ReleaseMutex();
        }


    }
}
