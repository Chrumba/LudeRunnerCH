using LudeRunnerCH.GameLogic.Player.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.GUI
{
    public class GUIinventory
    {

        public GameLogic.Player.Inventory.PInventory inventory { get; set; }
        public int start_x { get; set; }
        public int start_y {  get; set; }
        public int cell_width { get; set; }
        public int cell_height { get; set; }
        private int intend { get; set; }
        public ConsoleColor Frame_color { get; set; }

        public GUIinventory(PInventory inventory, int start_x, int start_y, int cell_width, int cell_height, int intend, ConsoleColor frame_color)
        {
            this.inventory = inventory;
            this.start_x = start_x;
            this.start_y = start_y;
            this.cell_width = cell_width;
            this.cell_height = cell_height;
            this.intend = intend;
            Frame_color = frame_color;
        }




        public  void RenderGUI() //Render the gui in console with set parameters 
        {



            int count = inventory.CountItems;

            for (int i = 0; i < (count-1)*(start_x+cell_width); i += cell_width+intend)
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
        
        public  Utils.Vector[] GetVectorsGUISlots() //Return x+1 y+1 slots 
        {
            int count = inventory.CountItems;
            Utils.Vector[] result = new Utils.Vector[count];

            int temp = start_x+1;

            for (int i = 0; i < count; i++)
            {
                result[i] = new Utils.Vector(temp, start_y +1);
                temp += cell_width + intend;
            }
            return result;

        }


    }
}
