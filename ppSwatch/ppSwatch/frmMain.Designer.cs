namespace ppSwatch
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
            this.c1 = new System.Windows.Forms.Label();
            this.c2 = new System.Windows.Forms.Label();
            this.c3 = new System.Windows.Forms.Label();
            this.tScan = new System.Windows.Forms.Timer(this.components);
            this.tRainbow = new System.Windows.Forms.Timer(this.components);
            this.chkRainbow = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbOS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1
            // 
            this.c1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.c1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1.Location = new System.Drawing.Point(12, 86);
            this.c1.Margin = new System.Windows.Forms.Padding(3);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(48, 24);
            this.c1.TabIndex = 0;
            this.c1.Text = "1";
            this.c1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c2
            // 
            this.c2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.c2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c2.Location = new System.Drawing.Point(66, 86);
            this.c2.Margin = new System.Windows.Forms.Padding(3);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(48, 24);
            this.c2.TabIndex = 1;
            this.c2.Text = "2";
            this.c2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c3
            // 
            this.c3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.c3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c3.Location = new System.Drawing.Point(120, 86);
            this.c3.Margin = new System.Windows.Forms.Padding(3);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(48, 24);
            this.c3.TabIndex = 2;
            this.c3.Text = "3";
            this.c3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tScan
            // 
            this.tScan.Tick += new System.EventHandler(this.tScan_Tick);
            // 
            // tRainbow
            // 
            this.tRainbow.Interval = 10;
            this.tRainbow.Tick += new System.EventHandler(this.tRainbow_Tick);
            // 
            // chkRainbow
            // 
            this.chkRainbow.AutoSize = true;
            this.chkRainbow.Location = new System.Drawing.Point(12, 116);
            this.chkRainbow.Name = "chkRainbow";
            this.chkRainbow.Size = new System.Drawing.Size(133, 17);
            this.chkRainbow.TabIndex = 6;
            this.chkRainbow.Text = "HOLY FUCKING SHIT";
            this.chkRainbow.UseVisualStyleBackColor = true;
            this.chkRainbow.CheckedChanged += new System.EventHandler(this.chkRainbow_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 68);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lbOS
            // 
            this.lbOS.AutoSize = true;
            this.lbOS.Location = new System.Drawing.Point(12, 148);
            this.lbOS.Name = "lbOS";
            this.lbOS.Size = new System.Drawing.Size(71, 13);
            this.lbOS.TabIndex = 9;
            this.lbOS.Text = "Unknown OS";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(180, 170);
            this.Controls.Add(this.lbOS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkRainbow);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.c1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "ppSwatch";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label c1;
        private System.Windows.Forms.Label c2;
        private System.Windows.Forms.Label c3;
        private System.Windows.Forms.Timer tScan;
        private System.Windows.Forms.Timer tRainbow;
        private System.Windows.Forms.CheckBox chkRainbow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbOS;
    }
}

