using System;
using System.Collections.Generic;
using System.Text;

namespace LoliBot
{
    class XTea
    {
        protected uint[] ConvertBytesToUints(byte[] bPacket, int intOffset, int intCount)
        {
            uint[] nArray = new uint[intCount / 4];
            int startIndex = intOffset;
            for (int i = 0; startIndex < (intOffset + intCount); i++)
            {
                nArray[i] = BitConverter.ToUInt32(bPacket, startIndex);
                startIndex += 4;
            }
            return nArray;
        }
        protected byte[] ConvertUintstoBytes(uint[] bPacket)
        {
            byte[] destinationArray = new byte[bPacket.Length * 4];
            int index = 0;
            for (int i = 0; index < bPacket.Length; i += 4)
            {
                byte[] bytes = BitConverter.GetBytes(bPacket[index]);
                Array.Copy(bytes, 0, destinationArray, i, bytes.Length);
                index++;
            }
            return destinationArray;
        }
        public byte[] XTEADecrypt(byte[] bPacket, int intOffset, int intCount, byte[] bKey)
        {
            uint n1 = 0x20;
            uint n2 = 0xc6ef3720;
            uint n3 = 0x9e3779b9;
            uint[] nArray = this.ConvertBytesToUints(bPacket, intOffset, intCount);
            uint[] nArray2 = new uint[] { BitConverter.ToUInt32(bKey, 0), BitConverter.ToUInt32(bKey, 4), BitConverter.ToUInt32(bKey, 8), BitConverter.ToUInt32(bKey, 12) };
            while (n1-- > 0)
            {
                nArray[1] -= (((nArray[0] << 4) ^ (nArray[0] >> 5)) + nArray[0]) ^ (n2 + nArray2[(int)((IntPtr)((n2 >> 11) & 3))]);
                n2 -= n3;
                nArray[0] -= (((nArray[1] << 4) ^ (nArray[1] >> 5)) + nArray[1]) ^ (n2 + nArray2[(int)((IntPtr)(n2 & 3))]);
            }
            return this.ConvertUintstoBytes(nArray);
        }
        public byte[] XTEAEncrypt(byte[] bPacket, int intOffset, int intCount, byte[] bKey)
        {
            uint n1 = 0;
            uint n2 = 0x9e3779b9;
            uint n3 = 0x20;
            uint[] nArray = this.ConvertBytesToUints(bPacket, intOffset, intCount);
            uint[] nArray2 = new uint[] { BitConverter.ToUInt32(bKey, 0), BitConverter.ToUInt32(bKey, 4), BitConverter.ToUInt32(bKey, 8), BitConverter.ToUInt32(bKey, 12) };
            while (n3-- > 0)
            {
                nArray[0] += (((nArray[1] << 4) ^ (nArray[1] >> 5)) + nArray[1]) ^ (n1 + nArray2[(int)((IntPtr)(n1 & 3))]);
                n1 += n2;
                nArray[1] += (((nArray[0] << 4) ^ (nArray[0] >> 5)) + nArray[0]) ^ (n1 + nArray2[(int)((IntPtr)((n1 >> 11) & 3))]);
            }
            return this.ConvertUintstoBytes(nArray);
        }
    }
}
