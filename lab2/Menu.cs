
using System;
using System.Collections.Generic;

namespace lab2
{
    class Menu
    {
        private readonly DictionaryMethods<ConsoleKey> _method;
        private bool _continueMenu = true;

        public DictionaryMethods<ConsoleKey> Method => _method;
        public bool ContinueMenu => _continueMenu;

        private readonly Vector _v1, _v2;

        public Menu(Vector v1, Vector v2)
        {
            _method = new(new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.D1, PrintVecInfo },
                { ConsoleKey.D2, VecSum },
                { ConsoleKey.D3, VecDif },
                { ConsoleKey.D4, VecAbs },
                { ConsoleKey.D5, ScalVec },
                { ConsoleKey.D0, ExitMenu }
            });

            _v1 = v1;
            _v2 = v2;
        }

        // Key1
        private void PrintVecInfo()
        {
            Console.WriteLine($"v1({_v1.X}, {_v1.Y})");
            Console.WriteLine($"v2({_v2.X}, {_v2.Y})");
        }
        private void PrintVecInfo(Vector v)
        {
            Console.WriteLine($"v({v.X}, {v.Y})");
        }

        // Key2
        private void VecSum()
        {
            Vector v = _v1 + _v2;
            Console.Write("v1 + v2 = ");
            PrintVecInfo(v);
        }

        // Key3
        private void VecDif()
        {
            Vector v = _v1 - _v2;
            Console.Write("v1 - v2 = ");
            PrintVecInfo(v);
        }

        // Key4
        private void VecAbs()
        {
            Console.WriteLine($"|v1| = {_v1.Abs()}");
            Console.WriteLine($"|v2| = {_v2.Abs()}");
        }

        // Key5
        private void ScalVec()
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
            Vector new_v1 = _v1 * a;
            Vector new_v2 = _v2 * a;
            PrintVecInfo();
            PrintVecInfo(new_v1);
            PrintVecInfo(new_v2);
        }

        // Key0
        private void ExitMenu()
        {
            _continueMenu = false;
        }

    }
}

