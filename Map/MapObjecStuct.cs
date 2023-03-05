using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Map
{
    public readonly struct Wall
    {
        private const char WallChar = '#';

        public const int IntModel = 1;

        public Wall(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; } 
        public int Y { get; }
        public ConsoleColor Color { get; }



        public void Draw()
        {
            Console.ForegroundColor= Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(WallChar);

        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

    }
    public readonly struct Lader
    {
        private const char WallChar = '|';
        public const int IntModel = 2;

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }

        public Lader(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(WallChar);

        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public readonly struct Nothing
        {
            private const char WallChar = ' ';
            public const int IntModel = 0;

            public int X { get; }
            public int Y { get; }

            public Nothing(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Draw()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(WallChar);

            }

        }

    }
}
