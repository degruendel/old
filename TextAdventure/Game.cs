using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Game
    {
        Location currentLocation;

        public bool isRunning = true;
        private bool _gameOver = false;

        private List<Item> inventory;
        private Npc currentNpc;
        private Npc currentEnemy;
        private List<Npc> allNpcs;

        public Game()
        {
            inventory = new List<Item>();
            allNpcs = new List<Npc>();

            Console.WriteLine("Welcome adventurer, prepare yourself for a fantastical journey into the unknown.");
            Console.WriteLine("Press 'h' or type 'help' for help.");

            //Rooms

            //Storage
            Location storage = new Location("Storage", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            storage.addItem(rock);
            Npc butler = new Npc("Alfred Sharp", "Grey hair, a small mustache and a perfectly aligned suit dressed that man. He looked exactly like you would imagine a butler to look like.", true, "Well Mr. Grifford, despite this terrible happenings today, i have much work to do. Because of the absence of Lord Charlie Battenberg till tomorrow. And before you ask, i have been in the service Room this whole day, assisting Lady Battenberg. The only strange thing, exept the 'incident', is that my precious cleaning mop is missing since this morning.", 100, storage);

            //Corridor
            Location corridor = new Location("Corridor", "You have reached the end of a long dark hallway. You can\nsee nowhere to go but back.");
            Item window = new Item("window", false, "A single sheet of glass. It seems sealed up.");
            corridor.addItem(window);

            //Cannonleft
            Location cannon_left = new Location("Cannonroom left side", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            //Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            cannon_left.addItem(rock);

            //Cannonright
            Location cannon_right = new Location("Cannonroom right side", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            //Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            cannon_right.addItem(rock);

            //Deck
            Location deck = new Location("Deck", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            //Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            deck.addItem(rock);

            //Control
            Location control = new Location("Steering", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            //Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            control.addItem(rock);

            //Captainsroom
            Location captainsroom = new Location("Captainsrooms", "You stand at the entrance of a long hallway. The hallways gets darker\nand darker, and you cannot see what lies beyond. To the east\nis an old oaken door, unlocked and beckoning.");
            //Item rock = new Item("rock", true, "A rather jagged rock, slightly smaller than a fist.");
            captainsroom.addItem(rock);

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

            allNpcs.Add(butler);

            currentLocation = deck;
            showLocation();
        }

        public void showLocation()
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
            if(currentLocation.GetNpcs().Count > 0)
                {
                    Console.WriteLine("\nAnd i remember:");
                    for(int i = 0; i < currentLocation.GetNpcs().Count; i++)
                    {
                        Console.WriteLine(currentLocation.GetNpcs()[i].GetName());
                    }
                    Console.Write("being in the " + currentLocation.getTitle() + "\n");
                }

            Console.WriteLine("\nAvailable Exits: \n");

            foreach (Exit exit in currentLocation.getExits())
            {
                Console.WriteLine(exit.getDirection());
            }

            Console.WriteLine();
        }

        // TODO: Implement the input handling algorithm.
        public void doAction(string command)
        {
            //Help command is NEW
            if (command == "help" || command == "h")
            {
                Console.WriteLine("Welcome to this Text Adventure!");
                Console.WriteLine("'look(l)':               Shows you the room, its exits, and any items it contains.");
                Console.WriteLine("'take(t) [itemname]':    Attempts to pick up an item.");
                Console.WriteLine("'inventory(i)':          Allows you to see the items in your inventory.");
                Console.WriteLine(" 'drop(d) [itemname]:    Lets you drop a specific item from your inventory.");
                Console.WriteLine("'quit(q)':               Quits the game.");
                Console.WriteLine();
                Console.WriteLine("Directions can be input as either the full word, or the abbriviation, \ne.g. 'north or n'");
                return;
            }

            //If statement to access the player inventory
            //This can't be changed a great deal
            if ((command == "inventory") || (command == "i"))
            {
                showInventory();
                Console.WriteLine();
                return;
            }

            //If statement for player to pick up objects
            //This works fine. Change how the function works later though.
            if (command.Length >= 4 && command.Substring(0, 4) == "take")
            {
                if (command == "take")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(5)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(5) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(5)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "This item does not exist.\n");
                    return;
                }
            }

            if (command.Length >= 1 && command.Substring(0, 1) == "t")
            {
                if (command == "t")
                {
                    Console.WriteLine("\nPlease specify what you would like to pick up.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(2)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(2)));
                    Console.WriteLine("\nYou pick up the " + command.Substring(2) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(2)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nYou cannot pick up the " + command.Substring(2) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + "This item does not exist.\n");
                    return;
                }
            }

            if (command == "look" || command == "l")
            {
                showLocation();
                if (currentLocation.getInventory().Count == 0)
                {
                    Console.WriteLine("There are no items of interest in the room.\n");
                }
                return;
            }

            if ((command.Length >= 4 && command.Substring(0, 4) == "drop"))
            {
                if (command == "drop")
                {
                    Console.WriteLine("\nPlease specify what you would like to drop.\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.Substring(5)))
                {

                    currentLocation.addItem(inventory.Find(x => x.Name == command.Substring(5)));
                    inventory.Remove(currentLocation.getInventory().Find(x => x.Name == command.Substring(5)));
                    Console.WriteLine("\nI dropped the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(5) + " does not exist.\n");
                    return;
                }
            }

            if ((command.Length >= 1 && command.Substring(0, 1) == "d"))
            {
                if (command == "d")
                {
                    Console.WriteLine("\nPlease specify what you would like to drop.\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.Substring(2)))
                {

                    currentLocation.addItem(inventory.Find(x => x.Name == command.Substring(2)));
                    inventory.Remove(currentLocation.getInventory().Find(x => x.Name == command.Substring(2)));
                    Console.WriteLine("\nI dropped the " + command.Substring(2) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(2) + " does not exist.\n");
                    return;
                }
            }



            if (moveRoom(command))
                return;

            Console.WriteLine("\nInvalid command, are you confused?\n");
        }

        private bool moveRoom(string command)
        {
            foreach (Exit exit in currentLocation.getExits())
            {
                if (command == exit.ToString().ToLower() || command == exit.getShortDirection().ToLower())
                {
                    currentLocation = exit.getLeadsTo();
                    Console.WriteLine("\nYou move " + exit.ToString() + " to the:\n");
                    showLocation();
                    return true;
                }
            }
            return false;
        }



        private void showInventory()
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

        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            // instantly check for a quit
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }


            if (!_gameOver)
            {
                // otherwise, process commands.
                doAction(currentCommand);
            }
            else
            {
                Console.WriteLine("\nNope. Time to quit.\n");
            }
        }
    }
}