using LudeRunnerCH.GameLogic.Player.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Item
{
    public class Items
    {
        public class PickUps: PIItem
        {
            public PIItem Coin()
            {
                PIItem coin = new PIItem()
                {
                    count = 0,
                    ItemID= 0, 
                    Description = " Одна гривня",
                    Model = '@',
                    Name = "Гривня",
                    MaxStack = 99,
                };
                return coin;
            }





        }




    }
}
