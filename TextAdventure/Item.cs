using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Item
    {

        public string name;
        private bool useable;
        private string description;

        public Item(string _name, bool canUse, string _description)
        {
            name = _name;
            useable = canUse;
            description = _description;
        }

        public string Name
        {
            get { return name; }
        }

        public bool Useable
        {
            get { return useable; }
        }

        public string Description
        {
            get { return description; }
        }
    }
}