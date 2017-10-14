using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace liveslide
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool btVIEW = false;
        System.Collections.ArrayList images =
            new System.Collections.ArrayList();
        System.Net.WebClient wc = new System.Net.WebClient();
        string[] sActions;
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = Point.Empty;
            this.Show(); Application.DoEvents();

            if (System.IO.File.Exists("gaveconf.ini"))
                sActions = System.IO.File.ReadAllText
                    ("gaveconf.ini").Replace("\r", "").Split('\n');
            else sActions = new string[]{
                "http://cgi.4chan.org/h/imgboard.html",
                "http://cgi.4chan.org/h/",
                "</a>  &nbsp; [<a href=\"",
                "\">Reply</a>]", ""};

            BackgroundWorker bwGET = new BackgroundWorker();
            bwGET.DoWork += new DoWorkEventHandler(bwGET_DoWork);
            bwGET.RunWorkerAsync();

            Timer tVIEW = new Timer();
            tVIEW.Tick += new EventHandler(tVIEW_Tick);
            tVIEW.Interval = 2000;
            tVIEW.Start();
        }

        void bwGET_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                string src = wc.DownloadString(sActions[0]);
                if (sActions[2].Length > 2 &&
                    src.Contains(sActions[2]))
                {
                    string[] hrefs = split(src, sActions[2]);
                    src = "";
                    for (int a = 1; a < hrefs.Length; a++)
                        hrefs[a] = sActions[1] + split
                            (hrefs[a], sActions[3])[0];
                    for (int a = 1; a < hrefs.Length; a++)
                        src += new System.Net.WebClient().
                            DownloadString(hrefs[a]);
                }
                string[] img = split(src, "<a ");
                for (int a = 0; a < img.Length; a++)
                {
                    if (!img[a].Contains("href=\"")) continue;
                    img[a] = split(split(img[a], "href=\"")[1], "\"")[0];
                    if (img[a].EndsWith(".png") || img[a].EndsWith(".PNG") ||
                        img[a].EndsWith(".jpg") || img[a].EndsWith(".JPG"))
                    {
                        while (images.Count > 10)
                            System.Threading.Thread.Sleep(10);
                        byte[] b = wc.DownloadData(img[a]);
                        using (System.IO.MemoryStream ms =
                            new System.IO.MemoryStream(b))
                            images.Add(new Bitmap(ms));
                    }
                }
            }
        }

        string[] split(string a, string b)
        {
            return a.Split(new string[] { b }, StringSplitOptions.None);
        }

        void tVIEW_Tick(object sender, EventArgs e)
        {
            if (btVIEW) return; btVIEW = true;
            label1.Text = "Images ready: " + images.Count;
            Application.DoEvents();
            if (images.Count > 0)
            {
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage.Dispose();
                    this.BackgroundImage = null;
                }
                if (pb.Image != null) pb.Image.Dispose();
                pb.Image = ((Bitmap)images[0]).Clone() as Image;
                images.RemoveAt(0);
            }
            Application.DoEvents();
            btVIEW = false;
        }
    }
}
