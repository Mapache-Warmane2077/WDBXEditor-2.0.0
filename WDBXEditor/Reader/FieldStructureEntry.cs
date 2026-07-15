using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDBXEditor.Reader
{
    public class FieldStructureEntry(short bits, ushort offset, byte commondatatype = 0xFF)
    {
        public short Bits = bits;
        public ushort Offset = offset;
        public int Length = 1;

        public bool CommonDataColumn => CommonDataType != 0xFF;
        public byte CommonDataType = commondatatype;

        public int ByteCount
        {
            get
            {
                int value = (32 - Bits) >> 3;
                return (value < 0 ? Math.Abs(value) + 4 : value);
            }
        }

        public int BitCount
        {
            get
            {
                int bitSize = 32 - Bits;
                if (bitSize < 0)
                    bitSize = (bitSize * -1) + 32;
                return bitSize;
            }
        }

        public void SetLength(FieldStructureEntry nextField)
        {
            this.Length = Math.Max(1, (int)Math.Floor((nextField.Offset - this.Offset) / (double)this.ByteCount));
        }
    }
}
