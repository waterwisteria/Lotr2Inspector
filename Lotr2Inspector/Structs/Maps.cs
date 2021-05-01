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
	public class Maps : StringArray
	{
		public Maps()
		{
			Item = 0;
			Offset = 0x225;
			BaseStructAddress = 0x19835E;
			StructAddress = getStructAddress();
			Properties = StructProperties();
		}
	}
}
