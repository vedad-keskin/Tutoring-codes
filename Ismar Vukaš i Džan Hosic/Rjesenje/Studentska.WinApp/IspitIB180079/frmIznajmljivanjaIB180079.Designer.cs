namespace Studentska.WinApp.IspitIB180079
{
    partial class frmIznajmljivanjaIB180079
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
            cmbStudent = new ComboBox();
            cmbKnjiga = new ComboBox();
            btnIznajmi = new Button();
            dgvPodaci = new DataGridView();
            StudentInfo = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(397, 9);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Knjiga:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 0;
            label2.Text = "Student:";
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(12, 32);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(365, 28);
            cmbStudent.TabIndex = 1;
            // 
            // cmbKnjiga
            // 
            cmbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKnjiga.FormattingEnabled = true;
            cmbKnjiga.Location = new Point(397, 32);
            cmbKnjiga.Name = "cmbKnjiga";
            cmbKnjiga.Size = new Size(365, 28);
            cmbKnjiga.TabIndex = 1;
            // 
            // btnIznajmi
            // 
            btnIznajmi.Location = new Point(778, 32);
            btnIznajmi.Name = "btnIznajmi";
            btnIznajmi.Size = new Size(172, 29);
            btnIznajmi.TabIndex = 2;
            btnIznajmi.Text = "Iznajmi";
            btnIznajmi.UseVisualStyleBackColor = true;
            btnIznajmi.Click += btnIznajmi_Click;
            // 
            // dgvPodaci
            // 
            dgvPodaci.AllowUserToAddRows = false;
            dgvPodaci.AllowUserToDeleteRows = false;
            dgvPodaci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { StudentInfo, Knjiga, DatumIznajmljivanja, Vracena });
            dgvPodaci.Location = new Point(12, 71);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(938, 291);
            dgvPodaci.TabIndex = 5;
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
            // Vracena
            // 
            Vracena.DataPropertyName = "Vracena";
            Vracena.HeaderText = "Vracena";
            Vracena.MinimumWidth = 6;
            Vracena.Name = "Vracena";
            Vracena.ReadOnly = true;
            Vracena.Width = 75;
            // 
            // frmIznajmljivanjaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 374);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmi);
            Controls.Add(cmbKnjiga);
            Controls.Add(cmbStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmIznajmljivanjaIB180079";
            Text = "Iznajmljivanja knjiga";
            Load += frmIznajmljivanjaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbStudent;
        private ComboBox cmbKnjiga;
        private Button btnIznajmi;
        private DataGridView dgvPodaci;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewCheckBoxColumn Vracena;
    }
}