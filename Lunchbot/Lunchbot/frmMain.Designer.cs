namespace Lunchbot
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
            this.tHotkeys = new System.Windows.Forms.Timer(this.components);
            this.tMoveAbout = new System.Windows.Forms.Timer(this.components);
            this.lnk = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LtrDraw_chkConserveLetters = new System.Windows.Forms.CheckBox();
            this.LtrDraw_chkSpamLetters = new System.Windows.Forms.CheckBox();
            this.lbRatio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbChars = new System.Windows.Forms.Label();
            this.lbBlacks = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LtrDraw_cmdPrepare = new System.Windows.Forms.Button();
            this.LtrDraw_cmdBrowse = new System.Windows.Forms.Button();
            this.LtrDraw_txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tHotkeys
            // 
            this.tHotkeys.Enabled = true;
            this.tHotkeys.Interval = 1;
            this.tHotkeys.Tick += new System.EventHandler(this.tHotkeys_Tick);
            // 
            // tMoveAbout
            // 
            this.tMoveAbout.Interval = 1;
            this.tMoveAbout.Tick += new System.EventHandler(this.tMoveAbout_Tick);
            // 
            // lnk
            // 
            this.lnk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnk.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk.Location = new System.Drawing.Point(12, 48);
            this.lnk.Name = "lnk";
            this.lnk.Size = new System.Drawing.Size(228, 20);
            this.lnk.TabIndex = 1;
            this.lnk.Text = "www.Praetox.com";
            this.lnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnk.Click += new System.EventHandler(this.lnk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 33);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 119);
            this.label1.TabIndex = 3;
            this.label1.Text = "Q - Set offset 1\r\nW - Set offset 2\r\n\r\n | - Stops current activity\r\n1 - Move all t" +
                "o corner\r\n2 - Move out from corner\r\n3 - Move about wildly";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 178);
            this.label2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LtrDraw_chkConserveLetters);
            this.groupBox1.Controls.Add(this.LtrDraw_chkSpamLetters);
            this.groupBox1.Controls.Add(this.lbRatio);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbChars);
            this.groupBox1.Controls.Add(this.lbBlacks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LtrDraw_cmdPrepare);
            this.groupBox1.Controls.Add(this.LtrDraw_cmdBrowse);
            this.groupBox1.Controls.Add(this.LtrDraw_txtPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.ForeColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Location = new System.Drawing.Point(297, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 172);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autodraw";
            // 
            // LtrDraw_chkConserveLetters
            // 
            this.LtrDraw_chkConserveLetters.AutoSize = true;
            this.LtrDraw_chkConserveLetters.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LtrDraw_chkConserveLetters.Checked = true;
            this.LtrDraw_chkConserveLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LtrDraw_chkConserveLetters.Location = new System.Drawing.Point(200, 97);
            this.LtrDraw_chkConserveLetters.Name = "LtrDraw_chkConserveLetters";
            this.LtrDraw_chkConserveLetters.Size = new System.Drawing.Size(79, 17);
            this.LtrDraw_chkConserveLetters.TabIndex = 14;
            this.LtrDraw_chkConserveLetters.Text = "Conserve l.";
            this.LtrDraw_chkConserveLetters.UseVisualStyleBackColor = true;
            // 
            // LtrDraw_chkSpamLetters
            // 
            this.LtrDraw_chkSpamLetters.AutoSize = true;
            this.LtrDraw_chkSpamLetters.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LtrDraw_chkSpamLetters.Location = new System.Drawing.Point(195, 74);
            this.LtrDraw_chkSpamLetters.Name = "LtrDraw_chkSpamLetters";
            this.LtrDraw_chkSpamLetters.Size = new System.Drawing.Size(84, 17);
            this.LtrDraw_chkSpamLetters.TabIndex = 13;
            this.LtrDraw_chkSpamLetters.Text = "Spam letters";
            this.LtrDraw_chkSpamLetters.UseVisualStyleBackColor = true;
            // 
            // lbRatio
            // 
            this.lbRatio.Location = new System.Drawing.Point(62, 97);
            this.lbRatio.Name = "lbRatio";
            this.lbRatio.Size = new System.Drawing.Size(50, 13);
            this.lbRatio.TabIndex = 12;
            this.lbRatio.Text = "n/a";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Ratio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "760x544";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChars
            // 
            this.lbChars.Location = new System.Drawing.Point(62, 84);
            this.lbChars.Name = "lbChars";
            this.lbChars.Size = new System.Drawing.Size(50, 13);
            this.lbChars.TabIndex = 9;
            this.lbChars.Text = "n/a";
            // 
            // lbBlacks
            // 
            this.lbBlacks.Location = new System.Drawing.Point(62, 71);
            this.lbBlacks.Name = "lbBlacks";
            this.lbBlacks.Size = new System.Drawing.Size(50, 13);
            this.lbBlacks.TabIndex = 8;
            this.lbBlacks.Text = "n/a";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Chars:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Black:";
            // 
            // LtrDraw_cmdPrepare
            // 
            this.LtrDraw_cmdPrepare.ForeColor = System.Drawing.Color.Black;
            this.LtrDraw_cmdPrepare.Location = new System.Drawing.Point(6, 45);
            this.LtrDraw_cmdPrepare.Name = "LtrDraw_cmdPrepare";
            this.LtrDraw_cmdPrepare.Size = new System.Drawing.Size(273, 23);
            this.LtrDraw_cmdPrepare.TabIndex = 3;
            this.LtrDraw_cmdPrepare.Text = "P r e p a r e     t h e     a w e s o m e n e s s";
            this.LtrDraw_cmdPrepare.UseVisualStyleBackColor = true;
            this.LtrDraw_cmdPrepare.Click += new System.EventHandler(this.cmdPrepare_Click);
            // 
            // LtrDraw_cmdBrowse
            // 
            this.LtrDraw_cmdBrowse.ForeColor = System.Drawing.Color.Black;
            this.LtrDraw_cmdBrowse.Location = new System.Drawing.Point(204, 17);
            this.LtrDraw_cmdBrowse.Name = "LtrDraw_cmdBrowse";
            this.LtrDraw_cmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.LtrDraw_cmdBrowse.TabIndex = 2;
            this.LtrDraw_cmdBrowse.Text = "Browse...";
            this.LtrDraw_cmdBrowse.UseVisualStyleBackColor = true;
            this.LtrDraw_cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // LtrDraw_txtPath
            // 
            this.LtrDraw_txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LtrDraw_txtPath.ForeColor = System.Drawing.Color.White;
            this.LtrDraw_txtPath.Location = new System.Drawing.Point(48, 19);
            this.LtrDraw_txtPath.Name = "LtrDraw_txtPath";
            this.LtrDraw_txtPath.Size = new System.Drawing.Size(150, 20);
            this.LtrDraw_txtPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Image";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 59);
            this.label8.TabIndex = 7;
            this.label8.Text = "Press 4 to draw image.\r\nIdea by Anonylulz @ Appunity";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(275, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(246, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 6;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSpeed.ForeColor = System.Drawing.Color.White;
            this.txtSpeed.Location = new System.Drawing.Point(12, 164);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(29, 20);
            this.txtSpeed.TabIndex = 0;
            this.txtSpeed.Text = "5";
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpeed_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "SPD";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(594, 196);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnk);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Lunchbot v";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tHotkeys;
        private System.Windows.Forms.Timer tMoveAbout;
        private System.Windows.Forms.Label lnk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LtrDraw_cmdBrowse;
        private System.Windows.Forms.TextBox LtrDraw_txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbChars;
        private System.Windows.Forms.Label lbBlacks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LtrDraw_cmdPrepare;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbRatio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox LtrDraw_chkSpamLetters;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox LtrDraw_chkConserveLetters;
    }
}

