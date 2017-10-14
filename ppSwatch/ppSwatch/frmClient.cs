using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ppSwatch
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        public static Process target = null;
        Process[] procs = Process.GetProcessesByName("mspaint");
        private void frmClient_Load(object sender, EventArgs e)
        {
            if (procs.Length == 0)
            {
                Process.Start("mspaint.exe"); Application.DoEvents();
                target = Process.GetProcessesByName("mspaint")[0];
                this.Close(); return;
            }
            for (int a = 0; a < procs.Length; a++)
                ddProc.Items.Add(procs[a].MainWindowTitle);
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            target = procs[ddProc.SelectedIndex];
            this.Close();
        }
    }
}
