using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
	public abstract class StringArray : MemStruct
	{
		public int Count()
		{
			return Properties.Count();
		}
		/**
		 * Uses StructAddress as the base and offset as a fake delimiter. Explode string by null char.
		 * 
		 */ 
		protected override Dictionary<string, MemStructProperty> StructProperties()
		{
			int bytesRead     = 0;
			int stringCounter = 0;
			byte stringLength = 0;
			byte[] buffer = new byte[Offset];
			Dictionary<string, MemStructProperty> structProperties = new Dictionary<string, MemStructProperty>();
			
			ReadProcessMemory((int) ProcessHandle, StructAddress, buffer, Offset, ref bytesRead);

			// buffer = ReadLords2Mem(StructAddress, Offset);

			// Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, buffer.Length));

			for(int i = 0; i <= buffer.Length - 1; i++)
			{
				// A trailing null char is really necessary to include the last element
				if(buffer[i] == '\0')
				{
					structProperties.Add($"{stringCounter++}", new MemStructProperty(i - stringLength, stringLength));

					stringLength = 0;
				}

				else
				{
					stringLength++;
				}
			}
			
			return structProperties;
		}

		override public String ToString()
		{
			String s = "";
			
			foreach (KeyValuePair<String, MemStructProperty> kvp in Properties)
			{
				s += kvp.Key + ": '" + Get(kvp.Key, false) + "'" + Environment.NewLine;
			}

			return s;
		}
	}
}
