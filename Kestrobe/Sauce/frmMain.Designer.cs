namespace Kestrobe {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tScript = new System.Windows.Forms.Timer(this.components);
            this._Tracks = new System.Windows.Forms.CheckedListBox();
            this._CheckAll = new System.Windows.Forms.CheckBox();
            this._Reload = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._CurB = new System.Windows.Forms.Label();
            this._BPM = new System.Windows.Forms.Label();
            this._Location = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Prog2 = new System.Windows.Forms.Label();
            this.Prog1 = new System.Windows.Forms.Label();
            this._Next = new System.Windows.Forms.Button();
            this._Play = new System.Windows.Forms.Button();
            this._Prev = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tScript
            // 
            this.tScript.Enabled = true;
            this.tScript.Interval = 10;
            this.tScript.Tick += new System.EventHandler(this.tScript_Tick);
            // 
            // _Tracks
            // 
            this._Tracks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this._Tracks.ForeColor = System.Drawing.Color.White;
            this._Tracks.FormattingEnabled = true;
            this._Tracks.Location = new System.Drawing.Point(12, 12);
            this._Tracks.Name = "_Tracks";
            this._Tracks.Size = new System.Drawing.Size(268, 124);
            this._Tracks.TabIndex = 0;
            // 
            // _CheckAll
            // 
            this._CheckAll.AutoSize = true;
            this._CheckAll.ForeColor = System.Drawing.Color.White;
            this._CheckAll.Location = new System.Drawing.Point(12, 142);
            this._CheckAll.Name = "_CheckAll";
            this._CheckAll.Size = new System.Drawing.Size(70, 17);
            this._CheckAll.TabIndex = 1;
            this._CheckAll.Text = "Check all";
            this._CheckAll.UseVisualStyleBackColor = true;
            this._CheckAll.CheckedChanged += new System.EventHandler(this._CheckAll_CheckedChanged);
            // 
            // _Reload
            // 
            this._Reload.AutoSize = true;
            this._Reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Reload.ForeColor = System.Drawing.Color.White;
            this._Reload.Location = new System.Drawing.Point(224, 143);
            this._Reload.Name = "_Reload";
            this._Reload.Size = new System.Drawing.Size(56, 13);
            this._Reload.TabIndex = 2;
            this._Reload.Text = "Reload list";
            this._Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._CurB);
            this.panel1.Controls.Add(this._BPM);
            this.panel1.Controls.Add(this._Location);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Prog2);
            this.panel1.Controls.Add(this.Prog1);
            this.panel1.Controls.Add(this._Next);
            this.panel1.Controls.Add(this._Play);
            this.panel1.Controls.Add(this._Prev);
            this.panel1.Location = new System.Drawing.Point(12, 174);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 97);
            this.panel1.TabIndex = 3;
            // 
            // _CurB
            // 
            this._CurB.ForeColor = System.Drawing.Color.White;
            this._CurB.Location = new System.Drawing.Point(181, 55);
            this._CurB.Margin = new System.Windows.Forms.Padding(3);
            this._CurB.Name = "_CurB";
            this._CurB.Size = new System.Drawing.Size(82, 13);
            this._CurB.TabIndex = 10;
            this._CurB.Text = "X";
            // 
            // _BPM
            // 
            this._BPM.ForeColor = System.Drawing.Color.White;
            this._BPM.Location = new System.Drawing.Point(91, 55);
            this._BPM.Margin = new System.Windows.Forms.Padding(3);
            this._BPM.Name = "_BPM";
            this._BPM.Size = new System.Drawing.Size(84, 13);
            this._BPM.TabIndex = 9;
            this._BPM.Text = "XXX";
            // 
            // _Location
            // 
            this._Location.ForeColor = System.Drawing.Color.White;
            this._Location.Location = new System.Drawing.Point(3, 55);
            this._Location.Margin = new System.Windows.Forms.Padding(3);
            this._Location.Name = "_Location";
            this._Location.Size = new System.Drawing.Size(82, 13);
            this._Location.TabIndex = 8;
            this._Location.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(181, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current B";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(91, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Track BPM";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Location";
            // 
            // Prog2
            // 
            this.Prog2.BackColor = System.Drawing.Color.White;
            this.Prog2.Location = new System.Drawing.Point(3, 29);
            this.Prog2.Name = "Prog2";
            this.Prog2.Size = new System.Drawing.Size(260, 8);
            this.Prog2.TabIndex = 4;
            this.Prog2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Prog2_MouseMove);
            this.Prog2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Prog2_MouseDown);
            // 
            // Prog1
            // 
            this.Prog1.BackColor = System.Drawing.Color.Black;
            this.Prog1.Location = new System.Drawing.Point(4, 30);
            this.Prog1.Name = "Prog1";
            this.Prog1.Size = new System.Drawing.Size(260, 8);
            this.Prog1.TabIndex = 3;
            this.Prog1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Prog1_MouseMove);
            this.Prog1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Prog1_MouseDown);
            // 
            // _Next
            // 
            this._Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._Next.ForeColor = System.Drawing.Color.White;
            this._Next.Location = new System.Drawing.Point(180, 3);
            this._Next.Name = "_Next";
            this._Next.Size = new System.Drawing.Size(83, 23);
            this._Next.TabIndex = 2;
            this._Next.Text = ">>";
            this._Next.UseVisualStyleBackColor = false;
            this._Next.Click += new System.EventHandler(this._Next_Click);
            // 
            // _Play
            // 
            this._Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._Play.ForeColor = System.Drawing.Color.White;
            this._Play.Location = new System.Drawing.Point(92, 3);
            this._Play.Name = "_Play";
            this._Play.Size = new System.Drawing.Size(82, 23);
            this._Play.TabIndex = 1;
            this._Play.Text = "|>";
            this._Play.UseVisualStyleBackColor = false;
            this._Play.Click += new System.EventHandler(this._Play_Click);
            // 
            // _Prev
            // 
            this._Prev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._Prev.ForeColor = System.Drawing.Color.White;
            this._Prev.Location = new System.Drawing.Point(3, 3);
            this._Prev.Name = "_Prev";
            this._Prev.Size = new System.Drawing.Size(83, 23);
            this._Prev.TabIndex = 0;
            this._Prev.Text = "<<";
            this._Prev.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(292, 283);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._Reload);
            this.Controls.Add(this._CheckAll);
            this.Controls.Add(this._Tracks);
            this.Name = "frmMain";
            this.Text = "Kestrobe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tScript;
        private System.Windows.Forms.CheckedListBox _Tracks;
        private System.Windows.Forms.CheckBox _CheckAll;
        private System.Windows.Forms.Label _Reload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Prog2;
        private System.Windows.Forms.Label Prog1;
        private System.Windows.Forms.Button _Next;
        private System.Windows.Forms.Button _Play;
        private System.Windows.Forms.Button _Prev;
        private System.Windows.Forms.Label _CurB;
        private System.Windows.Forms.Label _BPM;
        private System.Windows.Forms.Label _Location;
    }
}

