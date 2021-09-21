
using System;

namespace lab3
{
    internal static class AppMain
    {
        static void PrintInfo()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1.Упорядочить и вывести данные авиалайнеров");
            Console.WriteLine("2.Вывести первые 6 бортов");
            Console.WriteLine("3.Последние 2 номера рейса");
            Console.WriteLine("4.Средний взлетный вес");
            Console.WriteLine("5.Запись в XML");
            Console.WriteLine("6.Чтение из XML");
            Console.WriteLine("0.Выход");
        }

        static void Main()
        {
            IMenu<ConsoleKey> menu = new MenuLab3();

            while (menu.ContinueMenu)
            {
                PrintInfo();

                if (!menu.Method.Invoke(Console.ReadKey(true).Key))
                {
                    Console.WriteLine("\nНеизвестная опция!");
                }
            }
        }
    }
}

