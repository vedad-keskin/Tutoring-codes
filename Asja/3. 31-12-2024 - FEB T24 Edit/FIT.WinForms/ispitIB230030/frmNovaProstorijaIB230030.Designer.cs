namespace FIT.WinForms.ispitIB230030
{
    partial class frmNovaProstorijaIB230030
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
            label4 = new Label();
            pbLogo = new PictureBox();
            err = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            txtKapacitet = new TextBox();
            txtOznaka = new TextBox();
            txtNaziv = new TextBox();
            btnSacuvaj = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 21);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Logo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 60);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(259, 124);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 0;
            label3.Text = "Oznaka:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(416, 124);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "Kapacitet:";
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(30, 44);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(213, 182);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            pbLogo.DoubleClick += pbLogo_DoubleClick;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtKapacitet
            // 
            txtKapacitet.Location = new Point(416, 143);
            txtKapacitet.Name = "txtKapacitet";
            txtKapacitet.Size = new Size(151, 27);
            txtKapacitet.TabIndex = 2;
            // 
            // txtOznaka
            // 
            txtOznaka.Location = new Point(259, 143);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(151, 27);
            txtOznaka.TabIndex = 2;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(259, 83);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(308, 27);
            txtNaziv.TabIndex = 2;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(473, 197);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(94, 29);
            btnSacuvaj.TabIndex = 3;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // frmNovaProstorijaIB230030
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 238);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtNaziv);
            Controls.Add(txtOznaka);
            Controls.Add(txtKapacitet);
            Controls.Add(pbLogo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovaProstorijaIB230030";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o prostoriji";
            Load += frmNovaProstorijaIB230030_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pbLogo;
        private ErrorProvider err;
        private TextBox txtKapacitet;
        private OpenFileDialog openFileDialog1;
        private TextBox txtOznaka;
        private Button btnSacuvaj;
        private TextBox txtNaziv;
    }
}