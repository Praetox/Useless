using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lunchbot
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("Gdi32.dll")]
        public static extern int GetPixel(System.IntPtr hdc, int nXPos, int nYPos);
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr wnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        public const uint MOUSEEVENTF_LEFTUP = 0x04;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const uint MOUSEEVENTF_RIGHTUP = 0x10;

        /* Documentation
         * 
         * 1: Move to corner
         * 2: Move from corner to random locations
         * 3: Move about
         * 4: Draw image
         *
         */

        static int imgW = 760, imgH = 544, iChars = 182, iBlacks = 0, iRatio = 0;
        static bool[,] pix = new bool[imgW, imgH];
        static bool intMoveAbout = false;
        static int actMoveAbout = 1;
        static int iDelay = 5;
        static Point Ofs1, Ofs2;

        public frmMain()
        {
            InitializeComponent();
        }

        private void tHotkeys_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.Q) == -32767) Ofs1 = Cursor.Position;
            if (GetAsyncKeyState(Keys.W) == -32767) Ofs2 = Cursor.Position;
            if (GetAsyncKeyState(Keys.OemPipe) == -32767) tMoveAbout.Stop();
            if (GetAsyncKeyState(Keys.D1) == -32767) { actMoveAbout = 1; tMoveAbout.Start(); }
            if (GetAsyncKeyState(Keys.D2) == -32767) { actMoveAbout = 2; tMoveAbout.Start(); }
            if (GetAsyncKeyState(Keys.D3) == -32767) { actMoveAbout = 3; tMoveAbout.Start(); }
            if (GetAsyncKeyState(Keys.D4) == -32767) { actMoveAbout = 4; tMoveAbout.Start(); }
        }

        private void tMoveAbout_Tick(object sender, EventArgs e)
        {
            if (intMoveAbout) return; intMoveAbout = true;
            Random rnd = new Random();
            if (actMoveAbout == 1)
            {
                IntPtr DC = GetDC((IntPtr)0);
                for (int x = Ofs1.X; x <= Ofs2.X; x += 2)
                {
                    for (int y = Ofs1.Y; y <= Ofs2.Y; y += 2)
                    {
                        if (x > Ofs1.X + 50 || y > Ofs1.Y + 50)
                        {
                            if (GetPixel(DC, x, y) != 0xFFFFFF)
                            {
                                Cursor.Position = new Point(x + 5, y + 5);
                                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                Cursor.Position = new Point(Ofs1.X, Ofs1.Y);
                                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);
                            }
                        }
                    }
                    if (tMoveAbout.Enabled == false) { intMoveAbout = false; return; }
                }
                ReleaseDC(DC);
            }
            if (actMoveAbout == 2)
            {
                int rndX = rnd.Next(Ofs1.X, Ofs2.X);
                int rndY = rnd.Next(Ofs1.Y, Ofs2.Y);

                Cursor.Position = new Point(Ofs1.X + 5, Ofs1.Y + 5);
                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                Cursor.Position = new Point(rndX, rndY);
                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);
            }
            if (actMoveAbout == 3)
            {
                IntPtr DC = GetDC((IntPtr)0);
                while (true)
                {
                    int rndX1 = rnd.Next(Ofs1.X, Ofs2.X);
                    int rndY1 = rnd.Next(Ofs1.Y, Ofs2.Y);
                    int rndX2 = rnd.Next(Ofs1.X, Ofs2.X);
                    int rndY2 = rnd.Next(Ofs1.Y, Ofs2.Y);

                    if (GetPixel(DC, rndX1, rndY1) != 0xFFFFFF)
                    {
                        Cursor.Position = new Point(rndX1, rndY1);
                        Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                        Cursor.Position = new Point(rndX2, rndY2);
                        Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                        break;
                    }
                }
                ReleaseDC(DC);
            }
            if (actMoveAbout == 4)
            {
                int curDiff = 0; actMoveAbout = 0;
                bool bSpamLetters = LtrDraw_chkSpamLetters.Checked;
                bool bConserveLetters = LtrDraw_chkConserveLetters.Checked;
                IntPtr DC = GetDC((IntPtr)0);
                for (int y = 0; y < imgH; y++)
                {
                    for (int x = 0; x < imgW; x++)
                    {
                        if (pix[x, y])
                        {
                            curDiff++;
                            if (curDiff >= iRatio)
                            {
                                bool PlaceLetterHere = false;
                                if (bSpamLetters)
                                {
                                    PlaceLetterHere = true;
                                }
                                else
                                {
                                    if (!bConserveLetters)
                                    {
                                        PlaceLetterHere = (
                                            GetPixel(DC, (Ofs1.X) + 0 + x, (Ofs1.Y + y) + 0) == 0xFFFFFF);
                                    }
                                    else
                                    {
                                        PlaceLetterHere = (
                                             GetPixel(DC, (Ofs1.X) - 3 + x, (Ofs1.Y + y) - 3) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 0 + x, (Ofs1.Y + y) - 3) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 3 + x, (Ofs1.Y + y) - 3) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) - 3 + x, (Ofs1.Y + y) + 0) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 0 + x, (Ofs1.Y + y) + 0) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 3 + x, (Ofs1.Y + y) + 0) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) - 3 + x, (Ofs1.Y + y) + 3) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 0 + x, (Ofs1.Y + y) + 3) == 0xFFFFFF &&
                                             GetPixel(DC, (Ofs1.X) + 3 + x, (Ofs1.Y + y) + 3) == 0xFFFFFF);
                                    }
                                }
                                if (PlaceLetterHere)
                                {
                                    curDiff = 0;
                                    Cursor.Position = new Point(Ofs1.X + 5, Ofs1.Y + 5);
                                    Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                                    Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                    Cursor.Position = new Point(Ofs1.X + (x - 8), Ofs1.Y + (y - 12));
                                    Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);

                                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                    Application.DoEvents(); System.Threading.Thread.Sleep(iDelay);
                                }
                            }
                        }
                    }
                    if (tMoveAbout.Enabled == false) { intMoveAbout = false; return; }
                }
                ReleaseDC(DC);
            }
            intMoveAbout = false;
        }

        private void lnk_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.Praetox.com/");
        }

        private void cmdPrepare_Click(object sender, EventArgs e)
        {
            if (LtrDraw_txtPath.Text == "") { cmdBrowse_Click(new object(), new EventArgs()); return; }

            iBlacks = 0;
            pix = GetBlacks(LtrDraw_txtPath.Text);
            for (int y = 0; y < imgH; y++)
                for (int x = 0; x < imgW; x++)
                    if (pix[x, y]) iBlacks++;

            iRatio = (int)Math.Ceiling(((double)1/((double)iChars / (double)iBlacks)));
            
            lbBlacks.Text = "" + iBlacks;
            lbChars.Text = "" + iChars;
            lbRatio.Text = "" + iRatio;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = Application.StartupPath + "\\images";
            fd.Filter = "16-colour bitmap image (*.bmp)|*.bmp";
            fd.ShowDialog();
            if (fd.FileName != "") LtrDraw_txtPath.Text = fd.FileName;
            LtrDraw_txtPath.SelectionStart = LtrDraw_txtPath.Text.Length;
            LtrDraw_txtPath.SelectionLength = 0; LtrDraw_txtPath.ScrollToCaret();
            if (fd.FileName != "") cmdPrepare_Click(new object(), new EventArgs());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += Application.ProductVersion;
        }

        private bool[,] GetBlacks(string sFile)
        {
            System.IO.FileStream fs = new System.IO.FileStream(LtrDraw_txtPath.Text, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            byte[] bRaw = new byte[(imgW * imgH) / 2];
            br.Read(new byte[0x76], 0, 0x76);
            br.Read(bRaw, 0, (imgW * imgH) / 2);
            br.Close(); fs.Close(); fs.Dispose();

            bool[,] bSet = new bool[imgW, imgH];
            int iRawPos = 0; bool bHugeDef = true;
            for (int y = imgH - 1; y >= 0; y--)
            {
                for (int x = 0; x < imgW; x++)
                {
                    if (bHugeDef)
                    {
                        if (bRaw[iRawPos] == 0xF0 || bRaw[iRawPos] == 0xFF)
                            bSet[x, y] = false;
                        else bSet[x, y] = true;
                    }
                    else
                    {
                        if (bRaw[iRawPos] == 0x0F || bRaw[iRawPos] == 0xFF)
                            bSet[x, y] = false;
                        else bSet[x, y] = true;
                    }
                    if (!bHugeDef) iRawPos++; bHugeDef = !bHugeDef;
                }
            }
            return bSet;
        }

        private void txtSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { if (iDelay<=100) iDelay++; }
            if (e.KeyCode == Keys.Down) { if (iDelay >= 1) iDelay--; }
            txtSpeed.Text = "" + iDelay;
        }
    }
}
