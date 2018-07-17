using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Npc
    {
        private string name;
        private bool fightable;
        private string description;
        private string answer;
        private int health;
        private Location currentLocation;
        private List<Item> inventory;
        Random r = new Random();
        int damage;
        

        public Npc(string _name, string _description, bool _fightable, string _answer, int _health, Location _currentLocation)
        {
            name = _name;
            fightable = _fightable;
            description = _description;
            answer = _answer;
            health = _health;
            currentLocation = _currentLocation;
            inventory = new List<Item>();
        }
    
        public void ChangeCurrentRoom(Location location)
        {
            currentLocation = location;
            return;
        }

        public Location GetCurrentRoom()
        {
            return currentLocation;
        }

        public string GetName()
        {
            return name;
        }

        public bool GetFightable()
        {
            return fightable;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetAnswer()
        {
            return answer;
        }

        public int GetHealth()
        {
            return health;
        }

        public void ReduceHealth()
        {
            damage = r.Next(10,90);
            health = health - damage;
        }

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }
    }
}