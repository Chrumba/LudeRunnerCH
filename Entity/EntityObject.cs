using LudeRunnerCH.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Entity
{
    public class EntityObject
    {
        public Utils.Vector Vector { get; set; }
        private char Model { get; set; }
        private ConsoleColor Color { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public EntityObject(char model, ConsoleColor color, string name, int id, Vector vector)
        {
            Model = model;
            Color = color;
            Name = name;
            Id = id;
            Vector = vector;
        }

        public void Draw(Vector vector, ConsoleColor subColor = ConsoleColor.White)
        {
            ConsoleColor color = subColor != ConsoleColor.White ? subColor : Color;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(vector.x, vector.y);
            Console.Write(Model);
        }

        public void Clear(Vector vector)
        {
            Console.SetCursorPosition(vector.x, vector.y);
            Console.Write(" ");
        }


    }
}
