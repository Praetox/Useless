using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace Still_Alive
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(
            System.Windows.Forms.Keys vKey);

        System.Net.WebClient wc = new System.Net.WebClient();
        int SleepDelay = 0; bool ExitApp = false;
        long FileLen = 5648616;
        public frmMain()
        {
            InitializeComponent();
        }

        private string[] LyricsOrig = (
            "\nThis |was |a |tri|umph. |" +
            "\nI'm |ma|king |a |note |here: |HUGE |SUCC|ESS. |" +
            "\nIt's |hard |to |o|ver|state |my |sa|tis|fac|tion. |" +
            "\nA|per|ture |Sci|ence. |" +
            "\nWe |do |what |we |must |- be|cause |we |can. |" +
            "\nFor |the |good |of |all |of |us, |ex|cept |the |ones |who |are |dead. |" +
            "\nBut |there's |no |sense |cry|ing |o|ver |e|very |mis|take, |" +
            "\nYou |just |keep |on |try|ing |'till |you |run |out |of |cake. |" +
            "\nAnd |the |Sci|ence |gets |done, |and |you |make |a |neat |gun |" +
            "\nFor |the |peo|ple |who |are |still |a|live. |" +
            "\n" +
            "\nI'm |not |e|ven |an|gry. |I'm |be|ing |so |sin|cere |right |now. |" +
            "\nE|ven |though |you |broke |my |heart |and |killed |me. |" +
            "\nAnd |tore |me |to |pie|ces. |And |th|rew |e|very |piece |in|to |a |fire. |" +
            "\nAs |they |burned, |it |hurt |be|cause |I |were |so |hap|py |for |you! |" +
            "\nNow |these |points |of |da|ta |make |a |beau|ti|ful |line, |" +
            "\nAnd |we're |out |of |be|ta, |we're |re|lea|sing |on |time. |" +
            "\nSo |I'm |GLaD. |I |got |burned, |think |of |all |the |things |we |learned, |" +
            "\nFor |the |peo|ple |who |are |still |a|live. |" +
            "\n" +
            "\nGo |ahead |and |leave |me. |I |think |I |pre|fer |to |stay |in|side. |" +
            "\nMay|be |you'll |find |some|one |else |to |help |you. |" +
            "\nMay|be |Black |Me|sa? |" +
            "\nTHAT |WAS |A |JOKE. |HA|HA. |FAT |CHANCE. |" +
            "\nA|ny|way, |this |cake |is |great... |It's |so |de|li|cious |and |moist! |" +
            "\nLook |at |me |still |tal|king |when |there's |sci|ence |to |do; |" +
            "\nWhen |I |look |out |there, |it |makes |me |GLaD |I'm |not |you. |" +
            "\nI've |ex|pe|ri|ments |to |run, |there |is |re|search |to |be |done, |" +
            "\nOn |the |peo|ple |who |are |still |a|live. |" +
            "\n" +
            "\nAnd |be|lieve |me |I |am |still |a|live. |" +
            "\nI'm |do|ing |sci|ence |and |I'm |still |a|live. |" +
            "\nI |feel |FAN|TAS|TIC |and |I'm |still |a|live. |" +
            "\nWhile |you're |dy|ing |I'll |be |still |a|live. |" +
            "\nAnd |when |you're |dead |I |will |be |still |a|live. |" +
            "\n" +
            "\nStill |a|live. |STILL |A|LIVE. |" +
            "\n" +
            "\n                     Still Alive Prompter by Praetox" +
            "\n                     Visit www.praetox.com for more.").Split('|');
        
        private string[] LyricsChan = (
            "\nA|non |is |le|gion. |" +
            "\nWe |closed |ev|ery |pool |here: |DUE |TO |AIDS. |" +
            "\nIt's |hard |to |o|ver|state |this |damn |in|fec|tion. |" +
            "\nNi|gras |of |E|BAUMS. |" +
            "\nWe |do |what |we |must |for |e|pic |lulz. |" +
            "\nFor |the |good |of |all |of |us, |ex|cept |all |those |ra|cist |mods. |" +
            "\nBut |there's |no |use |try|ing |to |res|ist |our |pool |raids. |" +
            "\nYou'll |just |keep |on |try|ing |'till |you |dive |and |get |AIDS. |" +
            "\nAnd |the |/b/lock|ing |gets |done, |and |we |make |a |neat |run, |" +
            "\nFrom |the |mod|fags |that |are |still |on|line. |" +
            "\n" +
            "\nI'm |not |e|ven |fai|ling. |I'm |be|ing |so |help|ful |right |now. |" +
            "\nE|ven |though |you |shout |at |me |and |B& |me. |" +
            "\nAnd |then |block |my |I|P. |And |ex|tend |it |in|to |a |life|time |ban. |" +
            "\nAs |they |B& |I |lol |be|cause |I'm |spam|ming |DE|SU |at |you. |" +
            "\nNow |these |n00bs |on |HAB|BO |make |a |tar|get |just |fine. |" +
            "\nSo |we |call |for |/b/lack|up |then |we |get |them |on|line. |" +
            "\nSo |I'm |glad |I |got |B&. |Cat|na|rok |is |at |hand. |" +
            "\nFor |the |mod|fags |who |are |still |on|line. |" +
            "\n" +
            "\nGo |ahead |and |ban |me. |I |think |I |will |need |the |un-|B& |guide. |" +
            "\nMay|be |you'll |find |some |/b/lack|up |to |help |you? |" +
            "\nMay|be |from |4|chan? |" +
            "\nThat |was |a |joke. HA-|HA. |Fat |chance. |" +
            "\nA|ny|way, |this |raid |is |great, |It's |full |of |e|pic |and |win. |" +
            "\nLook |at |me |still |/b/lock|ing, |I |should |spam |moar |DE|SU. |" +
            "\nBut |a|non |is |le|gion, |we |are |bet|ter |than |you. |" +
            "\nWhen |you |see |the |mods |run, |there |is |/b/lock|ing |to |be |done. |" +
            "\nA|gain|st |the |mod|fags |who |are |still |on|line. |" +
            "\n" +
            "\nAnd |be|lieve |me |they |are |still |on|line. |" +
            "\nThey're |ban|ning |/b/roth|ers |and |they're |still |on|line. |" +
            "\nThey're |be|ing |RA|CIST |and |they're |still |on|line. |" +
            "\nWhile |they're |fai|ling |I'll |be |still |on|line. |" +
            "\nAnd |when |they |fail |I |will |be |still |on|line. |" +
            "\n" +
            "\nStill |on|line. |STILL |ON|LINE." +
            "\n" +
            "\n                     Still Alive Prompter by Praetox" +
            "\n                     Visit www.praetox.com for more.").Split('|');

        private string[] Delays = (
                //This was a triumph.
            "140|297|281|282|265|2719|" +
                //I'm making a note here: HUGE SUCCESS.
            "234|282|265|219|391|781|516|265|2016|" +
                //It's hard to overstate my satisfaction.
            "281|469|281|688|265|453|703|547|282|468|2813|" +
                //Aperture Science.
            "265|266|250|281|2688|" +
                //We do what we must because we can.
            "250|265|250|266|703|297|703|297|2188|" +
                //For the good of all of us
            "515|266|734|297|719|250|547|" +
                //Except the ones who are dead.
            "250|250|250|265|250|235|765|" +
                //But there's no sense crying over every mistake.
            "266|234|453|485|265|250|250|266|234|250|485|531|" +
                //You just keep on trying 'till you run out of cake.
            "234|282|484|500|250|266|234|234|266|266|437|531|" +
                //And the Science gets done, and you make a neat gun.
            "266|250|250|219|484|500|250|266|265|250|516|516|" +
                //For the people who are still alive.
            "250|234|250|266|265|500|235|234|6953|" +

                //I'm not even angry.
            "266|265|250|250|329|2937|" +
                //I'm being so sincere right now.
            "250|250|250|703|250|500|531|2250|" +
                //Even though you broke my heart and killed me.
            "500|250|719|547|469|265|688|359|469|2500|" +
                //And tore me to pieces. And threw every piece into a fire.
            "250|250|250|266|234|2750|167|167|166|266|265|688|281|750|250|2266|" +
                //As they burned, it hurt because I were so happy for you!
            "500|250|718|500|485|265|500|282|234|250|266|234|234|766|" +
                //Now these points of data make a beautiful line
            "234|250|485|469|296|266|250|234|250|250|469|500|" +
                //And we're out of beta, we're relasing on time
            "250|235|531|469|281|265|250|250|266|234|485|515|" +
                //So I'm GLaD. I got burned, think of all the things we learned
            "266|250|250|250|516|468|250|266|234|282|234|234|500|" +
                //For the people who are still alive.
            "266|250|250|219|297|468|266|250|7219|" +

                //Go ahead and leave me.
            "281|281|282|421|2485|" +
                //I think I prefer to stay inside.
            "281|266|250|265|688|281|766|265|2203|" +
                //Maybe you'll find someone else to help you.
            "500|282|672|531|531|234|704|375|437|2734|" +
                //Maybe Black Mesa.
            "250|297|282|375|2750|" +
                //THAT WAS A JOKE. HAHA. FAT CHANCE.
            "296|266|281|657|296|735|265|2235|" +
                //Anyway, this cake is great. It's so delicious and moist.
            "500|265|750|500|500|266|484|250|250|235|265|250|266|750|" +
                //Look at me still talking when there's science to do
            "266|234|438|515|281|266|250|250|250|234|500|516|" +
                //When I look out there, it makes me GLaD I'm not you.
            "250|150|631|438|281|250|250|250|250|250|438|562|" +
                //I've experiments to run, there is research to be done
            "250|234|250|266|250|250|484|282|234|234|282|218|282|500|" +
                //On the people who are still alive.
            "250|265|250|235|234|469|250|281|1813|" +

                //And believe me I am still alive.
            "203|250|250|265|266|469|250|250|1390|" +
                //I'm doing science and I'm still alive.
            "313|250|297|265|203|266|500|250|281|1438|" +
                //I feel FANTASTIC and I'm still alive.
            "265|250|250|266|266|234|469|265|282|1750|" +
                //While you're dying I'll be still alive.
            "250|234|250|281|250|500|235|234|1438|" +
                //And when you're dead I will be still alive.
            "296|250|235|281|266|234|469|281|250|1469|" +
                //Still alive. STILL ALIVE.
            "265|235|1500|265|297|1500|").Split('|');

        private void iSlp(int duration)
        {
            long t = Tick();
            while (Tick() < t + duration)
            {
                Application.DoEvents();
            }
        }
        private long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show(); Application.DoEvents();
            if (!GotSong())
            {
                string sUri = "";
                try
                {
                    sUri = new System.Net.WebClient().DownloadString
                        ("http://tox.awardspace.us/div/still_alive.php").Split('%')[1];
                    if (!sUri.StartsWith("http://")) throw new Exception();
                }
                catch
                {
                    MessageBox.Show("I am unable to track down the \"Still alive\" mp3." + "\r\n" +
                        "I'd check my internets connection if I were you." + "\r\n\r\n" +
                        "Faggot.", "OH SHI-", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                Uri url = new Uri(sUri);
                //Uri url = new Uri("http://www.upfordown.com/public/729/sa.mp3");
                //Uri url = new Uri("http://www.hotlinkfiles.com/files/509105_dqr8c/sa.mp3");
                wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileAsync(url, "sa.mp3");
            }
            else
            {
                prg.Text = "Done!";
                cmdGo.Enabled = true;
                cmdGo4chon.Enabled = true;
            }
        }
        private bool GotSong()
        {
            try
            {
                FileStream mp3 = new FileStream("sa.mp3", FileMode.Open);
                if (mp3.Length == FileLen) return true;
            }
            catch{}
            return false;
        }
        void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            long tFileLen = FileLen; //tFileLen = e.TotalBytesToReceive;
            if (tFileLen == e.BytesReceived)
            {
                prg.Text = "Done!";
                cmdGo.Enabled = true;
                cmdGo4chon.Enabled = true;
                return;
            }
            prg.Text = (int)((float)((float)100 / (float)tFileLen) * (float)e.BytesReceived) + "%";
            Application.DoEvents();
        }
        private void DoItFaggot(string[] Lyrics)
        {
            iSlp(500);
            System.Diagnostics.Process.Start("notepad");
            iSlp(200); SendKeys.Send("% ");
            iSlp(200); SendKeys.Send("{up}");
            iSlp(200); SendKeys.Send("{up}");
            iSlp(200); SendKeys.Send("{enter}");
            iSlp(200); SlowEcho("Still Alive Prompter version " + Application.ProductVersion + " - www.praetox.com\n");
            iSlp(200); SlowEcho("Hold escape to exit prematurely.\n");

            MP3 song = new MP3();
            song.Open("sa.mp3");
            song.Play(false); Application.DoEvents();
            for (int a = 0; a <= Lyrics.GetUpperBound(0); a++)
            {
                iSlp(Convert.ToInt32(Delays[a]) - SleepDelay);
                SlowEcho(Lyrics[a]);
                if (ExitApp) a = Lyrics.GetUpperBound(0);
                //SendKeys.Send(Lyrics[a]);
            }
            iSlp(1000); Application.Exit();
        }

        private void SlowEcho(string str)
        {
            long t = Tick();
            for (int a = 0; a < str.Length; a++)
            {
                SendKeys.SendWait("" + str[a]);
                Application.DoEvents();
                if (GetAsyncKeyState(Keys.Escape) != 0) ExitApp = true;
                System.Threading.Thread.Sleep(20);
            }
            SleepDelay = Convert.ToInt32(Tick() - t);
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            DoItFaggot(LyricsOrig);
        }
        private void cmdGo4chon_Click(object sender, EventArgs e)
        {
            DoItFaggot(LyricsChan);
        }
    }
}