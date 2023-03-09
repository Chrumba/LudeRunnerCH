using LudeRunnerCH.Map.Entity;


namespace LudeRunnerCH.Map
{
    public class Generator
    {

        public static void ConsoleSides(int width = game.WindowWIDTH, int height = game.WindowHEIGHT, ConsoleColor color = ConsoleColor.DarkGray)
        {
            for (int y = 0; y < height; y++)
            {
                new GUI.Pixel(0, y, color).Draw();
                new GUI.Pixel(width - 1, y, color).Draw();
            }
            
            for (int x = 1; x < width; x++)
            {
                new GUI.Pixel(x, 0, color).Draw();
                new GUI.Pixel(x, height-1, color).Draw();
            }

        }


        public static MapObjects[,] GeneratorMap(int width, int height)
        {
            MapObjects[,] map = new MapObjects[width, height];

            
            

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y += 6)
                {
                    MapObjects Wall = new MapObjects(name: "Wall", id: 1, model: '#', color: ConsoleColor.DarkGray, vector: new Utils.Vector(x, y));
                    map[x, y] = Wall;
                    
                }

            }

            for (int x = 4; x < map.GetLength(0); x += 12)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    MapObjects Lader = new MapObjects(name: "Lader", id: 2, model: '|', color: ConsoleColor.DarkYellow, vector: new Utils.Vector(x, y));
                    map[x, y] = Lader;
                }

            }


            return map;
        } 

        public static void RenderMap(MapObjects[,] map, int intend=0)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y =0; y < map.GetLength(1); y++)
                {
                    if (map[x,y]!=null)
                    {
                        map[x, y].Draw(new Utils.Vector(x+intend,y+intend));
                    }
                    
                }
            }
        }
    }
}
