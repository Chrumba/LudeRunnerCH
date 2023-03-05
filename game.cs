using LudeRunnerCH.Map.Entity;
using LudeRunnerCH.Map.MapLogic;
using static System.Console;
namespace LudeRunnerCH
{
    public class game
    {

        public const int WIDTH = 60;
        public const int HEIGHT = 30;
        
        public const int WindowWIDTH = 70;
        public const int WindowHEIGHT = 40;




        public const int intend = 4;

        public const ConsoleColor WallColor = ConsoleColor.Yellow;
        public const ConsoleColor LaderColor = ConsoleColor.Blue;
        public const ConsoleColor PlayerColor = ConsoleColor.Green;



        static void Main(string[] args)
        {
            SetWindowSize(WindowWIDTH, WindowHEIGHT);
            SetBufferSize(WindowWIDTH, WindowHEIGHT);
            CursorVisible = false;

            int[,] map = Map.Generator.IntMapGenerator(WIDTH, HEIGHT);
            int[,] EntityMap = new int[WIDTH, HEIGHT];
            Array.Copy(map, EntityMap, map.Length);
            Map.Generator.CharRender(map, intend , intend);


            int x = 2;
            int y = 5;
            int temp_x, temp_y;

            EntityMap[x, y] = PlayerSturct.IntModel;

            
            new PlayerSturct(x + intend, y + intend, PlayerColor).Draw();

            while(true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    
                    case ConsoleKey.UpArrow:
                        if (EntityLogic.Colission(map, Map.Wall.IntModel, x, y - 1) && !EntityLogic.Colission(map, Map.Lader.IntModel, x, y))
                        {
                            EntityMap = EntityLogic.MapSwap(map, EntityMap, x, y, x, y-1);
                            y--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (EntityLogic.Colission(map, Map.Wall.IntModel, x, y + 1) && !EntityLogic.Colission(map, Map.Lader.IntModel, x, y))
                        {
                            EntityMap = EntityLogic.MapSwap(map, EntityMap, x, y, x, y + 1);
                            y++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0 && EntityLogic.Colission(map, Map.Wall.IntModel, x - 1, y))
                        {
                            EntityMap = EntityLogic.MapSwap(map, EntityMap, x, y, x-1, y);
                            x--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < WIDTH - 1 && EntityLogic.Colission(map, Map.Wall.IntModel, x + 1, y))
                        {
                            EntityMap = EntityLogic.MapSwap(map, EntityMap, x, y, x+1, y);
                            x++;
                        }
                        break;
                }
                if (!EntityLogic.Colission(map, x, y + 1))
                {
                    temp_x = x; temp_y = y;
                    while (!EntityLogic.Colission(map, x, y + 1))
                    {
                        y++;
                    }
                    EntityMap = EntityLogic.MapSwap(map, EntityMap, temp_x, temp_y, x, y);
                }
                

                Map.Generator.CharRender(EntityMap, intend, intend);
            }
            
        }

    }
}