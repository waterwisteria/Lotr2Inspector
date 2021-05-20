using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	public class Player : MemStruct
	{
		public Player(int item)
		{
			Item = item;
			Offset = 0x160;
			BaseStructAddress = 0x17C178;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			return new Dictionary<string, MemStructProperty>
			{
				{
					"gold",
					new MemStructProperty(0x0, 4)
				},
				{
					"gold last season",
					new MemStructProperty(0x4, 4)
				},
				{
					"iron",
					new MemStructProperty(0x8, 4)
				},
				{
					"iron last season",
					new MemStructProperty(0xC, 4)
				},
				{
					"stone",
					new MemStructProperty(0x10, 4)
				},
				{
					"stone last season",
					new MemStructProperty(0x14, 4)
				},
				{
					"wood",
					new MemStructProperty(0x18, 4)
				},
				{
					"wood last season",
					new MemStructProperty(0x1C, 4)
				},
				{
					"bows",
					new MemStructProperty(0x28, 4)
				},
				{
					"maces",
					new MemStructProperty(0x2C, 4)
				},
				{
					"swords",
					new MemStructProperty(0x30, 4)
				},
				{
					"pikes",
					new MemStructProperty(0x34, 4)
				},
				{
					"archers",
					new MemStructProperty(0x38, 4)
				},
				{
					"knights",
					new MemStructProperty(0x3C, 4)
				}
			};
		}
	}
}
