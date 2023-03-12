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

        private bool Hide { get; set;} = false;
        public MapObjects(char model, ConsoleColor color, string name, int id, Vector vector)
        {
            Model = model;
            Color = color;
            Name = name;
            Id = id;
            Vector= vector;
        }

        public void Draw(Vector vector , ConsoleColor subColor = ConsoleColor.White)
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

        public void Hides(int intend = 0)
        {
            Clear(new Vector(Vector.x + intend, Vector.y + intend));
            Hide = true;
        }


        public bool GetHide() 
        {
            if (this != null)
            {
                return this.Hide;
            }
            return false;
        }

        public void SetHide(bool value)
        {
            if (this != null)
            {
                Hide = value;
            }
            
        }

    }

}
