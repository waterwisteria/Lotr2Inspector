using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector
{
	/**
	 * The game static data
	 * 
	 */
	public class Config
	{
		public const int MAX_TOWNS = 16;
		public const int MAX_PLAYERS = 5; // I don't get the feeling that indie lords get to be a player otherwise the count should be MAX_TOWNS - main player
		public const int TILES_X = 64;
		public const int TILES_Y = TILES_X;
		public const int HUMAN_PLAYER_INDEX = 1;

		// This should be somehow set by Maps which knows how many maps there are.
		// Not sure this would include user maps.
		public const int TOTAL_MAPS = 59;

		public static Color[] Colors = new Color[]
		{
			Color.FromArgb(0, 200, 0), // green
			Color.FromArgb(156, 0, 16), // red
			Color.FromArgb(252, 215, 3), // yellow
			Color.FromArgb(99, 99, 99), // grey
			Color.FromArgb(84, 0, 120), // purle
			Color.FromArgb(0, 39, 145), // blue
		};
	}
}
