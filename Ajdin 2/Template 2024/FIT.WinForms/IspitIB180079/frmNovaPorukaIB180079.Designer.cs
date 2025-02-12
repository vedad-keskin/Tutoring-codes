namespace FIT.WinForms.IspitIB180079
{
    partial class frmNovaPorukaIB180079
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
            cbPredmet = new ComboBox();
            dtpValidnost = new DateTimePicker();
            txtSadrzaj = new TextBox();
            pbSlika = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbSlika).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 0;
            label1.Text = "Odaberite predmet:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 0;
            label2.Text = "Poruka je validna do:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 0;
            label3.Text = "Sadržaj poruke:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(343, 9);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 0;
            label4.Text = "Slika:";
            // 
            // cbPredmet
            // 
            cbPredmet.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPredmet.FormattingEnabled = true;
            cbPredmet.Location = new Point(12, 38);
            cbPredmet.Name = "cbPredmet";
            cbPredmet.Size = new Size(314, 28);
            cbPredmet.TabIndex = 1;
            // 
            // dtpValidnost
            // 
            dtpValidnost.Location = new Point(12, 92);
            dtpValidnost.Name = "dtpValidnost";
            dtpValidnost.Size = new Size(314, 27);
            dtpValidnost.TabIndex = 2;
            // 
            // txtSadrzaj
            // 
            txtSadrzaj.Location = new Point(12, 154);
            txtSadrzaj.Multiline = true;
            txtSadrzaj.Name = "txtSadrzaj";
            txtSadrzaj.Size = new Size(314, 167);
            txtSadrzaj.TabIndex = 3;
            // 
            // pbSlika
            // 
            pbSlika.Location = new Point(343, 38);
            pbSlika.Name = "pbSlika";
            pbSlika.Size = new Size(358, 283);
            pbSlika.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlika.TabIndex = 4;
            pbSlika.TabStop = false;
            pbSlika.DoubleClick += pbSlika_DoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(576, 334);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 5;
            button1.Text = "Sačuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(430, 334);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 5;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmNovaPorukaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 375);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pbSlika);
            Controls.Add(txtSadrzaj);
            Controls.Add(dtpValidnost);
            Controls.Add(cbPredmet);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovaPorukaIB180079";
            Text = "Poruka";
            Load += frmNovaPorukaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)pbSlika).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbPredmet;
        private DateTimePicker dtpValidnost;
        private TextBox txtSadrzaj;
        private PictureBox pbSlika;
        private Button button1;
        private Button button2;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider err;
    }
}