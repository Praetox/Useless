namespace pTib_FTP
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
            this.Client_GBox = new System.Windows.Forms.GroupBox();
            this.Client_Refresh = new System.Windows.Forms.Button();
            this.Client_CBox = new System.Windows.Forms.ComboBox();
            this.FTP_GBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FTP_Host = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FTP_Rate = new System.Windows.Forms.TextBox();
            this.FTP_Path = new System.Windows.Forms.TextBox();
            this.FTP_Pass = new System.Windows.Forms.TextBox();
            this.FTP_User = new System.Windows.Forms.TextBox();
            this.Status_GBox = new System.Windows.Forms.GroupBox();
            this.Status_Toggle = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Website_Template = new System.Windows.Forms.TextBox();
            this.tMain = new System.Windows.Forms.Timer(this.components);
            this.Client_GBox.SuspendLayout();
            this.FTP_GBox.SuspendLayout();
            this.Status_GBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Client_GBox
            // 
            this.Client_GBox.Controls.Add(this.Client_Refresh);
            this.Client_GBox.Controls.Add(this.Client_CBox);
            this.Client_GBox.Location = new System.Drawing.Point(12, 12);
            this.Client_GBox.Name = "Client_GBox";
            this.Client_GBox.Size = new System.Drawing.Size(260, 46);
            this.Client_GBox.TabIndex = 0;
            this.Client_GBox.TabStop = false;
            this.Client_GBox.Text = "Tibia client";
            this.Client_GBox.Enter += new System.EventHandler(this.Client_GBox_Enter);
            // 
            // Client_Refresh
            // 
            this.Client_Refresh.Location = new System.Drawing.Point(187, 18);
            this.Client_Refresh.Name = "Client_Refresh";
            this.Client_Refresh.Size = new System.Drawing.Size(67, 22);
            this.Client_Refresh.TabIndex = 1;
            this.Client_Refresh.Text = "Refresh";
            this.Client_Refresh.UseVisualStyleBackColor = true;
            this.Client_Refresh.Click += new System.EventHandler(this.Client_Refresh_Click);
            // 
            // Client_CBox
            // 
            this.Client_CBox.FormattingEnabled = true;
            this.Client_CBox.Location = new System.Drawing.Point(6, 19);
            this.Client_CBox.Name = "Client_CBox";
            this.Client_CBox.Size = new System.Drawing.Size(175, 21);
            this.Client_CBox.TabIndex = 0;
            this.Client_CBox.SelectedIndexChanged += new System.EventHandler(this.Client_CBox_SelectedIndexChanged);
            // 
            // FTP_GBox
            // 
            this.FTP_GBox.Controls.Add(this.label5);
            this.FTP_GBox.Controls.Add(this.FTP_Host);
            this.FTP_GBox.Controls.Add(this.label4);
            this.FTP_GBox.Controls.Add(this.label3);
            this.FTP_GBox.Controls.Add(this.label2);
            this.FTP_GBox.Controls.Add(this.label1);
            this.FTP_GBox.Controls.Add(this.FTP_Rate);
            this.FTP_GBox.Controls.Add(this.FTP_Path);
            this.FTP_GBox.Controls.Add(this.FTP_Pass);
            this.FTP_GBox.Controls.Add(this.FTP_User);
            this.FTP_GBox.Location = new System.Drawing.Point(12, 64);
            this.FTP_GBox.Name = "FTP_GBox";
            this.FTP_GBox.Size = new System.Drawing.Size(260, 149);
            this.FTP_GBox.TabIndex = 1;
            this.FTP_GBox.TabStop = false;
            this.FTP_GBox.Text = "FTP Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Host";
            // 
            // FTP_Host
            // 
            this.FTP_Host.Location = new System.Drawing.Point(70, 19);
            this.FTP_Host.Name = "FTP_Host";
            this.FTP_Host.Size = new System.Drawing.Size(184, 20);
            this.FTP_Host.TabIndex = 2;
            this.FTP_Host.TextChanged += new System.EventHandler(this.FTP_Host_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Upload rate (every x second)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "File path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // FTP_Rate
            // 
            this.FTP_Rate.Location = new System.Drawing.Point(162, 123);
            this.FTP_Rate.Name = "FTP_Rate";
            this.FTP_Rate.Size = new System.Drawing.Size(92, 20);
            this.FTP_Rate.TabIndex = 6;
            this.FTP_Rate.Text = "300";
            // 
            // FTP_Path
            // 
            this.FTP_Path.Location = new System.Drawing.Point(70, 97);
            this.FTP_Path.Name = "FTP_Path";
            this.FTP_Path.Size = new System.Drawing.Size(184, 20);
            this.FTP_Path.TabIndex = 5;
            this.FTP_Path.Text = "tibstats_%nick%.html";
            // 
            // FTP_Pass
            // 
            this.FTP_Pass.Location = new System.Drawing.Point(70, 71);
            this.FTP_Pass.Name = "FTP_Pass";
            this.FTP_Pass.PasswordChar = '*';
            this.FTP_Pass.Size = new System.Drawing.Size(184, 20);
            this.FTP_Pass.TabIndex = 4;
            // 
            // FTP_User
            // 
            this.FTP_User.Location = new System.Drawing.Point(70, 45);
            this.FTP_User.Name = "FTP_User";
            this.FTP_User.Size = new System.Drawing.Size(184, 20);
            this.FTP_User.TabIndex = 3;
            // 
            // Status_GBox
            // 
            this.Status_GBox.Controls.Add(this.Status_Toggle);
            this.Status_GBox.Controls.Add(this.Status);
            this.Status_GBox.Location = new System.Drawing.Point(12, 219);
            this.Status_GBox.Name = "Status_GBox";
            this.Status_GBox.Size = new System.Drawing.Size(260, 71);
            this.Status_GBox.TabIndex = 2;
            this.Status_GBox.TabStop = false;
            this.Status_GBox.Text = "Uploader status";
            // 
            // Status_Toggle
            // 
            this.Status_Toggle.Location = new System.Drawing.Point(6, 42);
            this.Status_Toggle.Name = "Status_Toggle";
            this.Status_Toggle.Size = new System.Drawing.Size(248, 23);
            this.Status_Toggle.TabIndex = 8;
            this.Status_Toggle.Text = "Enable";
            this.Status_Toggle.UseVisualStyleBackColor = true;
            this.Status_Toggle.Click += new System.EventHandler(this.Status_Toggle_Click);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(6, 16);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(248, 23);
            this.Status.TabIndex = 3;
            this.Status.Text = "The uploader is not activated";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Website_Template);
            this.groupBox1.Location = new System.Drawing.Point(278, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 278);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Website";
            // 
            // Website_Template
            // 
            this.Website_Template.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Website_Template.Location = new System.Drawing.Point(6, 19);
            this.Website_Template.Multiline = true;
            this.Website_Template.Name = "Website_Template";
            this.Website_Template.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Website_Template.Size = new System.Drawing.Size(538, 253);
            this.Website_Template.TabIndex = 7;
            this.Website_Template.Text = resources.GetString("Website_Template.Text");
            // 
            // tMain
            // 
            this.tMain.Tick += new System.EventHandler(this.tMain_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 302);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Status_GBox);
            this.Controls.Add(this.FTP_GBox);
            this.Controls.Add(this.Client_GBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "pTib FTP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Client_GBox.ResumeLayout(false);
            this.FTP_GBox.ResumeLayout(false);
            this.FTP_GBox.PerformLayout();
            this.Status_GBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Client_GBox;
        private System.Windows.Forms.Button Client_Refresh;
        private System.Windows.Forms.ComboBox Client_CBox;
        private System.Windows.Forms.GroupBox FTP_GBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FTP_Rate;
        private System.Windows.Forms.TextBox FTP_Path;
        private System.Windows.Forms.TextBox FTP_Pass;
        private System.Windows.Forms.TextBox FTP_User;
        private System.Windows.Forms.GroupBox Status_GBox;
        private System.Windows.Forms.Button Status_Toggle;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Website_Template;
        private System.Windows.Forms.Timer tMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FTP_Host;
    }
}

