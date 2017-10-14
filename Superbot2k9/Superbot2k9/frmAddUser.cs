using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Superbot2k9 {
    public partial class frmAddUser : Form {
        public frmAddUser() {
            InitializeComponent();
        }
        public Fail fail;
        private void button1_Click(object sender, EventArgs e) {
            string txt = button1.Text;
            button1.Text = "Vennligst vent";
            Application.DoEvents();
            Fail fail = new Fail(textBox1.Text, textBox2.Text);
                bool ok = fail.Login();
                string msg = "Kontoen returnerte følgende flag: \r\n\r\n";
                if (fail.status == KontoStatus.ok) msg += "Levende, korrekt passord";
                if (fail.status == KontoStatus.modkill) msg += "Drept av moderator";
                if (fail.status == KontoStatus.drept) msg += "Drept av medspiller";
                if (fail.status == KontoStatus.feilpw) msg += "Ukorrekt passord";
                if (fail.status == KontoStatus.ukjent) msg += "Ukjent (serverfail)";
                MessageBox.Show(msg);
                if (ok) {
                    this.fail = fail; this.Close();
                }
                button1.Text = txt;
        }

        private void frmAddUser_Load(object sender, EventArgs e) {
            this.Show(); Application.DoEvents();
            textBox1.Focus();
        }
    }
}
