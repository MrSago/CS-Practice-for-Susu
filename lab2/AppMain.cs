
using System;

namespace lab2
{
    class AppMain
    {
        static Vector v1, v2;

        static void PrintVecInfo()
        {
            Console.WriteLine($"v1({v1.X}, {v1.Y})");
            Console.WriteLine($"v2({v2.X}, {v2.Y})");
        }

        static void PrintVecInfo(Vector v)
        {
            Console.WriteLine($"v({v.X}, {v.Y})");
        }

        static void VecSum()
        {
            Vector v = v1 + v2;
            Console.Write("v1 + v2 = ");
            PrintVecInfo(v);
        }

        static void VecDif()
        {
            Vector v = v1 - v2;
            Console.Write("v1 - v2 = ");
            PrintVecInfo(v);
        }

        static void VecAbs()
        {
            Console.WriteLine($"|v1| = {v1.Abs()}");
            Console.WriteLine($"|v2| = {v2.Abs()}");
        }

        static void ScalVec()
        {
            double a;
            try
            {
                Console.WriteLine("Введите скаляр: ");
                a = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            Vector new_v1 = v1 * a;
            Vector new_v2 = v2 * a;
            PrintVecInfo();
            PrintVecInfo(new_v1);
            PrintVecInfo(new_v2);
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

            v1 = new(xv1, yv1);
            v2 = new(xv2, yv2);

            bool cont = true;
            while (cont)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1.Информация о векторах");
                Console.WriteLine("2.Сложение v1+v2");
                Console.WriteLine("3.Вычитение v1-v2");
                Console.WriteLine("4.Длины векторов |v1|, |v2|");
                Console.WriteLine("5.Умножение на скаляр v1 и v2");
                Console.WriteLine("0.Выход");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        PrintVecInfo();
                    break;

                    case ConsoleKey.D2:
                        VecSum();
                    break;

                    case ConsoleKey.D3:
                        VecDif();
                    break;

                    case ConsoleKey.D4:
                        VecAbs();
                    break;

                    case ConsoleKey.D5:
                        ScalVec();
                    break;

                    case ConsoleKey.D0:
                        cont = false;
                    break;

                    default:
                        Console.WriteLine("Неизвестная опция!");
                    break;
                }
            }
        }
    }
}

