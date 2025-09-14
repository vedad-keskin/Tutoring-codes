namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmPretraga2IB180079
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
            cbDrzava = new ComboBox();
            cbSpol = new ComboBox();
            dgvStudenti = new DataGridView();
            StudentInfo = new DataGridViewTextBoxColumn();
            DrzavaInfo = new DataGridViewTextBoxColumn();
            Grad = new DataGridViewTextBoxColumn();
            Spol = new DataGridViewTextBoxColumn();
            Aktivan = new DataGridViewCheckBoxColumn();
            DatumRodjenja = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            chbAktivan = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Država:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 9);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 0;
            label2.Text = "Spol:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 0;
            label3.Text = "Ime ili prezime:";
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(12, 27);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(219, 23);
            txtImePrezime.TabIndex = 1;
            txtImePrezime.TextChanged += txtImePrezime_TextChanged;
            // 
            // cbDrzava
            // 
            cbDrzava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDrzava.FormattingEnabled = true;
            cbDrzava.Location = new Point(240, 27);
            cbDrzava.Name = "cbDrzava";
            cbDrzava.Size = new Size(219, 23);
            cbDrzava.TabIndex = 2;
            cbDrzava.SelectedIndexChanged += cbDrzava_SelectedIndexChanged;
            // 
            // cbSpol
            // 
            cbSpol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpol.FormattingEnabled = true;
            cbSpol.Location = new Point(471, 27);
            cbSpol.Name = "cbSpol";
            cbSpol.Size = new Size(202, 23);
            cbSpol.TabIndex = 2;
            cbSpol.SelectedIndexChanged += cbSpol_SelectedIndexChanged;
            // 
            // dgvStudenti
            // 
            dgvStudenti.AllowUserToAddRows = false;
            dgvStudenti.AllowUserToDeleteRows = false;
            dgvStudenti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudenti.Columns.AddRange(new DataGridViewColumn[] { StudentInfo, DrzavaInfo, Grad, Spol, Aktivan, DatumRodjenja });
            dgvStudenti.Location = new Point(12, 100);
            dgvStudenti.Name = "dgvStudenti";
            dgvStudenti.ReadOnly = true;
            dgvStudenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudenti.Size = new Size(843, 247);
            dgvStudenti.TabIndex = 3;
            // 
            // StudentInfo
            // 
            StudentInfo.DataPropertyName = "StudentInfo";
            StudentInfo.HeaderText = "(Indeks) Ime i prezime";
            StudentInfo.Name = "StudentInfo";
            StudentInfo.ReadOnly = true;
            StudentInfo.Width = 200;
            // 
            // DrzavaInfo
            // 
            DrzavaInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DrzavaInfo.DataPropertyName = "DrzavaInfo";
            DrzavaInfo.HeaderText = "Država";
            DrzavaInfo.Name = "DrzavaInfo";
            DrzavaInfo.ReadOnly = true;
            // 
            // Grad
            // 
            Grad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grad.DataPropertyName = "Grad";
            Grad.HeaderText = "Grad";
            Grad.Name = "Grad";
            Grad.ReadOnly = true;
            // 
            // Spol
            // 
            Spol.DataPropertyName = "Spol";
            Spol.HeaderText = "Spol";
            Spol.Name = "Spol";
            Spol.ReadOnly = true;
            // 
            // Aktivan
            // 
            Aktivan.DataPropertyName = "Aktivan";
            Aktivan.HeaderText = "Aktivan";
            Aktivan.Name = "Aktivan";
            Aktivan.ReadOnly = true;
            // 
            // DatumRodjenja
            // 
            DatumRodjenja.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumRodjenja.DataPropertyName = "DatumRodjenja";
            DatumRodjenja.HeaderText = "Datum rođenja";
            DatumRodjenja.Name = "DatumRodjenja";
            DatumRodjenja.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 53);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 4;
            label4.Text = "Datum rođenja od:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(240, 53);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 4;
            label5.Text = "do:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(468, 53);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 4;
            label6.Text = "Aktivan:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(12, 71);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(219, 23);
            dtpDatumOd.TabIndex = 5;
            dtpDatumOd.Value = new DateTime(2000, 9, 13, 17, 32, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(240, 71);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(219, 23);
            dtpDatumDo.TabIndex = 5;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // chbAktivan
            // 
            chbAktivan.AutoSize = true;
            chbAktivan.Checked = true;
            chbAktivan.CheckState = CheckState.Checked;
            chbAktivan.Location = new Point(471, 73);
            chbAktivan.Name = "chbAktivan";
            chbAktivan.Size = new Size(66, 19);
            chbAktivan.TabIndex = 6;
            chbAktivan.Text = "Aktivan";
            chbAktivan.UseVisualStyleBackColor = true;
            chbAktivan.CheckedChanged += chbAktivan_CheckedChanged;
            // 
            // frmPretraga2IB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 359);
            Controls.Add(chbAktivan);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvStudenti);
            Controls.Add(cbSpol);
            Controls.Add(cbDrzava);
            Controls.Add(txtImePrezime);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretraga2IB180079";
            Text = "Broj prikazanih studenata placeholder";
            Load += frmPretraga2IB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtImePrezime;
        private ComboBox cbDrzava;
        private ComboBox cbSpol;
        private DataGridView dgvStudenti;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewTextBoxColumn DrzavaInfo;
        private DataGridViewTextBoxColumn Grad;
        private DataGridViewTextBoxColumn Spol;
        private DataGridViewCheckBoxColumn Aktivan;
        private DataGridViewTextBoxColumn DatumRodjenja;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private CheckBox chbAktivan;
    }
}