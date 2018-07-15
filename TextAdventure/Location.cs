using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Location
    {
        private string roomTitle;
        private string roomDescription;
        private List<Exit> exits;
        private List<Item> inventory;
        private List<Npc> npcs;



        public Location(string title, string description)
        {
            roomTitle = title;
            roomDescription = description;
            exits = new List<Exit>();
            inventory = new List<Item>();
            npcs = new List<Npc>();
        }

        public override string ToString()
        {
            return roomTitle;
        }

        public void addExit(Exit exit)
        {
            exits.Add(exit);
        }

        public void removeExit(Exit exit)
        {
            if (exits.Contains(exit))
            {
                exits.Remove(exit);
            }
        }

        public List<Exit> getExits()
        {
            return new List<Exit>(exits);
        }

        public List<Item> getInventory()
        {
            return new List<Item>(inventory);
        }

        public void addItem(Item itemToAdd)
        {
            inventory.Add(itemToAdd);
        }

        public void removeItem(Item itemToRemove)
        {
            if (inventory.Contains(itemToRemove))
            {
                inventory.Remove(itemToRemove);
            }
        }

        public Item takeItem(string name)
        {
            foreach (Item _item in inventory)
            {
                if (_item.Name.ToLower() == name)
                {
                    Item temp = _item;
                    inventory.Remove(temp);
                    return temp;
                }
            }

            return null;
        }

        public List<Npc> GetNpcs()
        {
            return new List<Npc>(npcs);
        }

        public void AddNpc(Npc npc)
        {
            npcs.Add(npc);
        }

        public void RemoveNpc(Npc npc)
        {
            if (npcs.Contains(npc))
            {
                npcs.Remove(npc);
            }
        }

        public string getTitle()
        {
            return roomTitle;
        }

        public void setTitle(string title)
        {
            roomTitle = title;
        }

        public string getDescription()
        {
            return roomDescription;
        }

        public void setDescription(string description)
        {
            roomDescription = description;
        }
    }
}