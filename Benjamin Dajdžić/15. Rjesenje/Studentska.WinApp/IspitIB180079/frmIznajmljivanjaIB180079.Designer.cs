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
            cbStudent = new ComboBox();
            cbKnjiga = new ComboBox();
            btnIznajmi = new Button();
            dgvPodaci = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Knjiga = new DataGridViewTextBoxColumn();
            DatumIznajmljivanja = new DataGridViewTextBoxColumn();
            Vracena = new DataGridViewCheckBoxColumn();
            btnGenerisi = new Button();
            btnPotvrda = new Button();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Student:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(354, 7);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 0;
            label2.Text = "Knjiga:";
            // 
            // cbStudent
            // 
            cbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent.FormattingEnabled = true;
            cbStudent.Location = new Point(10, 24);
            cbStudent.Margin = new Padding(3, 2, 3, 2);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(335, 23);
            cbStudent.TabIndex = 1;
            // 
            // cbKnjiga
            // 
            cbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKnjiga.FormattingEnabled = true;
            cbKnjiga.Location = new Point(354, 24);
            cbKnjiga.Margin = new Padding(3, 2, 3, 2);
            cbKnjiga.Name = "cbKnjiga";
            cbKnjiga.Size = new Size(335, 23);
            cbKnjiga.TabIndex = 1;
            // 
            // btnIznajmi
            // 
            btnIznajmi.Location = new Point(693, 23);
            btnIznajmi.Margin = new Padding(3, 2, 3, 2);
            btnIznajmi.Name = "btnIznajmi";
            btnIznajmi.Size = new Size(171, 22);
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
            dgvPodaci.Columns.AddRange(new DataGridViewColumn[] { Student, Knjiga, DatumIznajmljivanja, Vracena });
            dgvPodaci.Location = new Point(10, 50);
            dgvPodaci.Margin = new Padding(3, 2, 3, 2);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(853, 260);
            dgvPodaci.TabIndex = 5;
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
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(10, 315);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(152, 23);
            btnGenerisi.TabIndex = 6;
            btnGenerisi.Text = "Generiši iznajmljivanja";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(712, 315);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(152, 23);
            btnPotvrda.TabIndex = 6;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 344);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(852, 186);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator info";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 22);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(840, 149);
            txtInfo.TabIndex = 0;
            // 
            // frmIznajmljivanjaIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 542);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrda);
            Controls.Add(btnGenerisi);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmi);
            Controls.Add(cbKnjiga);
            Controls.Add(cbStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmIznajmljivanjaIB180079";
            Text = "Iznajmljivanje knjiga";
            FormClosed += frmIznajmljivanjaIB180079_FormClosed;
            Load += frmIznajmljivanjaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbStudent;
        private ComboBox cbKnjiga;
        private Button btnIznajmi;
        private DataGridView dgvPodaci;
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