namespace Hammerkey
{
    partial class Form1
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
            this.Hammer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Hammer
            // 
            this.Hammer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hammer.Location = new System.Drawing.Point(12, 12);
            this.Hammer.Name = "Hammer";
            this.Hammer.Size = new System.Drawing.Size(268, 242);
            this.Hammer.TabIndex = 0;
            this.Hammer.Text = "Hammer!";
            this.Hammer.UseVisualStyleBackColor = true;
            this.Hammer.Click += new System.EventHandler(this.Hammer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 263);
            this.Controls.Add(this.Hammer);
            this.Name = "Form1";
            this.Text = "Praetox | Hammer that key!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Hammer;
    }
}

