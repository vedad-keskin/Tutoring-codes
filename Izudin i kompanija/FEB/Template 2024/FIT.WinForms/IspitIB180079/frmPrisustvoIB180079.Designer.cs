namespace FIT.WinForms.IspitIB180079
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
            lblPrebrojavanje = new Label();
            label1 = new Label();
            label2 = new Label();
            cbNastava = new ComboBox();
            cbStudent = new ComboBox();
            btnDodaj = new Button();
            dgvPrisustva = new DataGridView();
            Nastava = new DataGridViewTextBoxColumn();
            Student = new DataGridViewTextBoxColumn();
            err = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            btnGenerisi = new Button();
            txtBroj = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPrisustva).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNazivProstorije
            // 
            lblNazivProstorije.Font = new Font("Segoe UI", 20F);
            lblNazivProstorije.Location = new Point(12, 9);
            lblNazivProstorije.Name = "lblNazivProstorije";
            lblNazivProstorije.Size = new Size(672, 52);
            lblNazivProstorije.TabIndex = 0;
            lblNazivProstorije.Text = "Naziv prostorije placeholder";
            // 
            // lblPrebrojavanje
            // 
            lblPrebrojavanje.Font = new Font("Segoe UI", 20F);
            lblPrebrojavanje.Location = new Point(724, 9);
            lblPrebrojavanje.Name = "lblPrebrojavanje";
            lblPrebrojavanje.Size = new Size(97, 52);
            lblPrebrojavanje.TabIndex = 0;
            lblPrebrojavanje.Text = "?/?";
            lblPrebrojavanje.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 1;
            label1.Text = "Nastava:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(355, 61);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 1;
            label2.Text = "Student:";
            // 
            // cbNastava
            // 
            cbNastava.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNastava.FormattingEnabled = true;
            cbNastava.Location = new Point(12, 84);
            cbNastava.Name = "cbNastava";
            cbNastava.Size = new Size(325, 28);
            cbNastava.TabIndex = 2;
            cbNastava.SelectedIndexChanged += cbNastava_SelectedIndexChanged;
            // 
            // cbStudent
            // 
            cbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStudent.FormattingEnabled = true;
            cbStudent.Location = new Point(355, 84);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(325, 28);
            cbStudent.TabIndex = 2;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(697, 83);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(124, 29);
            btnDodaj.TabIndex = 3;
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
            dgvPrisustva.Location = new Point(12, 118);
            dgvPrisustva.Name = "dgvPrisustva";
            dgvPrisustva.ReadOnly = true;
            dgvPrisustva.RowHeadersWidth = 51;
            dgvPrisustva.RowTemplate.Height = 29;
            dgvPrisustva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrisustva.Size = new Size(809, 188);
            dgvPrisustva.TabIndex = 4;
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
            // err
            // 
            err.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Controls.Add(btnGenerisi);
            groupBox1.Controls.Add(txtBroj);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 325);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(807, 214);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator";
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(237, 35);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(118, 29);
            btnGenerisi.TabIndex = 2;
            btnGenerisi.Text = "Generiši";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(106, 36);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(125, 27);
            txtBroj.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 38);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 0;
            label3.Text = "Broj zapisa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 71);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 0;
            label4.Text = "Info:";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(15, 94);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(774, 114);
            txtInfo.TabIndex = 3;
            // 
            // frmPrisustvoIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 551);
            Controls.Add(groupBox1);
            Controls.Add(dgvPrisustva);
            Controls.Add(btnDodaj);
            Controls.Add(cbStudent);
            Controls.Add(cbNastava);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNazivProstorije);
            Controls.Add(lblPrebrojavanje);
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
        private Label lblPrebrojavanje;
        private Label label1;
        private Label label2;
        private ComboBox cbNastava;
        private ComboBox cbStudent;
        private Button btnDodaj;
        private DataGridView dgvPrisustva;
        private DataGridViewTextBoxColumn Nastava;
        private DataGridViewTextBoxColumn Student;
        private ErrorProvider err;
        private GroupBox groupBox1;
        private Button btnGenerisi;
        private TextBox txtBroj;
        private Label label3;
        private TextBox txtInfo;
        private Label label4;
    }
}