﻿namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmRazmjeneIB180079
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
            label5 = new Label();
            cbDrzava = new ComboBox();
            cbUniverzitet = new ComboBox();
            txtECTS = new TextBox();
            dtpDatumPocetak = new DateTimePicker();
            dtpDatumKraj = new DateTimePicker();
            btnSacuvaj = new Button();
            dgvRazmjene = new DataGridView();
            Univerzitet = new DataGridViewTextBoxColumn();
            DatumPocetak = new DataGridViewTextBoxColumn();
            DatumKraj = new DataGridViewTextBoxColumn();
            ECTS = new DataGridViewTextBoxColumn();
            Okoncana = new DataGridViewCheckBoxColumn();
            Obrisi = new DataGridViewButtonColumn();
            err = new ErrorProvider(components);
            btnPotvrda = new Button();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            btnGenerisi = new Button();
            txtBroj = new TextBox();
            txtECTSM = new TextBox();
            cbUniverzitetM = new ComboBox();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Država:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 0;
            label2.Text = "Univerzitet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(443, 9);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 0;
            label3.Text = "Broj kredita:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(579, 9);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 0;
            label4.Text = "Početak razmjene:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(829, 9);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 0;
            label5.Text = "Kraj razmjene:";
            // 
            // cbDrzava
            // 
            cbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDrzava.FormattingEnabled = true;
            cbDrzava.Location = new Point(12, 32);
            cbDrzava.Name = "cbDrzava";
            cbDrzava.Size = new Size(208, 28);
            cbDrzava.TabIndex = 1;
            cbDrzava.SelectedIndexChanged += cbDrzava_SelectedIndexChanged;
            // 
            // cbUniverzitet
            // 
            cbUniverzitet.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUniverzitet.FormattingEnabled = true;
            cbUniverzitet.Location = new Point(226, 32);
            cbUniverzitet.Name = "cbUniverzitet";
            cbUniverzitet.Size = new Size(208, 28);
            cbUniverzitet.TabIndex = 1;
            // 
            // txtECTS
            // 
            txtECTS.Location = new Point(443, 33);
            txtECTS.Name = "txtECTS";
            txtECTS.Size = new Size(125, 27);
            txtECTS.TabIndex = 2;
            // 
            // dtpDatumPocetak
            // 
            dtpDatumPocetak.Location = new Point(579, 33);
            dtpDatumPocetak.Name = "dtpDatumPocetak";
            dtpDatumPocetak.Size = new Size(250, 27);
            dtpDatumPocetak.TabIndex = 3;
            // 
            // dtpDatumKraj
            // 
            dtpDatumKraj.Location = new Point(835, 33);
            dtpDatumKraj.Name = "dtpDatumKraj";
            dtpDatumKraj.Size = new Size(250, 27);
            dtpDatumKraj.TabIndex = 3;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(1091, 31);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(94, 29);
            btnSacuvaj.TabIndex = 4;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // dgvRazmjene
            // 
            dgvRazmjene.AllowUserToAddRows = false;
            dgvRazmjene.AllowUserToDeleteRows = false;
            dgvRazmjene.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRazmjene.Columns.AddRange(new DataGridViewColumn[] { Univerzitet, DatumPocetak, DatumKraj, ECTS, Okoncana, Obrisi });
            dgvRazmjene.Location = new Point(12, 66);
            dgvRazmjene.Name = "dgvRazmjene";
            dgvRazmjene.ReadOnly = true;
            dgvRazmjene.RowHeadersWidth = 51;
            dgvRazmjene.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRazmjene.Size = new Size(1173, 302);
            dgvRazmjene.TabIndex = 5;
            dgvRazmjene.CellContentClick += dgvRazmjene_CellContentClick;
            // 
            // Univerzitet
            // 
            Univerzitet.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Univerzitet.DataPropertyName = "Univerzitet";
            Univerzitet.HeaderText = "Univerzitet";
            Univerzitet.MinimumWidth = 6;
            Univerzitet.Name = "Univerzitet";
            Univerzitet.ReadOnly = true;
            // 
            // DatumPocetak
            // 
            DatumPocetak.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumPocetak.DataPropertyName = "DatumPocetak";
            DatumPocetak.HeaderText = "Početak";
            DatumPocetak.MinimumWidth = 6;
            DatumPocetak.Name = "DatumPocetak";
            DatumPocetak.ReadOnly = true;
            // 
            // DatumKraj
            // 
            DatumKraj.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumKraj.DataPropertyName = "DatumKraj";
            DatumKraj.HeaderText = "Kraj";
            DatumKraj.MinimumWidth = 6;
            DatumKraj.Name = "DatumKraj";
            DatumKraj.ReadOnly = true;
            // 
            // ECTS
            // 
            ECTS.DataPropertyName = "ECTS";
            ECTS.HeaderText = "ECTS";
            ECTS.MinimumWidth = 6;
            ECTS.Name = "ECTS";
            ECTS.ReadOnly = true;
            ECTS.Width = 125;
            // 
            // Okoncana
            // 
            Okoncana.DataPropertyName = "Okoncana";
            Okoncana.HeaderText = "Okončana";
            Okoncana.MinimumWidth = 6;
            Okoncana.Name = "Okoncana";
            Okoncana.ReadOnly = true;
            Okoncana.Width = 125;
            // 
            // Obrisi
            // 
            Obrisi.HeaderText = "";
            Obrisi.MinimumWidth = 6;
            Obrisi.Name = "Obrisi";
            Obrisi.ReadOnly = true;
            Obrisi.Text = "Obriši";
            Obrisi.UseColumnTextForButtonValue = true;
            Obrisi.Width = 125;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(1048, 383);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(137, 29);
            btnPotvrda.TabIndex = 6;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Controls.Add(btnGenerisi);
            groupBox1.Controls.Add(txtBroj);
            groupBox1.Controls.Add(txtECTSM);
            groupBox1.Controls.Add(cbUniverzitetM);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(12, 418);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1169, 202);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator razmjena";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(309, 57);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(843, 122);
            txtInfo.TabIndex = 4;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(20, 150);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(280, 29);
            btnGenerisi.TabIndex = 3;
            btnGenerisi.Text = "Generiši razmjene >>>>>";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(20, 117);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(137, 27);
            txtBroj.TabIndex = 2;
            // 
            // txtECTSM
            // 
            txtECTSM.Location = new Point(168, 117);
            txtECTSM.Name = "txtECTSM";
            txtECTSM.Size = new Size(132, 27);
            txtECTSM.TabIndex = 2;
            // 
            // cbUniverzitetM
            // 
            cbUniverzitetM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUniverzitetM.FormattingEnabled = true;
            cbUniverzitetM.Location = new Point(20, 57);
            cbUniverzitetM.Name = "cbUniverzitetM";
            cbUniverzitetM.Size = new Size(280, 28);
            cbUniverzitetM.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(309, 34);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 0;
            label9.Text = "Info:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 34);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 0;
            label7.Text = "Univerzitet:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(168, 94);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 0;
            label8.Text = "Broj kredita:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 94);
            label6.Name = "label6";
            label6.Size = new Size(104, 20);
            label6.TabIndex = 0;
            label6.Text = "Broj razmjena:";
            // 
            // frmRazmjeneIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 632);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrda);
            Controls.Add(dgvRazmjene);
            Controls.Add(btnSacuvaj);
            Controls.Add(dtpDatumKraj);
            Controls.Add(dtpDatumPocetak);
            Controls.Add(txtECTS);
            Controls.Add(cbUniverzitet);
            Controls.Add(cbDrzava);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmRazmjeneIB180079";
            Text = "Razmjene studenta placeholder";
            Load += frmRazmjeneIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRazmjene).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cbDrzava;
        private ComboBox cbUniverzitet;
        private TextBox txtECTS;
        private DateTimePicker dtpDatumPocetak;
        private DateTimePicker dtpDatumKraj;
        private Button btnSacuvaj;
        private DataGridView dgvRazmjene;
        private DataGridViewTextBoxColumn Univerzitet;
        private DataGridViewTextBoxColumn DatumPocetak;
        private DataGridViewTextBoxColumn DatumKraj;
        private DataGridViewTextBoxColumn ECTS;
        private DataGridViewCheckBoxColumn Okoncana;
        private DataGridViewButtonColumn Obrisi;
        private ErrorProvider err;
        private GroupBox groupBox1;
        private TextBox txtInfo;
        private Button btnGenerisi;
        private TextBox txtBroj;
        private TextBox txtECTSM;
        private ComboBox cbUniverzitetM;
        private Label label9;
        private Label label7;
        private Label label8;
        private Label label6;
        private Button btnPotvrda;
    }
}