using Lotr2Inspector.Structs;
using Lotr2Inspector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.InteropServices;

/**
 * Represent a struct and it's properties in memory... that is part of an array
 * 
 */
namespace Lotr2Inspector.Structs
{
    public abstract class MemStruct
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        protected const int BASE_ADDRESS = Process.LORDS2_BASE_ADDRESS;

        public void setStruct(int item, int offset, int baseStructAddress)
        {
            Item = item;
            Offset = offset;
            BaseStructAddress = baseStructAddress;
            StructAddress = getStructAddress();
            Properties = StructProperties();
        }

        // @TODO This whole thing is quit messy, unclear, not completely logical.
        public int GetBaseStructAddress(String name)
        {
            return BaseStructAddress + (Item * Offset) + Properties[name].Offset;
        }

        public int GetStructAddress(String name)
        {
            return StructAddress + Properties[name].Offset;
        }

        public int getBaseStructAddress()
        {
            // Just to get at the start of the array/struct
            return BaseStructAddress + (Item * Offset);
        }

        protected int getStructAddress()
        {
            return BASE_ADDRESS + getBaseStructAddress();
        }

        /**
         * Return a signed integer
         * 
         */
        public int Get(String name)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];
            uint r;

            if(Properties.ContainsKey(name))
            {
                //buffer = ReadLords2Mem(StructAddress + Properties[name].Offset, Properties[name].Size);

                ReadProcessMemory((int) ProcessHandle, StructAddress + Properties[name].Offset, buffer, Properties[name].Size, ref bytesRead);

                if(Properties[name].IsSigned)
                {
                    switch(Properties[name].Size)
                    {
                        // This a byte so manually convert to a proper signed int because BitConverter won't do it.
                        case 1:
                            r = BitConverter.ToUInt16(buffer, 0);

                            if (r > SByte.MaxValue)
                            {
                                r -= 256;
                            }

                            return (int) r;

                        case 2:
                            return (int) BitConverter.ToInt16(buffer, 0);

                        case 4:
                            r = BitConverter.ToUInt32(buffer, 0);

                            if (r > System.Int32.MaxValue)
                            {
                                r -= (uint) System.Int16.MaxValue;
                            }

                            return (int) r;
                    }
                }

                else
                {
                    return BitConverter.ToInt32(buffer, 0);
                }
            }

            throw new Exception($"key don exist: {name}");
        }


        /**
         * Return an unsigned integer
         * 
         */
        public uint GetUInt(String name)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[4];

            if (Properties.ContainsKey(name))
            {
                buffer = ReadLords2Mem(StructAddress + Properties[name].Offset, Properties[name].Size);

                ReadProcessMemory((int)ProcessHandle, StructAddress + Properties[name].Offset, buffer, Properties[name].Size, ref bytesRead);

                return BitConverter.ToUInt32(buffer, 0);
            }

            throw new Exception($"key don exist: {name}");
        }

        public String Get(String name, bool trim)
        {
            String s;
            byte[] buffer;

            if(Properties.ContainsKey(name))
            {
                buffer = new byte[Properties[name].Size];
                buffer = ReadLords2Mem(GetStructAddress(name), Properties[name].Size);
                
                // ReadProcessMemory((int) ProcessHandle, StructAddress + Properties[name].Offset, buffer, Properties[name].Size, ref bytesRead);

                // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-byte-array-to-an-int

                s = Encoding.ASCII.GetString(buffer, 0, Properties[name].Size);

                if(trim)
                {
                    s = s.Trim();
                }

                return s;
            }

            throw new Exception($"key don exist: {name}");
        }

        public void Set(String name, int value)
        {
            if (Properties.ContainsKey(name))
            {
                WriteLords2Mem(GetStructAddress(name), value);
            }

            else
            {
                throw new Exception("key don exist");
            }
        }

        public static String ToHex(int x)
        {
            return "0x" + x.ToString("X");
		}

        public static void WriteLords2Mem(int address, int write)
        {
            Console.WriteLine($"Writing '{write.ToString()}' to {ToHex(address)}");

            WriteLords2Mem(address, BitConverter.GetBytes(write));

            // Console.WriteLine($"Reading back value: {BitConverter.ToInt32(ReadLords2Mem(address, 1), 0)}");
        }

        public static void WriteLords2Mem(int address, byte[] write)
        {
            int bytesWritten = 0;
			WriteProcessMemory((int) ProcessHandle, address, write, write.Length, ref bytesWritten);
		}

        public static byte[] ReadLords2Mem(int address, int size)
        {
            bool r;
            int bytesRead = 0;
            byte[] buffer;

            buffer = new byte[size];

            r = ReadProcessMemory((int) ProcessHandle, address, buffer, size, ref bytesRead);

            if(r == false)
            {
                throw new Exception("ReadProcessMemory failed: " + Marshal.GetLastWin32Error());
			}

            return buffer;
        }

        abstract protected Dictionary<string, MemStructProperty> StructProperties();

        // Address where all the same structs reside
        public int BaseStructAddress
        {
            get; set;
        }

        // Absolute address of the item
        public int StructAddress
        {
            get; set;
        }

        public int Offset
        {
            get; set;
        }

        public int Item
        {
            get; set;
        }

        public Dictionary<String, MemStructProperty> Properties
        {
            get; set;
        }

        public static IntPtr ProcessHandle
        {
            get; set;
        }

        override public String ToString()
        {
            String s = "";

            foreach(KeyValuePair<String, MemStructProperty> kvp in Properties)
            {
                // FatalExecutionEngineError 0xc0000005, some obscure JIT static string bug
                //s += $"{kvp.Key}: {Get(kvp.Key)}{Environment.NewLine}";
                
                s += kvp.Key + ":" + Get(kvp.Key) + Environment.NewLine;
            }

            return s;
        }
    }
}
