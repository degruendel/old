using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class Door
    {
		public enum Directions
		{
			North, South, East, West
		};

		public static string[] shortDirections = {"N", "S", "E", "W"};

		private Room leadsTo;
		private Directions direction;
		private string directionName;
        private bool locked;

		

		public Door(Directions _direction, Room newLeadsTo, string _directionName, bool _locked)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
            directionName = _directionName;
            locked = _locked;
        }

		public override string ToString()
		{
			return direction.ToString();
		}

		public void setDirection(Directions _direction)
		{
			direction = _direction;
		}

		public Directions getDirection()
		{
			return direction;
		}

		public string getShortDirection()
		{
			return shortDirections[(int)direction].ToLower();
		}

		public void setLeadsTo(Room _leadsTo)
		{
			leadsTo = _leadsTo;
		}

		public Room getLeadsTo()
		{
			return leadsTo;
		}
    }
}