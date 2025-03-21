﻿namespace FIT.WinForms.IspitIB180079
{
    partial class frmGradoviIB180079
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
            pbZastava = new PictureBox();
            lblNazivDrzave = new Label();
            dgvGradovi = new DataGridView();
            Naziv = new DataGridViewTextBoxColumn();
            Status = new DataGridViewCheckBoxColumn();
            Promijeni = new DataGridViewButtonColumn();
            label1 = new Label();
            txtNaziv = new TextBox();
            button1 = new Button();
            err = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            button2 = new Button();
            chbStatus = new CheckBox();
            txtInfo = new TextBox();
            txtBroj = new TextBox();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbZastava).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGradovi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pbZastava
            // 
            pbZastava.Location = new Point(12, 24);
            pbZastava.Name = "pbZastava";
            pbZastava.Size = new Size(201, 105);
            pbZastava.SizeMode = PictureBoxSizeMode.StretchImage;
            pbZastava.TabIndex = 0;
            pbZastava.TabStop = false;
            // 
            // lblNazivDrzave
            // 
            lblNazivDrzave.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNazivDrzave.Location = new Point(237, 53);
            lblNazivDrzave.Name = "lblNazivDrzave";
            lblNazivDrzave.Size = new Size(359, 76);
            lblNazivDrzave.TabIndex = 1;
            // 
            // dgvGradovi
            // 
            dgvGradovi.AllowUserToAddRows = false;
            dgvGradovi.AllowUserToDeleteRows = false;
            dgvGradovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGradovi.Columns.AddRange(new DataGridViewColumn[] { Naziv, Status, Promijeni });
            dgvGradovi.Location = new Point(12, 196);
            dgvGradovi.Name = "dgvGradovi";
            dgvGradovi.ReadOnly = true;
            dgvGradovi.RowHeadersWidth = 51;
            dgvGradovi.RowTemplate.Height = 29;
            dgvGradovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGradovi.Size = new Size(619, 209);
            dgvGradovi.TabIndex = 2;
            dgvGradovi.CellContentClick += dgvGradovi_CellContentClick;
            // 
            // Naziv
            // 
            Naziv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Naziv.DataPropertyName = "Naziv";
            Naziv.HeaderText = "Naziv grada";
            Naziv.MinimumWidth = 6;
            Naziv.Name = "Naziv";
            Naziv.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Aktivan";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // Promijeni
            // 
            Promijeni.HeaderText = "";
            Promijeni.MinimumWidth = 6;
            Promijeni.Name = "Promijeni";
            Promijeni.ReadOnly = true;
            Promijeni.Text = "Promijeni status";
            Promijeni.UseColumnTextForButtonValue = true;
            Promijeni.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 152);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 3;
            label1.Text = "Unesite naziv grada";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(157, 149);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(331, 27);
            txtNaziv.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(502, 148);
            button1.Name = "button1";
            button1.Size = new Size(129, 29);
            button1.TabIndex = 5;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(chbStatus);
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Controls.Add(txtBroj);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 421);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(619, 206);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator";
            // 
            // button2
            // 
            button2.Location = new Point(335, 29);
            button2.Name = "button2";
            button2.Size = new Size(151, 29);
            button2.TabIndex = 3;
            button2.Text = "Generiši";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // chbStatus
            // 
            chbStatus.AutoSize = true;
            chbStatus.Location = new Point(253, 33);
            chbStatus.Name = "chbStatus";
            chbStatus.Size = new Size(76, 24);
            chbStatus.TabIndex = 2;
            chbStatus.Text = "Aktivni";
            chbStatus.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 89);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(607, 111);
            txtInfo.TabIndex = 1;
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(110, 31);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(125, 27);
            txtBroj.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 66);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 0;
            label3.Text = "Info:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 33);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 0;
            label2.Text = "Broj gradova:";
            // 
            // frmGradoviIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 639);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(txtNaziv);
            Controls.Add(label1);
            Controls.Add(dgvGradovi);
            Controls.Add(lblNazivDrzave);
            Controls.Add(pbZastava);
            Name = "frmGradoviIB180079";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o gradovima";
            FormClosed += frmGradoviIB180079_FormClosed;
            Load += frmGradoviIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)pbZastava).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGradovi).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbZastava;
        private Label lblNazivDrzave;
        private DataGridView dgvGradovi;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewCheckBoxColumn Status;
        private DataGridViewButtonColumn Promijeni;
        private Label label1;
        private TextBox txtNaziv;
        private Button button1;
        private ErrorProvider err;
        private GroupBox groupBox1;
        private Button button2;
        private CheckBox chbStatus;
        private TextBox txtInfo;
        private TextBox txtBroj;
        private Label label3;
        private Label label2;
    }
}