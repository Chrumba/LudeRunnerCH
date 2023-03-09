using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Entity.Player.Inventory
{

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
