﻿namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmNovoUvjerenjeIB180079
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
            txtSvrha = new TextBox();
            cbVrsta = new ComboBox();
            pbUplatnica = new PictureBox();
            btnSacuvaj = new Button();
            btnOtkazi = new Button();
            err = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "Vrsta uvjerenja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 9);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 0;
            label2.Text = "Skenirana uplatnica:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 0;
            label3.Text = "Svrha uvjerenja:";
            // 
            // txtSvrha
            // 
            txtSvrha.Location = new Point(12, 86);
            txtSvrha.Multiline = true;
            txtSvrha.Name = "txtSvrha";
            txtSvrha.Size = new Size(272, 242);
            txtSvrha.TabIndex = 1;
            // 
            // cbVrsta
            // 
            cbVrsta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVrsta.FormattingEnabled = true;
            cbVrsta.Items.AddRange(new object[] { "Uvjerenje o položenim ispitima", "Uvjerenje o statusu studenta" });
            cbVrsta.Location = new Point(12, 32);
            cbVrsta.Name = "cbVrsta";
            cbVrsta.Size = new Size(272, 28);
            cbVrsta.TabIndex = 2;
            // 
            // pbUplatnica
            // 
            pbUplatnica.Location = new Point(307, 32);
            pbUplatnica.Name = "pbUplatnica";
            pbUplatnica.Size = new Size(516, 241);
            pbUplatnica.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUplatnica.TabIndex = 3;
            pbUplatnica.TabStop = false;
            pbUplatnica.DoubleClick += pbUplatnica_DoubleClick;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(709, 299);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(114, 29);
            btnSacuvaj.TabIndex = 4;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnOtkazi
            // 
            btnOtkazi.Location = new Point(589, 299);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(114, 29);
            btnOtkazi.TabIndex = 4;
            btnOtkazi.Text = "Otkaži";
            btnOtkazi.UseVisualStyleBackColor = true;
            btnOtkazi.Click += btnOtkazi_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmNovoUvjerenjeIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 347);
            Controls.Add(btnOtkazi);
            Controls.Add(btnSacuvaj);
            Controls.Add(pbUplatnica);
            Controls.Add(cbVrsta);
            Controls.Add(txtSvrha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovoUvjerenjeIB180079";
            Text = "Novi zahtjev za izdavanjem uvjerenja";
            Load += frmNovoUvjerenjeIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSvrha;
        private ComboBox cbVrsta;
        private PictureBox pbUplatnica;
        private Button btnSacuvaj;
        private Button btnOtkazi;
        private ErrorProvider err;
        private OpenFileDialog openFileDialog1;
    }
}