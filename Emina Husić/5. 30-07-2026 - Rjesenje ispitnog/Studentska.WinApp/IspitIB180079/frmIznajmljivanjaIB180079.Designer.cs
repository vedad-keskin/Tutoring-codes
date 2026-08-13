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
            dgvStudentiKnjige = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            btnGenerisi = new Button();
            btnPotvrda = new Button();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Student:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 9);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 0;
            label2.Text = "Knjiga:";
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(12, 32);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(408, 28);
            cmbStudent.TabIndex = 1;
            // 
            // cmbKnjiga
            // 
            cmbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKnjiga.FormattingEnabled = true;
            cmbKnjiga.Location = new Point(426, 32);
            cmbKnjiga.Name = "cmbKnjiga";
            cmbKnjiga.Size = new Size(440, 28);
            cmbKnjiga.TabIndex = 1;
            // 
            // btnIznajmi
            // 
            btnIznajmi.Location = new Point(872, 32);
            btnIznajmi.Name = "btnIznajmi";
            btnIznajmi.Size = new Size(116, 29);
            btnIznajmi.TabIndex = 2;
            btnIznajmi.Text = "Iznajmi";
            btnIznajmi.UseVisualStyleBackColor = true;
            btnIznajmi.Click += btnIznajmi_Click;
            // 
            // dgvStudentiKnjige
            // 
            dgvStudentiKnjige.AllowUserToAddRows = false;
            dgvStudentiKnjige.AllowUserToDeleteRows = false;
            dgvStudentiKnjige.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiKnjige.Columns.AddRange(new DataGridViewColumn[] { Student, Knjiga, DatumIznajmljivanja, Vracena });
            dgvStudentiKnjige.Location = new Point(12, 66);
            dgvStudentiKnjige.Name = "dgvStudentiKnjige";
            dgvStudentiKnjige.ReadOnly = true;
            dgvStudentiKnjige.RowHeadersWidth = 51;
            dgvStudentiKnjige.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiKnjige.Size = new Size(976, 255);
            dgvStudentiKnjige.TabIndex = 3;
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
            // Vracena
            // 
            Vracena.DataPropertyName = "Vracena";
            Vracena.HeaderText = "Vracena";
            Vracena.MinimumWidth = 6;
            Vracena.Name = "Vracena";
            Vracena.ReadOnly = true;
            Vracena.Width = 125;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(12, 327);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(289, 29);
            btnGenerisi.TabIndex = 4;
            btnGenerisi.Text = "Generiši iznajmljivanja";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(786, 327);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(202, 29);
            btnPotvrda.TabIndex = 4;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 362);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(976, 233);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator info";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 26);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(964, 201);
            txtInfo.TabIndex = 0;
            // 
            // frmIznajmljivanjaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 607);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrda);
            Controls.Add(btnGenerisi);
            Controls.Add(dgvStudentiKnjige);
            Controls.Add(btnIznajmi);
            Controls.Add(cmbKnjiga);
            Controls.Add(cmbStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmIznajmljivanjaIB180079";
            Text = "Iznajmljivanje knjiga";
            FormClosing += frmIznajmljivanjaIB180079_FormClosing;
            Load += frmIznajmljivanjaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiKnjige).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbStudent;
        private ComboBox cmbKnjiga;
        private Button btnIznajmi;
        private DataGridView dgvStudentiKnjige;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewCheckBoxColumn Vracena;
        private Button btnGenerisi;
        private Button btnPotvrda;
        private GroupBox groupBox1;
        private TextBox txtInfo;
    }
}