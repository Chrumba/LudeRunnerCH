using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GameLogic.Player.Inventory
{

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxStack { get; set; }

        public Item(int id, string name, string description, int maxStack)
        {
            Id = id;
            Name = name;
            Description = description;
            MaxStack = maxStack;
        }

        public  Item SubItem(int subId, string subName, string subDescription, int subMaxStack = -1)
        {
            int max_stack = subMaxStack != -1 ? subMaxStack : MaxStack;
            Item item = new Item(subId, subName, subDescription, max_stack);            
            return item;
        }


    }


    public class PInventory
    {
        public int CountItems { get; set; }

        public Item[] PILInit()
        {
            int count = CountItems;
            Item[] invetory = new Item[count];
            return invetory;
        }

        


    }
}
