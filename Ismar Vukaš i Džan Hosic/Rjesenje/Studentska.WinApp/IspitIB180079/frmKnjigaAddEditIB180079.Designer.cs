namespace Studentska.WinApp.IspitIB180079
{
    partial class frmKnjigaAddEditIB180079
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNaziv = new TextBox();
            txtAutor = new TextBox();
            txtBrojPrimjeraka = new TextBox();
            btnSacuvaj = new Button();
            pbSlika = new PictureBox();
            ofdSlika = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(241, 9);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv knjige:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 64);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 0;
            label2.Text = "Autori:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 125);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 0;
            label3.Text = "Broj primjeraka:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(241, 32);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(365, 27);
            txtNaziv.TabIndex = 1;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(241, 87);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(365, 27);
            txtAutor.TabIndex = 1;
            // 
            // txtBrojPrimjeraka
            // 
            txtBrojPrimjeraka.Location = new Point(241, 148);
            txtBrojPrimjeraka.Name = "txtBrojPrimjeraka";
            txtBrojPrimjeraka.Size = new Size(365, 27);
            txtBrojPrimjeraka.TabIndex = 1;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(451, 211);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(155, 29);
            btnSacuvaj.TabIndex = 2;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // pbSlika
            // 
            pbSlika.BorderStyle = BorderStyle.FixedSingle;
            pbSlika.Location = new Point(12, 12);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(187, 238);
            pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlika.TabIndex = 3;
            pbSlika.TabStop = false;
            pbSlika.DoubleClick += pbSlika_DoubleClick;
            // 
            // ofdSlika
            // 
            ofdSlika.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmKnjigaAddEditIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 259);
            Controls.Add(pbSlika);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtBrojPrimjeraka);
            Controls.Add(txtAutor);
            Controls.Add(txtNaziv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmKnjigaAddEditIB180079";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o knjizi";
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNaziv;
        private TextBox txtAutor;
        private TextBox txtBrojPrimjeraka;
        private Button btnSacuvaj;
        private PictureBox pbSlika;
        private OpenFileDialog ofdSlika;
        private ErrorProvider err;
    }
}