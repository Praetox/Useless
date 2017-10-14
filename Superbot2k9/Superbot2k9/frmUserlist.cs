using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Superbot2k9 {
    public partial class frmUserlist : Form {
        public frmUserlist(Fail[] fail) {
            InitializeComponent();
            this.al = new ArrayList();
            for (int a = 0; a < fail.Length; a++)
                al.Add(fail[a]);
        }
        ArrayList al;
        private void frmUserlist_Load(object sender, EventArgs e) {
            upd();
        }
        private void button1_Click(object sender, EventArgs e) {
            frmAddUser fau = new frmAddUser();
            fau.ShowDialog();
            Fail fail = fau.fail;
            if (fail != null)
                al.Add(fail);
            upd();
        }
        private void upd() {
            listBox1.Items.Clear();
            for (int a = 0; a < al.Count; a++) {
                listBox1.Items.Add(((Fail)al[a]).sUser);
            }
        }
        public Fail[] getFail() {
            Fail[] ret = new Fail[al.Count];
            for (int a = 0; a < ret.Length; a++)
                ret[a] = (Fail)al[a];
            return ret;
        }

        private void button2_Click(object sender, EventArgs e) {
            while (listBox1.SelectedItems.Count > 0) {
                int o = listBox1.SelectedIndices[0];
                al.RemoveAt(o); upd();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
