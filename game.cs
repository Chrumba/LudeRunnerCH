using LudeRunnerCH.Entity;
using LudeRunnerCH.Entity.Player.Inventory;
using LudeRunnerCH.Map;
using LudeRunnerCH.Map.Entity;
using LudeRunnerCH.Map.MapLogic;
using LudeRunnerCH.Utils;
using System.Collections.Generic;
using static System.Console;
namespace LudeRunnerCH
{
    public class game
    {

        public const int WIDTH = 60;
        public const int HEIGHT = 30;
        
        public const int WindowWIDTH = 70;
        public const int WindowHEIGHT = 50;

        public const int intend = 1;

        public const ConsoleColor WallColor = ConsoleColor.Yellow;
        public const ConsoleColor LaderColor = ConsoleColor.Blue;
        public const ConsoleColor PlayerColor = ConsoleColor.Green;

        public static bool GameStop = false;
        public static Queue<AnyVector<MapObjects, Logic.Time>> DiggedObjects = new();

        public static void InitMap()
        {
            //Console config
            Generator.ConsoleSides(WIDTH + intend + 1, HEIGHT + intend + 1);

            //Map layers init
            MapObjects[,] MapObjecstMap = Generator.GeneratorMap(WIDTH, HEIGHT);
            EntityObject[,] EntityMap2 = new EntityObject[WIDTH, HEIGHT];
            Dictionary<Vector, Item> ItemMap = new Dictionary<Vector, Item>();

            //inventory init
            PInventory inven = new PInventory() { CountItems = 4 };
            Dictionary<int, Item> PlayerInventory = new Dictionary<int, Item>();

            int IvnventoryIntend = 2;
            int SlotWidth = 4;
            int SlotHeight = 5;
            GUI.GUIinventory GUIe = new GUI.GUIinventory(inven, 3, HEIGHT + 3, SlotHeight, SlotWidth, IvnventoryIntend, ConsoleColor.DarkGray);
            GUIe.RenderGUI();
            Vector[] guiSlots = GUIe.GetVectorsGUISlots();

            //items init
            Item coin = new Item(id: 1, name: "Гривня", description: "", maxStack: 99, model: '@', color: ConsoleColor.DarkMagenta, count: 0);
            coin.Render(new Vector(6 + intend, 5 + intend));
            ItemMap.Add(new Vector(6, 5), coin);


            //Player init
            EntityObject player = new EntityObject(model: 'I', ConsoleColor.Green, name: "Gamer", id: 1, vector: new Vector(2, 5));
            EntityMap2[2, 5] = player;
            player.Draw(new Vector(2 + intend, 5 + intend));
            PlayerInventory.Add(0, coin);


            Generator.RenderMap(MapObjecstMap, intend);
            int x, y;
            bool inventorChanged = true;
             

            while (!GameStop)
            {
                //player manager
                x = player.Vector.x;
                y = player.Vector.y;
                EntityMap2[x, y] = null;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.Clear(new Vector(x + intend, y + intend));



                //Player controll
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y - 1) && MapObjecstMap[x, y - 1] != null && y > 0)
                        {
                            if (MapObjecstMap[x, y - 1].Name == "Lader")
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                                y--;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y + 1) && MapObjecstMap[x, y + 1] != null && y < WIDTH - 1)
                        {
                            if (MapObjecstMap[x, y + 1].Name == "Lader")
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                                y++;
                            }

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (x < WIDTH - 1 && !EntityLogic.ColissionWithObject(player, MapObjecstMap, "Wall", x + 1, y))
                        {
                            if (MapObjecstMap[x, y] != null)
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                            }


                            x++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0 && !EntityLogic.ColissionWithObject(player, MapObjecstMap, "Wall", x - 1, y))
                        {
                            if (MapObjecstMap[x, y] != null)
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                            }

                            x--;
                        }
                        break;

                    case ConsoleKey.Z:
                        if (MapObjecstMap[x - 1, y + 1].Name == "Wall" && keyInfo.Modifiers == 0)
                        {
                            ConsoleKeyInfo arrowKey = Console.ReadKey(true);

                            switch (arrowKey.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    MapObjecstMap[x - 1, y + 1].Hides(intend);
                                    
                                    DiggedObjects.Enqueue(new AnyVector<MapObjects, Logic.Time>(MapObjecstMap[x - 1, y + 1], new Logic.Time()));
                                    break;
                                case ConsoleKey.RightArrow:
                                    MapObjecstMap[x + 1, y + 1].Hides(intend);
                                    DiggedObjects.Enqueue(new AnyVector<MapObjects, Logic.Time>(MapObjecstMap[x + 1, y + 1], new Logic.Time()));
                                    break;
                                case ConsoleKey.DownArrow:
                                    MapObjecstMap[x, y + 1].Hides(intend);
                                    DiggedObjects.Enqueue(new AnyVector<MapObjects, Logic.Time>(MapObjecstMap[x, y + 1], new Logic.Time()));
                                    break;
                            }
                            DiggedObjects.First().Second.SetTimer(4);
                        }

                        break;
                };

                if (DiggedObjects.Count != 0)
                {
                    
                    if (DiggedObjects.First().Second.TimeElapsed1())
                    {
                        DiggedObjects.First().First.SetHide(false);
                        DiggedObjects.First().First.Draw(new Vector(DiggedObjects.First().First.Vector.x + intend, DiggedObjects.First().First.Vector.y + intend));
                        DiggedObjects.Dequeue();
                    }
                }


                //Coin add in a inventory 
                if (ItemMap.ContainsKey(new Vector(x, y)))
                {
                    PlayerInventory[0] = coin.ChangeCount(coin.Count + 1);
                    inventorChanged = true;
                }


                //Gravitation 
                if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y + 1) || MapObjecstMap[x,y+1].GetHide())
                {
                    int yy = y;
                    while (MapObjecstMap[x, yy + 1] == null || MapObjecstMap[x, yy + 1].GetHide())
                    {
                        yy++;
                    }
                    y = yy;
                }

                //Inventory render
                if (inventorChanged)
                {
                    for (int i = 0; i < guiSlots.Length; i++)
                    {
                        if (PlayerInventory.ContainsKey(i))
                        {
                            ForegroundColor = ConsoleColor.White;
                            SetCursorPosition(guiSlots[i].x, guiSlots[i].y);
                            Write(PlayerInventory[i].Count);
                            PlayerInventory[i].Render(new Vector(guiSlots[i].x + 2, guiSlots[i].y + 1));
                        }

                    }
                }
                inventorChanged = false;


                //Player render
                EntityMap2[x, y] = player;
                player.Draw(new Vector(x + intend, y + intend));
                player.Vector = new Vector(x, y);


            }
            Console.ReadLine();
        }





        static void Main(string[] args)
        {
            SetWindowSize(WindowWIDTH, WindowHEIGHT);
            SetBufferSize(WindowWIDTH, WindowHEIGHT);
            CursorVisible = false;

            InitMap();
        }

    }
}