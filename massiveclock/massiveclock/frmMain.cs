using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace massiveclock {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        Bitmap bg = new Bitmap("c:\\massiveclock.jpg");
        private void frmMain_Load(object sender, EventArgs e) {
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill; pb.Visible = true;
            this.Controls.Add(pb);

            this.Bounds = Screen.FromControl(this).Bounds;
            Timer t = new Timer(); t.Interval = 1000;
            t.Tick += delegate(object lol, EventArgs dongs) {
                string str = DateTime.Now.ToLongTimeString();
                Bitmap b = new Bitmap(this.Width, this.Height);
                using (Graphics g = Graphics.FromImage(b)) {
                    g.DrawImage(bg, this.Bounds);
                    Font f = new Font("Verdana", 128);
                    double ofsX = 0; double ofsY = 0;
                    SizeF fsz = g.MeasureString(str, f);
                    ofsX = this.Width / 2 - fsz.Width / 2;
                    ofsY = this.Height / 2 - fsz.Height / 2;
                    g.DrawString(str, f, Brushes.Black,
                        (float)ofsX + 2, (float)ofsY + 2);
                    g.DrawString(str, f, Brushes.White,
                        (float)ofsX + 0, (float)ofsY + 0);
                }
                if (pb.Image != null)
                    pb.Image.Dispose();
                pb.Image = b;
            }; t.Start();
        }
    }
}
