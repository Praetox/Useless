using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pDigClk
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /*pColor[,] pcDisp = new pColor[48, 30];
        Bitmap pDisp = new Bitmap(48, 30);*/
        LabelArray laDisp;
        public static int[,] bDisp = new int[24, 15];
        public static Color[] caGUI = new Color[]
        {
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(96, 96, 96),
            Color.FromArgb(255, 0, 0),
            Color.FromArgb(0, 255, 0),
            Color.FromArgb(0, 0, 255),
            Color.FromArgb(255, 255, 0),
            Color.FromArgb(255, 0, 255),
            Color.FromArgb(0, 255, 255)
        };
        public static double dColMul = 0.5;
        public static int[][,] DCharsN = new int[11][,];
        public static int[][,] DCharsB = new int[11][,];
        public static pColor pcol_Display_Back = new pColor(255, 32, 32, 32);
        public static pColor pcol_DCharsN_Face = new pColor(255, 255, 255, 255);
        public static pColor pcol_DCharsN_Shdw = new pColor(128, 0, 0, 0);
        Random rnd = new Random();

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show(); Application.DoEvents();
            this.Size = Screen.FromControl(this).Bounds.Size;
            this.Hide(); Application.DoEvents();
            this.Location = Point.Empty;
            
            /*pColor[,] pc = new pColor[255,100];
            for (int y = 0; y < 100; y++)
                for (int x = 0; x < 255; x++)
                {
                    pc[x, y] = new pColor();
                    int iVal = (int)Math.Round(
                        ((double)y / 100) * (double)x);
                    pc[x, y].rgb(iVal, 0, iVal);
                }
            pbDisp.Image = mkImg(pc) as Image;*/

            for (int a = 0; a < caGUI.Length; a++)
            {
                int R = caGUI[a].R;
                int G = caGUI[a].G;
                int B = caGUI[a].B;
                R = (int)Math.Round((double)R * dColMul);
                G = (int)Math.Round((double)G * dColMul);
                B = (int)Math.Round((double)B * dColMul);
                if (R > 255) R = 255;
                if (G > 255) G = 255;
                if (B > 255) B = 255;
                caGUI[a] = Color.FromArgb(R, G, B);
            }

            DCharsN[0] = MakeIntMap(3, 5, "111101101101111");
            DCharsN[1] = MakeIntMap(3, 5, "010010010010010");
            DCharsN[2] = MakeIntMap(3, 5, "111001111100111");
            DCharsN[3] = MakeIntMap(3, 5, "111001111001111");
            DCharsN[4] = MakeIntMap(3, 5, "101101111001001");
            DCharsN[5] = MakeIntMap(3, 5, "111100111001111");
            DCharsN[6] = MakeIntMap(3, 5, "111100111101111");
            DCharsN[7] = MakeIntMap(3, 5, "111001001001001");
            DCharsN[8] = MakeIntMap(3, 5, "111101111101111");
            DCharsN[9] = MakeIntMap(3, 5, "111101111001111");
            DCharsN[10] = MakeIntMap(1, 5, "01010");

            DCharsB[0] = MakeIntMap(6, 10, "111111111111" + "110011110011" + "110011110011" + "110011110011" + "111111111111");
            DCharsB[1] = MakeIntMap(6, 10, "001100001100" + "001100001100" + "001100001100" + "001100001100" + "001100001100");
            DCharsB[2] = MakeIntMap(6, 10, "111111111111" + "000011000011" + "111111111111" + "110000110000" + "111111111111");
            DCharsB[3] = MakeIntMap(6, 10, "111111111111" + "000011000011" + "111111111111" + "000011000011" + "111111111111");
            DCharsB[4] = MakeIntMap(6, 10, "110011110011" + "110011110011" + "111111111111" + "000011000011" + "000011000011");
            DCharsB[5] = MakeIntMap(6, 10, "111111111111" + "110000110000" + "111111111111" + "000011000011" + "111111111111");
            DCharsB[6] = MakeIntMap(6, 10, "111111111111" + "110000110000" + "111111111111" + "110011110011" + "111111111111");
            DCharsB[7] = MakeIntMap(6, 10, "111111111111" + "000011000011" + "000011000011" + "000011000011" + "000011000011");
            DCharsB[8] = MakeIntMap(6, 10, "111111111111" + "110011110011" + "111111111111" + "110011110011" + "111111111111");
            DCharsB[9] = MakeIntMap(6, 10, "111111111111" + "110011110011" + "111111111111" + "000011000011" + "111111111111");
            DCharsB[10] = MakeIntMap(2, 10, "00001111000011110000");

            int iLbW = this.Width / bDisp.GetLength(0);
            int iLbH = this.Height / bDisp.GetLength(1);
            int iSkewX = (this.Width - (iLbW*bDisp.GetLength(0))) / 2;
            int iSkewY = (this.Height - (iLbH * bDisp.GetLength(1))) / 2;

            Label lb = new Label();
            this.Controls.Add(lb);
            lb.AutoSize = false;
            lb.ForeColor = Color.White;
            lb.Dock = DockStyle.Fill;
            lb.Font = new Font("Arial", 22);
            lb.Text = "'tis loadin, dude.";
            lb.TextAlign = ContentAlignment.MiddleCenter;
            this.Show(); Application.DoEvents();

            this.SuspendLayout();
            laDisp = new LabelArray(this);
            for (int y = 0; y < bDisp.GetLength(1); y++)
                for (int x = 0; x < bDisp.GetLength(0); x++)
                {
                    laDisp.NewLabel();
                    int iCur = (y * bDisp.GetLength(0)) + x;
                    laDisp[iCur].BackColor = Color.Black;
                    laDisp[iCur].Width = iLbW-1;
                    laDisp[iCur].Height = iLbH-1;
                    laDisp[iCur].Location = new Point(
                        x * iLbW + iSkewX,
                        y * iLbH + iSkewY);
                    laDisp[iCur].Text = "";
                    //laDisp[iCur].ForeColor = Color.FromArgb(24, 24, 24);
                    laDisp[iCur].Visible = true;
                }
            this.ResumeLayout();

            lb.Dispose();
            tRedraw.Start();
            //pbDisp.Image = new Bitmap(pbDisp.Width, pbDisp.Height);
        }

        private void Shuffle()
        {
            int iLbW = this.Width / bDisp.GetLength(0);
            int iLbH = this.Height / bDisp.GetLength(1);
            int iSkewX = (this.Width - (iLbW * bDisp.GetLength(0))) / 2;
            int iSkewY = (this.Height - (iLbH * bDisp.GetLength(1))) / 2;

            int iCol = rnd.Next(2, 9);
            this.SuspendLayout();
            for (int y = 0; y < bDisp.GetLength(1); y++)
                for (int x = 0; x < bDisp.GetLength(0); x++)
                {
                    int iCur = (y * bDisp.GetLength(0)) + x;
                    laDisp[iCur].BackColor = caGUI[iCol];
                }
            this.ResumeLayout();
        }

        private int[,] MakeIntMap(int W, int H, string M)
        {
            int[,] ret = new int[W, H];
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                    ret[x, y] = (int)M[(y * W) + x] - (int)'0';
            return ret;
        }
        private void WriteToDisp(int oX, int oY, int[,] iMap)
        {
            int W = iMap.GetUpperBound(0)+1;
            int H = iMap.GetUpperBound(1)+1;
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    /*if (iMap[x, y] == 1) bMap.SetPixel
                        (x + oX, y + oY, Color.FromArgb(255, 255, 255));*/
                    if (iMap[x, y] == 1) bDisp[x + oX, y + oY] = 1;
                    if (iMap[x, y] == 2) bDisp[x + oX, y + oY] = 2;
                }
        }

        private void pbDisp_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbDisp_Click(object sender, EventArgs e)
        {

        }

        /*private Bitmap mkImg(pColor[,] pcImg, int W, int H)
        {
            int iW = pcImg.GetUpperBound(0); if (W == 0) W = iW; int iMulX = W / iW;
            int iH = pcImg.GetUpperBound(1); if (H == 0) H = iH; int iMulY = H / iH;
            Bitmap bmTmp = new Bitmap(W, H);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmTmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bp = ms.GetBuffer(); bmTmp.Dispose(); ms.Dispose();

            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                {
                    int iTL = ((H - y) * W - W + (x)) * 4;
                    bp[54 + iTL + 3] = (byte)pcImg[x / iMulX, y / iMulY].rgb().A;
                    bp[54 + iTL + 2] = (byte)pcImg[x / iMulX, y / iMulY].rgb().R;
                    bp[54 + iTL + 1] = (byte)pcImg[x / iMulX, y / iMulY].rgb().G;
                    bp[54 + iTL + 0] = (byte)pcImg[x / iMulX, y / iMulY].rgb().B;
                }

            System.IO.MemoryStream msRet = new System.IO.MemoryStream(bp);
            Bitmap bRet = new Bitmap(msRet); return bRet;
        }*/

        private void tRedraw_Tick(object sender, EventArgs e)
        {
            /*for (int y = 0; y < pcDisp.GetLength(1); y++)
                for (int x = 0; x < pcDisp.GetLength(0); x++)
                    pcDisp[x, y] = pcol_Display_Back;*/
            //pDisp = new Bitmap(pDisp.Width, pDisp.Height);
            
            for (int y = 0; y < bDisp.GetLength(1); y++)
                for (int x = 0; x < bDisp.GetLength(0); x++)
                    bDisp[x, y] = 0;

            int cX = 3; int cY = 5;
            string sVar = DateTime.Now.ToShortTimeString();
            for (int l = 0; l < sVar.Length; l++)
            {
                int iChr = 10; double dSec = (double)DateTime.Now.Second;
                if (sVar[l] != ':') iChr = (int)sVar[l] - (int)'0';
                if (iChr != 10 || (Math.Floor(dSec / 2) == Math.Ceiling(dSec / 2)))
                    WriteToDisp(cX, cY, DCharsN[iChr]);
                cX += DCharsN[iChr].GetLength(0) + 1;
            }

            RedrawDisp();
            /*if (pbDisp.Image != null) pbDisp.Image.Dispose();
            pbDisp.Image = ResizeBitmap(pDisp, pbDisp.Width, pbDisp.Height);*/
        }
        private void RedrawDisp()
        {
            for (int y = 0; y < bDisp.GetLength(1); y++)
                for (int x = 0; x < bDisp.GetLength(0); x++)
                    laDisp[(y * bDisp.GetLength(0)) + x]
                        .BackColor = caGUI[bDisp[x, y]];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shuffle();
        }
        /*private Bitmap ResizeBitmap(Bitmap b, int w, int h)
        {
            Bitmap bRet = new Bitmap(w, h);
            using (Graphics gOut = Graphics.FromImage((Image)bRet))
            {
                gOut.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gOut.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                gOut.DrawImage(b, 0, 0, w, h);
            }
            return bRet;
        }*/
    }

    public class pColor
    {
        private pRGB pcRGB = new pRGB();
        private pHSV pcHSV = new pHSV();

        public pColor() {}
        public pColor(int iA, int iR, int iG, int iB)
        {
            rgb(iA, iR, iG, iB);
        }
        
        public pRGB rgb()
        {
            return rgb(new pRGB());
        }
        public pRGB rgb(pRGB set)
        {
            if (set.A != -1)
            {
                pcRGB = set;
                pcHSV = new pHSV();
            }
            return pcRGB;
        }
        public pRGB rgb(int iA, int iR, int iG, int iB)
        {
            pRGB set = new pRGB();
            set.A = iA; set.R = iR; set.G = iG; set.B = iB;
            return rgb(set);
        }
        public pRGB rgb(int iR, int iG, int iB)
        {
            return rgb(255, iR, iG, iB);
        }
        
        public pHSV hsv()
        {
            return hsv(new pHSV());
        }
        public pHSV hsv(pHSV set)
        {
            if (set.A != -1)
            {
                pcHSV = set;
                pcRGB = new pRGB();
            }
            return pcHSV;
        }
    }
    public class pRGB
    {
        public int A = -1;
        public int R = -1;
        public int G = -1;
        public int B = -1;
    }
    public class pHSV
    {
        public int A = -1;
        public int H = -1;
        public int S = -1;
        public int V = -1;
    }
}
