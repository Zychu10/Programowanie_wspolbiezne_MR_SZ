using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestLogic
{
    [TestClass]
    public class CreationTest
    {

        private LogicAbstractApi LApi;


        [TestMethod]
        public void testCreateApi()
        {
            LApi = LogicAbstractApi.CreateApi(800, 600);
            Assert.IsNotNull(LApi);
        }

        [TestMethod]
        public void getCount()
        {
            LApi = LogicAbstractApi.CreateApi(800, 600);
            Assert.AreEqual(800, LApi.Width);
            Assert.AreEqual(600, LApi.Height);
            LApi.CreateBalls(5);
            Assert.AreEqual(5, LApi.GetCount);
            LApi.CreateBalls(-3);
            Assert.AreEqual(2, LApi.GetCount);
            LApi.CreateBalls(-3);
            Assert.AreEqual(0, LApi.GetCount);
        }

        [TestMethod]
        public void testWallCollision()
        {
            LApi = LogicAbstractApi.CreateApi(800, 600);
            LApi.CreateBalls(1);
            LApi.GetBall(0).VelocityX = 5;
            LApi.GetBall(0).X = 790;
            Assert.AreNotEqual(5, LApi.GetBall(0).VelocityX);
            LApi.GetBall(0).VelocityX = -3;
            LApi.GetBall(0).X = -3;
            Assert.AreNotEqual(-3, LApi.GetBall(0).VelocityX);
            LApi.GetBall(0).VelocityY = -7;
            LApi.GetBall(0).Y = -2;
            Assert.AreNotEqual(-7, LApi.GetBall(0).VelocityY);
            LApi.GetBall(0).VelocityY = 7;
            LApi.GetBall(0).Y = 607;
            Assert.AreNotEqual(7, LApi.GetBall(0).VelocityY);

        }



    }
}