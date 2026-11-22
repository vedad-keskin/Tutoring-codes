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
            lblPretraga = new Label();
            txtPretraga = new TextBox();
            chbVracena = new CheckBox();
            btnDodaj = new Button();
            btnIznajmljivanja = new Button();
            dgvPodaci = new DataGridView();
            StudentInfo = new DataGridViewTextBoxColumn();
            AktivanInfo = new DataGridViewCheckBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
            label1 = new Label();
            cbKnjiga = new ComboBox();
            label2 = new Label();
            cbAktivan = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            SuspendLayout();
            // 
            // lblPretraga
            // 
            lblPretraga.AutoSize = true;
            lblPretraga.Location = new Point(10, 7);
            lblPretraga.Name = "lblPretraga";
            lblPretraga.Size = new Size(208, 15);
            lblPretraga.TabIndex = 0;
            lblPretraga.Text = "Ime i prezime korisnika ili naziv knjige:";
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(10, 24);
            txtPretraga.Margin = new Padding(3, 2, 3, 2);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(347, 23);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Checked = true;
            chbVracena.CheckState = CheckState.Checked;
            chbVracena.Location = new Point(362, 26);
            chbVracena.Margin = new Padding(3, 2, 3, 2);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(68, 19);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(793, 26);
            btnDodaj.Margin = new Padding(3, 2, 3, 2);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(121, 22);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj knjigu";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIznajmljivanja
            // 
            btnIznajmljivanja.Location = new Point(919, 26);
            btnIznajmljivanja.Margin = new Padding(3, 2, 3, 2);
            btnIznajmljivanja.Name = "btnIznajmljivanja";
            btnIznajmljivanja.Size = new Size(121, 22);
            btnIznajmljivanja.TabIndex = 3;
            btnIznajmljivanja.Text = "Iznajmljivanja";
            btnIznajmljivanja.UseVisualStyleBackColor = true;
            // 
            // dgvPodaci
            // 
            dgvPodaci.AllowUserToAddRows = false;
            dgvPodaci.AllowUserToDeleteRows = false;
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { StudentInfo, AktivanInfo, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvPodaci.Location = new Point(12, 100);
            dgvPodaci.Margin = new Padding(3, 2, 3, 2);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(1027, 246);
            dgvPodaci.TabIndex = 4;
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
            // AktivanInfo
            // 
            AktivanInfo.DataPropertyName = "AktivanInfo";
            AktivanInfo.HeaderText = "Aktivan";
            AktivanInfo.Name = "AktivanInfo";
            AktivanInfo.ReadOnly = true;
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
            label1.Location = new Point(10, 54);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Knjiga:";
            // 
            // cbKnjiga
            // 
            cbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKnjiga.FormattingEnabled = true;
            cbKnjiga.Location = new Point(10, 72);
            cbKnjiga.Name = "cbKnjiga";
            cbKnjiga.Size = new Size(225, 23);
            cbKnjiga.TabIndex = 5;
            cbKnjiga.SelectedIndexChanged += cbKnjiga_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 54);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 0;
            label2.Text = "Aktivan:";
            // 
            // cbAktivan
            // 
            cbAktivan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAktivan.FormattingEnabled = true;
            cbAktivan.Items.AddRange(new object[] { "Svi", "Aktivni", "Neaktivni" });
            cbAktivan.Location = new Point(241, 72);
            cbAktivan.Name = "cbAktivan";
            cbAktivan.Size = new Size(216, 23);
            cbAktivan.TabIndex = 6;
            cbAktivan.SelectedIndexChanged += cbAktivan_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(465, 54);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 0;
            label3.Text = "Datum od:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(756, 54);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 0;
            label4.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(463, 72);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(279, 23);
            dtpDatumOd.TabIndex = 7;
            dtpDatumOd.Value = new DateTime(2000, 11, 22, 22, 19, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(756, 72);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(282, 23);
            dtpDatumDo.TabIndex = 7;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1050, 357);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(cbAktivan);
            Controls.Add(cbKnjiga);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodaj);
            Controls.Add(chbVracena);
            Controls.Add(txtPretraga);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPretraga);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih podataka: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPretraga;
        private TextBox txtPretraga;
        private CheckBox chbVracena;
        private Button btnDodaj;
        private Button btnIznajmljivanja;
        private DataGridView dgvPodaci;
        private Label label1;
        private ComboBox cbKnjiga;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewCheckBoxColumn AktivanInfo;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
        private Label label2;
        private ComboBox cbAktivan;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
    }
}