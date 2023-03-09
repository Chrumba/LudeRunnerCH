using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxStack { get; set; }
        public char Model { get; set; }
        public ConsoleColor Color{ get; set; }

        public Item(int id, string name, string description, int maxStack, char model, ConsoleColor color)
        {
            Id = id;
            Name = name;
            Description = description;
            MaxStack = maxStack;
            Model = model;
            Color = color;
        }

        public Item SubItem(int subId, string subName, string subDescription, int subMaxStack = -1, char subModel = ' ', ConsoleColor subColor = ConsoleColor.White)
        {
            int max_stack = subMaxStack != -1 ? subMaxStack : MaxStack;
            char model = subModel != ' ' ? subModel : Model;
            ConsoleColor color = subColor != ConsoleColor.White? subColor : Color;

            Item item = new Item(subId, subName, subDescription, max_stack, model, color);
            return item;
        }

        public void Render(Utils.Vector vector)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(vector.x, vector.y);
            Console.Write(Model);
        }
    }
   

}
