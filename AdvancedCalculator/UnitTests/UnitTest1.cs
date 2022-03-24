using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testy_Jednostkowe
{
    [TestClass]
    public class Test
    {

        [TestMethod]
        public void Testing_Add()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Add(4.4, 6.23), 10.63);
            Assert.AreEqual(AdvancedCalculator.Calculator.Add(-254, 364), 110);
            Assert.AreEqual(AdvancedCalculator.Calculator.Add(72.9, 23), 95.9);
            Assert.AreEqual(AdvancedCalculator.Calculator.Add(4, -5), -1);
        }

        [TestMethod]
        public void Testing_Subtract()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Substract(12, 7), 5);
            Assert.AreEqual(AdvancedCalculator.Calculator.Substract(-8, 2), -10);
            Assert.AreEqual(AdvancedCalculator.Calculator.Substract(85, 69), 16);
            Assert.AreEqual(AdvancedCalculator.Calculator.Substract(4, -9), 13);
        }

        [TestMethod]
        public void Testing_Multiplication()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Multiplication(3, 4), 12);
            Assert.AreEqual(AdvancedCalculator.Calculator.Multiplication(3.5, -9), -31.5);
            Assert.AreEqual(AdvancedCalculator.Calculator.Multiplication(-4, 0), 0);
            Assert.AreEqual(AdvancedCalculator.Calculator.Multiplication(-8, -5), 40);
        }

        [TestMethod]
        public void Testing_Division()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Division(42, 7), 6);
            Assert.AreEqual(AdvancedCalculator.Calculator.Division(-9, 3), -3);
            Assert.AreEqual(AdvancedCalculator.Calculator.Division(123, -3), -41);
            Assert.ThrowsException<ArgumentException>(() => AdvancedCalculator.Calculator.Division(45, 0));
        }

        [TestMethod]
        public void Testing_Average()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Average(1, 2, 3), 2);
            Assert.AreEqual(AdvancedCalculator.Calculator.Average(0, 4, -7), -1);
            Assert.AreEqual(AdvancedCalculator.Calculator.Average(-4.3, 17.75, 5.3), 6.25);
            Assert.AreEqual(AdvancedCalculator.Calculator.Average(9.65, 14.78, 4.25), 9.56);
        }

        [TestMethod]
        public void Testing_Min()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Min(-56.7, 34.23, 12.942), -56.7);
            Assert.AreEqual(AdvancedCalculator.Calculator.Min(24, 0, 32), 0);
            Assert.AreEqual(AdvancedCalculator.Calculator.Min(12.88, 12.888, 12.8), 12.8);
            Assert.AreEqual(AdvancedCalculator.Calculator.Min(122, 133, 122), 122);

        }

        [TestMethod]
        public void Testing_Max()
        {
            Assert.AreEqual(AdvancedCalculator.Calculator.Max(35, 21, 78), 78);
            Assert.AreEqual(AdvancedCalculator.Calculator.Max(12, -54.6, 44.09), 44.09);
            Assert.AreEqual(AdvancedCalculator.Calculator.Max(34.5, 34.555, 34.55), 34.555);
            Assert.AreEqual(AdvancedCalculator.Calculator.Max(-134, -136, -168), -134);
        }

    }
}