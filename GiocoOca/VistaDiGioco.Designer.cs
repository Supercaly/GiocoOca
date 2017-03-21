namespace GiocoOca
{
    partial class VistaDiGioco
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLancioDadi = new System.Windows.Forms.Label();
            this.bottoneLanciaDadi = new System.Windows.Forms.Button();
            this.pannelloTavolo = new System.Windows.Forms.Panel();
            this.bottoneRegole = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bottoneRegole);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelLancioDadi);
            this.panel1.Controls.Add(this.bottoneLanciaDadi);
            this.panel1.Controls.Add(this.pannelloTavolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 521);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lancio Dadi:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLancioDadi
            // 
            this.labelLancioDadi.AutoSize = true;
            this.labelLancioDadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.labelLancioDadi.Location = new System.Drawing.Point(474, 451);
            this.labelLancioDadi.Name = "labelLancioDadi";
            this.labelLancioDadi.Size = new System.Drawing.Size(24, 25);
            this.labelLancioDadi.TabIndex = 3;
            this.labelLancioDadi.Text = "0";
            // 
            // bottoneLanciaDadi
            // 
            this.bottoneLanciaDadi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bottoneLanciaDadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.bottoneLanciaDadi.Location = new System.Drawing.Point(678, 442);
            this.bottoneLanciaDadi.Name = "bottoneLanciaDadi";
            this.bottoneLanciaDadi.Size = new System.Drawing.Size(94, 46);
            this.bottoneLanciaDadi.TabIndex = 1;
            this.bottoneLanciaDadi.Text = "Lancia Dadi";
            this.bottoneLanciaDadi.UseVisualStyleBackColor = true;
            // 
            // pannelloTavolo
            // 
            this.pannelloTavolo.Location = new System.Drawing.Point(12, 12);
            this.pannelloTavolo.Name = "pannelloTavolo";
            this.pannelloTavolo.Size = new System.Drawing.Size(760, 400);
            this.pannelloTavolo.TabIndex = 0;
            // 
            // bottoneRegole
            // 
            this.bottoneRegole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bottoneRegole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.bottoneRegole.Location = new System.Drawing.Point(578, 442);
            this.bottoneRegole.Name = "bottoneRegole";
            this.bottoneRegole.Size = new System.Drawing.Size(94, 46);
            this.bottoneRegole.TabIndex = 5;
            this.bottoneRegole.Text = "Regole";
            this.bottoneRegole.UseVisualStyleBackColor = true;
            this.bottoneRegole.Click += new System.EventHandler(this.bottoneRegole_Click);
            // 
            // VistaDiGioco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VistaDiGioco";
            this.Text = "Gioco Dell\'Oca";
            this.Load += new System.EventHandler(this.Vista2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pannelloTavolo;
        private System.Windows.Forms.Button bottoneLanciaDadi;
        private System.Windows.Forms.Label labelLancioDadi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bottoneRegole;
    }
}