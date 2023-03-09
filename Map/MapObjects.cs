using LudeRunnerCH.Utils;

namespace LudeRunnerCH.Map
{
    public class MapObjects
    {
        private char Model { get; set; }
        private ConsoleColor Color { get; set; }
        public string Name { get; set; }
        public int Id { get; set; } 
        public Vector Vector { get; set; }


        public MapObjects(char model, ConsoleColor color, string name, int id, Vector vector)
        {
            Model = model;
            Color = color;
            Name = name;
            Id = id;
            Vector= vector;
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
