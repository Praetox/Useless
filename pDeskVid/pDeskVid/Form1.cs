using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pDeskVid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, ref RECT rc);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT { public int X1, Y1, X2, Y2; }
        

        public static readonly int WM_COMMAND = 0x111;
        public static readonly int MIN_ALL = 419;
        public static readonly int MIN_ALL_UNDO = 416;
        public static IntPtr LastWnd;

        private void MCI(string vl)
        {
            mciSendString(vl, null, 0, IntPtr.Zero);
        }
        private void mLoad(string vl, IntPtr TargetWnd)
        {
            MCI("stop pMov");
            MCI("close pMov");
            MCI("open \"" + vl + "\" type mpegvideo alias pMov " +
                "parent " + TargetWnd + " style " + 0x40000000);
        }
        private void mPlay(IntPtr TargetWnd)
        {
            RECT vSize = new RECT(); GetWindowRect(TargetWnd, ref vSize);
            MCI("play pMov REPEAT");
            MCI("Put pMov window at 0 0 " +
                (vSize.X2 - vSize.X1) + " " +
                (vSize.Y2 - vSize.Y1));
        }
        private void mStop()
        {
            MCI("stop pMov");
        }
        private void mClose()
        {
            MCI("stop pMov");
            MCI("close pMov");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false; this.ShowInTaskbar = false; this.Hide();
            nIco.Icon = this.Icon; nIco.Visible = true; Application.DoEvents();
            System.Net.WebClient wc = new System.Net.WebClient();
            string sURL = wc.DownloadString("http://tox.awardspace.us/spin.txt");
            wc.DownloadFile(sURL, "spin.avi");
            nIco.Visible = false;
        }

        private void tHotkeys_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.MediaNextTrack) != 0)
            {
                nIco.Visible = true; Application.DoEvents();
                LastWnd = GetForegroundWindow();
                mLoad("spin.avi", GetDesktopWindow());
                mPlay(GetDesktopWindow());
                SendMessage(FindWindow("Shell_TrayWnd", null), WM_COMMAND, MIN_ALL, 0);
            }
            if (GetAsyncKeyState(Keys.MediaPreviousTrack) != 0)
            {
                nIco.Visible = false; Application.DoEvents();
                mClose();
                SendMessage(FindWindow("Shell_TrayWnd", null), WM_COMMAND, MIN_ALL_UNDO, 0);
                Application.DoEvents(); SetForegroundWindow(LastWnd);
            }
            if (GetAsyncKeyState(Keys.MediaStop) != 0)
            {
                mLoad("spin.avi", GetForegroundWindow());
                mPlay(GetForegroundWindow()); System.Threading.Thread.Sleep(1000); mClose();
            }
        }
    }
}
