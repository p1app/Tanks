using System;

namespace Homework_if
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы запустили калькулятор с использованием if");

            Console.WriteLine("Введите первое число");
            double firstNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число число");
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите операцию: '+', '-', '/', '*' ");
            string sign = Console.ReadLine();

            if (sign == "+")
            {
                double sumResult = firstNumber + secondNumber;
                Console.WriteLine("Сумма введных чисел равна " + sumResult);
            }
            else if (sign == "-")
            {
                double diffResult = firstNumber - secondNumber;
                Console.WriteLine("Разность введных чисел равна " + diffResult);
            }
            else if (sign == "/")
            {
                double quotResult = firstNumber / secondNumber;
                Console.WriteLine("Частное введных чисел равно " + quotResult);
            }
            else if (sign == "*")
            {
                double prodResult = firstNumber * secondNumber;
                Console.WriteLine("Произведение введных чисел равно " + prodResult);
            }
            else { Console.WriteLine("Введен неккоректный знак"); }
        }
    }
}
