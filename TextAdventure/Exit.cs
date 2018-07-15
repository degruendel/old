using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Exit
    {
		public enum Directions
		{
			North, South, East, West
		};

		public static string[] shortDirections = {"N", "S", "E", "W"};

		private Location leadsTo;
		private Directions direction;

		public Exit(Directions _direction, Location newLeadsTo)
		{
			direction = _direction;
			leadsTo = newLeadsTo;
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

		public void setLeadsTo(Location _leadsTo)
		{
			leadsTo = _leadsTo;
		}

		public Location getLeadsTo()
		{
			return leadsTo;
		}
    }
}