using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LoliBot
{
    public partial class frmMain : Form
    {
        private const int t2aDelay = 0;
        Memory Tib = new Memory();
        System.Diagnostics.Process[] TibiaClients;

        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Clipboard.Clear(); Clipboard.SetImage(bbLight.ImageLarge); Application.Exit();
            //bg.Image = new Bitmap("c:/VN.jpg") as Image;
            bg.Size = bg.Image.Size; bg.Left = this.Width - bg.Width - 8; bg.Top = this.Height - bg.Height - 34;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Client_Refresh_Click(new object(), new EventArgs());
        }

        #region Standard Praetox Functions
        ///<summary>
        /// Splits msg by delim, returns bit part
        ///</summary>
        public static string Split(string msg, string delim, int part)
        {
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
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        ///<summary>
        /// Counts occurrences of delim within msg
        ///</summary>
        public static int Countword(string msg, string delim)
        {
            int ret = 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
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
        ///<summary>
        /// Returns system clock in seconds
        ///</summary>
        public int tck()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Returns what tck will be after vl seconds
        ///</summary>
        public int T2A(int vl)
        {
            int ret = tck() + vl + t2aDelay;
            if (ret > 86400) ret -= 86400;
            return ret;
        }
        ///<summary>
        /// Returns the waiting time until tck is vl
        ///</summary>
        public int T2B(int vl)
        {
            int ret = vl - tck();
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        ///<summary>
        /// Returns how many seconds tck has passed vl
        ///</summary>
        public int T2C(int vl)
        {
            int ret = tck() - vl;
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
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
        ///<summary>
        /// Displays / hides images in internet explorer
        ///</summary>
        public static void IE_Images(bool show)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
            key = key.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true);
            if (show) key.SetValue("Display Inline Images", "yes");
            if (!show) key.SetValue("Display Inline Images", "no");
            key.Close();
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
        #region Lock-on to Tibia
        private void Client_Refresh_Click(object sender, EventArgs e)
        {
            Client_Combo.Items.Clear();
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
                    Client_Combo.Items.Add("[" + Proc.Id + "] " + CharName);
                    Tib.Close(); Tib.mTarget = new System.Diagnostics.Process();
                }
                Client_Combo.SelectedIndex = 0;
            }
        }
        private void Client_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tib.isSet()) Win32API.SetWindowText(Tib.mTarget.MainWindowHandle, "Tibia   ");
            if (Tib.isSet()) Tib.Close();
            Tib.mTarget = TibiaClients[Client_Combo.SelectedIndex]; Tib.Open(); Application.DoEvents();
            Win32API.SetWindowText(Tib.mTarget.MainWindowHandle, "LB | " + Tib.RString(BL_Player() + MAdr.BL_Name));
        }
        #endregion
        #region Kandy stuff
        private void Hotkeys_Timer_Tick(object sender, EventArgs e)
        {
            if (Win32API.GetAsyncKeyState(Keys.LControlKey) != 0)
            {
                if (Win32API.GetAsyncKeyState(Keys.PageUp) == -32767)
                {
                    if (Levelspy_Toggle.Text == "Enable") Levelspy_Toggle_Click(new object(), new EventArgs());
                    Levelspy_Up_Click(new object(), new EventArgs());
                }
                if (Win32API.GetAsyncKeyState(Keys.PageDown) == -32767)
                {
                    if (Levelspy_Toggle.Text == "Enable") Levelspy_Toggle_Click(new object(), new EventArgs());
                    Levelspy_Down_Click(new object(), new EventArgs());
                }
                if (Win32API.GetAsyncKeyState(Keys.Home) == -32767)
                {
                    if (Levelspy_Toggle.Text == "Disable") Levelspy_Toggle_Click(new object(), new EventArgs());
                }
            }
            if (Win32API.GetAsyncKeyState(Keys.LMenu) != 0)
            {
                if (Win32API.GetAsyncKeyState(Keys.Scroll) == -32767)
                {
                    //Tib.WInt(MAdr.CH_S0, );
                    Tib.WInt(MAdr.CH_S1, 3400);
                    Tib.WInt(MAdr.CH_S2, 3399);
                    Tib.WInt(MAdr.CH_S3, 3342);
                    Tib.WInt(MAdr.CH_S4, 3422);
                    Tib.WInt(MAdr.CH_S5, 3363);
                    Tib.WInt(MAdr.CH_S6, 3556);
                    Tib.WInt(MAdr.CH_S7, 3572);
                    //Tib.WInt(MAdr.CH_S8, );

                }
            }
            if (Win32API.GetAsyncKeyState(Keys.End) == -32767)
                CH_Message("LoliBot >> " + ExpLeft() + ".");
            if (Win32API.GetAsyncKeyState(Keys.Home) == -32767)
                Light_Toggle_Click(new object(), new EventArgs());
        }
        private string ExpLeft()
        {
            int Level = Tib.RInt(MAdr.CH_Lvl) + 1; int cExp = Tib.RInt(MAdr.CH_Exp); int ExpLeft = Exp2Lvl(Level) - cExp;
            string ret = Decimize(Convert.ToString(ExpLeft)) + " exp to level " + Level;
            string Mobs = "#Skunk%3#Badger%5#Rat%5#Cave Rat%10#Snake%10#Bat%10#Spider%12#Bug%18#Wolf%18#Troll%20#Winter Wolf%20#Hyaena%20#Spit Nettle%20#Island troll%20#Poison Spider%22#Bear%23#" +
                          "Frost Troll%23#Panda%23#Wasp%24#Orc%25#Goblin%25#Swamp Troll%25#Polar Bear%28#Lion%30#Cobra%30#Dworc Venomsniper%30#Crab%30#Centipede%30#Skeleton%35#Dworc Fleshhunter%35#" +
                          "Dworc Voodoomaster%35#Orc Spearman%38#Rotworm%40#Crocodile%40#Tiger%40#Elf%42#Larva%44#Dwarf%45#Scorpion%45#Smuggler%48#Orc Warrior%50#Minotaur%50#War Wolf%55#Amazon%60#" +
                          "Wild Warrior%60#Minotaur Archer%65#Bandit%65#Dwarf Soldier%70#Elf Scout%75#Ghoul%85#Valkyrie%85#Stalker%90#Gazer%90#Tortoise%90#Lizard Sentinel%100#Sibang%100#Novice Of The Cult%100#" +
                          "Assassin%105#Orc Rider%110#Orc Shaman%110#Fire Devil%110#Kongra%110#Ghost%120#Witch%120#Scarab%120#Tarantula%120#Pirate Marauder%125#Merlkin%135#Dark Monk%145#Lizard Templar%145#" +
                          "Cyclops%150#Hunter%150#Minotaur Mage%150#Mummy%150#Gargoyle%150#Terror Bird%150#Carniphila%150#Minotaur Guard%160#Slime%160#Stone Golem%160#Elephant%160#Dwarf Guard%165#" +
                          "Beholder%170#Elf Arcanist%175#Pirate Cutthroat%175#Blue Djinn%190#Green Djinn%190#Crypt Shambler%195#Orc Berserker%195#Monk%200#Lizard Snakecharmer%200#The Horned Fox%200#" +
                          "Fire Elemental%220#Demon Skeleton%240#Dwarf Geomancer%245#Pirate Ghost%250#Quara Constrictor%250#Orc Leader%270#Elder Beholder%280#Vampire%290#Efreet%300#Marid%300#Pirate Corsair%350#" +
                          "Dharalion%380#Fernfang%400#Quara Mantassin%400#Priestess%420#Yeti%460#The Evil Eye%500#Enlightened of the Cult%500#General Murius%550#Bonebeast%580#Necromancer%580#Orc Warlord%670#" +
                          "Dragon%700#Necropharus%700#Ancient Scarab%720#Quara Hydromancer%800#Banshee%900#Giant Spider%900#Lich%900#Hero%1200#Quara Pincher%1200#Black Knight%1600#Grorlam%1600#" +
                          "Quara Predator%1600#Serpent Spawn%2000#Dragon Lord%2100#Hydra%2100#Behemoth%2500#The Old Widow%2800#Dipthrah%2900#Omruc%2950#Thalas%2950#Vashresamun%2950#Morguthis%3000#" +
                          "Mahrdis%3050#Ashmunrah%3100#Rahemos%3100#Warlock%4000#Demodras%4000#Demon%6000#";
            int TargetID = Tib.RInt(MAdr.BOX_3); string TargetName = "";
            for (int a = MAdr.BL_Start; a <= MAdr.BL_End; a += MAdr.BL_Dist)
            {
                if (Tib.RInt(a + MAdr.BL_ID) == TargetID) TargetName = Tib.RString(a + MAdr.BL_Name);
            }
            if (TargetName != "")
            {
                int TargetExp = Convert.ToInt32(Split(Split(Mobs, "#" + TargetName + "%", 1), "#", 0));
                float fMobsLeft = (float)ExpLeft / (float)TargetExp;
                int MobsLeft = (int)fMobsLeft; if ((float)MobsLeft != fMobsLeft) MobsLeft++;
                ret += " (" + MobsLeft + " " + TargetName.ToLower() + "s)";
            }
            return ret;
        }
        private int Exp2Lvl(int Level)
        {
            double lvl = (double)Level;
            return (int)((((double)50 / (double)3) * Math.Pow(Level, 3)) - (100 * Math.Pow(Level, 2)) +
                        (((double)850 / (double)3) * Level) - 200);
        }
        #endregion
        #region Light hack
        private void Light_Toggle_Click(object sender, EventArgs e)
        {
            if (Light_Toggle.Text == "Enable")
            {
                Light_Timer.Enabled = true;
                Light_Toggle.Text = "Disable";
                Light_Timer_Tick(new object(), new EventArgs());
                CH_Message("LoliBot >> Lighthack >> Enabled");
            }
            else
            {
                Light_Timer.Enabled = false;
                Light_Toggle.Text = "Enable";
                CH_Message("LoliBot >> Lighthack >> Disabled");
            }
        }
        private void Light_Power_ValueChanged(object sender, EventArgs e)
        {
            if (!Light_Timer.Enabled) return;
            Light_Timer_Tick(new object(), new EventArgs());
            CH_Message("LoliBot >> Lighthack >> Strength " + Light_Power.Value);
        }
        private void Light_Timer_Tick(object sender, EventArgs e)
        {
            Tib.WInt(BL_Player() + MAdr.BL_LStr, Light_Power.Value + 2);
            Tib.WInt(BL_Player() + MAdr.BL_LCol, 207);
        }
        #endregion
        #region Namespy
        private void Namespy_Toggle_Click(object sender, EventArgs e)
        {
            if (Namespy_Toggle.Text == "Enable")
            {
                Namespy_Toggle.Text = "Disable";
                Tib.WNops(MAdr.Map_Namespy_Nop1, 2);
                Tib.WNops(MAdr.Map_Namespy_Nop2, 2);
                CH_Message("LoliBot >> Namespy >> Enabled");
            }
            else
            {
                Namespy_Toggle.Text = "Enable";
                Tib.WInt(MAdr.Map_Namespy_Nop1, MAdr.Map_Namespy_VlNop1, 2);
                Tib.WInt(MAdr.Map_Namespy_Nop2, MAdr.Map_Namespy_VlNop2, 2);
                CH_Message("LoliBot >> Namespy >> Disabled");
            }
        }
        #endregion
        #region Levelspy
        private void Levelspy_Toggle_Click(object sender, EventArgs e)
        {
            if (Levelspy_Toggle.Text == "Enable")
            {
                Levelspy_Toggle.Text = "Disable";
                Tib.WNops(MAdr.Map_Levelspy_Nop, 2);
                if (Tib.RInt(MAdr.CH_Z) <= MAdr.Map_Levelspy_DefaultZ)
                {
                    Tib.WInt(MAdr.Map_Levelspy_Above, MAdr.Map_Levelspy_DefaultZ - Tib.RInt(MAdr.CH_Z), 1);
                    Tib.WInt(MAdr.Map_Levelspy_Below, MAdr.Map_Levelspy_VlBelow, 1);
                }
                else
                {
                    Tib.WInt(MAdr.Map_Levelspy_Above, MAdr.Map_Levelspy_VlAbove, 1);
                    Tib.WInt(MAdr.Map_Levelspy_Below, MAdr.Map_Levelspy_VlBelow, 1);
                }
                CH_Message("LoliBot >> Levelspy >> Enabled");
            }
            else
            {
                Levelspy_Toggle.Text = "Enable";
                Tib.WInt(MAdr.Map_Levelspy_Nop, MAdr.Map_Levelspy_VlNop, 2);
                Tib.WInt(MAdr.Map_Levelspy_Above, MAdr.Map_Levelspy_VlAbove, 1);
                Tib.WInt(MAdr.Map_Levelspy_Below, MAdr.Map_Levelspy_VlBelow, 1);
                CH_Message("LoliBot >> Levelspy >> Disabled");
            }
        }
        private void Levelspy_Up_Click(object sender, EventArgs e)
        {
            if (Levelspy_Toggle.Text == "Enable") CH_Message("LoliBot >> Levelspy >> Enable first!");
            if (Levelspy_Toggle.Text == "Enable") return;
            int GroundLevel = 0;
            if (Tib.RInt(MAdr.CH_Z) <= MAdr.Map_Levelspy_DefaultZ)
            {
                GroundLevel = MAdr.Map_Levelspy_Above;              // Above ground
            }
            else
            {
                GroundLevel = MAdr.Map_Levelspy_Below;              // Below ground
            }
            int CurrLevel = Tib.RInt(GroundLevel, 1);
            if (CurrLevel >= MAdr.Map_Levelspy_VlMax)
            {
                CurrLevel = MAdr.Map_Levelspy_VlMin;                // Skip back to start
            }
            else
            {
                CurrLevel++;                                        // Increase one level
            }
            Tib.WInt(GroundLevel, CurrLevel, 1);
            CH_Message("LoliBot >> Levelspy >> Up (" + CurrLevel + ")");
        }
        private void Levelspy_Down_Click(object sender, EventArgs e)
        {
            if (Levelspy_Toggle.Text == "Enable") CH_Message("LoliBot >> Levelspy >> Enable first!");
            if (Levelspy_Toggle.Text == "Enable") return;
            int GroundLevel = 0;
            if (Tib.RInt(MAdr.CH_Z) <= MAdr.Map_Levelspy_DefaultZ)
            {
                GroundLevel = MAdr.Map_Levelspy_Above;              // Above ground
            }
            else
            {
                GroundLevel = MAdr.Map_Levelspy_Below;              // Below ground
            }
            int CurrLevel = Tib.RInt(GroundLevel, 1);
            if (CurrLevel <= MAdr.Map_Levelspy_VlMin)
            {
                CurrLevel = MAdr.Map_Levelspy_VlMax;                // Skip back to start
            }
            else
            {
                CurrLevel--;                                        // Increase one level
            }
            Tib.WInt(GroundLevel, CurrLevel, 1);
            CH_Message("LoliBot >> Levelspy >> Down (" + CurrLevel + ")");
        }
        #endregion
        #region NFWater
        private void NFWater_Toggle_Click(object sender, EventArgs e)
        {
            if (NFWater_Toggle.Text == "Enable")
            {
                NFWater_Toggle.Text = "Disable";
                NFWater_Timer.Enabled = true;
                NFWater_Timer_Tick(new object(), new EventArgs());
                CH_Message("LoliBot >> NFWater >> Enabled");
            }
            else
            {
                NFWater_Toggle.Text = "Enable";
                NFWater_Timer.Enabled = false;
                CH_Message("LoliBot >> NFWater >> Disabled");
            }
        }
        private void NFWater_Timer_Tick(object sender, EventArgs e)
        {
            int MapStart = Tib.RInt(MAdr.Map_Ptr);
            for (int a = MapStart; a <= MapStart + (MAdr.Map_Tiles * MAdr.Map_TileDist); a += MAdr.Map_TileDist)
            {
                int TileID = Tib.RInt(a + MAdr.Map_ObjectIdOffset);
                if (TileID >= MAdr.Tile_Water_Fish_Begin && TileID <= MAdr.Tile_Water_Fish_End)
                {
                    Tib.WInt(a + MAdr.Map_ObjectIdOffset, MAdr.Tile_Water_Old);
                }
            }
        }
        #endregion
        #region Show invisible
        private void ShowInvis_Toggle_Click(object sender, EventArgs e)
        {
            if (ShowInvis_Toggle.Text == "Enable")
            {
                ShowInvis_Timer.Enabled = true;
                ShowInvis_Toggle.Text = "Disable";
                ShowInvis_Timer_Tick(new object(), new EventArgs());
                CH_Message("LoliBot >> Show invisible >> Enabled");
            }
            else
            {
                ShowInvis_Timer.Enabled = false;
                ShowInvis_Toggle.Text = "Enable";
                CH_Message("LoliBot >> Show invisible >> Disabled");
            }
        }
        private void ShowInvis_Timer_Tick(object sender, EventArgs e)
        {
            for (int a = MAdr.BL_Start; a <= MAdr.BL_End; a += MAdr.BL_Dist)
            {
                if (Tib.RInt(a + MAdr.BL_OFit) == MAdr.OFit_Invis)
                {
                    Tib.WInt(a + MAdr.BL_OFit, MAdr.OFit_Druid);
                }
            }
        }
        #endregion
        #region Simple GPS
        private void SimpleGPS_Toggle_Click(object sender, EventArgs e)
        {
            if (SimpleGPS_Toggle.Text == "Enable")
            {
                SimpleGPS_Timer.Enabled = true;
                SimpleGPS_Toggle.Text = "Disable";
                SimpleGPS_Timer_Tick(new object(), new EventArgs());
            }
            else
            {
                SimpleGPS_Timer.Enabled = false;
                SimpleGPS_Toggle.Text = "Enable";
                CH_Message("LoliBot >> Simple GPS >> Disabled");
            }
        }

        private void SimpleGPS_Timer_Tick(object sender, EventArgs e)
        {
            int CharX = Tib.RInt(MAdr.CH_X);
            int CharY = Tib.RInt(MAdr.CH_Y);
            int CharZ = Tib.RInt(MAdr.CH_Z);
            CH_Message("LoliBot >> Simple GPS >> " + CharX + "," + CharY + "," + CharZ);
        }
        #endregion

        #region BubbleBar
        private void bbLight_Click(object sender, DevComponents.WinUI.ClickEventArgs e)
        {
            Light_Toggle_Click(new object(), new EventArgs());
        }

        private void bbNFWater_Click(object sender, DevComponents.WinUI.ClickEventArgs e)
        {
            NFWater_Toggle_Click(new object(), new EventArgs());
        }
        private void bbSimpleGPS_Click(object sender, DevComponents.WinUI.ClickEventArgs e)
        {
            SimpleGPS_Toggle_Click(new object(), new EventArgs());
        }

        private void bbNamespy_Click(object sender, DevComponents.WinUI.ClickEventArgs e)
        {
            Namespy_Toggle_Click(new object(), new EventArgs());
        }

        private void bbShowInvis_Click(object sender, DevComponents.WinUI.ClickEventArgs e)
        {
            ShowInvis_Toggle_Click(new object(), new EventArgs());
        }
        #endregion
    }
}