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
            label1 = new Label();
            tbPretraga = new TextBox();
            chbVracena = new CheckBox();
            btnDodajKnjigu = new Button();
            btnIznajmljivanja = new Button();
            dgvPodaci = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            AktivanInfo = new DataGridViewCheckBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
            label2 = new Label();
            cbKnjiga = new ComboBox();
            label3 = new Label();
            cbAktivan = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(263, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime korisnika ili naziv knjige:";
            // 
            // tbPretraga
            // 
            tbPretraga.Location = new Point(12, 32);
            tbPretraga.Name = "tbPretraga";
            tbPretraga.Size = new Size(492, 27);
            tbPretraga.TabIndex = 1;
            tbPretraga.TextChanged += tbPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Checked = true;
            chbVracena.CheckState = CheckState.Checked;
            chbVracena.Location = new Point(510, 35);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodajKnjigu
            // 
            btnDodajKnjigu.Location = new Point(842, 33);
            btnDodajKnjigu.Name = "btnDodajKnjigu";
            btnDodajKnjigu.Size = new Size(170, 29);
            btnDodajKnjigu.TabIndex = 3;
            btnDodajKnjigu.Text = "Dodaj knjigu";
            btnDodajKnjigu.UseVisualStyleBackColor = true;
            // 
            // btnIznajmljivanja
            // 
            btnIznajmljivanja.Location = new Point(1018, 33);
            btnIznajmljivanja.Name = "btnIznajmljivanja";
            btnIznajmljivanja.Size = new Size(170, 29);
            btnIznajmljivanja.TabIndex = 3;
            btnIznajmljivanja.Tag = "";
            btnIznajmljivanja.Text = "Iznajmljivanja";
            btnIznajmljivanja.UseVisualStyleBackColor = true;
            // 
            // dgvPodaci
            // 
            dgvPodaci.AllowUserToAddRows = false;
            dgvPodaci.AllowUserToDeleteRows = false;
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { Student, AktivanInfo, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvPodaci.Location = new Point(6, 127);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(1176, 358);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 0;
            label2.Text = "Knjiga:";
            // 
            // cbKnjiga
            // 
            cbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKnjiga.FormattingEnabled = true;
            cbKnjiga.Location = new Point(12, 85);
            cbKnjiga.Name = "cbKnjiga";
            cbKnjiga.Size = new Size(295, 28);
            cbKnjiga.TabIndex = 5;
            cbKnjiga.SelectedIndexChanged += cbKnjiga_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 62);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 0;
            label3.Text = "Aktivnost studenta:";
            // 
            // cbAktivan
            // 
            cbAktivan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAktivan.FormattingEnabled = true;
            cbAktivan.Items.AddRange(new object[] { "Svi", "Aktivni", "Neaktivni" });
            cbAktivan.Location = new Point(313, 85);
            cbAktivan.Name = "cbAktivan";
            cbAktivan.Size = new Size(295, 28);
            cbAktivan.TabIndex = 5;
            cbAktivan.SelectedIndexChanged += cbAktivan_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(612, 62);
            label4.Name = "label4";
            label4.Size = new Size(174, 20);
            label4.TabIndex = 0;
            label4.Text = "Datum iznajmljivanja od:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(907, 63);
            label5.Name = "label5";
            label5.Size = new Size(30, 20);
            label5.TabIndex = 0;
            label5.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(614, 85);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(275, 27);
            dtpDatumOd.TabIndex = 6;
            dtpDatumOd.Value = new DateTime(2000, 10, 23, 15, 55, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(905, 85);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(277, 27);
            dtpDatumDo.TabIndex = 6;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 497);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(cbAktivan);
            Controls.Add(cbKnjiga);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodajKnjigu);
            Controls.Add(chbVracena);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbPretraga);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih podataka: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbPretraga;
        private CheckBox chbVracena;
        private Button btnDodajKnjigu;
        private Button btnIznajmljivanja;
        private DataGridView dgvPodaci;
        private Label label2;
        private ComboBox cbKnjiga;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewCheckBoxColumn AktivanInfo;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
        private Label label3;
        private ComboBox cbAktivan;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
    }
}