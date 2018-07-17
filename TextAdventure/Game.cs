using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Game
    {
        Location currentLocation;
        public bool isRunning = true;
        private bool _gameOver = false;
        private List<Item> inventory;
        private Npc currentNpc;
        private Npc currentEnemy;
        private List<Npc> allNpcs;
        private List<Location> allLocations;
        private int turnCounter;
        private Player player;

        public Game()
        {
            inventory = new List<Item>();
            allNpcs = new List<Npc>();
            turnCounter = 0;
            Player player = new Player(100);

            Console.WriteLine();
            Console.WriteLine("Welcome pirate on this adventure!");
            Console.WriteLine("Type 'help(h)' for the controls.");

            //Rooms

            //Storage
            Location storage = new Location("Storage", "This dark room is the storage of the ship. Watch out the ceiling is very low!");
            Item barrel = new Item("barrel", false, "This barrel contains gunpowder. But it looks like this is way to heavy for me.");
            storage.addItem(barrel);
            Npc parrot = new Npc("Parrot", "Cute little feathered friend. Maybe he can talk?", true, "Korax, korax. Arrrr.", 100, storage);
            storage.AddNpc(parrot);

            //Corridor
            Location corridor = new Location("Corridor", "This is the corridor underneath the deck. From here you can go to the storage ('north(n)') or to the cannonrooms ('west(w)' or 'east(e)').");
            Item bucket = new Item("bucket", true, "It't very difficult to find a reliable cleaning pirat. Isn't that a job for you?");
            corridor.addItem(bucket);

            //Cannonleft
            Location cannon_left = new Location("Cannonroom left side", "Wow look at these big cannons. A little bit gunpowder here and a cannonball there and we should have a nice little firework.");
            Item cannon1 = new Item("cannon 1", false, "Very impressive.");
            Item cannon2 = new Item("cannon 2", false, "Does this cannon look different from the others?");
            Item cannon3 = new Item("cannon 3", false, "I really want to try out this one.");
            cannon_left.addItem(cannon1);
            cannon_left.addItem(cannon2);
            cannon_left.addItem(cannon3);

            //Cannonright
            Location cannon_right = new Location("Cannonroom right side", "Did you ever saw such big cannons? I did't.");
            Item cannon4 = new Item("cannon 4", false, "Booom... Just kidding.");
            Item cannon5 = new Item("cannon 5", false, "I wonder what this lever does.");
            Item cannon6 = new Item("cannon 6", false, "This looks broken.");
            cannon_right.addItem(cannon4);
            cannon_right.addItem(cannon5);
            cannon_right.addItem(cannon6);

            //Deck
            Location deck = new Location("Deck", "From here you can smell the salted water and watch the sunset. Romantic huh?");
            Item telescope = new Item("telescope", true, "Maybe someone lost it. There is an island, right there!");
            deck.addItem(telescope);

            //Control
            Location control = new Location("Steering", "From here the steeringman can maneuver the ship. By the way where is he? Oh watch out we are swimming into a rock soon!");
            Item map = new Item("map", true, "This map shows us all the hidden treasures around here. Maybe we should find an island.");
            Item pistol = new Item("pistol", true, "A gun? Yeah. But where is the ammunition?");
            control.addItem(map);
            control.addItem(pistol);

            //Captainsroom
            Location captainsroom = new Location("Captainsrooms", "Wow really luxurious. One day I will become captain.");
            Item ammunition = new Item("ammunition", true, "I know for what this is...");
            captainsroom.addItem(ammunition);

            //Exits

            //Storage
            storage.addExit(new Exit(Exit.Directions.South, corridor));

            //Corridor
            corridor.addExit(new Exit(Exit.Directions.North, storage));
            corridor.addExit(new Exit(Exit.Directions.South, deck));
            corridor.addExit(new Exit(Exit.Directions.West, cannon_left));
            corridor.addExit(new Exit(Exit.Directions.East, cannon_right));

            //Deck
            deck.addExit(new Exit(Exit.Directions.North, corridor));
            deck.addExit(new Exit(Exit.Directions.South, control));
            deck.addExit(new Exit(Exit.Directions.East, captainsroom));
            deck.addExit(new Exit(Exit.Directions.West, captainsroom));

            //Control
            control.addExit(new Exit(Exit.Directions.North, deck));

            //Captainsroom
            captainsroom.addExit(new Exit(Exit.Directions.West, deck));
            captainsroom.addExit(new Exit(Exit.Directions.East, deck));

            //Cannonleft
            cannon_left.addExit(new Exit(Exit.Directions.East, corridor));

            //Cannonright
            cannon_right.addExit(new Exit(Exit.Directions.West, corridor));

            //NPCs
            allNpcs.Add(parrot);

            currentLocation = deck;
            ShowLocation();
        }

        //showLocation
        public void ShowLocation()
        {
            Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
            Console.WriteLine(currentLocation.getDescription());

            if (currentLocation.getInventory().Count > 0)
            {
                Console.WriteLine("\nThe room contains the following:\n");

                for (int i = 0; i < currentLocation.getInventory().Count; i++)
                {
                    Console.WriteLine(currentLocation.getInventory()[i].Name);
                }
            }
            if (currentLocation.GetNpcs().Count > 0)
            {
                Console.WriteLine("\nAnd there is:");
                for (int i = 0; i < currentLocation.GetNpcs().Count; i++)
                {
                    Console.WriteLine(currentLocation.GetNpcs()[i].GetName());
                }
            }

            Console.WriteLine("\nAvailable Exits: \n");

            foreach (Exit exit in currentLocation.getExits())
            {
                Console.WriteLine(exit.getDirection());
            }

            Console.WriteLine();
        }

        //Commands
        public void Action(string command)
        {
            //Help
            if (command == "help" || command == "h")
            {
                Console.WriteLine("'look(l)':               Shows you the room, its exits, and any items it contains.");
                Console.WriteLine("'take(t) [itemname]':    Attempts to pick up an item.");
                Console.WriteLine("'inventory(i)':          Allows you to see the items in your inventory.");
                Console.WriteLine("'drop(d) [itemname]':    Lets you drop a specific item from your inventory.");
                Console.WriteLine("'look at [itemname]':    Lets you go closer to an item.");
                Console.WriteLine("'speak(sp) [name]':      Talk to a character.");
                Console.WriteLine("'quit(q)':               Quits the game.");
                Console.WriteLine();
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'north or n'");
                return;
            }

            //Inventory
            if ((command == "inventory") || (command == "i"))
            {
                ShowInventory();
                Console.WriteLine();
                return;
            }

            //Take
            if (command.Length >= 4 && command.Substring(0, 4) == "take")
            {
                if (command == "take")
                {
                    Console.WriteLine("\nWhat would you like to pick up?\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(5)));
                    Console.WriteLine("\nYou picked up the " + command.Substring(5) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "Can't find this item here.\n");
                    return;
                }
            }

            //Take(t)
            if (command.Length >= 1 && command.Substring(0, 1) == "t")
            {
                if (command == "t")
                {
                    Console.WriteLine("\nWhat would you like to pick up?\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(2)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(2)));
                    Console.WriteLine("\nYou picked up the " + command.Substring(2) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(2)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(2) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "Can't find this item here.\n");
                    return;
                }
            }

            //Look
            if (command == "look" || command == "l")
            {
                ShowLocation();
                if (currentLocation.getInventory().Count == 0)
                {
                    Console.WriteLine("It's too dark to see any items.\n");
                }
                return;
            }

            //Drop
            if ((command.Length >= 4 && command.Substring(0, 4) == "drop"))
            {
                if (command == "drop")
                {
                    Console.WriteLine("\nWhat would you like to drop?\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.Substring(5)))
                {

                    currentLocation.addItem(inventory.Find(x => x.Name == command.Substring(5)));
                    inventory.Remove(currentLocation.getInventory().Find(x => x.Name == command.Substring(5)));
                    Console.WriteLine("\nYou dropped the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(5) + " does not exist.\n");
                    return;
                }
            }

            //Drop(d)
            if ((command.Length >= 1 && command.Substring(0, 1) == "d"))
            {
                if (command == "d")
                {
                    Console.WriteLine("\nWhat would you like to drop?\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.Substring(2)))
                {

                    currentLocation.addItem(inventory.Find(x => x.Name == command.Substring(2)));
                    inventory.Remove(currentLocation.getInventory().Find(x => x.Name == command.Substring(2)));
                    Console.WriteLine("\nYou dropped the " + command.Substring(2) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(2) + " does not exist.\n");
                    return;
                }
            }

            //Look at
            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
                if (command == "look at")
                {
                    Console.WriteLine("\nPlease specify what you wish to look at.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) || inventory.Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains(command.Substring(8))).Description + "\n");
                    return;
                }
                if(currentLocation.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))))
                    {
                        Console.WriteLine("\n" + currentLocation.GetNpcs().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))).GetDescription() + "\n");
                        return;
                    }
                else
                {
                    Console.WriteLine("\nThat item does not exist in this location or your inventory.\n");
                    return;
                }
            }

            //Speak
            if((command.Length >= 5) && (command.Substring(0, 5) == "speak"))
            {
                if(command == "speak")
                    {
                        Console.WriteLine("\nI can't speak with myself.");
                        return;
                    }
                if(currentLocation.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(6))))
                    {
                        Console.WriteLine("\n" + currentLocation.GetNpcs().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(6))).GetAnswer() + "\n");
                        return;
                    }
            }

            //Speak(s)
            if((command.Length >= 2) && (command.Substring(0, 2) == "sp"))
            {
                if(command == "sp")
                    {
                        Console.WriteLine("\nI can't speak with myself.");
                        return;
                    }
                if(currentLocation.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(3))))
                    {
                        Console.WriteLine("\n" + currentLocation.GetNpcs().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(3))).GetAnswer() + "\n");
                        return;
                    }
            }

            //Attack
            if((command.Length >= 6) && (command.ToLower().Substring(0, 6) == "attack"))
            {
                if(command == "attack")
                    {
                        Console.WriteLine("\nYou can't attack nobody.");
                        return;
                    }
                if(currentLocation.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(7))))
                {
                    currentEnemy = currentLocation.GetNpcs().Find(x => x.GetName().ToLower() == command.ToLower().Substring(7));

                    if(currentEnemy.GetFightable() == true)
                    {
                        if(player.GetHealth() > 0)
                        {
                            if(currentEnemy.GetHealth() > 0)
                            {
                                currentEnemy.ReduceHealth();
                                player.ReduceHealth();
                            } 
                        }
                        if(player.GetHealth() > 0)
                        {
                            if(currentEnemy.GetHealth() <= 0)
                            {
                                Console.WriteLine(currentEnemy.GetName() + " died.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You died!");
                            _gameOver = true;
                            Update();
                        }
                    }
                }
            }

            //moving
            if (MoveRoom(command))
                return;

            Console.WriteLine("\nThis can't be done. Try 'help(h)' instead.\n");
        }

        //moving
        private bool MoveRoom(string command)
        {
            foreach (Exit exit in currentLocation.getExits())
            {
                if (command == exit.ToString().ToLower() || command == exit.getShortDirection().ToLower())
                {
                    currentLocation = exit.getLeadsTo();
                    Console.WriteLine("\nYou move " + exit.ToString() + " to the:\n");
                    ShowLocation();
                    return true;
                }
            }
            return false;
        }


        //NPC
        /* public void MoveNpc(string npc, string room)
        {
            Npc _currentNpc = allNpcs.Find(x => x.GetName().Equals(npc));
            Location npcCurrentRoom = allRooms.Find(y => y.Equals(allNpcs.Find(x => x.GetName().Equals(npc)).GetCurrentRoom()));
            Location npcNewRoom = allRooms.Find(x => x.getTitle().Equals(room));
            npcCurrentRoom.RemoveNpc(_currentNpc);
            npcNewRoom.AddNpc(_currentNpc);
            _currentNpc.ChangeCurrentRoom(npcNewRoom);
            return;
        } */

        /* public void Events(string command)
        {
            if (turnCounter > 3)
            {
                MoveNpc("Alfred Sharp", "Deck");
            }
            return;
        } */

        //show the inventory
        private void ShowInventory()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nYour bag is empty.\n");
            }
        }

        //update game
        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            //quit game
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }

            if (!_gameOver)
            {
                Action(currentCommand);
                turnCounter = turnCounter + 1;
            }
            else
            {
                Console.WriteLine("\nGame over.\n");
            }
        }
    }
}