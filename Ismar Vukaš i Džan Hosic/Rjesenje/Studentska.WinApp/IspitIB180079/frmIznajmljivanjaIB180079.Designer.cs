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
            btnGenerisi = new Button();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPodaci).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(347, 7);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Knjiga:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 7);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 0;
            label2.Text = "Student:";
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(10, 24);
            cmbStudent.Margin = new Padding(3, 2, 3, 2);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(320, 23);
            cmbStudent.TabIndex = 1;
            // 
            // cmbKnjiga
            // 
            cmbKnjiga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKnjiga.FormattingEnabled = true;
            cmbKnjiga.Location = new Point(347, 24);
            cmbKnjiga.Margin = new Padding(3, 2, 3, 2);
            cmbKnjiga.Name = "cmbKnjiga";
            cmbKnjiga.Size = new Size(320, 23);
            cmbKnjiga.TabIndex = 1;
            // 
            // btnIznajmi
            // 
            btnIznajmi.Location = new Point(681, 24);
            btnIznajmi.Margin = new Padding(3, 2, 3, 2);
            btnIznajmi.Name = "btnIznajmi";
            btnIznajmi.Size = new Size(150, 22);
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
            dgvPodaci.Location = new Point(10, 53);
            dgvPodaci.Margin = new Padding(3, 2, 3, 2);
            dgvPodaci.Name = "dgvPodaci";
            dgvPodaci.ReadOnly = true;
            dgvPodaci.RowHeadersWidth = 51;
            dgvPodaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPodaci.Size = new Size(821, 218);
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
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(10, 276);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(171, 23);
            btnGenerisi.TabIndex = 6;
            btnGenerisi.Text = "Generiši iznajmljivanja";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(819, 187);
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
            txtInfo.Size = new Size(807, 159);
            txtInfo.TabIndex = 0;
            // 
            // frmIznajmljivanjaIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 504);
            Controls.Add(groupBox1);
            Controls.Add(btnGenerisi);
            Controls.Add(dgvPodaci);
            Controls.Add(btnIznajmi);
            Controls.Add(cmbKnjiga);
            Controls.Add(cmbStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmIznajmljivanjaIB180079";
            Text = "Iznajmljivanja knjiga";
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
        private ComboBox cmbStudent;
        private ComboBox cmbKnjiga;
        private Button btnIznajmi;
        private DataGridView dgvPodaci;
        private DataGridViewTextBoxColumn StudentInfo;
        private DataGridViewTextBoxColumn Knjiga;
        private DataGridViewTextBoxColumn DatumIznajmljivanja;
        private DataGridViewCheckBoxColumn Vracena;
        private Button btnGenerisi;
        private GroupBox groupBox1;
        private TextBox txtInfo;
    }
}