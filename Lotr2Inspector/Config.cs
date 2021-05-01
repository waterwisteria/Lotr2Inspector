using System;
using System.Collections.Generic;
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
		public const int TILES_X = 64;
		public const int TILES_Y = TILES_X;
		public const int HUMAN_PLAYER_INDEX = 1;

		// This should be somehow set by Maps which knows how many maps there are.
		// Not sure this would include user maps.
		public const int TOTAL_MAPS = 59;
	}
}
