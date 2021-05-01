using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lotr2Inspector.Structs
{
    class Viewport : MemStruct
    {
        public Viewport()
        {
            Item = 0;
            Offset = 0x0;
            BaseStructAddress = 0x1651B4;
            StructAddress = getStructAddress();
            Properties = StructProperties();
        }

        public int x
        {
            get
            {
                return Get("x");
            }
        }

        public int y
        {
            get
            {
                return Get("y");
            }
        }

        protected override Dictionary<string, MemStructProperty> StructProperties()
        {
            return new Dictionary<string, MemStructProperty>
            {
                {
                    "x",
                    new MemStructProperty(0x0, 4)
                },
                {
                    "y",
                    new MemStructProperty(0x4, 4)
                }
            };
        }
    }
}
