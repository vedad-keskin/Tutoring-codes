namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmPrisustvoIB180079
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
            components = new System.ComponentModel.Container();
            lblNazivProstorije = new Label();
            lblBrojac = new Label();
            cbNastava = new ComboBox();
            lblStudent = new Label();
            label1 = new Label();
            btnDodaj = new Button();
            dgvPrisustva = new DataGridView();
            Nastava = new DataGridViewTextBoxColumn();
            Student = new DataGridViewTextBoxColumn();
            cbStudent = new ComboBox();
            err = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            txtBroj = new TextBox();
            txtInfo = new TextBox();
            btnGenerisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrisustva).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNazivProstorije
            // 
            lblNazivProstorije.AutoSize = true;
            lblNazivProstorije.Font = new Font("Segoe UI", 20F);
            lblNazivProstorije.Location = new Point(12, 9);
            lblNazivProstorije.Name = "lblNazivProstorije";
            lblNazivProstorije.Size = new Size(439, 46);
            lblNazivProstorije.TabIndex = 0;
            lblNazivProstorije.Text = "Naziv prostorije placeholder";
            // 
            // lblBrojac
            // 
            lblBrojac.AutoSize = true;
            lblBrojac.Font = new Font("Segoe UI", 20F);
            lblBrojac.Location = new Point(767, 9);
            lblBrojac.Name = "lblBrojac";
            lblBrojac.Size = new Size(69, 46);
            lblBrojac.TabIndex = 0;
            lblBrojac.Text = "0/0";
            // 
            // cbNastava
            // 
            cbNastava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNastava.FormattingEnabled = true;
            cbNastava.Location = new Point(12, 91);
            cbNastava.Name = "cbNastava";
            cbNastava.Size = new Size(320, 28);
            cbNastava.TabIndex = 6;
            cbNastava.SelectedIndexChanged += cbNastava_SelectedIndexChanged;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(338, 68);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(63, 20);
            lblStudent.TabIndex = 3;
            lblStudent.Text = "Student:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 68);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 4;
            label1.Text = "Nastava:";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(631, 90);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(149, 29);
            btnDodaj.TabIndex = 7;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // dgvPrisustva
            // 
            dgvPrisustva.AllowUserToAddRows = false;
            dgvPrisustva.AllowUserToDeleteRows = false;
            dgvPrisustva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrisustva.Columns.AddRange(new DataGridViewColumn[] { Nastava, Student });
            dgvPrisustva.Location = new Point(12, 125);
            dgvPrisustva.Name = "dgvPrisustva";
            dgvPrisustva.ReadOnly = true;
            dgvPrisustva.RowHeadersWidth = 51;
            dgvPrisustva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrisustva.Size = new Size(843, 204);
            dgvPrisustva.TabIndex = 8;
            // 
            // Nastava
            // 
            Nastava.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nastava.DataPropertyName = "Nastava";
            Nastava.HeaderText = "Predmet, prostorija, vrijeme";
            Nastava.MinimumWidth = 6;
            Nastava.Name = "Nastava";
            Nastava.ReadOnly = true;
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
            // cbStudent
            // 
            cbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent.FormattingEnabled = true;
            cbStudent.Location = new Point(338, 91);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(280, 28);
            cbStudent.TabIndex = 9;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGenerisi);
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Controls.Add(txtBroj);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 344);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 243);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 66);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 0;
            label2.Text = "Info:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 32);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 0;
            label3.Text = "Broj zapisa:";
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(106, 29);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(140, 27);
            txtBroj.TabIndex = 1;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(15, 89);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(809, 148);
            txtInfo.TabIndex = 1;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(265, 28);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(124, 29);
            btnGenerisi.TabIndex = 2;
            btnGenerisi.Text = "Generiši";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // frmPrisustvoIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 599);
            Controls.Add(groupBox1);
            Controls.Add(cbStudent);
            Controls.Add(dgvPrisustva);
            Controls.Add(btnDodaj);
            Controls.Add(cbNastava);
            Controls.Add(lblStudent);
            Controls.Add(label1);
            Controls.Add(lblBrojac);
            Controls.Add(lblNazivProstorije);
            Name = "frmPrisustvoIB180079";
            Text = "Evidencija nastave";
            Load += frmPrisustvoIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrisustva).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNazivProstorije;
        private Label lblBrojac;
        private ComboBox cbDan;
        private ComboBox cbNastava;
        private Label lblStudent;
        private Label label1;
        private Button btnDodaj;
        private DataGridView dgvPrisustva;
        private DataGridViewTextBoxColumn Nastava;
        private DataGridViewTextBoxColumn Student;
        private ComboBox cbStudent;
        private ErrorProvider err;
        private GroupBox groupBox1;
        private Label label2;
        private Button btnGenerisi;
        private TextBox txtInfo;
        private TextBox txtBroj;
        private Label label3;
    }
}