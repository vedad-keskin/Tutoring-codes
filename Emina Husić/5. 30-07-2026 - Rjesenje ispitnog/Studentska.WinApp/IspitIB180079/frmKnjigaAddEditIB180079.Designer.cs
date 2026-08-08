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
            pbSlika = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNaziv = new TextBox();
            txtAutor = new TextBox();
            txtBrojPrimjeraka = new TextBox();
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
            pbSlika.Size = new Size(189, 220);
            pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlika.TabIndex = 0;
            pbSlika.TabStop = false;
            pbSlika.DoubleClick += pbSlika_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 12);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 1;
            label1.Text = "Naziv knjige:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 69);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 1;
            label2.Text = "Autori:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(222, 130);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 1;
            label3.Text = "Broj primjeraka:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(222, 35);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(298, 27);
            txtNaziv.TabIndex = 2;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(222, 92);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(298, 27);
            txtAutor.TabIndex = 2;
            // 
            // txtBrojPrimjeraka
            // 
            txtBrojPrimjeraka.Location = new Point(222, 153);
            txtBrojPrimjeraka.Name = "txtBrojPrimjeraka";
            txtBrojPrimjeraka.Size = new Size(298, 27);
            txtBrojPrimjeraka.TabIndex = 2;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(375, 203);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(145, 29);
            btnSacuvaj.TabIndex = 3;
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
            // frmKnjigaAddEditIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 249);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtBrojPrimjeraka);
            Controls.Add(txtAutor);
            Controls.Add(txtNaziv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbSlika);
            Name = "frmKnjigaAddEditIB180079";
            Text = "Podaci o knjizi";
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSlika;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNaziv;
        private TextBox txtAutor;
        private TextBox txtBrojPrimjeraka;
        private Button btnSacuvaj;
        private OpenFileDialog ofd;
        private ErrorProvider err;
    }
}