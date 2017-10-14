using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ppSwatch
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Memory mem = new Memory();
        const int iCStep = 5;
        int iR = 255; int iRD = iCStep;
        int iG = 0; int iGD = 0;
        int iB = 0; int iBD = 0;

        MOfs mXP = new MOfs();
        MOfs mVI = new MOfs();
        MOfs mOS = new MOfs();

        private void frmMain_Load(object sender, EventArgs e)
        {
            mXP.aMain = 0x01030000;
            mXP.aCol1 = 0xe87c;
            mXP.aCol2 = 0xd6a0;
            mXP.aCol3 = 0xd6a4;
            mVI.aMain = 0x0; //whut
            mVI.aCol1 = 0x4144;
            mVI.aCol2 = 0x2cd8;
            mVI.aCol3 = 0x2cdc;
            mVI.aTool = 0x2db9;

            Form f = new frmClient(); f.ShowDialog();
            this.TopMost = true; mem.mTarget = frmClient.target; mem.Open();
            mem.SetTitle("OH GOD HOW DID THIS GET HERE I AM NOT GOOD WITH COMPUTAR");
            MessageBox.Show("Now it's time to find those offsets!" + "\r\n\r\n" +
                "Note: If you just started paint, skip to #3" + "\r\n\r\n" +
                "#1. Left click the black color box in paint" + "\r\n" +
                "#2. Right click the white color box in paint" + "\r\n" +
                "#3. Click OK when ready", "Oh, hi.");
            if (mem.RInt(mXP.aMain + mXP.aCol1) == 0x000000 &&
                mem.RInt(mXP.aMain + mXP.aCol2) == 0xffffff)
            {
                lbOS.Text = "WinXP 5.1.2600";
                mOS = mXP; mOS.prep();
            }
            else
            {
                int ofs = MOfs.aMin;
                while (ofs < MOfs.aMax)
                {
                    if (mem.RInt(ofs + mVI.aCol1) == 0x000000 &&
                        mem.RInt(ofs + mVI.aCol2) == 0xffffff)
                    {
                        lbOS.Text = "Vista 6.0.6001 SP1 (" + (ofs / 0x10000).ToString("X") + ")";
                        mOS = mVI; mOS.aMain = ofs;
                        mOS.prep(); break;
                    }
                    else ofs += 0x10000;
                }
            }
            if (mOS.aMain == 0)
            {
                MessageBox.Show("ppSwatch does not support your version of MSPaint (yet)." + "\r\n\r\n" +
                    "Please send Praetox a copy of your mspaint.exe, along with" + "\r\n" +
                    "a screenshot of winver.exe showing your windows information.");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            this.TopMost = false;
            tScan.Start();
        }
        private void tScan_Tick(object sender, EventArgs e)
        {
            if (mem.mTarget.HasExited)
            {
                tScan.Stop();
                MessageBox.Show("How rude.");
                Application.Exit();
            }
            string sC1 = mem.RInt(mOS.aCol1).ToString("X6");
            string sC2 = mem.RInt(mOS.aCol2).ToString("X6");
            string sC3 = mem.RInt(mOS.aCol3).ToString("X6");
            Color C1 = Color.FromArgb(
                Convert.ToInt32(sC1.Substring(4, 2), 16),
                Convert.ToInt32(sC1.Substring(2, 2), 16),
                Convert.ToInt32(sC1.Substring(0, 2), 16));
            Color C2 = Color.FromArgb(
                Convert.ToInt32(sC2.Substring(4, 2), 16),
                Convert.ToInt32(sC2.Substring(2, 2), 16),
                Convert.ToInt32(sC2.Substring(0, 2), 16));
            Color C3 = Color.FromArgb(
                Convert.ToInt32(sC3.Substring(4, 2), 16),
                Convert.ToInt32(sC3.Substring(2, 2), 16),
                Convert.ToInt32(sC3.Substring(0, 2), 16));
            c1.BackColor = C1;
            c2.BackColor = C2;
            c3.BackColor = C3;
        }

        private void chkRainbow_CheckedChanged(object sender, EventArgs e)
        {
            tRainbow.Enabled = chkRainbow.Checked;
        }
        private void tRainbow_Tick(object sender, EventArgs e)
        {
            iR += iRD; iG += iGD; iB += iBD;
            if (iR > 255) { iR = 255; iRD = 0; iBD = -iCStep; } //red 255, blue --
            if (iB < 0) { iB = 0; iBD = 0; iGD = iCStep; }      //red 255, green ++
            if (iG > 255) { iG = 255; iGD = 0; iRD = -iCStep; } //green 255, red --
            if (iR < 0) { iR = 0; iRD = 0; iBD = iCStep; }      //green 255, blue ++
            if (iB > 255) { iB = 255; iBD = 0; iGD = -iCStep; } //blue 255, green --
            if (iG < 0) { iG = 0; iGD = 0; iRD = iCStep; }      //blue 255, red ++
            mem.WInt(mOS.aCol1, iR + (iG * 256) + (iB * 256 * 256), 8);
        }
    }
}
