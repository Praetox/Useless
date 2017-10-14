using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Superbot2k9 {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }
        private Fail[] fail = new Fail[0];
        private void frmMain_Load(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show(
                "This was made the 1st of april.\r\n\r\n" +
                "To skip right to the joke, press \"Yes\".\r\n" +
                "To see how it actually worked, hit \"No\".", "hurf durf",
                MessageBoxButtons.YesNo)) new frmFuckYeah().Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            frmUserlist fu = new frmUserlist(fail);
            fu.ShowDialog(); fail = fu.getFail();
            label5.Text = fail.Length + "";
        }

        private void button2_Click(object sender, EventArgs e) {
            if (fail.Length == 0) {
                MessageBox.Show("Du må legge til brukere først!",
                    "Brukerfeil", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            } else new frmFuckYeah().Show();
        }
    }
    public enum KontoStatus {
        ok, feilpw, drept, modkill, ukjent
    };
    public class Fail {
        IPEndPoint ipEP;
        IPAddress ipHost;
        public string sUser;
        public string sPass;
        public string sSess;
        public bool LoggedIn;
        public KontoStatus status = KontoStatus.ukjent;

        public bool debug = false;
        const int NM_PORT = 80;
        const string NM_HOST = "nordicmafia.net";
        const string NM_SESS = "Set-Cookie: PHPSESSID=";
        const string ANTIBOT = "=3>Anti-bot bekreftelse:<";
        const string NOT_LOGGED_IN = "<font color=red><b>Du er ikke logget inn!</b></font>";
        const string URL_KRIM = "nordic/index.php?side=krim";
        const string URL_PRES = "nordic/index.php?side=utpressing";
        const string URL_FIGH = "nordic/index.php?side=fightclub";
        const string URL_BILT = "nordic/index.php?side=gta";
        string[] VALG_KRIM = new string[] { "bank", "bensin", "automat", "lomme" };

        // MAIN METHODS
        public Fail(string sUser, string sPass) {
            if (debug) Console.WriteLine("Constructor");
            ipHost = Dns.GetHostAddresses(NM_HOST)[0];
            ipEP = new IPEndPoint(ipHost, NM_PORT);
            this.sUser = sUser; this.sPass = sPass;
        }
        private Socket getSck() {
            if (debug) Console.WriteLine("getSck");
            AddressFamily adrFam = AddressFamily.InterNetwork;
            SocketType sckTyp = SocketType.Stream;
            ProtocolType proTyp = ProtocolType.Tcp;
            Socket sck = new Socket(adrFam, sckTyp, proTyp);
            sck.Connect(ipEP); return sck;
        }
        public string GET(string sSite) {
            if (debug) Console.WriteLine("GET");
            Socket sck = getSck();
            sck.Send(toByt("GET /" + sSite + " HTTP/1.0" + "\r\n"));
            sck.Send(toByt("Host: " + NM_HOST + "\r\n"));
            sck.Send(toByt("Connection: close" + "\r\n"));
            if (sSess != "")
                sck.Send(toByt("Cookie: PHPSESSID=" + sSess + "; " +
                    "__utma=34354323.2625683346.3678435859.4264297645.4855366763.1; " +
                    "__utmc=34354323; " +
                    "__utmz=34354323.6414241682.1.1.utmccn=(direct)|utmcsr=(direct)|utmcmd=(none); " +
                    "__utmb=34354323" + "\r\n"));
            sck.Send(toByt("\r\n"));
            string sHead = GiveHead(sck);
            int iLen = GiveCLen(sck, sHead);
            string ret = GiveBody(sck, iLen);
            if (debug) Console.WriteLine(ret);
            return ret;
        }
        public string POST(string sSite, string sData) {
            if (debug) Console.WriteLine("POST");
            Socket sck = getSck();
            string sPacket =
                "POST /" + sSite + " HTTP/1.0" + "\r\n" +
                "Host: " + NM_HOST + "\r\n" +
                "Connection: close" + "\r\n" +
                "Cookie: PHPSESSID=" + sSess + "; " +
                "__utma=34354323.2625683346.3678435859.4264297645.4855366763.1; " +
                "__utmc=34354323; " +
                "__utmz=34354323.6414241682.1.1.utmccn=(direct)|utmcsr=(direct)|utmcmd=(none); " +
                "__utmb=34354323" + "\r\n" +
                "Content-Type: application/x-www-form-urlencoded" + "\r\n" +
                "Content-Length: " + sData.Length + "\r\n" +
                "\r\n" + sData + "\r\n\r\n";
            if (debug) Console.Write(sPacket);
            sck.Send(toByt(sPacket));
            string sHead = GiveHead(sck);
            int iLen = GiveCLen(sck, sHead);
            string ret = GiveBody(sck, iLen);
            if (debug) Console.WriteLine(ret);
            return ret;
        }
        public void ClearSession() {
            if (debug) Console.WriteLine("ClearSession");
            sSess = "";
        }

        // INTERNAL METHODS
        private string GiveHead(Socket sck) {
            if (debug) Console.WriteLine("GiveHead");
            string sRet = "";
            while (sck.Connected &&
                !sRet.EndsWith("\r\n\r\n")) {
                byte[] blah = new byte[1];
                sck.Receive(blah);
                if (blah[0] == 0) break;
                sRet += (char)blah[0];
            }
            if (sRet.Contains(NM_SESS))
                sSess = Split(Split(sRet,
                    NM_SESS)[1], ";")[0];
            return sRet;
        }
        private int GiveCLen(Socket sck, string sHead) {
            if (debug) Console.WriteLine("GiveCLen");
            if (!sHead.Contains("Content-Length: "))
                return -1; //OMGWTF SERVER FAILS >.<
            return Convert.ToInt32(Split(Split(sHead,
                "Content-Length: ")[1], "\r\n")[0]);
        }
        private string GiveBody(Socket sck, int iLen) {
            if (debug) Console.WriteLine("GiveBody");
            int iRead = 0; int iOfs = 0;
            bool InfiniteLength = (iLen == -1);
            if (InfiniteLength) iLen =
                (int)Math.Pow(2, 17);

            byte[] bBody = new byte[iLen];
            while (sck.Connected &&
                (iLen > 0 || InfiniteLength)) {
                iRead = sck.Available; if (iRead == 0) {
                    string nig = toStr(bBody);
                    if (nig.Contains("</html>") ||
                        nig.Contains("</HTML>"))
                        break; //lolsolution
                }
                sck.Receive(bBody, iOfs, iRead, SocketFlags.None);
                iOfs += iRead; iLen -= iRead;
            }
            sck.Close();
            return toStr(bBody).Trim(new char[] { '\0' });
            //Jeg er for lat til å trimme byte-arrayet
            //dersom lengden ikke sendes i http head.
            //trim() gjør jobben effektivt nok.
        }

        // HELPER METHODS
        private string toStr(byte[] b) {
            if (debug) Console.WriteLine("  toStr");
            return Encoding.UTF8.GetString(b);
        }
        private byte[] toByt(string s) {
            if (debug) Console.WriteLine("  toByt");
            return Encoding.UTF8.GetBytes(s);
        }
        string[] Split(string a, string b) {
            if (debug) Console.WriteLine("  Split");
            return a.Split(new string[] { b },
                StringSplitOptions.None);
        }
        public string urlEnc(string s) {
            if (debug) Console.WriteLine("urlEnc");
            //Dette var ensformig. Tror jeg tok med de
            //viktigste. Fortsett om du gidder. Egads.
            string[] a = new string[]{"%"," ","!","\"","#",
                "$","&","'","(",")","*","+",",","-",".","/",
                ":",";","<","=",">","?","@","[","\\","]","^",
                "_","`","{","|","}","~","æ","ø","å","Æ","Ø","Å"};
            string[] b = new string[]{"%25","%20","%21","%22","%23","%24",
                "%26","%27","%28","%29","%2A","%2B","%2C","%2D","%2E","%2F",
                "%3A","%3B","%3C","%3D","%3E","%3F","%40","%5B","%5C","%5D",
                "%5E","%5F","%60","%7B","%7C","%7D","%7E",
                "%E6","%f8","%E5","%C6","%D8","%C5"};
            for (int c = 0; c < a.Length; c++)
                s = s.Replace(a[c], b[c]);
            return s;
        }

        // NORDICMAFIA SHIT
        public bool Login() {
            if (debug) Console.WriteLine("Login");
            ClearSession(); //fuck your session
            GET("nordic/"); //I want a new one.
            if (debug) Console.WriteLine("SESS#" + sSess);
            string s = POST("nordic/logginn.php",
                "brukernavn=" + urlEnc(sUser) + "&" +
                "passoord=" + urlEnc(sPass) + "&" +
                "Submit=Logg+Inn%21&" +
                "kqqwe=FFGGGLNNLNFLMN");
            LoggedIn = s.Contains("<b>Hoved</b>");
            if (LoggedIn)
                status = KontoStatus.ok;
            else status = KontoStatus.ukjent;
            if (s.Contains("<b>Feil brukernavn/passord!</b>"))
                status = KontoStatus.feilpw;
            if (s.Contains("<b>Du har blitt drept!</b>"))
                status = KontoStatus.drept;
            if (s.Contains("<b>Du ble drept av en moderator"))
                status = KontoStatus.modkill;
            if (!LoggedIn) return false;
            System.Threading.Thread.Sleep(4000);
            //Nå må jeg lese videre til eksamen imorgen,
            //så tar en spansk en på tresekunders-sperra.
            return LoggedIn;
        }
        public int Kriminalitet(int valg) {
            //>0 = ventetid
            //-1 = Vellykket
            //-2 = Mislykket
            //-3 = Antibot
            //-4 = Whoops.
            string s = POST(URL_KRIM, "valg=" + VALG_KRIM[valg] + "&bekreftkrimsubmit=Utf%F8r%21");
            if (s.Contains(NOT_LOGGED_IN))
                if (Login()) return Kriminalitet(valg);
                else return -4; //OISANN HVA SKJEDDE NÅ?
            if (s.Contains(ANTIBOT)) return -3;
            System.Threading.Thread.Sleep(4000); //Ditto her.
            if (s.Contains("<span id=tell>")) return Convert.ToInt32(
                Split(Split(s, "<span id=tell>")[1], "</span>")[0]);
            if (s.Contains("Vellykket! ")) return -1;
            if (s.Contains("Mislykket! ")) return -2;
            return 9001; //Hm.
        }
        public int Utpressing() {
            //>0 = ventetid
            //-1 = Vellykket
            //-2 = Mislykket
            //-3 = Antibot
            //-4 = Whoops.
            string s = POST(URL_PRES, "subpress=Utf%F8r%21");
            if (s.Contains(NOT_LOGGED_IN))
                if (Login()) return Utpressing();
                else return -4; //OISANN HVA SKJEDDE NÅ?
            if (s.Contains(ANTIBOT)) return -3;
            System.Threading.Thread.Sleep(4000); //og her.
            if (s.Contains(" vente 16 minutter mellom")) return 30;
            if (s.Contains("Vellykket! ")) return -1;
            if (s.Contains("Mislykket! ")) return -2;
            return 9001; //Hm.
        }
        public int Fightclub() {
            //>0 = ventetid
            //-1 = Vellykket
            //-3 = Antibot
            //-4 = Whoops.
            string s = POST(URL_FIGH, "aktivitetvalg=1&subtrennaa=Utf%F8r%21");
            if (s.Contains(NOT_LOGGED_IN))
                if (Login()) return Fightclub();
                else return -4; //OISANN HVA SKJEDDE NÅ?
            if (s.Contains(ANTIBOT)) return -3;
            System.Threading.Thread.Sleep(4000); //yessda
            if (s.Contains(" vente til du har hvilt ut!")) return 120;
            if (s.Contains("Du tok 25 Pushups. Du m")) return -1;
            return 9001; //Hm.
        }
        public int Biltyveri(int valg) {
            //Nei nå gidder jeg ikke mer.
            return -3;
        }
    }
}
