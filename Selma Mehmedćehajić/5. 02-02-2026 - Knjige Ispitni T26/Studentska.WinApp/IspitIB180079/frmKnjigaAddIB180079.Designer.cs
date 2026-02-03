namespace Studentska.WinApp.IspitIB180079
{
    partial class frmKnjigaAddIB180079
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
            pbSlika = new PictureBox();
            label1 = new Label();
            txtNaziv = new TextBox();
            txtAutori = new TextBox();
            label2 = new Label();
            txtBroj = new TextBox();
            label3 = new Label();
            btnSacuvaj = new Button();
            ofd = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // pbSlika
            // 
            pbSlika.BorderStyle = BorderStyle.FixedSingle;
            pbSlika.Location = new Point(12, 12);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(188, 215);
            pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlika.TabIndex = 0;
            pbSlika.TabStop = false;
            pbSlika.DoubleClick += pbSlika_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 12);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 1;
            label1.Text = "Naziv knjige:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(219, 35);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(343, 27);
            txtNaziv.TabIndex = 2;
            // 
            // txtAutori
            // 
            txtAutori.Location = new Point(219, 96);
            txtAutori.Name = "txtAutori";
            txtAutori.Size = new Size(343, 27);
            txtAutori.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 73);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "Autori:";
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(219, 154);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(343, 27);
            txtBroj.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 131);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 5;
            label3.Text = "Broj primjeraka:";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(394, 198);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(168, 29);
            btnSacuvaj.TabIndex = 7;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmKnjigaAddIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 243);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtBroj);
            Controls.Add(label3);
            Controls.Add(txtAutori);
            Controls.Add(label2);
            Controls.Add(txtNaziv);
            Controls.Add(label1);
            Controls.Add(pbSlika);
            Name = "frmKnjigaAddIB180079";
            Text = "Podaci o knjizi";
            Load += frmKnjigaAddIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSlika;
        private Label label1;
        private TextBox txtNaziv;
        private TextBox txtAutori;
        private Label label2;
        private TextBox txtBroj;
        private Label label3;
        private Button btnSacuvaj;
        private OpenFileDialog ofd;
        private ErrorProvider err;
    }
}