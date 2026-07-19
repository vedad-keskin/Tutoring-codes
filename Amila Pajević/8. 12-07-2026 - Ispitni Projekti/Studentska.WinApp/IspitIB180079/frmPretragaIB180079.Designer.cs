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
            label2 = new Label();
            label3 = new Label();
            txtPretraga = new TextBox();
            cmbStatus = new ComboBox();
            cmbStanje = new ComboBox();
            btnNoviProjekat = new Button();
            btnNovaPrijava = new Button();
            btnPrint = new Button();
            dgvStudentiProjekti = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Projekat = new DataGridViewTextBoxColumn();
            RokZavrsetka = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            DatumPrijave = new DataGridViewTextBoxColumn();
            DatumPromjene = new DataGridViewTextBoxColumn();
            Stanje = new DataGridViewTextBoxColumn();
            Arhiviraj = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiProjekti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(277, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime i prezime studenta ili naziv projekta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(516, 9);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Status prijave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(767, 9);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 0;
            label3.Text = "Stanje prijave:";
            // 
            // txtPretraga
            // 
            txtPretraga.Location = new Point(12, 32);
            txtPretraga.Name = "txtPretraga";
            txtPretraga.Size = new Size(494, 27);
            txtPretraga.TabIndex = 1;
            txtPretraga.TextChanged += txtPretraga_TextChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Sve", "PODNESENA", "PRIHVACENA", "ODBIJENA", "ZAVRSENA" });
            cmbStatus.Location = new Point(516, 31);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(241, 28);
            cmbStatus.TabIndex = 2;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // cmbStanje
            // 
            cmbStanje.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStanje.FormattingEnabled = true;
            cmbStanje.Items.AddRange(new object[] { "Sve", "Aktivna", "Arhivirana" });
            cmbStanje.Location = new Point(767, 32);
            cmbStanje.Name = "cmbStanje";
            cmbStanje.Size = new Size(241, 28);
            cmbStanje.TabIndex = 2;
            cmbStanje.SelectedIndexChanged += cmbStanje_SelectedIndexChanged;
            // 
            // btnNoviProjekat
            // 
            btnNoviProjekat.Location = new Point(1178, 32);
            btnNoviProjekat.Name = "btnNoviProjekat";
            btnNoviProjekat.Size = new Size(159, 29);
            btnNoviProjekat.TabIndex = 3;
            btnNoviProjekat.Text = "Novi projekat";
            btnNoviProjekat.UseVisualStyleBackColor = true;
            btnNoviProjekat.Click += btnNoviProjekat_Click;
            // 
            // btnNovaPrijava
            // 
            btnNovaPrijava.Location = new Point(1343, 32);
            btnNovaPrijava.Name = "btnNovaPrijava";
            btnNovaPrijava.Size = new Size(159, 29);
            btnNovaPrijava.TabIndex = 3;
            btnNovaPrijava.Text = "Nova prijava";
            btnNovaPrijava.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1343, 537);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(159, 29);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvStudentiProjekti
            // 
            dgvStudentiProjekti.AllowUserToAddRows = false;
            dgvStudentiProjekti.AllowUserToDeleteRows = false;
            dgvStudentiProjekti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiProjekti.Columns.AddRange(new DataGridViewColumn[] { Student, Projekat, RokZavrsetka, Status, DatumPrijave, DatumPromjene, Stanje, Arhiviraj });
            dgvStudentiProjekti.Location = new Point(12, 65);
            dgvStudentiProjekti.Name = "dgvStudentiProjekti";
            dgvStudentiProjekti.ReadOnly = true;
            dgvStudentiProjekti.RowHeadersWidth = 51;
            dgvStudentiProjekti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiProjekti.Size = new Size(1488, 466);
            dgvStudentiProjekti.TabIndex = 4;
            dgvStudentiProjekti.CellContentClick += dgvStudentiProjekti_CellContentClick;
            // 
            // Student
            // 
            Student.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Student.DataPropertyName = "Student";
            Student.HeaderText = "Student";
            Student.MinimumWidth = 6;
            Student.Name = "Student";
            Student.ReadOnly = true;
            // 
            // Projekat
            // 
            Projekat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Projekat.DataPropertyName = "Projekat";
            Projekat.HeaderText = "Projekat";
            Projekat.MinimumWidth = 6;
            Projekat.Name = "Projekat";
            Projekat.ReadOnly = true;
            // 
            // RokZavrsetka
            // 
            RokZavrsetka.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RokZavrsetka.DataPropertyName = "RokZavrsetkaInfo";
            RokZavrsetka.HeaderText = "Rok završetka";
            RokZavrsetka.MinimumWidth = 6;
            RokZavrsetka.Name = "RokZavrsetka";
            RokZavrsetka.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status prijave";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // DatumPrijave
            // 
            DatumPrijave.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumPrijave.DataPropertyName = "DatumPrijave";
            DatumPrijave.HeaderText = "Prijavljen";
            DatumPrijave.MinimumWidth = 6;
            DatumPrijave.Name = "DatumPrijave";
            DatumPrijave.ReadOnly = true;
            // 
            // DatumPromjene
            // 
            DatumPromjene.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DatumPromjene.DataPropertyName = "DatumPromjene";
            DatumPromjene.HeaderText = "Promjena";
            DatumPromjene.MinimumWidth = 6;
            DatumPromjene.Name = "DatumPromjene";
            DatumPromjene.ReadOnly = true;
            // 
            // Stanje
            // 
            Stanje.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stanje.DataPropertyName = "ArhiviranoInfo";
            Stanje.HeaderText = "Stanje prijave";
            Stanje.MinimumWidth = 6;
            Stanje.Name = "Stanje";
            Stanje.ReadOnly = true;
            // 
            // Arhiviraj
            // 
            Arhiviraj.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Arhiviraj.HeaderText = "";
            Arhiviraj.MinimumWidth = 6;
            Arhiviraj.Name = "Arhiviraj";
            Arhiviraj.ReadOnly = true;
            Arhiviraj.Text = "Arhiviraj";
            Arhiviraj.UseColumnTextForButtonValue = true;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1512, 578);
            Controls.Add(dgvStudentiProjekti);
            Controls.Add(btnPrint);
            Controls.Add(btnNovaPrijava);
            Controls.Add(btnNoviProjekat);
            Controls.Add(cmbStanje);
            Controls.Add(cmbStatus);
            Controls.Add(txtPretraga);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "Pretraga prijava na projekte";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiProjekti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPretraga;
        private ComboBox cmbStatus;
        private ComboBox cmbStanje;
        private Button btnNoviProjekat;
        private Button btnNovaPrijava;
        private Button btnPrint;
        private DataGridView dgvStudentiProjekti;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Projekat;
        private DataGridViewTextBoxColumn RokZavrsetka;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn DatumPrijave;
        private DataGridViewTextBoxColumn DatumPromjene;
        private DataGridViewTextBoxColumn Stanje;
        private DataGridViewButtonColumn Arhiviraj;
    }
}