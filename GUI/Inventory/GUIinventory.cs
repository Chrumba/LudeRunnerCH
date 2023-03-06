using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GUI
{
    public class GUIinventory
    {
        public static void RenderGUI(GameLogic.Player.Inventory.PInventory inventory, int start_x, int start_y, int cell_width, int cell_height, int intend, ConsoleColor Frame_color)
        {

            int count = inventory.CountItems;

            for (int i = start_x; i <= count*(start_x+cell_width); i += cell_width+intend)
            {
                for (int x = start_x+i; x < cell_width+start_x+i; x++)
                {
                    new Pixel(x, start_y, Frame_color).Draw();
                    new Pixel(x, start_y + cell_height-1, Frame_color).Draw();

                }

                for (int y = start_y; y < cell_height+start_y; y++)
                {
                    new Pixel(i+start_x, y, Frame_color).Draw();
                    new Pixel(i+cell_width+start_x, y, Frame_color).Draw();
                }

                
            }
        }
    }
}
