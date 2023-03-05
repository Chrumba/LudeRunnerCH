using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Map.MapLogic
{
    public class MapLogic
    {
        public static void idConsolePrinter(int x, int y, int IdOfObject)
        {
            switch (IdOfObject)
            {
                case Wall.IntModel:
                    new Wall(x,y, game.WallColor).Draw();
                    break;
                case 2:
                    new Lader(x, y, game.LaderColor).Draw();
                    break;
            }
        }

    }
}
