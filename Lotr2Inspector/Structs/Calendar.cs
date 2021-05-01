using Lotr2Inspector.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/**
 * The farmer's calendar ;)
 * 
 */
namespace Lotr2Inspector.Structs
{
	public class Calendar : MemStruct
	{
		public Calendar()
		{
			Item = 0;
			Offset = 0x0;
			BaseStructAddress = 0x153EDC;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}

		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			return new Dictionary<string, MemStructProperty>
			{
				{
					"year",
					new MemStructProperty(0x0, 4)
                },

				{
					"turn", // turn number
					new MemStructProperty(0x54, 2)
                },

				{
					"season",
					new MemStructProperty(0x594, 1)
                }
			};
		}
	}
}
