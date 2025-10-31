using System;

namespace CalculatorLib
{
    public class ScientificCalculator : Calculator
    {
        public double Pow(double a, double b) //піднесення до степеня
        {
            LastResult = Math.Pow(a, b); // a - число; b - степінь 
            return LastResult;
        }

        public double Sqrt(double a) // Квадратний корінь(потім можна буде добавити ще алгебраічний, якщо буде час звісно)
        {
            if (a < 0)
                throw new InvalidOperationException("Неможливо обчислити корінь з від’ємного числа.");

            LastResult = Math.Sqrt(a);
            return LastResult;
        }

        public double Sin(double a)
        {
            LastResult = Math.Sin(a);
            return LastResult;
        }

        public double Cos(double a)
        {
            LastResult = Math.Cos(a);
            return LastResult;
        }

        // Перевизначення класу для спроби розширення базового функц.
        public override double Divide(double a, double b)
        {
            Console.WriteLine("[ScientificCalculator] Виконується ділення");
            return base.Divide(a, b); // Виклик базового методу
        }
    }
}
