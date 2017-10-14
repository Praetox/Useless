using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();
        Size sz = Screen.PrimaryScreen.WorkingArea.Size;

        private void tPENIS_Tick(object sender, EventArgs e)
        {
            Point ptLoc = new Point(random.Next(sz.Width/2), random.Next(sz.Height/2));
            Size szSize = new Size(
                random.Next(sz.Width / 4, sz.Width - ptLoc.X),
                random.Next(sz.Height / 4, sz.Height - ptLoc.Y));
            this.Location = ptLoc; this.Size = szSize;
            this.BackColor = colRand(0, 128);
            label1.ForeColor = colRand(128, 128);
        }

        private void tRAEP_Tick(object sender, EventArgs e)
        {
            this.Left += random.Next(-4, +4);
            this.Top += random.Next(-4, +4);
            this.Width += random.Next(-4, +4);
            this.Height += random.Next(-4, +4);
            Color c = this.BackColor;
            Color d = label1.ForeColor;
            int cr = colFuck(c.R);
            int cg = colFuck(c.G);
            int cb = colFuck(c.B);
            int dr = colFuck(d.R);
            int dg = colFuck(d.G);
            int db = colFuck(d.B);
            this.BackColor = Color.FromArgb(cr, cg, cb);
            label1.ForeColor = Color.FromArgb(dr, dg, db);
            Point curPos = Cursor.Position;
            curPos.X += random.Next(-8, +8);
            curPos.Y += random.Next(-8, +8);
            Cursor.Position = curPos;
        }
        private int colFuck(int v)
        {
            v += random.Next(-4, +8);
            v = Math.Max(0, v);
            v = Math.Min(v, 255);
            return v;
        }
        private Color colRand(int iStart, int iRange)
        {
            int cr = random.Next(iStart, iStart + iRange);
            int cg = random.Next(iStart, iStart + iRange);
            int cb = random.Next(iStart, iStart + iRange);
            return Color.FromArgb(cr, cg, cb);
        }
    }
}
