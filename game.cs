using LudeRunnerCH.Entity;
using LudeRunnerCH.Entity.Player.Inventory;
using LudeRunnerCH.Map;
using LudeRunnerCH.Map.Entity;
using LudeRunnerCH.Map.MapLogic;
using LudeRunnerCH.Utils;
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

        public void InitMap()
        {

        }

        static void Main(string[] args)
        {
            //Console config
            SetWindowSize(WindowWIDTH, WindowHEIGHT);
            SetBufferSize(WindowWIDTH, WindowHEIGHT);
            CursorVisible = false;
            Generator.ConsoleSides(WIDTH + intend + 1, HEIGHT + intend + 1);

            //Map layers init
            MapObjects[,] MapObjecstMap = Generator.GeneratorMap(WIDTH, HEIGHT);
            EntityObject[,] EntityMap2 = new EntityObject[WIDTH, HEIGHT];
            Dictionary<Vector, Item> ItemMap = new Dictionary<Vector, Item>();

            //inventory init
            PInventory inven = new PInventory() { CountItems = 4 };
            Dictionary<int, Item> PlayerInventory = new Dictionary<int, Item>();

            int IvnventoryIntend = 2;
            int SlotWidth = 5;
            int SlotHeight = 7;
            GUI.GUIinventory GUIe = new GUI.GUIinventory(inven, 3, HEIGHT + 3, SlotHeight, SlotWidth, IvnventoryIntend, ConsoleColor.DarkGray);
            GUIe.RenderGUI();
            Vector[] guiSlots = GUIe.GetVectorsGUISlots();

            //items init
            Item coin = new Item(id: 1, name: "Гривня", description: "", maxStack: 99, model: '@', color: ConsoleColor.DarkMagenta, count:0);
            coin.Render(new Vector(6+intend, 5 + intend));
            ItemMap.Add(new Vector(6, 5), coin);

            
            //Player init
            EntityObject player = new EntityObject(model: 'I', ConsoleColor.Green, name: "Игрок", id: 1, vector: new Vector(2,5));
            EntityMap2[2,5] = player;
            player.Draw(new Vector(2 + intend, 5 + intend));
            PlayerInventory.Add(0, coin);


            Generator.RenderMap(MapObjecstMap, intend);
            int x, y;
            while (true)
            {
                //player manager
                x = player.Vector.x ;
                y = player.Vector.y ;
                EntityMap2[x, y] = null;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.Clear(new Vector(x + intend, y + intend));

                //Coin add in a inventory 
                if (ItemMap.ContainsKey(new Vector(x, y)))
                {
                    PlayerInventory[0] = coin.ChangeCount(coin.Count + 1);
                }

                //Player controll
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y - 1) && MapObjecstMap[x, y - 1] != null && y > 0)
                        {
                            if (MapObjecstMap[x, y-1].Name == "Lader")
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                                y--;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y+1) && MapObjecstMap[x, y + 1] != null && y < WIDTH-1)
                        {
                            if (MapObjecstMap[x, y + 1].Name == "Lader")
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x+intend, y+intend));
                                y++;
                            }
                            
                        }
                        break; 
                    case ConsoleKey.RightArrow:
                        if (x < WIDTH - 1 && !EntityLogic.ColissionWithObject(player, MapObjecstMap, "Wall", x +1,y) )
                        {
                            if (MapObjecstMap[x, y] != null)
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                            }
                            
                            
                            x++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0 && !EntityLogic.ColissionWithObject(player, MapObjecstMap, "Wall", x-1,y) )
                        {
                            if (MapObjecstMap[x, y] != null)
                            {
                                MapObjecstMap[x, y].Draw(new Vector(x + intend, y + intend));
                            }

                            x--;
                        }
                        break;
                };

                //Gravitation 
                if (!EntityLogic.Colission(EntityMap2, MapObjecstMap, x, y + 1))
                {
                    int yy = y;
                    while (MapObjecstMap[x,yy+1] == null)
                    {
                        yy++;
                    }
                    y = yy;
                }

                //Inventory render
                for (int i = 0; i < guiSlots.Length; i++)
                {
                    if (PlayerInventory.ContainsKey(i))
                    {
                        ForegroundColor = ConsoleColor.White;
                        SetCursorPosition(guiSlots[i].x, guiSlots[i].y);
                        Write(PlayerInventory[i].Count);
                        PlayerInventory[i].Render(new Vector(guiSlots[i].x+2, guiSlots[i].y+1));
                    }
                    
                }
                //Player render
                EntityMap2[x, y] = player;
                player.Draw(new Vector(x + intend,y + intend));
                player.Vector = new Vector(x,y);


            }
            Console.ReadLine();
        }

    }
}