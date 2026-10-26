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
            btnDodajKnjigu = new Button();
            btnIznajmljivanje = new Button();
            dgvPodaci = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
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
            lblPretraga.Location = new Point(12, 9);
            lblPretraga.Name = "lblPretraga";
            lblPretraga.Size = new Size(263, 20);
            lblPretraga.TabIndex = 0;
            lblPretraga.Text = "Ime i prezime korisnika ili naziv knjige:";
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(12, 32);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(410, 27);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Checked = true;
            chbVracena.CheckState = CheckState.Checked;
            chbVracena.Location = new Point(428, 34);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodajKnjigu
            // 
            btnDodajKnjigu.Location = new Point(859, 34);
            btnDodajKnjigu.Name = "btnDodajKnjigu";
            btnDodajKnjigu.Size = new Size(154, 29);
            btnDodajKnjigu.TabIndex = 3;
            btnDodajKnjigu.Text = "Dodaj knjigu";
            btnDodajKnjigu.UseVisualStyleBackColor = true;
            // 
            // btnIznajmljivanje
            // 
            btnIznajmljivanje.Location = new Point(1018, 34);
            btnIznajmljivanje.Name = "btnIznajmljivanje";
            btnIznajmljivanje.Size = new Size(154, 29);
            btnIznajmljivanje.TabIndex = 3;
            btnIznajmljivanje.Text = "Iznajmljivanje";
            btnIznajmljivanje.UseVisualStyleBackColor = true;
            // 
            // dgvPodaci
            // 
            dgvPodaci.AllowUserToAddRows = false;
            dgvPodaci.AllowUserToDeleteRows = false;
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { Student, AktivanInfo, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvPodaci.Location = new Point(8, 128);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(1164, 347);
            dgvPodaci.TabIndex = 4;
            dgvPodaci.CellContentClick += dgvPodaci_CellContentClick;
            // 
            // Student
            // 
            Student.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Student.DataPropertyName = "StudentInfo";
            Student.HeaderText = "(Indeks) Ime i prezime";
            Student.MinimumWidth = 6;
            Student.Name = "Student";
            Student.ReadOnly = true;
            // 
            // AktivanInfo
            // 
            AktivanInfo.DataPropertyName = "AktivanInfo";
            AktivanInfo.HeaderText = "Aktivan";
            AktivanInfo.MinimumWidth = 6;
            AktivanInfo.Name = "AktivanInfo";
            AktivanInfo.ReadOnly = true;
            AktivanInfo.Width = 125;
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
            Vracena.Resizable = DataGridViewTriState.True;
            Vracena.SortMode = DataGridViewColumnSortMode.Automatic;
            Vracena.Width = 125;
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
            label1.Location = new Point(12, 71);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Knjiga:";
            // 
            // cbKnjiga
            // 
            cbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKnjiga.FormattingEnabled = true;
            cbKnjiga.Location = new Point(12, 94);
            cbKnjiga.Name = "cbKnjiga";
            cbKnjiga.Size = new Size(244, 28);
            cbKnjiga.TabIndex = 5;
            cbKnjiga.SelectedIndexChanged += cbKnjiga_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 71);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 0;
            label2.Text = "Aktivan:";
            // 
            // cbAktivan
            // 
            cbAktivan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAktivan.FormattingEnabled = true;
            cbAktivan.Items.AddRange(new object[] { "Svi", "Aktivni", "Neaktivni" });
            cbAktivan.Location = new Point(262, 94);
            cbAktivan.Name = "cbAktivan";
            cbAktivan.Size = new Size(249, 28);
            cbAktivan.TabIndex = 6;
            cbAktivan.SelectedIndexChanged += cbAktivan_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(519, 71);
            label3.Name = "label3";
            label3.Size = new Size(174, 20);
            label3.TabIndex = 0;
            label3.Text = "Datum iznajmljivanja od:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(850, 71);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 0;
            label4.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(519, 94);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(322, 27);
            dtpDatumOd.TabIndex = 7;
            dtpDatumOd.Value = new DateTime(2000, 10, 26, 16, 11, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(848, 94);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(322, 27);
            dtpDatumDo.TabIndex = 7;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1179, 487);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(cbAktivan);
            Controls.Add(cbKnjiga);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmljivanje);
            Controls.Add(btnDodajKnjigu);
            Controls.Add(chbVracena);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPretraga);
            Controls.Add(label1);
            Controls.Add(lblPretraga);
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
        private Button btnDodajKnjigu;
        private Button btnIznajmljivanje;
        private DataGridView dgvPodaci;
        private Label label1;
        private ComboBox cbKnjiga;
        private DataGridViewTextBoxColumn Student;
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