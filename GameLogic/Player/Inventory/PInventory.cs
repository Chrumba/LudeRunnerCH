using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GameLogic.Player.Inventory
{

    public class PIItem
    {
        public int ItemID { get; set; }
        public char Model { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MaxStack { get; set; }
        public int count { get; set; }

    }


    public class PInventory
    {
        public int CountItems { get; set; }

        public PIItem[] PILInit()
        {
            int count = CountItems;
            PIItem[] invetory = new PIItem[count];
            return invetory;
        }

        


    }
}
