using System;

namespace AleksandrovichLib
{
    public class Calculator
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }

        public double Subtraction(double a, double b)
        {
            return a - b;
        }

        public double Multiplication(double a, double b)
        {
            return a * b;
        }

        public double Division(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль недопустимо");
            return a / b;
        }

        public double Exponentiation(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
