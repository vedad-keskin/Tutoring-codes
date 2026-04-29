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
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Location = new Point(461, 34);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
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
            dgvStudentiKnjige.Location = new Point(12, 65);
            dgvStudentiKnjige.Name = "dgvStudentiKnjige";
            dgvStudentiKnjige.ReadOnly = true;
            dgvStudentiKnjige.RowHeadersWidth = 51;
            dgvStudentiKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiKnjige.Size = new Size(1051, 344);
            dgvStudentiKnjige.TabIndex = 4;
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
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 421);
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
    }
}