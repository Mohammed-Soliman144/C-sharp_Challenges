using System;
using System.Collections.Generic;

namespace ConsoleApp_Calculator
{
    class Calculator
    {
        private decimal Addition(decimal num1, decimal num2)
        {
            return Math.Round((num1 + num2), 4);
        }
        private decimal Division(decimal num1, decimal num2)
        {
            return num2 == 0 ? -0 : Math.Round((num1 / num2), 4);
        }
        private decimal Subtraction(decimal num1, decimal num2)
        {
            return Math.Round((num1 - num2), 4);
        }
        private decimal Multiplication(decimal num1, decimal num2)
        {
            return Math.Round((num1 * num2), 4);
        }

        public string Calculations()
        {
            decimal num1, num2;
            char operation;

            Console.WriteLine("Enter your first number");
            if (!decimal.TryParse(Console.ReadLine(), out num1))
                return "You entered invalid number";
            Console.WriteLine("Enter your operator of Calculation, and default (+)");
            // safe method to read character which prevents app from crashing char.TryParse bool => char.TryParse(Console.ReadLine(), out result) ? result :  null
            operation = char.TryParse(Console.ReadLine(), out char character) ? character : '+';
            Console.WriteLine("Enter your second number");
            if (!decimal.TryParse(Console.ReadLine(), out num2))
                return "You entered invalid number";
            switch (operation)
            {
                case '+':
                    return $"Result = {Convert.ToString(Addition(num1, num2))}";
                case '-':
                    return $"Result = {Convert.ToString(Subtraction(num1, num2))}";
                case '/':
                    return Division(num1, num2) == -0 ? "Can not divide by zero (0)" : $"Result = {Convert.ToString(Division(num1, num2))}";
                case '*':
                    return $"Result = {Convert.ToString(Multiplication(num1, num2))}";
            }
            return "";
        }
        static void Main(string[] args)
        {
            Calculator CalcApp = new Calculator();
            string result = CalcApp.Calculations();
            Console.WriteLine(result);
        }
    }
}