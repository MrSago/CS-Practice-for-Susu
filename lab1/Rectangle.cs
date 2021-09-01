
using System;

namespace lab1
{
    enum Direction
    {
        Left, Right, Up, Down
    }

    class Rectangle
    {
        private float _x1, _y1, _x2, _y2;

        public float X1 { get => _x1; set => _x1 = value; }
        public float Y1 { get => _y1; set => _y1 = value; }
        public float X2 { get => _x2; set => _x2 = value; }
        public float Y2 { get => _y2; set => _y2 = value; }

        public Rectangle(float x1, float y1, float x2, float y2)
        {
            if (x1 == x2 || x1 == y2)
            {
                throw new Exception("It's not rectangle");
            }
            _x1 = Math.Min(x1, x2);
            _y1 = Math.Min(y1, y2);
            _x2 = Math.Max(x1, x2);
            _y2 = Math.Max(y1, y2);
        }

        public void Move(Direction dir, float value)
        {
            switch (dir)
            {
                case Direction.Left:
                    _x1 -= value;
                    _x2 -= value;
                    break;

                case Direction.Right:
                    _x1 += value;
                    _x2 += value;
                    break;

                case Direction.Up:
                    _y1 += value;
                    _y2 += value;
                    break;

                case Direction.Down:
                    _y1 -= value;
                    _y2 -= value;
                    break;

                default:
                    throw new Exception("Unknown direction");
            }
        }

        static public Rectangle MinRect(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(Math.Min(r1.X1, r2.X1), Math.Min(r1.Y1, r2.Y1), Math.Max(r1.X1, r2.X2), Math.Max(r1.Y1, r2.Y2));
        }

        static public Rectangle UnionRect(Rectangle r1, Rectangle r2)
        {
            if (r2.X1 < r1.X1 && r1.X1 < r2.X2 && r2.Y1 < r1.Y1 && r1.Y1 < r2.Y2)
            {
                return new Rectangle(r1.X1, r1.Y1, Math.Min(r1.X2, r2.X2), Math.Min(r1.Y2, r2.Y2));
            }

            if (r1.X1 < r2.X1 && r2.X1 < r1.X2 && r1.Y1 < r2.Y1 && r2.Y1 < r1.Y2)
            {
                return new Rectangle(r2.X1, r2.Y1, Math.Min(r1.X2, r2.X2), Math.Min(r1.Y2, r2.Y2));
            }

            if (r1.X1 < r2.X1 && r2.X1 < r1.X2 && r1.Y1 < r2.Y2 && r2.Y2 < r1.Y1)
            {
                return new Rectangle(r2.X1, r2.Y2, Math.Min(r1.X2, r2.X2), Math.Min(r1.Y1, r2.Y1));
            }

            if (r2.X1 < r1.X1 && r2.X1 < r1.X2 && r2.Y1 < r1.Y2 && r2.Y2 < r1.Y1)
            {
                return new Rectangle(r1.X1, r1.Y2, Math.Min(r1.X2, r2.X2), Math.Min(r1.Y1, r2.Y1));
            }

            return null;
        }
    }
}

