using System;
using System.Collections.Generic;

namespace TextAdventure
{
    class Player
    {
        private int health;
        private List<Item> inventory;
        Random r = new Random();
        int damage;

        public Player(int _health)
        {
            inventory = new List<Item>();
            health = _health;
        }

        public int GetHealth()
        {
            return health;
        }

        public int ReduceHealth()
        {
            damage = r.Next(10,90);
            health = health - damage;
            return health;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }
    }
}