using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	// Represents something on the map that moves, like an army or a merchant
	// WARNING: They're only updated when visible on the screen. Also, the order
	// and data types may change depending on what the moveable is.
    class Moveable : MemStruct
    {
		public Moveable(int item)
		{
			Item = item;
			Offset = 0x1A4;
			BaseStructAddress = 0x12f254;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			return new Dictionary<string, MemStructProperty>
			{
				{
					"owner",
					new MemStructProperty(0x0, 1)
				},
				{
					"color",
					new MemStructProperty(0x1, 1)
				},
				{
					"type",
					new MemStructProperty(0x8, 1)
				},
				{
					"x1",
					new MemStructProperty(0x14, 1)
				},
				{
					"y1",
					new MemStructProperty(0x15, 1)
				},
				{
					"x2",
					new MemStructProperty(0x16, 1)
				},
				{
					"y2",
					new MemStructProperty(0x17, 1)
				},
				{
					"x3",
					new MemStructProperty(0x1D, 1)
				},
				{
					"y3",
					new MemStructProperty(0x1E, 1)
				},
				{
					"moves used",
					new MemStructProperty(0x153, 1)
				},
				{
					"total moves",
					new MemStructProperty(0x154, 1)
				},
				{
					"total units",
					new MemStructProperty(0x168, 4)
				},
				{
					"peasants",
					new MemStructProperty(0x16C, 2)
				},
				{
					"crossbowmen",
					new MemStructProperty(0x16E, 2)
				},
				{
					"macemen",
					new MemStructProperty(0x170, 2)
				},
				{
					"swordsmen",
					new MemStructProperty(0x172, 2)
				},
				{
					"pikemen",
					new MemStructProperty(0x174, 2)
				},
				{
					"archers",
					new MemStructProperty(0x176, 2)
				},
				{
					"knights",
					new MemStructProperty(0x178, 2)
				}
			};
		}
	}
}
