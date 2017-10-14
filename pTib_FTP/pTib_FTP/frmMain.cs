using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pTib_FTP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private int t2aDelay = 0, t2next = 0;
        Memory Tib = new Memory(); bool intMain = false;
        System.Diagnostics.Process[] TibiaClients;

        #region Conversions
        /// <summary>
        /// Returns character from ascii
        /// </summary>
        private string Chr(int id)
        {
            return Convert.ToChar(id).ToString();
        }
        /// <summary>
        /// Returns ascii from character
        /// </summary>
        private int Asc(char id)
        {
            return Convert.ToInt16(id);
        }
        /// <summary>
        /// Converts integer to byte
        /// </summary>
        public byte[] Int2Byte(int Value)
        {
            byte[] rawbuf = BitConverter.GetBytes(Value);
            int a = 0; for (a = rawbuf.Length; a > 0; a--) if (rawbuf[a - 1] != 0) break;
            byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = rawbuf[a];
            return buf;
        }
        /// <summary>
        /// Converts byte to string
        /// </summary>
        public String Byte2Str(byte[] Value)
        {
            int len = 0; for (len = Value.Length; len > 0; len--) if (Value[len - 1] != 0) break;
            string ret = ""; for (int a = 0; a < len; a++) ret += (char)Value[a];
            //byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = Value[a];
            return ret; //System.Text.Encoding.ASCII.GetString(buf);
        }
        /// <summary>
        /// Converts string to byte
        /// </summary>
        public byte[] Str2Byte(string Value)
        {
            byte[] ret = new byte[Value.Length];
            for (int a = 0; a < Value.Length; a++) ret[a] = (byte)Value[a];
            return ret;
        }
        #endregion
        #region "Standard" functions
        ///<summary>
        /// Splits msg by delim, returns bit part
        ///</summary>
        public static string Split(string msg, string delim, int part)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return "";
            if (msg.IndexOf(delim) == -1) return msg;
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        ///<summary>
        /// Splits msg by delim, returns string array
        ///</summary>
        public static string[] aSplit(string msg, string delim)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return new string[0];
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        /// <summary>
        /// Alternative aSplit, should be faster
        /// </summary>
        public string[] aSplit2(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    ret[spt] = msg.Substring(0, FoundPos); spt++;
                    msg = msg.Substring(FoundPos + delimLen);
                }
            }
            ret[spt] = msg; return ret;
        }
        ///<summary>
        /// Counts occurrences of delim within msg
        ///</summary>
        public static int Countword(string msg, string delim)
        {
            int ret = 0; if (msg == "" || msg == null || delim == "" || delim == null) return 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
        }
        /// <summary>
        /// Alternative Countword, should be faster
        /// </summary>
        public int Countword2(string msg, string delim)
        {
            int ret = 0; int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    msg = msg.Substring(FoundPos + delimLen); ret++;
                }
            }
            return ret;
        }
        ///<summary>
        /// Converts a number (vl) into a digit-grouped string
        ///</summary>
        public static string Decimize(string vl)
        {
            string ret = ""; int spt = 0;
            while (vl.Length != 0)
            {
                if (spt == 3)
                {
                    ret = "," + ret; spt = 0;
                }
                ret = vl.Substring(vl.Length - 1, 1) + ret;
                vl = vl.Substring(0, vl.Length - 1);
                spt++;
            }
            return ret;
        }
        ///<summary>
        /// Creates a string containing vl number of spaces
        ///</summary>
        public static string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }
        ///<summary>
        /// Removes all spaces at start and end of vl
        ///</summary>
        public static string unSpace(string vl)
        {
            string ret = vl;
            try
            {
                while (ret.Substring(0, 1) == " ")
                {
                    ret = ret.Substring(1);
                }
                while (ret.Substring(ret.Length - 1) == " ")
                {
                    ret = ret.Substring(0, ret.Length - 1);
                }
                return ret;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Removes all newlines at start and end of vl
        /// </summary>
        public static string unNewline(string vl)
        {
            try
            {
                while ((vl.Substring(0, 1) == "\r") || (vl.Substring(0, 1) == "\n"))
                {
                    vl = vl.Substring(1);
                }
                while ((vl.Substring(vl.Length - 1) == "\r") || (vl.Substring(vl.Length - 1) == "\n"))
                {
                    vl = vl.Substring(0, vl.Length - 1);
                }
                return vl;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Returns system clock in seconds
        ///</summary>
        public int sTick()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Returns what sTick will be after vl seconds
        ///</summary>
        public int T2A(int vl)
        {
            int ret = sTick() + vl + t2aDelay;
            if (ret > 86400) ret -= 86400;
            return ret;
        }
        ///<summary>
        /// Returns the waiting time until sTick is vl
        ///</summary>
        public int T2B(int vl)
        {
            int ret = vl - sTick();
            if (ret < 0) ret += 86400;
            if (ret > 3610) ret = 0;
            return ret;
        }
        ///<summary>
        /// Returns how many seconds sTick has passed vl
        ///</summary>
        public int T2C(int vl)
        {
            int ret = sTick() - vl;
            if (ret < 0) ret += 86400;
            if (ret > 3610) ret = 0;
            return ret;
        }
        ///<summary>
        /// Sleeps for vl seconds
        ///</summary>
        public void iSlp(int vl)
        {
            long lol = Tick();
            while (Tick() < lol + vl)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }
        ///<summary>
        /// Returns system clock in miliseconds
        ///</summary>
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        ///<summary>
        /// Returns hh:mm:ss of vl (seconds)
        ///</summary>
        public string s2ms(int vl)
        {
            int iHour = 0; int iMins = 0; int iSecs = vl;
            while (iSecs >= 60)
            {
                iSecs -= 60; iMins++;
            }
            while (iMins >= 60)
            {
                iMins -= 60; iHour++;
            }
            string sHour = Convert.ToString(iHour); sHour = Space(2 - sHour.Length).Replace(" ", "0") + sHour;
            string sMins = Convert.ToString(iMins); sMins = Space(2 - sMins.Length).Replace(" ", "0") + sMins;
            string sSecs = Convert.ToString(iSecs); sSecs = Space(2 - sSecs.Length).Replace(" ", "0") + sSecs;
            return sHour + ":" + sMins + ":" + sSecs;
        }
        /// <summary>
        /// This function returns false and makes regkey if not exist.
        /// </summary>
        private bool Reg_DoesExist(string regPath)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key = key.OpenSubKey(regPath, true);
                long lol = key.SubKeyCount;
                return true;
            }
            catch
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key.CreateSubKey(regPath);
                return false;
            }
        }
        ///<summary>
        /// Returns current date and time
        ///</summary>
        public string TDNow()
        {
            return System.DateTime.Now.ToLongDateString() + " .::. " +
                   System.DateTime.Now.ToLongTimeString();
        }
        ///<summary>
        /// Returns MD5 of vl
        ///</summary>
        public string MD5(string vl)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(vl);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
        #endregion
        #region File and array manipulation
        /// <summary>
        /// Reads sFile, works with norwegian letters ae oo aa
        /// </summary>
        public string FileRead(string sFile)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(sFile, Encoding.GetEncoding("iso-8859-1"));
                string ret = sr.ReadToEnd();
                while ((ret.Substring(ret.Length - 1) == "\r") || (ret.Substring(ret.Length - 1) == "\n"))
                    ret = ret.Substring(0, ret.Length - 1);
                sr.Close(); sr.Dispose(); return ret;
            }
            catch { return ""; }
        }
        /// <summary>
        /// Writes sVal to sFile, works with norwegian letters ae oo aa
        /// </summary>
        /// <param name="sFile">Target file</param>
        /// <param name="sVal">The string to write</param>
        /// <param name="bAppend">Append instead of overwrite</param>
        public void FileWrite(string sFile, string sVal, bool bAppend)
        {
            System.IO.FileMode AccessType = System.IO.FileMode.Create;
            if (bAppend) AccessType = System.IO.FileMode.Append;
            System.IO.FileStream fs = new System.IO.FileStream(sFile, AccessType);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        public void FileWrite(string sFile, string sVal)
        {
            FileWrite(sFile, sVal, false);
        }
        /// <summary>
        /// Sorts vl[] alphabetically, ignores letters other than 0-9 a-z
        /// </summary>
        public string[] SortStringArrayAlphabetically(string[] vl)
        {
            for (int a = vl.GetUpperBound(0); a >= 0; a--)
            {
                for (int b = 0; b < a; b++) //changed "b <= a" to "b < a"
                {
                    if (string.Compare(vl[b], vl[b + 1], true) > 0)
                    {
                        //Swap values
                        string tmp = vl[b].ToString();
                        vl[b] = vl[b + 1];
                        vl[b + 1] = tmp;
                    }
                }
            }
            return vl;
        }
        #endregion
        #region Basic Memory Functions
        public int BL_Player()
        {
            int CharID = Tib.RInt(MAdr.CH_ID);
            for (int a = MAdr.BL_Start; a < MAdr.BL_End; a += MAdr.BL_Dist)
            {
                if (Tib.RInt(a + MAdr.BL_ID) == CharID) return a;
            }
            return 0;
        }
        public void CH_Message(string vl)
        {
            Tib.WString(MAdr.CH_TSt, vl + (char)0); Tib.WInt(MAdr.CH_TTi, 30);
        }
        #endregion

        void lg(string vl)
        {
            Status.Text = vl; Application.DoEvents();
        }

        private void Status_Toggle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(FTP_Rate.Text) >= 3600)
            {
                MessageBox.Show("Sorry, but the highest allowed interval is:\r\n3600 seconds (one hour)."); return;
            }
            if (!Website_Template.Text.Contains("%pUrl%"))
            {
                MessageBox.Show("Please keep the %pUrl% tag somewhere in the template."); return;
            }
            if (Status_Toggle.Text == "Enable")
            {
                tMain.Start(); Status_Toggle.Text = "Disable";
            }
            else
            {
                tMain.Stop(); Status_Toggle.Text = "Enable";
            }
            FileWrite("general.ini",
                "<FTP_Host>" + FTP_Host.Text + "</FTP_Host>" + "\r\n" +
                "<FTP_User>" + FTP_User.Text + "</FTP_User>" + "\r\n" +
                "<FTP_Pass>" + FTP_Pass.Text + "</FTP_Pass>" + "\r\n" +
                "<FTP_Path>" + FTP_Path.Text + "</FTP_Path>" + "\r\n" +
                "<FTP_Rate>" + FTP_Rate.Text + "</FTP_Rate>" + "\r\n");
            FileWrite("template.ini", Website_Template.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t2next = T2A(0);
            Client_Refresh_Click(new object(), new EventArgs());
            if (System.IO.File.Exists("general.ini"))
            {
                string iniGeneral = FileRead("general.ini");
                FTP_Host.Text = Split(Split(iniGeneral, "<FTP_Host>", 1), "</FTP_Host>", 0);
                FTP_User.Text = Split(Split(iniGeneral, "<FTP_User>", 1), "</FTP_User>", 0);
                FTP_Pass.Text = Split(Split(iniGeneral, "<FTP_Pass>", 1), "</FTP_Pass>", 0);
                FTP_Path.Text = Split(Split(iniGeneral, "<FTP_Path>", 1), "</FTP_Path>", 0);
                FTP_Rate.Text = Split(Split(iniGeneral, "<FTP_Rate>", 1), "</FTP_Rate>", 0);
            }
            if (System.IO.File.Exists("template.ini"))
            {
                string iniTemplate = FileRead("template.ini");
                Website_Template.Text = iniTemplate;
            }
        }

        private void Client_Refresh_Click(object sender, EventArgs e)
        {
            Client_CBox.Items.Clear();
            TibiaClients = System.Diagnostics.Process.GetProcessesByName("Tibia");
            if (TibiaClients.Length == 0)
            {
                MessageBox.Show("Could not find any Tibia clients!");
            }
            else
            {
                foreach (System.Diagnostics.Process Proc in TibiaClients)
                {
                    Tib.mTarget = Proc; Tib.Open(); int CharID = Tib.RInt(MAdr.CH_ID);
                    string CharName = "Unknown"; if (CharID != 0)
                        CharName = Tib.RString(BL_Player() + MAdr.BL_Name);
                    Client_CBox.Items.Add("[" + Proc.Id + "] " + CharName);
                    Tib.Close(); Tib.mTarget = new System.Diagnostics.Process();
                }
                Client_CBox.SelectedIndex = 0;
            }
        }
        private void Client_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tib.isSet()) Tib.Close();
            Tib.mTarget = TibiaClients[Client_CBox.SelectedIndex]; Tib.Open(); Application.DoEvents();
        }

        private void tMain_Tick(object sender, EventArgs e)
        {
            if (intMain) return; intMain = true;
            if (T2B(t2next) != 0 || !Website_Template.Text.Contains("%pUrl%"))
            {
                lg("Uploading in " + T2B(t2next) + " seconds"); intMain = false; return;
            }
            lg("Uploading...");
            t2next = T2A(Convert.ToInt32(FTP_Rate.Text));
            string cNick = Tib.RString(BL_Player() + MAdr.BL_Name);
            string cOnline = "No!";  if (Tib.RInt(MAdr.CH_Con)==8) cOnline = "Yes";

            double dLvl = (double)Tib.RInt(MAdr.CH_Lvl) + 1;
            int Exp2Lvl = (int)((((double)50 / (double)3) * Math.Pow(dLvl, 3)) - (100 * Math.Pow(dLvl, 2)) +
                          (((double)850 / (double)3) * dLvl) - 200);
            Exp2Lvl = Exp2Lvl - Tib.RInt(MAdr.CH_Exp);

            string fPath = FTP_Path.Text.Replace("%nick%", cNick
                .Replace(" ", "_")
                .Replace("'", ""))
                .Replace("\\", "/");
            string fName = fPath; if (fName.Contains("/"))
                fName = fName.Substring(fName.LastIndexOf("/"));

            string upVl = Website_Template.Text
                .Replace("%pUrl%", "<a href=\"http://www.praetox.com\">")
                .Replace("%nick%", Tib.RString(BL_Player() + MAdr.BL_Name))
                .Replace("%hp%", Tib.RInt(MAdr.CH_HP).ToString())
                .Replace("%mana%", Tib.RInt(MAdr.CH_Ma).ToString())
                .Replace("%exp%", Decimize(Tib.RInt(MAdr.CH_Exp).ToString()))
                .Replace("%e2l%", Decimize(Exp2Lvl.ToString()))
                .Replace("%explvl%", Tib.RInt(MAdr.CH_Lvl).ToString())
                .Replace("%maglvl%", Tib.RInt(MAdr.CH_Mlv).ToString())
                .Replace("%soul%", Tib.RInt(MAdr.CH_Sol).ToString())
                .Replace("%x%", Tib.RInt(MAdr.CH_X).ToString())
                .Replace("%y%", Tib.RInt(MAdr.CH_Y).ToString())
                .Replace("%z%", Tib.RInt(MAdr.CH_Z).ToString())
                .Replace("%cap%", Tib.RInt(MAdr.CH_Cap).ToString())
                .Replace("%online%", cOnline)
                .Replace("%skillL1%", Tib.RInt(MAdr.CH_SkillL1).ToString())
                .Replace("%skillL2%", Tib.RInt(MAdr.CH_SkillL2).ToString())
                .Replace("%skillL3%", Tib.RInt(MAdr.CH_SkillL3).ToString())
                .Replace("%skillL4%", Tib.RInt(MAdr.CH_SkillL4).ToString())
                .Replace("%skillL5%", Tib.RInt(MAdr.CH_SkillL5).ToString())
                .Replace("%skillL6%", Tib.RInt(MAdr.CH_SkillL6).ToString())
                .Replace("%skillL7%", Tib.RInt(MAdr.CH_SkillL7).ToString())
                .Replace("%skillP1%", Tib.RInt(MAdr.CH_SkillP1).ToString())
                .Replace("%skillP2%", Tib.RInt(MAdr.CH_SkillP2).ToString())
                .Replace("%skillP3%", Tib.RInt(MAdr.CH_SkillP3).ToString())
                .Replace("%skillP4%", Tib.RInt(MAdr.CH_SkillP4).ToString())
                .Replace("%skillP5%", Tib.RInt(MAdr.CH_SkillP5).ToString())
                .Replace("%skillP6%", Tib.RInt(MAdr.CH_SkillP6).ToString())
                .Replace("%skillP7%", Tib.RInt(MAdr.CH_SkillP7).ToString());
            FileWrite(fName, upVl);
            string ftpVl =
                "open " + FTP_Host.Text + "\r\n" +
                FTP_User.Text + "\r\n" +
                FTP_Pass.Text + "\r\n" +
                "PUT \"" + fName + "\" \"" + fPath + "\"" + "\r\n" +
                "bye";
            FileWrite("tmp.txt", ftpVl);
            
            System.Diagnostics.Process ftpProc =
                new System.Diagnostics.Process();
            ftpProc.StartInfo.FileName = "ftp.exe";
            ftpProc.StartInfo.Arguments = "-s:tmp.txt";
            ftpProc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ftpProc.Start();
            while (!ftpProc.HasExited)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
            this.Text = "pTib FTP v" + Application.ProductVersion + " - Uploading to " + fPath;
            lg("Upload completed!");
            intMain = false;
        }

        private void Client_GBox_Enter(object sender, EventArgs e)
        {

        }

        private void FTP_Host_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
