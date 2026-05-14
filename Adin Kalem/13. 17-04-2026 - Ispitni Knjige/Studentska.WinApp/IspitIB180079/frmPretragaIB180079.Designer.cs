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
            btnIznajmljivanja = new Button();
            dgvStudentiKnjige = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
            label1 = new Label();
            cbKnjige = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).BeginInit();
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
            txtPretraga.Size = new Size(433, 27);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Checked = true;
            chbVracena.CheckState = CheckState.Checked;
            chbVracena.Location = new Point(461, 34);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodajKnjigu
            // 
            btnDodajKnjigu.Location = new Point(676, 32);
            btnDodajKnjigu.Name = "btnDodajKnjigu";
            btnDodajKnjigu.Size = new Size(193, 29);
            btnDodajKnjigu.TabIndex = 3;
            btnDodajKnjigu.Text = "Dodaj knjigu";
            btnDodajKnjigu.UseVisualStyleBackColor = true;
            btnDodajKnjigu.Click += btnDodajKnjigu_Click;
            // 
            // btnIznajmljivanja
            // 
            btnIznajmljivanja.Location = new Point(875, 32);
            btnIznajmljivanja.Name = "btnIznajmljivanja";
            btnIznajmljivanja.Size = new Size(193, 29);
            btnIznajmljivanja.TabIndex = 3;
            btnIznajmljivanja.Text = "Iznajmljivanja";
            btnIznajmljivanja.UseVisualStyleBackColor = true;
            btnIznajmljivanja.Click += btnIznajmljivanja_Click;
            // 
            // dgvStudentiKnjige
            // 
            dgvStudentiKnjige.AllowUserToAddRows = false;
            dgvStudentiKnjige.AllowUserToDeleteRows = false;
            dgvStudentiKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiKnjige.Columns.AddRange(new DataGridViewColumn[] { Student, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvStudentiKnjige.Location = new Point(12, 118);
            dgvStudentiKnjige.Name = "dgvStudentiKnjige";
            dgvStudentiKnjige.ReadOnly = true;
            dgvStudentiKnjige.RowHeadersWidth = 51;
            dgvStudentiKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiKnjige.Size = new Size(1051, 291);
            dgvStudentiKnjige.TabIndex = 4;
            dgvStudentiKnjige.CellContentClick += dgvStudentiKnjige_CellContentClick;
            // 
            // Student
            // 
            Student.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Student.DataPropertyName = "Student";
            Student.HeaderText = "(Indeks) Ime i prezime";
            Student.MinimumWidth = 6;
            Student.Name = "Student";
            Student.ReadOnly = true;
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
            DatumVracanja.HeaderText = "Datum vraćanja";
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
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 5;
            label1.Text = "Knjiga:";
            // 
            // cbKnjige
            // 
            cbKnjige.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKnjige.FormattingEnabled = true;
            cbKnjige.Location = new Point(12, 85);
            cbKnjige.Name = "cbKnjige";
            cbKnjige.Size = new Size(433, 28);
            cbKnjige.TabIndex = 6;
            cbKnjige.SelectedIndexChanged += cbKnjige_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(451, 62);
            label2.Name = "label2";
            label2.Size = new Size(174, 20);
            label2.TabIndex = 5;
            label2.Text = "Datum iznajmljivanja od:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(758, 64);
            label3.Name = "label3";
            label3.Size = new Size(30, 20);
            label3.TabIndex = 5;
            label3.Text = "do:";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(452, 86);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(300, 27);
            dtpDatumOd.TabIndex = 7;
            dtpDatumOd.Value = new DateTime(2000, 5, 7, 16, 19, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(758, 86);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(305, 27);
            dtpDatumDo.TabIndex = 7;
            dtpDatumDo.Value = new DateTime(2027, 5, 14, 13, 21, 0, 0);
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 421);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(cbKnjige);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvStudentiKnjige);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodajKnjigu);
            Controls.Add(chbVracena);
            Controls.Add(txtPretraga);
            Controls.Add(lblPretraga);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih podataka: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPretraga;
        private TextBox txtPretraga;
        private CheckBox chbVracena;
        private Button btnDodajKnjigu;
        private Button btnIznajmljivanja;
        private DataGridView dgvStudentiKnjige;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
        private Label label1;
        private ComboBox cbKnjige;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
    }
}