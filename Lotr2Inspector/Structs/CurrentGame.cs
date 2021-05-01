using Lotr2Inspector.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	public class CurrentGame : MemStruct
	{
		public CurrentGame()
		{
			Item = 0;
			Offset = 0x0;
			BaseStructAddress = 0x13F034;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			return new Dictionary<string, MemStructProperty>
			{
				{
					"current map",
					new MemStructProperty(0x0, 1)
				},

				{
					"selected town",
					new MemStructProperty(0x3D908, 1)
                }
			};
		}

		public String GetMap()
		{
			return GetMap(Get("current map"));
		}

		public static String GetMap(int mapIndex)
		{
			return "unknown"; // game.Lords2.Maps.Get(mapIndex.ToString(), false);
		}

		public String GetTown()
		{
			return "";
		}
	}
}
