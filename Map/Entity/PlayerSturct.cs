using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Map.Entity
{
    public struct PlayerSturct
    {
        private const char ModelChar= 'I';
        public const int IntModel= 3;


        public int X { get; } 
        public int Y { get; }

        public ConsoleColor Color { get; }

        public PlayerSturct(int x, int y, ConsoleColor Color)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(ModelChar);

        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
