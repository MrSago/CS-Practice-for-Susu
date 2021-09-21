
using System;

namespace lab2
{
    internal static class AppMain
    {
        static void PrintInfo()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1.Информация о векторах");
            Console.WriteLine("2.Сложение v1+v2");
            Console.WriteLine("3.Вычитение v1-v2");
            Console.WriteLine("4.Длины векторов |v1|, |v2|");
            Console.WriteLine("5.Умножение на скаляр v1 и v2");
            Console.WriteLine("0.Выход");
        }

        static void Main()
        {
            double xv1, yv1, xv2, yv2;
            try
            {
                Console.WriteLine("Введите координаты вектора v1:");
                Console.Write("x=");
                xv1 = double.Parse(Console.ReadLine());
                Console.Write("y=");
                yv1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите координаты вектора v2:");
                Console.Write("x=");
                xv2 = double.Parse(Console.ReadLine());
                Console.Write("y=");
                yv2 = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

            IMenu<ConsoleKey> menu = new MenuLab2(new Vector(xv1, yv1), new Vector(xv2, yv2));

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

