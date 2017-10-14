namespace Still_Alive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.prg = new System.Windows.Forms.Label();
            this.cmdGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGo4chon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please wait, downloading...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prg
            // 
            this.prg.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prg.ForeColor = System.Drawing.Color.White;
            this.prg.Location = new System.Drawing.Point(12, 39);
            this.prg.Name = "prg";
            this.prg.Size = new System.Drawing.Size(268, 30);
            this.prg.TabIndex = 1;
            this.prg.Text = "0%";
            this.prg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdGo
            // 
            this.cmdGo.Enabled = false;
            this.cmdGo.Location = new System.Drawing.Point(178, 193);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(102, 23);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "Let\'s go already!";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 78);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // cmdGo4chon
            // 
            this.cmdGo4chon.Enabled = false;
            this.cmdGo4chon.Location = new System.Drawing.Point(12, 193);
            this.cmdGo4chon.Name = "cmdGo4chon";
            this.cmdGo4chon.Size = new System.Drawing.Size(70, 23);
            this.cmdGo4chon.TabIndex = 4;
            this.cmdGo4chon.Text = "4chon ver.";
            this.cmdGo4chon.UseVisualStyleBackColor = true;
            this.cmdGo4chon.Click += new System.EventHandler(this.cmdGo4chon_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 228);
            this.Controls.Add(this.cmdGo4chon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.prg);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "SA-Prompt";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prg;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGo4chon;
    }
}

