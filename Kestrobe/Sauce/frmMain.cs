using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kestrobe {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }
        Player pl = new Player();
        private void Reload_Click(object sender, EventArgs e) {
            string[] cic = new string[_Tracks.CheckedItems.Count];
            for (int a = 0; a < cic.Length; a++)
                cic[a] = (string)_Tracks.CheckedItems[a];
            _Tracks.Items.Clear();
            string[] tracks = System.IO.Directory
                .GetFiles("tracks", "*.kst");
            for (int a = 0; a < tracks.Length; a++) {
                tracks[a] = tracks[a].Substring(7);
                tracks[a] = tracks[a].Substring(0,
                    tracks[a].Length - 4);
                bool bChecked = false;
                for (int b = 0; b < cic.Length; b++)
                    if (cic[b] == tracks[a])
                        bChecked = true;
                _Tracks.Items.Add(tracks[a], bChecked);
            }
        }
        private void frmMain_Load(object sender, EventArgs e) {
            Reload_Click(sender, e);
            _CheckAll.Checked = true;
            _CheckAll_CheckedChanged(sender, e);
        }
        private void _CheckAll_CheckedChanged(object sender, EventArgs e) {
            bool bCheck = _CheckAll.Checked;
            for (int a = 0; a < _Tracks.Items.Count; a++)
                _Tracks.SetItemChecked(a, bCheck);
        }
        private void _Play_Click(object sender, EventArgs e) {
            pl.Open(_Tracks.CheckedItems[0].ToString());
            pl.Play();
        }

        MP3 m = new MP3();
        private void _Next_Click(object sender, EventArgs e) {
            m.Open("tracks\\I am maid.mp3");
            m.Play();
            System.Threading.Thread.Sleep(1000);
            System.Threading.Thread th =
                new System.Threading.Thread(new
                    System.Threading.ThreadStart(dongs));
            th.IsBackground = true; th.Start();
            MessageBox.Show("" + m.Pos());
        }
        void dongs() {
            System.Threading.Thread.Sleep(500);
            MessageBox.Show("" + m.Pos());
        }

        private void tScript_Tick(object sender, EventArgs e) {
            double dFull = (double)Prog1.Width;
            double dPos = pl.lPos;
            double dLen = pl.lLen;
            double dSize = dFull / dLen * dPos;
            Prog2.Width = (int)Math.Round(dSize);
            _Location.Text = pl.lPos + "";
            _BPM.Text = pl.BPM + "";
            _CurB.Text = pl.il + "";
        }

        private void Prog2_MouseDown(object sender, MouseEventArgs e) {
            SkipTo(e);
        }
        private void Prog2_MouseMove(object sender, MouseEventArgs e) {
            SkipTo(e);
        }
        private void Prog1_MouseDown(object sender, MouseEventArgs e) {
            SkipTo(e);
        }
        private void Prog1_MouseMove(object sender, MouseEventArgs e) {
            SkipTo(e);
        }
        private void SkipTo(MouseEventArgs e) {
            if (e.Button != MouseButtons.Left)
                return;

            double dFull = (double)Prog1.Width;
            double dLen = pl.lLen;
            double dSize = e.X;
            double dPos = dSize * dLen / dFull;
            pl.Skip((long)Math.Round(dPos));
        }
    }
    class Player {
        public long lPos = 0;
        public long lLen = 0;
        public Keys k1 = Keys.NumLock;
        public Keys k2 = Keys.CapsLock;
        public Keys k3 = Keys.Scroll;
        public long Next = 0;
        public double BPM = 0;
        public bool Done = false;
        public int il = 0;
        MP3 mp3 = new MP3();
        cmd nCmd = new cmd();
        StateMod sm = new StateMod();
        string[] scr = new string[0];
        bool EatShitAndDie = false;
        string track = "";
        public Player() {
            Timer tState = new Timer();
            tState.Tick += delegate(object s, EventArgs e) {
                lPos = mp3.Pos();
            };
            tState.Interval = 1;
            tState.Start();
        }
        public void Open(string track) {
            mp3.Open("tracks\\" + track + ".mp3");
            this.track = track; lLen = mp3.Len();
            Done = false;

            string[] saScr =
                System.IO.File.ReadAllText(
                "tracks\\" + track + ".kst")
                .Replace("\r", "").Trim('\n')
                .Split('\n'); il = 0;
            int iScrOfs = -1;
            for (int a = 0; a < saScr.Length; a++) {
                if (saScr[a] == "~GO!") { iScrOfs = a; break; }
                if (saScr[a].StartsWith("BPM:")) BPM =
                    Convert.ToInt32(saScr[a].Substring(4));
                if (saScr[a].StartsWith("DLY:")) Next =
                    Convert.ToInt32(saScr[a].Substring(4));
            }
            if (iScrOfs == -1) {
                MessageBox.Show("Your kst is fucked up.");
                return;
            }
            scr = new string[saScr.Length - iScrOfs];
            for (int a = 0; a < scr.Length; a++)
                scr[a] = saScr[a + iScrOfs];

            System.Threading.Thread th =
                new System.Threading.Thread(new
                    System.Threading.ThreadStart(Work));
            th.IsBackground = true;
            th.Start();
        }
        private void Work() {
            while (true) {
                if (EatShitAndDie) {
                    EatShitAndDie = false;
                    break;
                }
                if (lPos < Next) {
                    int slp = (int)Math.Max
                        (1, (Next - lPos) / 2);
                    System.Threading.Thread.Sleep(slp);
                    continue;
                }
                if (nCmd.BPM != 0) BPM = nCmd.BPM;
                if (nCmd.DLY != 0) Next += nCmd.DLY;
                if (nCmd.Beat != null) {
                    sm.set(k1, (nCmd.Beat[0] != 0));
                    sm.set(k2, (nCmd.Beat[1] != 0));
                    sm.set(k3, (nCmd.Beat[2] != 0));
                }
                double tmp = BPM / 60; //bps
                tmp = 1 / tmp; //spb
                tmp *= 1000 / 8; //mspb
                //MessageBox.Show(tmp + "");
                Next += (long)Math.Round(tmp);

                il++;
                while (il < scr.Length &&
                    scr[il] == "") il++;
                if (il >= scr.Length) break;
                nCmd = new cmd(scr[il], BPM);
            }
            Done = true;
        }
        public void Play() {
            mp3.Play();
        }
        public void Pause() {
            mp3.Pause();
        }
        public void Skip(long pos) {
            if (!Done) {
                EatShitAndDie = true;
                while (EatShitAndDie)
                    System.Threading.
                        Thread.Sleep(1);
            }
            mp3.Stop();
            Open(track);
            mp3.Play(pos);
        }
    }
    class cmd {
        public int[] Beat;
        public long DLY = 0;
        public double BPM = 0;
        public void sDLY(long v) { DLY = v; }
        public void sBPM(double v) { BPM = v; }
        public void sBeat(int[] v) { Beat = v; }
        public cmd(string scmd, double bpm) {
            BPM = bpm;
            Beat = new int[]{
                Convert.ToInt32(scmd[0]) - 48,
                Convert.ToInt32(scmd[1]) - 48,
                Convert.ToInt32(scmd[2]) - 48};
            if (scmd.Contains("BPM:")) {
                int ofs = scmd.IndexOf("BPM:");
                int len = ofs - scmd.IndexOf(" ", ofs);
                if (len < 0) len = scmd.Length - ofs;
                if (scmd[ofs] == '*') BPM *=
                    Convert.ToDouble(scmd.Substring
                    (ofs + 1, len - 1));
                else BPM = Convert.ToDouble(
                    scmd.Substring(ofs, len));
            }
            if (scmd.Contains("DLY:")) {
                int ofs = scmd.IndexOf("DLY:");
                int len = ofs - scmd.IndexOf(" ", ofs);
                if (len < 0) len = scmd.Length - ofs;
                DLY = Convert.ToInt32(
                    scmd.Substring(ofs, len));
            }
        }
        public cmd() { }
    }
    public class StateMod {
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern void keybd_event(byte bVk,
            byte bScan, long dwFlags, long dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern bool GetKeyState(byte nVirtKey);
        public void set(Keys key, bool on) {
            byte iKey = (byte)key;
            if (on && !GetKeyState(iKey) ||
                !on && GetKeyState(iKey)) {
                keybd_event(iKey, 0, 0, 0);
                keybd_event(iKey, 0, 2, 0);
            }
        }
    }
    public class MP3 {
        private bool isOpen;
        public long iPos = 0;

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern long mciSendString(string cmd,
            StringBuilder ret, int retLen, IntPtr hCallback);

        public void Open(string sFileName) {
            MCI("open \"" + sFileName + "\" type mpegvideo alias Kestrobe");
            MCI("set Kestrobe time format ms");
            iPos = 0; isOpen = true;
        }
        public void Play() {
            if (isOpen) {
                MCI("play Kestrobe from " + iPos);
            }
        }
        public void Play(long loc) {
            iPos = loc;
            Play();
        }
        public void Pause() {
            if (isOpen) {
                MCI("stop Kestrobe");
                iPos = Convert.ToInt32(MCI
                    ("status Kestrobe position"));
            }
        }
        public void Stop() {
            if (isOpen) {
                MCI("stop Kestrobe");
                iPos = 0;
            }
        }
        public void Close() {
            MCI("close Kestrobe");
            iPos = 0; isOpen = false;
        }
        public bool isPlaying() {
            return (MCI("status Kestrobe mode") == "playing");
        }
        public Int32 Pos() {
            if (isPlaying()) return Convert.ToInt32
                (MCI("status Kestrobe position"));
            return 0;
        }
        public Int32 Len() {
            if (isOpen) return Convert.ToInt32
                (MCI("status Kestrobe length"));
            return 0;
        }
        public string MCI(string qStr) {
            StringBuilder ret = new StringBuilder(255);
            mciSendString(qStr, ret, 255, (IntPtr)0);
            return ret.ToString();
        }
    }
}
