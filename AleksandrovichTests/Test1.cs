using Microsoft.VisualStudio.TestTools.UnitTesting;
using AleksandrovichLib;
using System;

namespace AleksandrovichTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Sum_10and20_Returns30()
        {
            double result = calculator.Sum(10, 20);
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void Subtraction_30and20_Returns10()
        {
            double result = calculator.Subtraction(30, 20);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Multiplication_10and2_Returns20()
        {
            double result = calculator.Multiplication(10, 2);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Division_20and2_Returns10()
        {
            double result = calculator.Division(20, 2);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Division_ByZero_ThrowsException()
        {
            try
            {
                calculator.Division(20, 0);
                Assert.Fail("Ожидалось исключение DivideByZeroException");
            }
            catch (DivideByZeroException)
            {

            }
        }

        [TestMethod]
        public void Exponentiation_2and3_Returns8()
        {
            double result = calculator.Exponentiation(2, 3);
            Assert.AreEqual(8, result);
        }
    }
}
