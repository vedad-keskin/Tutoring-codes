namespace Studentska.WinApp.IspitIB180079
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
            lblImePrezime = new Label();
            txtPretraga = new TextBox();
            chbVracena = new CheckBox();
            btnDodaj = new Button();
            btnIznajmljivanja = new Button();
            dgvPodaci = new DataGridView();
            StudentInfo = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
            label1 = new Label();
            cmbKnjige = new ComboBox();
            label2 = new Label();
            cmbVracena = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            SuspendLayout();
            // 
            // lblImePrezime
            // 
            lblImePrezime.AutoSize = true;
            lblImePrezime.Location = new Point(12, 76);
            lblImePrezime.Name = "lblImePrezime";
            lblImePrezime.Size = new Size(54, 20);
            lblImePrezime.TabIndex = 0;
            lblImePrezime.Text = "Knjiga:";
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(12, 42);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(394, 27);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Checked = true;
            chbVracena.CheckState = CheckState.Checked;
            chbVracena.Location = new Point(412, 42);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(902, 42);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(149, 29);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj knjigu";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIznajmljivanja
            // 
            btnIznajmljivanja.Location = new Point(1057, 42);
            btnIznajmljivanja.Name = "btnIznajmljivanja";
            btnIznajmljivanja.Size = new Size(149, 29);
            btnIznajmljivanja.TabIndex = 3;
            btnIznajmljivanja.Text = "Iznajmljivanja";
            btnIznajmljivanja.UseVisualStyleBackColor = true;
            // 
            // dgvPodaci
            // 
            dgvPodaci.AllowUserToAddRows = false;
            dgvPodaci.AllowUserToDeleteRows = false;
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { StudentInfo, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvPodaci.Location = new Point(12, 140);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(1193, 291);
            dgvPodaci.TabIndex = 4;
            dgvPodaci.CellContentClick += dgvPodaci_CellContentClick;
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
            // Knjiga
            // 
            Knjiga.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Knjiga.DataPropertyName = "Knjiga";
            Knjiga.HeaderText = "Knjiga";
            Knjiga.MinimumWidth = 6;
            Knjiga.Name = "Knjiga";
            Knjiga.ReadOnly = true;
            // 
            // DatumIznajmljivanja
            // 
            DatumIznajmljivanja.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumIznajmljivanja.DataPropertyName = "DatumIznajmljivanja";
            DatumIznajmljivanja.HeaderText = "Datum iznajmljivanja";
            DatumIznajmljivanja.MinimumWidth = 6;
            DatumIznajmljivanja.Name = "DatumIznajmljivanja";
            DatumIznajmljivanja.ReadOnly = true;
            // 
            // DatumVracanja
            // 
            DatumVracanja.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumVracanja.DataPropertyName = "DatumVracanja";
            DatumVracanja.HeaderText = "Datum vracanja";
            DatumVracanja.MinimumWidth = 6;
            DatumVracanja.Name = "DatumVracanja";
            DatumVracanja.ReadOnly = true;
            // 
            // Vracena
            // 
            Vracena.DataPropertyName = "Vracena";
            Vracena.HeaderText = "Vracena";
            Vracena.MinimumWidth = 6;
            Vracena.Name = "Vracena";
            Vracena.ReadOnly = true;
            Vracena.Width = 75;
            // 
            // Povrat
            // 
            Povrat.HeaderText = "";
            Povrat.MinimumWidth = 6;
            Povrat.Name = "Povrat";
            Povrat.ReadOnly = true;
            Povrat.Text = "Povrat";
            Povrat.UseColumnTextForButtonValue = true;
            Povrat.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(263, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime korisnika ili naziv knjige:";
            // 
            // cmbKnjige
            // 
            cmbKnjige.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKnjige.FormattingEnabled = true;
            cmbKnjige.Location = new Point(12, 99);
            cmbKnjige.Name = "cmbKnjige";
            cmbKnjige.Size = new Size(394, 28);
            cmbKnjige.TabIndex = 5;
            cmbKnjige.SelectedIndexChanged += cmbKnjige_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 76);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 0;
            label2.Text = "Vracena:";
            // 
            // cmbVracena
            // 
            cmbVracena.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVracena.FormattingEnabled = true;
            cmbVracena.Items.AddRange(new object[] { "VRACENE", "NISU VRACENE" });
            cmbVracena.Location = new Point(412, 99);
            cmbVracena.Name = "cmbVracena";
            cmbVracena.Size = new Size(232, 28);
            cmbVracena.TabIndex = 5;
            cmbVracena.SelectedIndexChanged += cmbKnjige_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(648, 76);
            label3.Name = "label3";
            label3.Size = new Size(174, 20);
            label3.TabIndex = 0;
            label3.Text = "Datum iznajmljivanja od:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(923, 77);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 0;
            label4.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(650, 100);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(267, 27);
            dtpDatumOd.TabIndex = 6;
            dtpDatumOd.Value = new DateTime(2000, 10, 15, 13, 12, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(923, 100);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(267, 27);
            dtpDatumDo.TabIndex = 6;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 438);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(cmbVracena);
            Controls.Add(cmbKnjige);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodaj);
            Controls.Add(chbVracena);
            Controls.Add(txtPretraga);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblImePrezime);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih podataka: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImePrezime;
        private TextBox txtPretraga;
        private CheckBox chbVracena;
        private Button btnDodaj;
        private Button btnIznajmljivanja;
        private DataGridView dgvPodaci;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
        private Label label1;
        private ComboBox cmbKnjige;
        private Label label2;
        private ComboBox cmbVracena;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
    }
}