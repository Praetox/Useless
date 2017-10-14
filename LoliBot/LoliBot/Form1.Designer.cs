namespace LoliBot
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Client_Form = new System.Windows.Forms.GroupBox();
            this.Client_Refresh = new System.Windows.Forms.Button();
            this.Client_Combo = new System.Windows.Forms.ComboBox();
            this.Light_Form = new System.Windows.Forms.GroupBox();
            this.Light_Toggle = new System.Windows.Forms.Button();
            this.Light_Power = new System.Windows.Forms.HScrollBar();
            this.Light_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Levelspy_Toggle = new System.Windows.Forms.Button();
            this.Levelspy_Down = new System.Windows.Forms.Button();
            this.Levelspy_Up = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Namespy_Toggle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NFWater_Toggle = new System.Windows.Forms.Button();
            this.NFWater_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ShowInvis_Toggle = new System.Windows.Forms.Button();
            this.ShowInvis_Timer = new System.Windows.Forms.Timer(this.components);
            this.bg = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SimpleGPS_Toggle = new System.Windows.Forms.Button();
            this.SimpleGPS_Timer = new System.Windows.Forms.Timer(this.components);
            this.Hotkeys_Timer = new System.Windows.Forms.Timer(this.components);
            this.Gametime_Timer = new System.Windows.Forms.Timer(this.components);
            this.bubbleBar1 = new DevComponents.WinUI.BubbleBar();
            this.General = new DevComponents.WinUI.BubbleBarTab(this.components);
            this.bbLight = new DevComponents.WinUI.BubbleButton();
            this.bbNFWater = new DevComponents.WinUI.BubbleButton();
            this.bbSimpleGPS = new DevComponents.WinUI.BubbleButton();
            this.bbNamespy = new DevComponents.WinUI.BubbleButton();
            this.bbShowInvis = new DevComponents.WinUI.BubbleButton();
            this.Alerts = new DevComponents.WinUI.BubbleBarTab(this.components);
            this.Client_Form.SuspendLayout();
            this.Light_Form.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Client_Form
            // 
            this.Client_Form.BackColor = System.Drawing.Color.Black;
            this.Client_Form.Controls.Add(this.Client_Refresh);
            this.Client_Form.Controls.Add(this.Client_Combo);
            this.Client_Form.ForeColor = System.Drawing.Color.LightBlue;
            this.Client_Form.Location = new System.Drawing.Point(12, 79);
            this.Client_Form.Name = "Client_Form";
            this.Client_Form.Size = new System.Drawing.Size(218, 46);
            this.Client_Form.TabIndex = 3;
            this.Client_Form.TabStop = false;
            this.Client_Form.Text = "Client";
            // 
            // Client_Refresh
            // 
            this.Client_Refresh.Location = new System.Drawing.Point(160, 19);
            this.Client_Refresh.Name = "Client_Refresh";
            this.Client_Refresh.Size = new System.Drawing.Size(52, 21);
            this.Client_Refresh.TabIndex = 2;
            this.Client_Refresh.Text = "Refresh";
            this.Client_Refresh.UseVisualStyleBackColor = false;
            this.Client_Refresh.Click += new System.EventHandler(this.Client_Refresh_Click);
            // 
            // Client_Combo
            // 
            this.Client_Combo.FormattingEnabled = true;
            this.Client_Combo.Location = new System.Drawing.Point(6, 19);
            this.Client_Combo.Name = "Client_Combo";
            this.Client_Combo.Size = new System.Drawing.Size(148, 21);
            this.Client_Combo.TabIndex = 2;
            this.Client_Combo.SelectedIndexChanged += new System.EventHandler(this.Client_Combo_SelectedIndexChanged);
            // 
            // Light_Form
            // 
            this.Light_Form.BackColor = System.Drawing.Color.Black;
            this.Light_Form.Controls.Add(this.Light_Toggle);
            this.Light_Form.Controls.Add(this.Light_Power);
            this.Light_Form.ForeColor = System.Drawing.Color.LightBlue;
            this.Light_Form.Location = new System.Drawing.Point(12, 131);
            this.Light_Form.Name = "Light_Form";
            this.Light_Form.Size = new System.Drawing.Size(218, 46);
            this.Light_Form.TabIndex = 2;
            this.Light_Form.TabStop = false;
            this.Light_Form.Text = "Light hack";
            // 
            // Light_Toggle
            // 
            this.Light_Toggle.Location = new System.Drawing.Point(6, 19);
            this.Light_Toggle.Name = "Light_Toggle";
            this.Light_Toggle.Size = new System.Drawing.Size(94, 21);
            this.Light_Toggle.TabIndex = 7;
            this.Light_Toggle.Text = "Enable";
            this.Light_Toggle.UseVisualStyleBackColor = false;
            this.Light_Toggle.Click += new System.EventHandler(this.Light_Toggle_Click);
            // 
            // Light_Power
            // 
            this.Light_Power.LargeChange = 1;
            this.Light_Power.Location = new System.Drawing.Point(103, 20);
            this.Light_Power.Maximum = 12;
            this.Light_Power.Name = "Light_Power";
            this.Light_Power.Size = new System.Drawing.Size(109, 18);
            this.Light_Power.TabIndex = 1;
            this.Light_Power.Value = 12;
            this.Light_Power.ValueChanged += new System.EventHandler(this.Light_Power_ValueChanged);
            // 
            // Light_Timer
            // 
            this.Light_Timer.Interval = 1000;
            this.Light_Timer.Tick += new System.EventHandler(this.Light_Timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.Levelspy_Toggle);
            this.groupBox1.Controls.Add(this.Levelspy_Down);
            this.groupBox1.Controls.Add(this.Levelspy_Up);
            this.groupBox1.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 46);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level spy";
            // 
            // Levelspy_Toggle
            // 
            this.Levelspy_Toggle.Location = new System.Drawing.Point(6, 19);
            this.Levelspy_Toggle.Name = "Levelspy_Toggle";
            this.Levelspy_Toggle.Size = new System.Drawing.Size(94, 21);
            this.Levelspy_Toggle.TabIndex = 5;
            this.Levelspy_Toggle.Text = "Enable";
            this.Levelspy_Toggle.UseVisualStyleBackColor = false;
            this.Levelspy_Toggle.Click += new System.EventHandler(this.Levelspy_Toggle_Click);
            // 
            // Levelspy_Down
            // 
            this.Levelspy_Down.Location = new System.Drawing.Point(168, 19);
            this.Levelspy_Down.Name = "Levelspy_Down";
            this.Levelspy_Down.Size = new System.Drawing.Size(44, 21);
            this.Levelspy_Down.TabIndex = 4;
            this.Levelspy_Down.Text = "Down";
            this.Levelspy_Down.UseVisualStyleBackColor = false;
            this.Levelspy_Down.Click += new System.EventHandler(this.Levelspy_Down_Click);
            // 
            // Levelspy_Up
            // 
            this.Levelspy_Up.Location = new System.Drawing.Point(118, 19);
            this.Levelspy_Up.Name = "Levelspy_Up";
            this.Levelspy_Up.Size = new System.Drawing.Size(44, 21);
            this.Levelspy_Up.TabIndex = 3;
            this.Levelspy_Up.Text = "Up";
            this.Levelspy_Up.UseVisualStyleBackColor = false;
            this.Levelspy_Up.Click += new System.EventHandler(this.Levelspy_Up_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.Namespy_Toggle);
            this.groupBox2.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox2.Location = new System.Drawing.Point(12, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 46);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Namespy";
            // 
            // Namespy_Toggle
            // 
            this.Namespy_Toggle.Location = new System.Drawing.Point(6, 19);
            this.Namespy_Toggle.Name = "Namespy_Toggle";
            this.Namespy_Toggle.Size = new System.Drawing.Size(94, 21);
            this.Namespy_Toggle.TabIndex = 6;
            this.Namespy_Toggle.Text = "Enable";
            this.Namespy_Toggle.UseVisualStyleBackColor = false;
            this.Namespy_Toggle.Click += new System.EventHandler(this.Namespy_Toggle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.NFWater_Toggle);
            this.groupBox3.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Location = new System.Drawing.Point(12, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 46);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Waterhack";
            // 
            // NFWater_Toggle
            // 
            this.NFWater_Toggle.Location = new System.Drawing.Point(6, 20);
            this.NFWater_Toggle.Name = "NFWater_Toggle";
            this.NFWater_Toggle.Size = new System.Drawing.Size(94, 21);
            this.NFWater_Toggle.TabIndex = 6;
            this.NFWater_Toggle.Text = "Enable";
            this.NFWater_Toggle.UseVisualStyleBackColor = false;
            this.NFWater_Toggle.Click += new System.EventHandler(this.NFWater_Toggle_Click);
            // 
            // NFWater_Timer
            // 
            this.NFWater_Timer.Interval = 1000;
            this.NFWater_Timer.Tick += new System.EventHandler(this.NFWater_Timer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Black;
            this.groupBox4.Controls.Add(this.ShowInvis_Toggle);
            this.groupBox4.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox4.Location = new System.Drawing.Point(124, 287);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(106, 46);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Show invisible";
            // 
            // ShowInvis_Toggle
            // 
            this.ShowInvis_Toggle.Location = new System.Drawing.Point(6, 20);
            this.ShowInvis_Toggle.Name = "ShowInvis_Toggle";
            this.ShowInvis_Toggle.Size = new System.Drawing.Size(94, 21);
            this.ShowInvis_Toggle.TabIndex = 6;
            this.ShowInvis_Toggle.Text = "Enable";
            this.ShowInvis_Toggle.UseVisualStyleBackColor = false;
            this.ShowInvis_Toggle.Click += new System.EventHandler(this.ShowInvis_Toggle_Click);
            // 
            // ShowInvis_Timer
            // 
            this.ShowInvis_Timer.Interval = 1000;
            this.ShowInvis_Timer.Tick += new System.EventHandler(this.ShowInvis_Timer_Tick);
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(372, 297);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(82, 74);
            this.bg.TabIndex = 8;
            this.bg.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Black;
            this.groupBox5.Controls.Add(this.SimpleGPS_Toggle);
            this.groupBox5.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox5.Location = new System.Drawing.Point(124, 183);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(106, 46);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Simple GPS";
            // 
            // SimpleGPS_Toggle
            // 
            this.SimpleGPS_Toggle.Location = new System.Drawing.Point(6, 20);
            this.SimpleGPS_Toggle.Name = "SimpleGPS_Toggle";
            this.SimpleGPS_Toggle.Size = new System.Drawing.Size(94, 21);
            this.SimpleGPS_Toggle.TabIndex = 6;
            this.SimpleGPS_Toggle.Text = "Enable";
            this.SimpleGPS_Toggle.UseVisualStyleBackColor = false;
            this.SimpleGPS_Toggle.Click += new System.EventHandler(this.SimpleGPS_Toggle_Click);
            // 
            // SimpleGPS_Timer
            // 
            this.SimpleGPS_Timer.Interval = 1000;
            this.SimpleGPS_Timer.Tick += new System.EventHandler(this.SimpleGPS_Timer_Tick);
            // 
            // Hotkeys_Timer
            // 
            this.Hotkeys_Timer.Enabled = true;
            this.Hotkeys_Timer.Interval = 3;
            this.Hotkeys_Timer.Tick += new System.EventHandler(this.Hotkeys_Timer_Tick);
            // 
            // Gametime_Timer
            // 
            this.Gametime_Timer.Enabled = true;
            this.Gametime_Timer.Interval = 1000;
            // 
            // bubbleBar1
            // 
            this.bubbleBar1.Alignment = DevComponents.WinUI.eBubbleButtonAlignment.Top;
            this.bubbleBar1.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottom = DevComponents.WinUI.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeft = DevComponents.WinUI.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRight = DevComponents.WinUI.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTop = DevComponents.WinUI.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingRight = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingTop = 3;
            this.bubbleBar1.ImageSizeLarge = new System.Drawing.Size(38, 38);
            this.bubbleBar1.ImageSizeNormal = new System.Drawing.Size(32, 32);
            this.bubbleBar1.Location = new System.Drawing.Point(12, 12);
            this.bubbleBar1.MouseOverTabColors.BackColor = System.Drawing.Color.Black;
            this.bubbleBar1.MouseOverTabColors.BackColor2 = System.Drawing.Color.White;
            this.bubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.Color.Silver;
            this.bubbleBar1.Name = "bubbleBar1";
            this.bubbleBar1.Padding = new System.Windows.Forms.Padding(100);
            this.bubbleBar1.SelectedTab = this.General;
            this.bubbleBar1.SelectedTabColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.bubbleBar1.SelectedTabColors.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.bubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar1.Size = new System.Drawing.Size(442, 61);
            this.bubbleBar1.TabIndex = 10;
            this.bubbleBar1.Tabs.Add(this.General);
            this.bubbleBar1.Tabs.Add(this.Alerts);
            this.bubbleBar1.Text = "Menu";
            this.bubbleBar1.TooltipFont = new System.Drawing.Font("Lucida Sans", 11.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // General
            // 
            this.General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.General.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.General.Buttons.AddRange(new DevComponents.WinUI.BubbleButton[] {
            this.bbLight,
            this.bbNFWater,
            this.bbSimpleGPS,
            this.bbNamespy,
            this.bbShowInvis});
            this.General.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.General.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.General.Name = "General";
            this.General.PredefinedColor = DevComponents.WinUI.eTabItemColor.Silver;
            this.General.Tag = "";
            this.General.Text = "General";
            this.General.TextColor = System.Drawing.Color.White;
            // 
            // bbLight
            // 
            this.bbLight.Image = ((System.Drawing.Image)(resources.GetObject("bbLight.Image")));
            this.bbLight.Name = "bbLight";
            this.bbLight.TooltipText = "Light hack";
            this.bbLight.Click += new DevComponents.WinUI.ClickEventHandler(this.bbLight_Click);
            // 
            // bbNFWater
            // 
            this.bbNFWater.Image = ((System.Drawing.Image)(resources.GetObject("bbNFWater.Image")));
            this.bbNFWater.Name = "bbNFWater";
            this.bbNFWater.TooltipText = "Waterhack";
            this.bbNFWater.Click += new DevComponents.WinUI.ClickEventHandler(this.bbNFWater_Click);
            // 
            // bbSimpleGPS
            // 
            this.bbSimpleGPS.Image = ((System.Drawing.Image)(resources.GetObject("bbSimpleGPS.Image")));
            this.bbSimpleGPS.Name = "bbSimpleGPS";
            this.bbSimpleGPS.TooltipText = "Simple GPS";
            this.bbSimpleGPS.Click += new DevComponents.WinUI.ClickEventHandler(this.bbSimpleGPS_Click);
            // 
            // bbNamespy
            // 
            this.bbNamespy.Image = ((System.Drawing.Image)(resources.GetObject("bbNamespy.Image")));
            this.bbNamespy.Name = "bbNamespy";
            this.bbNamespy.TooltipText = "Namespy";
            this.bbNamespy.Click += new DevComponents.WinUI.ClickEventHandler(this.bbNamespy_Click);
            // 
            // bbShowInvis
            // 
            this.bbShowInvis.Image = ((System.Drawing.Image)(resources.GetObject("bbShowInvis.Image")));
            this.bbShowInvis.Name = "bbShowInvis";
            this.bbShowInvis.TooltipText = "Show Invisible Creatures";
            this.bbShowInvis.Click += new DevComponents.WinUI.ClickEventHandler(this.bbShowInvis_Click);
            // 
            // Alerts
            // 
            this.Alerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.Alerts.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.Alerts.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.Alerts.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Alerts.Name = "Alerts";
            this.Alerts.PredefinedColor = DevComponents.WinUI.eTabItemColor.Silver;
            this.Alerts.Text = "Alerts";
            this.Alerts.TextColor = System.Drawing.Color.White;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(466, 383);
            this.Controls.Add(this.bubbleBar1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Client_Form);
            this.Controls.Add(this.Light_Form);
            this.Controls.Add(this.bg);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.Name = "frmMain";
            this.Opacity = 0.9;
            this.Text = "LoliBot BETA | www.praetox.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Client_Form.ResumeLayout(false);
            this.Light_Form.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Client_Form;
        private System.Windows.Forms.Button Client_Refresh;
        private System.Windows.Forms.ComboBox Client_Combo;
        private System.Windows.Forms.GroupBox Light_Form;
        private System.Windows.Forms.HScrollBar Light_Power;
        private System.Windows.Forms.Timer Light_Timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Levelspy_Up;
        private System.Windows.Forms.Button Levelspy_Down;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Namespy_Toggle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button NFWater_Toggle;
        private System.Windows.Forms.Timer NFWater_Timer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ShowInvis_Toggle;
        private System.Windows.Forms.Timer ShowInvis_Timer;
        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.Button Levelspy_Toggle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button SimpleGPS_Toggle;
        private System.Windows.Forms.Timer SimpleGPS_Timer;
        private System.Windows.Forms.Timer Hotkeys_Timer;
        private System.Windows.Forms.Button Light_Toggle;
        private System.Windows.Forms.Timer Gametime_Timer;
        private DevComponents.WinUI.BubbleBar bubbleBar1;
        private DevComponents.WinUI.BubbleBarTab General;
        private DevComponents.WinUI.BubbleButton bbLight;
        private DevComponents.WinUI.BubbleButton bbNFWater;
        private DevComponents.WinUI.BubbleButton bbSimpleGPS;
        private DevComponents.WinUI.BubbleButton bbNamespy;
        private DevComponents.WinUI.BubbleButton bbShowInvis;
        private DevComponents.WinUI.BubbleBarTab Alerts;
    }
}

