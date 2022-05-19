using Logic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    /*[TestClass]
    public class LogicTests
    {
        private LogicAbstractAPI LogicAPI;
        private Mock<TimerApi> timer;

        [TestMethod]
        public void getCount()
        {
            timer = new Mock<TimerApi>();
            LogicAPI = LogicAbstractAPI.CreateApi(900, 900, timer.Object);
            LogicAPI.CreateBallsList(8);
            Assert.AreEqual(8, LogicAPI.GetCounter);
            LogicAPI.CreateBallsList(-1);
            Assert.AreEqual(7, LogicAPI.GetCounter);
            LogicAPI.CreateBallsList(-9);
            Assert.AreEqual(0, LogicAPI.GetCounter);
        }

        [TestMethod]
        public void getRadiusInterval()
        {
            timer = new Mock<TimerApi>();
            LogicAPI = LogicAbstractAPI.CreateApi(300, 450, timer.Object);
            LogicAPI.CreateBallsList(1);
            int radius = LogicAPI.GetSize(0);
            Assert.IsTrue(radius >= 10);
            Assert.IsTrue(radius <= 70);
        }
        [TestMethod]
        public void getValidCoordinates()
        {
            timer = new Mock<TimerApi>();
            LogicAPI = LogicAbstractAPI.CreateApi(1000, 200, timer.Object);
            Assert.AreEqual(1000, LogicAPI.Width);
            Assert.AreEqual(200, LogicAPI.Height);
            LogicAPI.CreateBallsList(1);
            int radius = LogicAPI.GetSize(0);
            int x = LogicAPI.GetX(0);
            int y = LogicAPI.GetY(0);
            Assert.IsTrue(x >= radius);
            Assert.IsTrue(y >= radius);
            Assert.IsTrue(x <= LogicAPI.Width - radius);
            Assert.IsTrue(y <= LogicAPI.Height - radius);
        }
    }*/
}