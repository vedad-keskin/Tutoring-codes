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
            txtPretraga = new TextBox();
            chbVracena = new CheckBox();
            btnDodaj = new Button();
            btnIznajmljivanja = new Button();
            dgvStudentiKnjige = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            DatumVracanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            Povrat = new DataGridViewButtonColumn();
            label2 = new Label();
            label3 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(201, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime ili naziv knjige:";
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(12, 32);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(522, 27);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // chbVracena
            // 
            chbVracena.AutoSize = true;
            chbVracena.Location = new Point(540, 34);
            chbVracena.Name = "chbVracena";
            chbVracena.Size = new Size(83, 24);
            chbVracena.TabIndex = 2;
            chbVracena.Text = "Vraćena";
            chbVracena.UseVisualStyleBackColor = true;
            chbVracena.CheckedChanged += chbVracena_CheckedChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(737, 34);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(175, 29);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj knjigu";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIznajmljivanja
            // 
            btnIznajmljivanja.Location = new Point(918, 34);
            btnIznajmljivanja.Name = "btnIznajmljivanja";
            btnIznajmljivanja.Size = new Size(175, 29);
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
            dgvStudentiKnjige.Location = new Point(12, 101);
            dgvStudentiKnjige.Name = "dgvStudentiKnjige";
            dgvStudentiKnjige.ReadOnly = true;
            dgvStudentiKnjige.RowHeadersWidth = 51;
            dgvStudentiKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiKnjige.Size = new Size(1084, 354);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(171, 20);
            label2.TabIndex = 0;
            label2.Text = "Datum iznajmljivanja od";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(443, 73);
            label3.Name = "label3";
            label3.Size = new Size(27, 20);
            label3.TabIndex = 0;
            label3.Text = "do";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(187, 69);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 5;
            dtpDatumOd.Value = new DateTime(2000, 2, 5, 15, 48, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(474, 69);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 5;
            dtpDatumDo.Value = new DateTime(2030, 2, 5, 15, 48, 0, 0);
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 467);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(dgvStudentiKnjige);
            Controls.Add(btnIznajmljivanja);
            Controls.Add(btnDodaj);
            Controls.Add(chbVracena);
            Controls.Add(txtPretraga);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih podataka: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPretraga;
        private CheckBox chbVracena;
        private Button btnDodaj;
        private Button btnIznajmljivanja;
        private DataGridView dgvStudentiKnjige;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewTextBoxColumn DatumVracanja;
        private DataGridViewCheckBoxColumn Vracena;
        private DataGridViewButtonColumn Povrat;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
    }
}