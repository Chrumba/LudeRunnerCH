using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Utils
{
    public struct Vector
    {
        public int x { get; set; } 
        public int y { get; set; }

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }

    public struct AnyVector <TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public AnyVector(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;   
        }

    }

}
