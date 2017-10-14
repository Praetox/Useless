using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LoliBot
{
    class Win32API
    {
        #region Methods
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int FlashWindowEx(ref FlashWInfo fwi);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement windowPlacement);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int procid);
        [DllImport("user32", EntryPoint = "SetWindowTextA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr Handle, int nCmd);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, ref uint lpflOldProtect);
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        #endregion
        #region Types
        [Flags]
        public enum FlashWFlags : uint
        {
            FLASHW_CAPTION = 1,
            FLASHW_STOP = 0,
            FLASHW_TIMER = 4,
            FLASHW_TIMERNOFG = 12,
            FLASHW_TRAY = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FlashWInfo
        {
            public uint cbSize;
            public IntPtr hWnd;
            public Win32API.FlashWFlags dwFlags;
            public uint uCount;
            public uint dwTimeout;
            public FlashWInfo(IntPtr Handle, Win32API.FlashWFlags Flags, uint Count, uint Timeout)
            {
                this = new Win32API.FlashWInfo();
                this.hWnd = Handle;
                this.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(Win32API.FlashWInfo)));
                this.dwFlags = Flags;
                this.uCount = Count;
                this.dwTimeout = Timeout;
            }
        }

        public enum ShowState : uint
        {
            SW_HIDE = 0,
            SW_MINIMIZE = 6,
            SW_RESTORE = 9,
            SW_SHOW = 5,
            SW_SHOWDEFAULT = 10,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOWNORMAL = 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowPlacement
        {
            public uint Length;
            public uint Flags;
            public Win32API.ShowState ShowCmd;
            public System.Drawing.Point MinPosition;
            public System.Drawing.Point MaxPosition;
            public System.Drawing.Rectangle NormalPosition;
        }
        #endregion
    }
}
