using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace sn0w
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Bitmap bSrc;
        GifParser gif;
        Random rnd = new Random();
        private void go_Click(object sender, EventArgs e)
        {
            Point n = new Point(
                Convert.ToInt32(Amount_min.Text),
                Convert.ToInt32(Amount_max.Text));
            Point sz = new Point(
                Convert.ToInt32(Size_min.Text),
                Convert.ToInt32(Size_max.Text));
            Point spd = new Point(
                Convert.ToInt32(Speed_min.Text),
                Convert.ToInt32(Speed_max.Text));
            Point ang = new Point(
                Convert.ToInt32(Angle_min.Text),
                Convert.ToInt32(Angle_max.Text));
            Point psz = (Point)bSrc.Size;

            int iCnt = rnd.Next(n.X, n.Y);
            Snowflake[] flakes = new Snowflake[iCnt];
            for (int a = 0; a < flakes.Length; a++)
            {
                flakes[a] = new Snowflake(
                    new Point(rnd.Next(0, psz.X), rnd.Next(0, psz.Y)),
                    psz, rnd.Next(0, gif.im.Length), gif.im.Length,
                    rnd.Next(sz.X, sz.Y), rnd.Next(ang.X, ang.Y),
                    rnd.NextDouble() * (spd.Y - spd.X) + spd.X);
            }

            string s = go.Text;
            int iGenCnt = Convert.ToInt32(txtFrames.Text);
            for (int a = 0; a < iGenCnt; a++)
            {
                go.Text = "Frame " + a + " of " + iGenCnt;
                Application.DoEvents();
                Bitmap bOut = new Bitmap(psz.X, psz.Y);
                using (Graphics g = Graphics.FromImage(bOut))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.DrawImage(bSrc, Point.Empty);
                    for (int b = 0; b < flakes.Length; b++)
                    {
                        Flakedata fd = flakes[b].Next();
                        ColorMatrix matrix = new ColorMatrix();
                        ImageAttributes attr = new ImageAttributes();
                        matrix.Matrix20 = 1.2f;
                        matrix.Matrix21 = 1.3f;
                        matrix.Matrix12 = 2f;
                        attr.SetColorMatrix(matrix);
                        g.DrawImage(gif.im[fd.fr], new Rectangle(fd.pt, new Size(fd.sz, fd.sz)), 0, 0,
                            gif.im[fd.fr].Width, gif.im[fd.fr].Height, GraphicsUnit.Pixel, attr);
                    }
                }
                bOut.Save("sn0w-" + a.ToString("d4") + ".png");
            }
            go.Text = s;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            string s = go.Text;
            go.Text = "Parsing gif";
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            Application.DoEvents();
            bSrc = new Bitmap("image.png");
            gif = new GifParser("snow.gif");
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
            go.Text = s;
        }
    }
}
