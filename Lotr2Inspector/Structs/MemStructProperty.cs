using System;
using System.Text;

namespace Lotr2Inspector.Structs
{
    public class MemStructProperty
    {
        public MemStructProperty(int offset, Byte size = 0x1, bool isSigned = false)
        {
            this.Size = size;
            this.Offset = offset;
            this.IsSigned = isSigned;
        }

        // In bytes
        public Byte Size { get; }

        // Relative to parent object
        public int Offset { get; }

        public bool IsSigned { get; } = false;
    }
}
