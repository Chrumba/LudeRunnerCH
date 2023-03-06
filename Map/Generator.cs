using LudeRunnerCH.Map.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LudeRunnerCH.Map.Lader;

namespace LudeRunnerCH.Map
{
    public class Generator
    {
        public static void CharRender(int[,] IntMap, int x_indent, int y_indent)
        {
            for (int y = 0; y < game.HEIGHT; y++)
            {
                for (int x = 0; x < game.WIDTH; x++)
                {
                    if (IntMap[x, y] == Nothing.IntModel)
                    {
                        new Nothing(x + x_indent, y + y_indent).Draw();
                    }
                    if (IntMap[x,y] == Wall.IntModel)
                    {
                        new Wall(x + x_indent, y + y_indent, game.WallColor).Draw();
                    }
                    if (IntMap[x, y] == Lader.IntModel)
                    {
                        new Lader(x + x_indent, y + y_indent, game.LaderColor).Draw();
                    }
                    if (IntMap[x, y] == PlayerSturct.IntModel)
                    {
                        new PlayerSturct(x + x_indent, y + y_indent, game.PlayerColor).Draw();
                    }
                }
            }
        }


        public static int[,] IntMapGenerator(int width, int height)
        {
            int[,] map = new int[width, height];
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x,y]= Nothing.IntModel;
                }

            }

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y+=6)
                {
                    map[x, y] = Wall.IntModel;
                }

            }

            for (int x = 1; x < map.GetLength(0); x+=10)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = Lader.IntModel;
                }

            }


            return map;
        }

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


    }
}
