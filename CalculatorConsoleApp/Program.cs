using System;
using System.Text;
using CalculatorLib;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Калькулятор ===");
            Console.WriteLine("Оберіть тип калькулятора:");
            Console.WriteLine("1. Базовий");
            Console.WriteLine("2. Науковий");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            Calculator calc = (choice == "2") ? new ScientificCalculator() : new Calculator(); // використовуємо тернарний оператор щоб скоротити код(Можна написати ще через if|else btw)

            string lastMessage = "";
            bool hasResult = false;

            while (true)
            {
                Console.Clear();

                //Показуємо минулий результат або повідомлення, якщо вже щось було
                if (hasResult)
                {
                    Console.WriteLine("=== Попередній результат ===");
                    Console.WriteLine(lastMessage);
                    Console.WriteLine("=============================\n");
                }

                Console.WriteLine("Операції:");
                Console.WriteLine("1. Додавання");
                Console.WriteLine("2. Віднімання");
                Console.WriteLine("3. Множення");
                Console.WriteLine("4. Ділення");

                if (calc is ScientificCalculator)
                    Console.WriteLine("5. Sin\n6. Cos\n7. Степінь числа\n8. Корінь квадратний числа\n");

                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");
                string op = Console.ReadLine();

                if (op == "0") break;

                try
                {
                    double a, b;
                    double result = double.NaN;

                    switch (op)
                    {
                        case "1":
                            (a, b) = ReadTwoNumbers();
                            result = calc.Add(a, b);
                            lastMessage = $"Результат: {result}";
                            break;

                        case "2":
                            (a, b) = ReadTwoNumbers();
                            result = calc.Subtract(a, b);
                            lastMessage = $"Результат: {result}";
                            break;

                        case "3":
                            (a, b) = ReadTwoNumbers();
                            result = calc.Multiply(a, b);
                            lastMessage = $"Результат: {result}";
                            break;

                        case "4":
                            (a, b) = ReadTwoNumbers();
                            result = calc.Divide(a, b);
                            lastMessage = $"Результат: {result}";
                            break;

                        case "5" when calc is ScientificCalculator sci:
                            a = ReadNumber("Введіть кут (у радіанах): ");
                            result = sci.Sin(a);
                            lastMessage = $"Sin({a}) = {result}";
                            break;

                        case "6" when calc is ScientificCalculator sci2: // добавляю нумерацію до sci, щоб уникнути конфлікту імен в case(Бо вже було діло :d)
                            a = ReadNumber("Введіть кут (у радіанах): ");
                            result = sci2.Cos(a);
                            lastMessage = $"Cos({a}) = {result}";
                            break;

                        case "7" when calc is ScientificCalculator sci3:
                            (a, b) = ReadTwoNumbers();
                            result = sci3.Pow(a, b);
                            lastMessage = $"{a}^{b} = {result}";
                            break;

                        case "8" when calc is ScientificCalculator sci4:
                            a = ReadNumber("Введіть число: ");
                            result = sci4.Sqrt(a);
                            lastMessage = $"√{a} = {result}";
                            break;

                        default:
                            lastMessage = "Невідома операція.";
                            break;
                    }

                    hasResult = true;
                }
                catch (Exception ex)
                {
                    lastMessage = $"Помилка: {ex.Message}";
                    hasResult = true; // теж вважаємо “результатом” — щоб показати помилку
                }
            }

            Console.Clear();
            Console.WriteLine("Дякую за використання калькулятора!");
        }
        // Я вивів окремими функціями зчитування чисел, щоб не питати кожен раз в case(Можна потім спробувати в циклі зробити ввід першого числа, і якщо вибрана функція потребує 2 число, то тоді ми вже вводимо 2, але в мене горять дедлайни, тому зробив на швидкоруч :D)
        static (double, double) ReadTwoNumbers() // для функцій, що потребують два числа
        {
            double a = ReadNumber("Введіть перше число: ");
            double b = ReadNumber("Введіть друге число: ");
            return (a, b);
        }

        static double ReadNumber(string message) // для функцій, що потребують 1 число
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.WriteLine("Невірне число, спробуйте ще раз.");
            }
        }
    }
}
