using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GameLogic.Player.Inventory
{
    public class PInventory
    {
        public int CountItems { get; set; }
        public int MaxStack { get; set; }

        public int[] PILInit()
        {
            int count = CountItems;
            int[] invetory = new int[count];
            return invetory;
        }

    }
}
