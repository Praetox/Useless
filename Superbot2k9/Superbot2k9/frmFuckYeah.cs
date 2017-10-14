using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Superbot2k9 {
    public partial class frmFuckYeah : Form {
        public frmFuckYeah() {
            InitializeComponent();
        }
        Bitmap[] bm;
        System.Reflection.Assembly myAsm;
        private void frmFuckYeah_Load(object sender, EventArgs e) {
            bm = new Bitmap[4];
            myAsm = System.Reflection.Assembly.
                GetExecutingAssembly();

            Stream muss = rcSm("helix.mp3");
            byte[] mus = new byte[muss.Length];
            muss.Read(mus, 0, mus.Length);
            File.WriteAllBytes("efg.mp3", mus);
            MP3 mp3a = new MP3("a", "efg.mp3");
            bm[0] = rcBm("2.png");
            bm[1] = rcBm("3.png");
            bm[2] = rcBm("4.png");
            bm[3] = rcBm("1.png");

            int step = 200;
            int pic = 0; pb.Image = bm[pic];
            this.Width += bm[0].Width - this.Width;
            this.Height += bm[0].Height - this.Height;

            Size sz = Screen.FromControl
                (this).WorkingArea.Size;
            sz.Height -= this.Height;
            sz.Width -= this.Width;
            sz.Height /= 2;
            sz.Width /= 2;

            Timer tMove = new Timer();
            tMove.Tick += delegate(object o1, EventArgs o2) {
                double ang = mp3a.Pos() / (660 * Math.PI);
                double x = Math.Cos(ang) * sz.Width;
                double y = Math.Sin(ang) * sz.Height;
                this.Left = (int)x + sz.Width;
                this.Top = (int)y + sz.Height;
            }; tMove.Interval = 10;

            Timer tPic = new Timer();
            tPic.Tick += delegate(object o1, EventArgs o2) {
                int pos = mp3a.Pos();
                int num = pos / step;
                int rel = num % bm.Length;
                if (rel != pic) {
                    pb.Image = bm[rel];
                    pic = rel;
                }
            }; tPic.Interval = 1;

            this.Show(); Application.DoEvents();
            mp3a.Play(0); tMove.Start(); tPic.Start();
        }
        private Stream rcSm(string var) {
            return myAsm.GetManifestResourceStream(
                Application.ProductName +
                ".stash." + var);
        }
        private Bitmap rcBm(string var) {
            using (Stream strm = rcSm(var))
                return new Bitmap(strm);
        }
        private void pb_Click(object sender, EventArgs e) {

        }
    }
    public class MP3 {
        private string id;
        private bool isOpen;
        public long iPos = 0;

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern long mciSendString(
            string strCommand,          // The command to execute
            StringBuilder strReturn,    // The returned string (if any)
            int iReturnLength,          // The bitcount of the returned string
            IntPtr hwndCallback);       // Callback value of spec. handle
        public MP3(string id) {
            this.id = id;
        }
        public MP3(string id, string sFile) {
            this.id = id;
            Open(sFile);
        }
        public void Open(string sFile) {
            MCI("open \"" + sFile + "\" type mpegvideo alias " + id);
            MCI("set " + id + " time format ms");
            iPos = 0; isOpen = true;
        }
        public void Play() {
            if (isOpen) {
                MCI("play " + id + " from " + iPos + " repeat");
            }
        }
        public void Play(long loc) {
            iPos = loc;
            Play();
        }
        public void Pause() {
            if (isOpen) {
                MCI("stop " + id);
                iPos = Convert.ToInt32(MCI
                    ("status " + id + " position"));
            }
        }
        public void Stop() {
            if (isOpen) {
                MCI("stop " + id);
                iPos = 0;
            }
        }
        public void Close() {
            MCI("close " + id);
            iPos = 0; isOpen = false;
        }
        public bool isPlaying() {
            return (MCI("status " + id + " mode") == "playing");
        }
        public Int32 Pos() {
            if (isPlaying()) return Convert.ToInt32
                (MCI("status " + id + " position"));
            return 0;
        }
        public Int32 Len() {
            if (isPlaying()) return Convert.ToInt32
                (MCI("status " + id + " length"));
            return 0;
        }
        public string MCI(string qStr) {
            StringBuilder ret = new StringBuilder(255);
            mciSendString(qStr, ret, 255, (IntPtr)0);
            return ret.ToString();
        }
    }
}
