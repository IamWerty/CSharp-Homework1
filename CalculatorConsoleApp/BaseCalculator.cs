using System;

namespace CalculatorLib
{
    public class Calculator
    {
        public double LastResult { get; protected set; } // Змінна для результату

        public virtual double Add(double a, double b)
        {
            LastResult = a + b;
            return LastResult;
        }

        public virtual double Subtract(double a, double b)
        {
            LastResult = a - b;
            return LastResult;
        }

        public virtual double Multiply(double a, double b)
        {
            LastResult = a * b;
            return LastResult;
        }

        public virtual double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Ділення на нуль неможливе.");

            LastResult = a / b;
            return LastResult;
        }
    }
}
