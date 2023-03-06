using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GUI
{
    public struct Pixel
    {
        private const char pixel= '█';
        
        public int x; 
        public int y;
        public ConsoleColor color;

        public Pixel(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(pixel);
        }
        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
}
