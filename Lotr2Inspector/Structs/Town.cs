using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	public class Town : MemStruct
	{
		public const int RATION_MAX = 5;

		public Town(int item)
		{
			Item = item;
			Offset = 0x300;
			BaseStructAddress = 0x13FCB5;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		public String getRation(int ration)
		{
			String s = "unknown";

			switch(ration)
			{
				case 0:
					s = "none";
				break;

				case 1:
					s = "Quarter";
				break;

				case 2:
					s = "Half";
				break;

				case 3:
					s = "Normal";
				break;

				case 4:
					s = "Double";
					break;

				case 5:
					s = "Triple";
				break;
			}

			return s;
		}

        protected override Dictionary<string, MemStructProperty> StructProperties()
        {
			return new Dictionary<string, MemStructProperty>
			{
				{
					"owner",
					new MemStructProperty(0x0, 1, false)
				},
				{
					"color",
					new MemStructProperty(0x2, 1, false)
				},
				{
					"peasant slider",
					new MemStructProperty(0x3, 1, false)
				},
				{
					"health",
					new MemStructProperty(0x4, 1, false)
				},
				{
					"happiness",
					new MemStructProperty(0x7, 1, false)
				},
				{
					"happiness last season",
					new MemStructProperty(0x8, 1, false)
				},
				{
					"population",
					new MemStructProperty(0x1F, 4, false)
				},
				{
					"population last season",
					new MemStructProperty(0x23, 4, false)
				},
				{
					"taxes",
					new MemStructProperty(0xB4, 1, false)
				},
				{
					"farmers",
					new MemStructProperty(0xBF, 4, false)
				},
				{
					"farmers needed",
					new MemStructProperty(0xC7, 4, false)
				},
				{
					"dairy maids",
					new MemStructProperty(0xCB, 4, false)
				},
				{
					"dairy maids needed?",
					new MemStructProperty(0xD3, 4, false)
				},
				{
					"serfs",
					new MemStructProperty(0xD7, 4, false)
				},
				{
					"builders",
					new MemStructProperty(0xE3, 1, false)
				},
				{
					"miners",
					new MemStructProperty(0xEF, 1, false)
				},
				{
					"mine state",
					new MemStructProperty(0xF9, 1, false)
				},
				{
					"quarriers",
					new MemStructProperty(0xFB, 1, false)
				},
				{
					"quarry state",
					new MemStructProperty(0x105, 1, false)
				},
				{
					"foresters",
					new MemStructProperty(0x107, 1, false)
				},
				{
					"forestry state",
					new MemStructProperty(0x111, 1, false)
				},
				{
					"smiths",
					new MemStructProperty(0x113, 1, false)
				},
				{
					"idle townsfolk",
					new MemStructProperty(0x11F, 1, false)
				},
				{
					"ration achieved",
					new MemStructProperty(0x158, 1, false)
				},
				{
					"ration wanted",
					new MemStructProperty(0x159, 1, false)
				},
				{
					"wheat*",
					new MemStructProperty(0x17B, 1, false)
				},
				{
					"cows*",
					new MemStructProperty(0x17F, 4, false)
				},
				{
					"cow fields",
					new MemStructProperty(0x1FB, 1, false)
				},
				{
					"wheat fields",
					new MemStructProperty(0x1FC, 1, false)
				},
				{
					"reclaiming fields", // how many fields are being reclaimed
					new MemStructProperty(0x1FF, 1, false)
				},
				{
					"reclaim fields seasons left",
					new MemStructProperty(0x20F, 4, false)
				},
				{
					"wheat",
					new MemStructProperty(0x21F, 4, false)
				},
				{
					"wheat production",
					new MemStructProperty(0x227, 2, true)
				},
				{
					"cows",
					new MemStructProperty(0x24B, 1, false)
				},
				{
					"cow production",
					new MemStructProperty(0x253, 1, true)
				},
				{
					"blacksmith selected weapon",
					new MemStructProperty(0x28B, 1, false)
				},
				{
					"wood production",
					new MemStructProperty(0x2A3, 1, false)
				},
				{
					"ore production",
					new MemStructProperty(0x2BB, 4, true)
				},
				{
					"blacksmith state",
					new MemStructProperty(0x2C2, 1, false)
				},
				{
					"weapon production",
					new MemStructProperty(0x2D3, 1, false)
				},
				{
					"stone production",
					new MemStructProperty(0x2EB, 1, false)
				}
			};
		}
	}
}
