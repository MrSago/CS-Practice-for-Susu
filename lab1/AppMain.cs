
using System;
using System.Collections.Generic;

namespace lab1
{
    static class AppMain
    {
        static readonly Dictionary<string, Rectangle> rectangles = new();
        static bool ContinueMenu = true;

        // Key1
        static void PrintRect()
        {
            if (rectangles.Count <= 0)
            {
                Console.WriteLine("\nПрямоугольников нет на плоскости!");
                return;
            }
            Console.WriteLine("\nПрямоугольники и их координаты:");
            foreach (var r in rectangles)
            {
                Console.WriteLine($"Key: {r.Key} | ({r.Value.X1}, {r.Value.Y1}), ({r.Value.X2}, {r.Value.Y2})");
            }
        }

        // Key2
        static void AddRect()
        {
            Console.Write("\nВведите ключ: ");
            string key = Console.ReadLine();
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            if (rectangles.ContainsKey(key))
            {
                Console.WriteLine("Такой ключ уже существует!");
                return;
            }

            Console.WriteLine("Введите координаты: ");
            try
            {
                Console.Write("x1: ");
                float x1 = float.Parse(Console.ReadLine());

                Console.Write("y1: ");
                float y1 = float.Parse(Console.ReadLine());

                Console.Write("x2: ");
                float x2 = float.Parse(Console.ReadLine());

                Console.Write("y2: ");
                float y2 = float.Parse(Console.ReadLine());

                rectangles.Add(key, new Rectangle(x1, y1, x2, y2));
            }
            catch
            {
                Console.WriteLine("Ошибка ввода координат!");
            }
        }

        // Key3
        static void DelRect()
        {
            PrintRect();
            if (rectangles.Count <= 0)
            {
                return;
            }

            Console.Write("\nВведите ключ для удаления: ");
            string key = Console.ReadLine();
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            if (!rectangles.ContainsKey(key))
            {
                Console.WriteLine("Такой ключ не существует!");
                return;
            }

            rectangles.Remove(key);
        }

        // Key4
        static void MoveRect()
        {
            PrintRect();
            if (rectangles.Count <= 0)
            {
                return;
            }

            Console.Write("\nВведите ключ для перемещения: ");
            string key = Console.ReadLine();
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            if (!rectangles.ContainsKey(key))
            {
                Console.WriteLine("Такой ключ не существует!");
                return;
            }

            Console.WriteLine("Выберите направление стрелками");
            Direction direction;
            try
            {
                direction = Console.ReadKey(true).Key switch
                {
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.UpArrow => Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    _ => throw new Exception("Invalid key")
                };
            }
            catch
            {
                Console.WriteLine("Неизвестное направление!");
                return;
            }

            Console.Write("Введите значение: ");
            float value;
            try
            {
                value = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода значения!");
                return;
            }
            rectangles[key].Move(direction, value);
            Console.WriteLine($"Новые координаты: ({rectangles[key].X1}, {rectangles[key].Y1}), ({rectangles[key].X2}, {rectangles[key].Y2})");
        }

        // Key5
        static void MinRect()
        {
            PrintRect();
            if (rectangles.Count <= 0)
            {
                return;
            }

            Console.Write("Введите ключ первого прямоугольника: ");
            string key1 = Console.ReadLine();
            Console.Write("Введите ключ второго прямоугольника: ");
            string key2 = Console.ReadLine();
            if (string.IsNullOrEmpty(key1) || string.IsNullOrEmpty(key2))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            if (!rectangles.ContainsKey(key1) || !rectangles.ContainsKey(key2))
            {
                Console.WriteLine("Прямоугольники по ключам не найдены!");
                return;
            }

            Rectangle rectangle;
            try
            {
                rectangle = Rectangle.MinRect(rectangles[key1], rectangles[key2]);
            }
            catch
            {
                Console.WriteLine("Минимальный прямоугольник не найден!");
                return;
            }

            Console.Write("Введите ключ нового прямоугольника: ");
            string new_key = Console.ReadLine();
            if (string.IsNullOrEmpty(new_key) || rectangles.ContainsKey(new_key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            rectangles.Add(new_key, rectangle);
        }

        // Key6
        static void UnionRect()
        {
            PrintRect();
            if (rectangles.Count <= 0)
            {
                return;
            }

            Console.Write("Введите ключ первого прямоугольника: ");
            string key1 = Console.ReadLine();
            Console.Write("Введите ключ второго прямоугольника: ");
            string key2 = Console.ReadLine();
            if (string.IsNullOrEmpty(key1) || string.IsNullOrEmpty(key2))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            if (!rectangles.ContainsKey(key1) || !rectangles.ContainsKey(key2))
            {
                Console.WriteLine("Прямоугольники по ключам не найдены!");
                return;
            }

            Rectangle rectangle;
            try
            {
                rectangle = Rectangle.UnionRect(rectangles[key1], rectangles[key2]);
                if (rectangle == null)
                {
                    throw new Exception("Null object");
                }
            }
            catch
            {
                Console.WriteLine("Пересечение не найдено!");
                return;
            }

            Console.Write("Введите ключ нового прямоугольника:");
            string new_key = Console.ReadLine();
            if (string.IsNullOrEmpty(new_key) || rectangles.ContainsKey(new_key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
                return;
            }
            rectangles.Add(new_key, rectangle);
        }

        // Key7
        static void SetRectSize()
        {
            Console.Write("Введите ключ прямоугольника: ");
            string key = Console.ReadLine();
            if (string.IsNullOrEmpty(key) || !rectangles.ContainsKey(key))
            {
                Console.WriteLine("Ошибка ввода ключа!");
            }

            float weight, height;
            Console.WriteLine("Введите размеры прямоугольника: ");
            try
            {
                Console.Write("weight: ");
                weight = float.Parse(Console.ReadLine());
                Console.Write("height: ");
                height = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода значений!");
                return;
            }

            rectangles[key].SetSize(weight, height);
        }

        static void ExitMenu()
        {
            ContinueMenu = false;
        }

        static void Main()
        {
            Menu<ConsoleKey> menu = new(new Dictionary<ConsoleKey, Action>
            { 
                { ConsoleKey.D1, AddRect },
                { ConsoleKey.D2, DelRect },
                { ConsoleKey.D3, PrintRect },
                { ConsoleKey.D4, MoveRect },
                { ConsoleKey.D5, MinRect },
                { ConsoleKey.D6, UnionRect },
                { ConsoleKey.D7, SetRectSize },
                { ConsoleKey.D0, ExitMenu },
            });

            while (ContinueMenu)
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
                if (!menu.Invoke(Console.ReadKey(true).Key))
                {
                    Console.WriteLine("\nНеизвестная опция!");
                }
            }
        }
    }
}

