using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LoliBot
{
    /// <summary>
    /// This class allows you to read the memory of other applications.
    /// </summary>
    class Memory
    {
        #region Methods
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern long ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, ref int lpBuffer, int nSize, int lpNumberOfBytesWritten);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern long WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);
        #endregion
        #region Defines
        public const uint PROCESS_VM_READ = (0x0010);
        public const uint PROCESS_VM_WRITE = (0x0020);
        public const uint PROCESS_VM_OPERATION = (0x0008);
        public const uint PROCESS_ALL_ACCESS = (0x1F0FFF);
        private Process m_ReadProcess = null;
        private IntPtr m_hProcess = IntPtr.Zero;

        public Memory()
        {
        }

        public bool isSet()
        {
            try
            {
                IntPtr tmp = m_ReadProcess.MainWindowHandle;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Basic stuff
        public Process mTarget
        {
            get
            {
                return m_ReadProcess;
            }
            set
            {
                m_ReadProcess = value;
            }
        }
        public void Open()
        {
            m_hProcess = OpenProcess(PROCESS_ALL_ACCESS, 1, (uint)m_ReadProcess.Id);
        }

        public void Close()
        {
            int iRetValue;
            iRetValue = CloseHandle(m_hProcess);
            if (iRetValue == 0) throw new Exception("CloseHandle failed");
        }
        #endregion
        #region Conversions
        public byte[] Int2Byte(int Value)
        {
            byte[] rawbuf = BitConverter.GetBytes(Value);
            int a = 0; for (a = rawbuf.Length; a > 0; a--) if (rawbuf[a - 1] != 0) break;
            byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = rawbuf[a];
            return buf;
        }
        #endregion
        #region Read memory
        public byte[] RBytes(int Address, int Length)
        {
            byte[] buf = new byte[Length];
            for (int a = 0; a < Length; a++)
            {
                int iBuf = 0;
                ReadProcessMemory(m_hProcess, Address + a, ref iBuf, 1, 0);
                buf[a] = (byte)iBuf;
            }
            return buf;
        }
        public int RInt(int Address, int Size)
        {
            int ret = 0;
            ReadProcessMemory(m_hProcess, Address, ref ret, Size, 0);
            return ret;
        }
        public int RInt(int Address)
        {
            int ret = 0;
            ReadProcessMemory(m_hProcess, Address, ref ret, 4, 0);
            return ret;
        }
        public uint RUInt(int Address, int Size)
        {
            int ret = 0; int buf = (int)ret;
            ReadProcessMemory(m_hProcess, Address, ref buf, Size, 0);
            return (uint)buf;
        }
        public double RDouble(int Address)
        {
            byte[] buf = new byte[8];
            for (int a = 0; a < 8; a++)
            {
                int iBuf = RInt(Address + a, 1);
                buf[a] = (byte)iBuf;
            }
            return BitConverter.ToDouble(buf, 0);
        }
        public string RString(int Address)
        {
            int a = 0, buf = 0; string ret = "";
            while (true)
            {
                buf = RInt(Address + a, 1);
                if (buf != 0)
                {
                    ret += (char)buf;
                }else{
                    break;
                }
                a++;
            }
            return ret;
        }
        public string RString(int Address, int Length)
        {
            string ret = "";
            for (int a = 0; a < Length; a++)
            {
                int chr = RInt(Address + a, 1);
                ret += (char)chr;
            }
            return ret;
        }
        #endregion
        #region Write memory
        public void WByte(int Address, byte[] Value)
        {
            WriteProcessMemory(m_hProcess, Address, Value, (int)Value.Length, 0);
        }
        public void WInt(int Address, int Value)
        {
            byte[] buf = Int2Byte(Value);
            WriteProcessMemory(m_hProcess, Address, buf, (int)buf.Length, 0);
        }
        public void WInt(int Address, int Value, int Length)
        {
            byte[] buf = BitConverter.GetBytes(Value);
            WriteProcessMemory(m_hProcess, Address, buf, Length, 0);
        }
        public void WDouble(int Address, double Value)
        {
            byte[] buf = new byte[8];
            buf = BitConverter.GetBytes(Value);
            for (int a=0; a<8; a++)
            {
                WInt(Address + a, buf[a]);
            }
        }
        public void WString(int Address, string Value)
        {
            int Length = Value.Length;
            for (int a = 0; a < Length; a++)
            {
                WInt(Address + a, Convert.ToInt16(Value[a]), 1);
            }
            WInt(Address + Length, 0);
        }
        public void WByte(int Address, byte[] Value, int Offset, int Length)
        {
            for (int a = 0; a < Length; a++)
            {
                WInt(Address + a, Value[a + Offset]);
            }
        }
        public void WNops(int Address, int Amount)
        {
            Address--;
            for (int a = 1; a <= Amount; a++)
            {
                WInt(Address + a, 0x90);
            }
        }
        #endregion
    }
}
