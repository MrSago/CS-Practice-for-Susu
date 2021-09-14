
using System;

namespace lab2
{

    class Vector
    {
        private double _x, _y;

        public double X => _x;
        public double Y => _y;

        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Vector(double x1, double y1, double x2, double y2)
        {
            _x = x2 - x1;
            _y = y2 - y1;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1._x + v2._x, v1._y + v2._y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1._x - v2._x, v1._y - v2._y);
        }

        public static Vector operator *(Vector v1, double a)
        {
            return new Vector(v1._x * a, v1._y * a);
        }

        public double Abs()
        {
            return Math.Sqrt(_x * _x + _y * _y);
        }
    }
}

