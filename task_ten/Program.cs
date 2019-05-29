using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_ten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введите количество членов последовательности (не менее 2):   ");
            Console.ResetColor();
            int n = EnterAnInteger();
            Row numSequence = new Row();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
Заполнить...
1. рандомно.
2. с клавиатуры.");
            Console.ResetColor();
            switch(MenuOption())
            {
                case 1:
                    numSequence = new Row(n);
                    break;
                case 2:
                    for (int i = 0; i < n; i++)
                    {
                        numSequence.Add(EnterANumber());
                    }
                    break;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nПоследовательность");
            Console.ResetColor();
            PrintRow(numSequence);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nПоследовательность {x[1] - x[n], x[2] - x[n], ..., x[n-1] - x[n]}");
            Console.ResetColor();
            Row newSequence = new Row();
            for (int i = 0; i < n-1; i++)
                newSequence.Add(numSequence[i] - numSequence[n - 1]);
            PrintRow(newSequence);

            Console.CursorVisible = false;
            Console.ReadKey();
        }

        public static void PrintRow(Row row)
        {
            foreach (double item in row)
                Console.Write(item + "\t");
        }

        public static int EnterAnInteger() //ввод
        {
            bool ok = false;
            int number = 0;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число!");
                }
            } while (!ok);
            return number;
        }

        public static double EnterANumber() //ввод
        {
            Console.Write("Введите число:   ");
            bool ok = false;
            double number = 0;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число!");
                }
            } while (!ok);
            return number;
        }

        public static int MenuOption()
        {
            int option = 0;
            bool alright = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Пункт:    ");
                Console.ResetColor();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option < 1 || option > 2) Console.WriteLine("Error!");
                    else alright = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error!");
                    alright = false;
                }
            } while (!alright);

            return option;
        }

    }
}
