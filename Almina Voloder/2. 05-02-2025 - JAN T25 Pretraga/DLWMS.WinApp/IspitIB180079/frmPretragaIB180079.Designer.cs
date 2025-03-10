﻿namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmPretragaIB180079
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtImePrezime = new TextBox();
            cbSpol = new ComboBox();
            chbAktivan = new CheckBox();
            cbDrzava = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            dgvStudenti = new DataGridView();
            StudentInfo = new DataGridViewTextBoxColumn();
            DrzavaInfo = new DataGridViewTextBoxColumn();
            Grad = new DataGridViewTextBoxColumn();
            Spol = new DataGridViewTextBoxColumn();
            DatumRodjenja = new DataGridViewTextBoxColumn();
            Aktivan = new DataGridViewCheckBoxColumn();
            Razmjene = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime ili prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(295, 9);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 0;
            label2.Text = "Država:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(580, 9);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 0;
            label3.Text = "Spol:";
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(12, 32);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(273, 27);
            txtImePrezime.TabIndex = 1;
            txtImePrezime.TextChanged += txtImePrezime_TextChanged;
            // 
            // cbSpol
            // 
            cbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpol.FormattingEnabled = true;
            cbSpol.Location = new Point(580, 32);
            cbSpol.Name = "cbSpol";
            cbSpol.Size = new Size(277, 28);
            cbSpol.TabIndex = 2;
            cbSpol.SelectedIndexChanged += cbSpol_SelectedIndexChanged;
            // 
            // chbAktivan
            // 
            chbAktivan.AutoSize = true;
            chbAktivan.Checked = true;
            chbAktivan.CheckState = CheckState.Checked;
            chbAktivan.Location = new Point(863, 34);
            chbAktivan.Name = "chbAktivan";
            chbAktivan.Size = new Size(80, 24);
            chbAktivan.TabIndex = 3;
            chbAktivan.Text = "Aktivan";
            chbAktivan.UseVisualStyleBackColor = true;
            chbAktivan.CheckedChanged += chbAktivan_CheckedChanged;
            // 
            // cbDrzava
            // 
            cbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDrzava.FormattingEnabled = true;
            cbDrzava.Location = new Point(295, 32);
            cbDrzava.Name = "cbDrzava";
            cbDrzava.Size = new Size(277, 28);
            cbDrzava.TabIndex = 2;
            cbDrzava.SelectedIndexChanged += cbDrzava_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 62);
            label4.Name = "label4";
            label4.Size = new Size(144, 20);
            label4.TabIndex = 0;
            label4.Text = "Student je rođen od:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(295, 63);
            label5.Name = "label5";
            label5.Size = new Size(30, 20);
            label5.TabIndex = 0;
            label5.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(12, 85);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(273, 27);
            dtpDatumOd.TabIndex = 4;
            dtpDatumOd.Value = new DateTime(2000, 2, 5, 18, 17, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(291, 86);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(273, 27);
            dtpDatumDo.TabIndex = 4;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AllowUserToAddRows = false;
            dgvStudenti.AllowUserToDeleteRows = false;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { StudentInfo, DrzavaInfo, Grad, Spol, DatumRodjenja, Aktivan, Razmjene });
            dgvStudenti.Location = new Point(12, 119);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.ReadOnly = true;
            dgvStudenti.RowHeadersWidth = 51;
            dgvStudenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudenti.Size = new Size(1175, 274);
            dgvStudenti.TabIndex = 5;
            // 
            // StudentInfo
            // 
            StudentInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StudentInfo.DataPropertyName = "StudentInfo";
            StudentInfo.HeaderText = "(Indeks) Ime i prezime";
            StudentInfo.MinimumWidth = 6;
            StudentInfo.Name = "StudentInfo";
            StudentInfo.ReadOnly = true;
            // 
            // DrzavaInfo
            // 
            DrzavaInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DrzavaInfo.DataPropertyName = "DrzavaInfo";
            DrzavaInfo.HeaderText = "Država";
            DrzavaInfo.MinimumWidth = 6;
            DrzavaInfo.Name = "DrzavaInfo";
            DrzavaInfo.ReadOnly = true;
            // 
            // Grad
            // 
            Grad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grad.DataPropertyName = "Grad";
            Grad.HeaderText = "Grad";
            Grad.MinimumWidth = 6;
            Grad.Name = "Grad";
            Grad.ReadOnly = true;
            // 
            // Spol
            // 
            Spol.DataPropertyName = "Spol";
            Spol.HeaderText = "Spol";
            Spol.MinimumWidth = 6;
            Spol.Name = "Spol";
            Spol.ReadOnly = true;
            Spol.Width = 125;
            // 
            // DatumRodjenja
            // 
            DatumRodjenja.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumRodjenja.DataPropertyName = "DatumRodjenja";
            DatumRodjenja.HeaderText = "Datum rođenja";
            DatumRodjenja.MinimumWidth = 6;
            DatumRodjenja.Name = "DatumRodjenja";
            DatumRodjenja.ReadOnly = true;
            // 
            // Aktivan
            // 
            Aktivan.DataPropertyName = "Aktivan";
            Aktivan.HeaderText = "Aktivan";
            Aktivan.MinimumWidth = 6;
            Aktivan.Name = "Aktivan";
            Aktivan.ReadOnly = true;
            Aktivan.Width = 125;
            // 
            // Razmjene
            // 
            Razmjene.HeaderText = "";
            Razmjene.MinimumWidth = 6;
            Razmjene.Name = "Razmjene";
            Razmjene.ReadOnly = true;
            Razmjene.Text = "Razmjena";
            Razmjene.UseColumnTextForButtonValue = true;
            Razmjene.Width = 125;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 405);
            Controls.Add(dgvStudenti);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(chbAktivan);
            Controls.Add(cbSpol);
            Controls.Add(cbDrzava);
            Controls.Add(txtImePrezime);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "frmPretragaIB180079";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtImePrezime;
        private ComboBox cbSpol;
        private CheckBox chbAktivan;
        private ComboBox cbDrzava;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private DataGridView dgvStudenti;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewTextBoxColumn DrzavaInfo;
        private DataGridViewTextBoxColumn Grad;
        private DataGridViewTextBoxColumn Spol;
        private DataGridViewTextBoxColumn DatumRodjenja;
        private DataGridViewCheckBoxColumn Aktivan;
        private DataGridViewButtonColumn Razmjene;
    }
}