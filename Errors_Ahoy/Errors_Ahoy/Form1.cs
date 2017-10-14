using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Errors_Ahoy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Form[] w = new Form[32];
        double dOfs = 6.0; //2.75;
        double dOfsInc = 0.001;
        int iHorzMul = 0;
        int iVertMul = 0;
        double dIncStep = 0;
        int iSleep = 10;
        bool bStop = false;
        bool bActv = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            bActv = true;
            this.Show(); Application.DoEvents();
            for (int a = 0; a < w.Length; a++)
            {
                w[a] = new Form2();
                w[a].Show();
            }
            iHorzMul = Screen.PrimaryScreen.WorkingArea.Width / 2;
            iVertMul = Screen.PrimaryScreen.WorkingArea.Height / 2;
            iHorzMul -= w[0].Width / 2;
            iVertMul -= w[0].Height / 2;
            int iHorz = iHorzMul / w.Length;
            int iVert = iVertMul / w.Length;
            int iDisp = 100;
            while (true)
            {
                if (bStop)
                {
                    bStop = false;
                    bActv = false;
                    return;
                }
                if (iDisp > 10)
                {
                    iDisp = 0;
                    imgc.Text = "" + w.Length;
                    horz.Text = "" + iHorzMul;
                    vert.Text = "" + iVertMul;
                    dofs.Text = "" + Math.Round(dOfs, 4);
                    dinc.Text = "" + Math.Round(dOfsInc, 4);
                    slep.Text = "" + iSleep;
                }
                else iDisp++;
                for (int a = 0; a < w.Length; a++)
                {
                    double d = 2;
                    d *= Math.PI;
                    d /= w.Length;
                    d += dOfs;
                    w[a].Location = new Point(
                        (int)(iHorzMul + (iHorz * a * Math.Sin(a * d))),
                        (int)(iVertMul + (iVert * a * Math.Cos(a * d))));
                }

                Application.DoEvents();
                System.Threading.Thread.Sleep(iSleep);
                dOfs += dOfsInc;
            }
        }

        private void imgc_Click(object sender, EventArgs e)
        {
            if (bActv) { bStop = true; return; }

            for (int a = 0; a < w.Length; a++) w[a].Dispose();
            int i = w.Length + (int)Math.Ceiling(dIncStep);
            if (i < 0) i = 1; w = new Form[i];
            
            Form1_Load(new object(), new EventArgs());
        }

        private void horz_Click(object sender, EventArgs e)
        {
            iHorzMul += (int)Math.Ceiling(dIncStep);
            if (iHorzMul < 0) iHorzMul = 0;
        }

        private void vert_Click(object sender, EventArgs e)
        {
            iVertMul += (int)Math.Ceiling(dIncStep);
            if (iVertMul < 0) iVertMul = 0;
        }

        private void dofs_Click(object sender, EventArgs e)
        {
            dOfs += dIncStep;
        }

        private void dinc_Click(object sender, EventArgs e)
        {
            dOfsInc += dIncStep;
        }

        private void slep_Click(object sender, EventArgs e)
        {
            iSleep += (int)Math.Ceiling(dIncStep);
            if (iSleep < 0) iSleep = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) dIncStep = 0.001;
            if (e.KeyCode == Keys.W) dIncStep = 0.01;
            if (e.KeyCode == Keys.E) dIncStep = 0.1;
            if (e.KeyCode == Keys.R) dIncStep = 1;
            if (e.KeyCode == Keys.T) dIncStep = 10;
            if (e.KeyCode == Keys.Y) dIncStep = 100;
            if (e.KeyCode == Keys.A) dIncStep = -0.001;
            if (e.KeyCode == Keys.S) dIncStep = -0.01;
            if (e.KeyCode == Keys.D) dIncStep = -0.1;
            if (e.KeyCode == Keys.F) dIncStep = -1;
            if (e.KeyCode == Keys.G) dIncStep = -10;
            if (e.KeyCode == Keys.H) dIncStep = -100;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
