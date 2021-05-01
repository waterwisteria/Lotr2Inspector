using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * A single entity that lists all maps (not itemized)
 * 
 */
namespace Lotr2Inspector.Structs
{
	// List of towns for a given map, must first offset into the proper map area and then get the towns
	public class MapTowns : StringArray
	{
		public static List<List<String>> Towns = new List<List<String>>();

		public MapTowns()
		{
			Item = 0;
			Offset = 0x2371;
			BaseStructAddress = 0x195FEC;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		public static void FindMapsTowns()
		{
			// Find all the maps towns delimited by multiple CTY#.
			// The first town of every map seems out of bounds for the game,
			// so skip them.
			// Sample: "out of bound town", "town 1", "town 2", "CTY5", "CTY6", etc.

			if(Towns.Count() == 0)
			{
				int cursor = 0;
				MapTowns mt = new MapTowns();

				try
				{
					// For every map
					while(cursor < mt.Count())
					{
						List<String> towns = new List<String>();

						// Keep adding until we get CTY#
						while(mt.Get(cursor.ToString(), true).StartsWith("CTY") == false)
						{
							towns.Add(mt.Get(cursor.ToString(), true));

							cursor++;
						}

						if(towns.Count() > 0)
						{
							Towns.Add(towns);
						}

						// Skip all CTY#
						while(mt.Get(cursor.ToString(), true).StartsWith("CTY") && mt.Get(cursor.ToString(), true) != "CTY0 unused map here")
						{
							cursor++;
						}

						// Keep consistency with map ids in Towns
						if(mt.Get(cursor.ToString(), true) == "CTY0 unused map here")
						{
							Towns.Add(new List<String>());
							cursor++;
						}
					}
				}
				
				catch(Exception e)
				{
					// We don't care about key don exist exception, we're throught
					// hope that's the actual exception... :|
				}
			}
		}
	}
}
