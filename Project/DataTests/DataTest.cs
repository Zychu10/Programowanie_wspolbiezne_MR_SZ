using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestData
{
    [TestClass]
    public class DataCreationTest
    {
        private DataAbstractApi DApi;


        [TestMethod]
        public void testCreateApi()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            Assert.IsNotNull(DApi);
        }

        [TestMethod]
        public void getCount()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            Assert.AreEqual(800, DApi.Width);
            Assert.AreEqual(600, DApi.Height);
            DApi.CreateBallsList(5);
            Assert.AreEqual(5, DApi.GetCount);
            DApi.CreateBallsList(-3);
            Assert.AreEqual(2, DApi.GetCount);
            DApi.CreateBallsList(-3);
            Assert.AreEqual(0, DApi.GetCount);
        }

        [TestMethod]
        public void getBall()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            DApi.CreateBallsList(3);
            Assert.AreNotEqual(DApi.GetBall(0), DApi.GetBall(1));
            Assert.AreNotEqual(DApi.GetBall(1), DApi.GetBall(2));
            Assert.AreNotEqual(DApi.GetBall(0), DApi.GetBall(2));
        }

        [TestMethod]
        public void createIBallTest()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            DApi.CreateBallsList(1);
            Assert.AreEqual(1, DApi.GetBall(0).ID);

            Assert.IsTrue(DApi.GetBall(0).X >= DApi.GetBall(0).Size);
            Assert.IsTrue(DApi.GetBall(0).X <= (DApi.Width - DApi.GetBall(0).Size));
            Assert.IsTrue(DApi.GetBall(0).Y <= (DApi.Height - DApi.GetBall(0).Size));
            Assert.IsTrue(DApi.GetBall(0).Size >= 20 && DApi.GetBall(0).Size <= 40);
            Assert.IsTrue(DApi.GetBall(0).Weight >= 30 && DApi.GetBall(0).Weight <= 60);
            Assert.IsTrue(DApi.GetBall(0).VelocityX >= -10 && DApi.GetBall(0).VelocityX <= 10);
            Assert.IsTrue(DApi.GetBall(0).VelocityY >= -10 && DApi.GetBall(0).VelocityY <= 10);
        }

        [TestMethod]
        public void moveTest()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            DApi.CreateBallsList(1);
            double x = DApi.GetBall(0).X;
            double y = DApi.GetBall(0).Y;
            DApi.GetBall(0).VelocityX = 5;
            DApi.GetBall(0).VelocityY = 5;
            DApi.GetBall(0).Move();
            Assert.AreNotEqual(x, DApi.GetBall(0).X);
            Assert.AreNotEqual(y, DApi.GetBall(0).Y);
        }

        [TestMethod]
        public void setTests()
        {
            DApi = DataAbstractApi.CreateApi(800, 600);
            DApi.CreateBallsList(1);
            DApi.GetBall(0).X = 10;
            DApi.GetBall(0).Y = 17;
            DApi.GetBall(0).VelocityX = 4;
            DApi.GetBall(0).VelocityY = -3;
            Assert.AreEqual(10, DApi.GetBall(0).X);
            Assert.AreEqual(17, DApi.GetBall(0).Y);
            Assert.AreEqual(4, DApi.GetBall(0).VelocityX);
            Assert.AreEqual(-3, DApi.GetBall(0).VelocityY);
        }

    }
}