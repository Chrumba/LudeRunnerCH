using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Utils
{
    public class Vector
    {
        public int x { get; set; } 
        public int y { get; set; }

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX(int x )
        {
            return this.x;
        }


        public int getY(int y ) 
        {
            return this.y;
        }


    }
}
