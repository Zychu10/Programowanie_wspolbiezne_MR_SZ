using System;

namespace AdvancedCalculator
{
    public class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Substract(double a, double b)
        {
            return a - b;
        }
        public static double Multiplication(double a, double b)
        {
            return a * b;
        }
        public static double Division(double a, double b)
        {
            if (b != 0)
            {
                return (a / b);
            }
            else
            {
                throw new ArgumentException("You cannot divide by zero!");
            }
        }
        public static double Average(double a, double b, double c)
        {
            return (a + b + c) / 3;
        }
        public static double Min(double a, double b, double c)
        {
            double result;
            double[] array1 = { a, b, c };
            result = array1[0];
            for (int i = 1; i < array1.Length; i++)
            {
                if (result > array1[i])
                {
                    result = array1[i];
                }
            }
            return result;
        }
        public static double Max(double a, double b, double c)
        {
            double result;
            double[] array1 = { a, b, c };
            result = array1[0];
            for (int i = 1; i < array1.Length; i++)
            {
                if (result < array1[i])
                {
                    result = array1[i];
                }
            }
            return result;
        }
    }
}