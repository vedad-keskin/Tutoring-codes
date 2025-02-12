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
            button1 = new Button();
            pbLogo = new PictureBox();
            txtOznaka = new TextBox();
            txtNaziv = new TextBox();
            txtKapacitet = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Logo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(295, 52);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(301, 132);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 0;
            label3.Text = "Oznaka:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(482, 132);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 0;
            label4.Text = "Kapacitet:";
            // 
            // button1
            // 
            button1.Location = new Point(521, 231);
            button1.Name = "button1";
            button1.Size = new Size(130, 29);
            button1.TabIndex = 1;
            button1.Text = "Sačuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pbLogo
            // 
            pbLogo.Location = new Point(12, 52);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(248, 208);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            pbLogo.DoubleClick += pbLogo_DoubleClick;
            // 
            // txtOznaka
            // 
            txtOznaka.Location = new Point(295, 155);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(181, 27);
            txtOznaka.TabIndex = 3;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(295, 85);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(356, 27);
            txtNaziv.TabIndex = 3;
            // 
            // txtKapacitet
            // 
            txtKapacitet.Location = new Point(482, 155);
            txtKapacitet.Name = "txtKapacitet";
            txtKapacitet.Size = new Size(175, 27);
            txtKapacitet.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmNovaProstorijaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 282);
            Controls.Add(txtNaziv);
            Controls.Add(txtKapacitet);
            Controls.Add(txtOznaka);
            Controls.Add(pbLogo);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovaProstorijaIB180079";
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
        private Button button1;
        private PictureBox pbLogo;
        private TextBox txtOznaka;
        private TextBox txtNaziv;
        private TextBox txtKapacitet;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider err;
    }
}