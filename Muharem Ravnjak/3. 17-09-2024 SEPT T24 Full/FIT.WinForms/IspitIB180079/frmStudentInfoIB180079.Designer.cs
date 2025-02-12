namespace FIT.WinForms.IspitIB180079
{
    partial class frmStudentInfoIB180079
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
            pbSlika = new PictureBox();
            lblImePrezime = new Label();
            lblProsjek = new Label();
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            SuspendLayout();
            // 
            // pbSlika
            // 
            pbSlika.Location = new Point(48, 12);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(277, 255);
            pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlika.TabIndex = 0;
            pbSlika.TabStop = false;
            // 
            // lblImePrezime
            // 
            lblImePrezime.Font = new Font("Segoe UI", 20F);
            lblImePrezime.Location = new Point(48, 279);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(277, 46);
            lblImePrezime.TabIndex = 1;
            lblImePrezime.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblProsjek
            // 
            lblProsjek.Font = new Font("Segoe UI", 20F);
            lblProsjek.Location = new Point(48, 325);
            lblProsjek.Name = "lblProsjek";
            lblProsjek.Size = new Size(277, 46);
            lblProsjek.TabIndex = 1;
            lblProsjek.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmStudentInfoIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 399);
            Controls.Add(lblProsjek);
            Controls.Add(lblImePrezime);
            Controls.Add(pbSlika);
            Name = "frmStudentInfoIB180079";
            Text = "frmStudentInfoIB180079";
            Load += frmStudentInfoIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbSlika;
        private Label lblImePrezime;
        private Label lblProsjek;
    }
}