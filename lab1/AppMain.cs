
using System;

namespace lab1
{
    static class AppMain
    {
        static void PrintInfo()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1.Добавить прямоугольник");
            Console.WriteLine("2.Удалить прямоугольник");
            Console.WriteLine("3.Список прямоугольников на плоскости");
            Console.WriteLine("4.Переместить прямоугольник");
            Console.WriteLine("5.Построение наименьшего из двух");
            Console.WriteLine("6.Построение пересечения");
            Console.WriteLine("7.Установить размер");
            Console.WriteLine("0.Выход");
        }

        static void Main()
        {
            Menu menu = new();

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

