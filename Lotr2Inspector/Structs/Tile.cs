using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	public class Tile : MemStruct
	{
		/*
			public Tile(int item)
			{
				// Infer coordinates before using this, this is your exception...
				Item = item;
				Offset = 0x8;
				BaseStructAddress = 0x123198;
				StructAddress = getStructAddress(); // wrong! wrong! wrong! Address that is; well not so wrong after all, just missing the coords
				Properties = StructProperties();
			}
		*/
		public Tile(int x, int y)
		{
			TileX = x;
			TileY = y;
			Item = GetItemNumByCoordinates(TileX, TileY);
			Offset = 0x8;
			BaseStructAddress = 0x123198;
			StructAddress = getStructAddressByCoordinates(TileX, TileY);
			Properties = StructProperties();
		}

		private int getStructAddressByCoordinates(int x, int y)
        {
			return BASE_ADDRESS + BaseStructAddress + ((x - 1) * 8) + ((y - 1) * 0x200);
        }

		private int GetItemNumByCoordinates(int x, int y)
        {
			return ((y - 1) * 64) + x - 1;

		}

		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			return new Dictionary<string, MemStructProperty>
			{
				{
					"tertiary type",
					new MemStructProperty(0x0, 1)
				},
				{
					"primary type",
					new MemStructProperty(0x1, 1)
				},
				{
					"secondary type",
					new MemStructProperty(0x2, 1)
				},
				{
					"tile",
					new MemStructProperty(0x3, 1)
				},
				{
					"unknown 1",
					new MemStructProperty(0x4, 1)
				},
				{
					"unknown 2",
					new MemStructProperty(0x5, 1)
				},
				{
					"unknown 3",
					new MemStructProperty(0x6, 1)
				},
				{
					"town owner",
					new MemStructProperty(0x7, 1)
				}
			};
		}

		public int TileX
        {
			get; set;
        }

		public int TileY
        {
			get; set;
        }
    }
}
