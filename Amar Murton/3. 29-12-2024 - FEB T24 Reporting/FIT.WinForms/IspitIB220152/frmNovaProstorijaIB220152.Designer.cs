namespace FIT.WinForms.IspitIB220152
{
    partial class frmNovaProstorijaIB220152
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
            pbLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbNaziv = new TextBox();
            tbOznaka = new TextBox();
            tbKapacitet = new TextBox();
            btnSacuvaj = new Button();
            openFileDialog1 = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(12, 48);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(157, 126);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            pbLogo.DoubleClick += pbLogo_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 1;
            label1.Text = "Logo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 48);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 104);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 1;
            label3.Text = "Oznaka:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(307, 104);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 1;
            label4.Text = "Kapacitet:";
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(184, 66);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(232, 23);
            tbNaziv.TabIndex = 2;
            // 
            // tbOznaka
            // 
            tbOznaka.Location = new Point(184, 122);
            tbOznaka.Name = "tbOznaka";
            tbOznaka.Size = new Size(115, 23);
            tbOznaka.TabIndex = 2;
            // 
            // tbKapacitet
            // 
            tbKapacitet.Location = new Point(305, 122);
            tbKapacitet.Name = "tbKapacitet";
            tbKapacitet.Size = new Size(111, 23);
            tbKapacitet.TabIndex = 2;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(341, 163);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(75, 23);
            btnSacuvaj.TabIndex = 3;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmNovaProstorijaIB220152
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 189);
            Controls.Add(btnSacuvaj);
            Controls.Add(tbKapacitet);
            Controls.Add(tbOznaka);
            Controls.Add(tbNaziv);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbLogo);
            Name = "frmNovaProstorijaIB220152";
            Text = "Podaci o prostoriji";
            Load += frmNovaProstorijaIB220152_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbNaziv;
        private TextBox tbOznaka;
        private TextBox tbKapacitet;
        private Button btnSacuvaj;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider err;
    }
}