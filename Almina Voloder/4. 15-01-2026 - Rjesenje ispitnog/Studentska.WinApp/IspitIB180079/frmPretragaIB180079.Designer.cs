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
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
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
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Location = new Point(510, 35);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
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
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { Student, Knjiga, DatumIznajmljivanja, DatumVracanja, Vracena, Povrat });
            dgvPodaci.Location = new Point(12, 65);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(1176, 358);
            dgvPodaci.TabIndex = 4;
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
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 435);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodajKnjigu);
            Controls.Add(chbVracena);
            Controls.Add(tbPretraga);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "frmPretragaIB180079";
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
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
    }
}