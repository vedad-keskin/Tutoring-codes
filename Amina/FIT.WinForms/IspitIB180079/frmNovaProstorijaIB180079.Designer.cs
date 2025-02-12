namespace FIT.WinForms.IspitIB180079
{
    partial class frmNovaProstorijaIB180079
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
            txtOznaka = new TextBox();
            txtNaziv = new TextBox();
            txtKapacitet = new TextBox();
            button1 = new Button();
            err = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 54);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 118);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 0;
            label2.Text = "Oznaka:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(463, 118);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 0;
            label3.Text = "Kapacitet:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 20);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 0;
            label4.Text = "Logo:";
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(12, 54);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(217, 185);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            pbLogo.DoubleClick += pbLogo_DoubleClick;
            // 
            // txtOznaka
            // 
            txtOznaka.Location = new Point(262, 162);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(152, 27);
            txtOznaka.TabIndex = 2;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(262, 77);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(353, 27);
            txtNaziv.TabIndex = 2;
            // 
            // txtKapacitet
            // 
            txtKapacitet.Location = new Point(463, 162);
            txtKapacitet.Name = "txtKapacitet";
            txtKapacitet.Size = new Size(152, 27);
            txtKapacitet.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(491, 210);
            button1.Name = "button1";
            button1.Size = new Size(124, 29);
            button1.TabIndex = 3;
            button1.Text = "Sačuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmNovaProstorijaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 254);
            Controls.Add(button1);
            Controls.Add(txtNaziv);
            Controls.Add(txtKapacitet);
            Controls.Add(txtOznaka);
            Controls.Add(pbLogo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovaProstorijaIB180079";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o prostoriji";
            Load += frmNovaProstorijaIB180079_Load;
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
        private TextBox txtOznaka;
        private TextBox txtNaziv;
        private TextBox txtKapacitet;
        private Button button1;
        private ErrorProvider err;
        private OpenFileDialog openFileDialog1;
    }
}