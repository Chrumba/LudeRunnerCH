using LudeRunnerCH.Map.MapLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH
{
    public class EntityLogic
    {
        public static bool Colission(int[,] IntMap, int IdOfObject,int x, int y)
        {
            if (IntMap[x,y]!=IdOfObject)
            {
                return true;
            }
            return false;
        }
        public static bool Colission(int[,] IntMap, int x, int y)
        {
            if (IntMap[x,y]!=0)
            {
                return true;
            }
            return false;
        }

        public static int[,] MapSwap(int[,] IntMap, int[,]IntMapEntity, int x1, int y1, int x2, int y2)
        {
            IntMapEntity[x2, y2] = IntMapEntity[x1, y1];
            IntMapEntity[x1, y1] = IntMap[x1, y1];
            return IntMapEntity;
        }

    }
}
