using LudeRunnerCH.Entity;
using LudeRunnerCH.Map;
using LudeRunnerCH.Map.MapLogic;
using LudeRunnerCH.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH
{
    public class EntityLogic
    {
        /*
        public static bool Colission(int[,] IntMap, int IdOfObject,int x, int y) // Return the bool meaning, when objects have colission 
        {
            if (IntMap[x,y]!=IdOfObject)
            {
                return true;
            }
            return false;
        }
        public static bool Colission(int[,] IntMap, int x, int y)  // Return the bool meaning, when objects have colission with any object
        {
            if (IntMap[x,y] != Map.Nothing.IntModel)
            {
                return true;
            }
            return false;
        }*/
        public static bool Colission(EntityObject[,] entity, MapObjects[,] mapObjects, int x, int y)  // Return the bool meaning, when objects have colission with any object
        {
            if (entity[x,y] == null || mapObjects[x, y] == null)
            {
                return false;
            }
            if (entity[x,y].Vector.x == mapObjects[x,y].Vector.x || entity[x, y].Vector.y == mapObjects[x, y].Vector.y)
            {
                return true;
            }
            return false;
        }
        public static bool ColissionWithAnyObject(EntityObject entity, MapObjects[,] mapObjects, int x, int y)  // Return the bool meaning, when objects have colission with any object
        {
            if (entity == null || mapObjects[x,y] == null)
            {
                return false; 
            }

            return true;
        }
        public static bool ColissionWithObject(EntityObject entity, MapObjects[,] mapObjects, string objectName, int x, int y)  // Return the bool meaning, when objects have colission with any object
        {
            if (entity == null || mapObjects[x,y] == null)
            {
                return false; 
            }
            if (mapObjects[x,y].Name == objectName)
            {
                return true;
            }


            return false;
        }


        public static bool Collision(EntityObject entity, Vector vector)
        {
            if(entity.Vector.x == vector.x && entity.Vector.y == vector.y)
    {
                return true;
            }

            return false;
        }

    }
}
