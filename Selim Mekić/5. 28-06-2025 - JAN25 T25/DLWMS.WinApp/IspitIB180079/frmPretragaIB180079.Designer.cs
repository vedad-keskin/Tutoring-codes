namespace DLWMS.WinApp.IspitIB180079
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
            cbGodina = new ComboBox();
            cbStipendija = new ComboBox();
            dgvStudentStipendije = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            GodinaInfo = new DataGridViewTextBoxColumn();
            StipendijaInfo = new DataGridViewTextBoxColumn();
            IznosInfo = new DataGridViewTextBoxColumn();
            UkupnoInfo = new DataGridViewTextBoxColumn();
            Ukloni = new DataGridViewButtonColumn();
            btnStipendije = new Button();
            btnDodajStipendiju = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentStipendije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 19);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // cbGodina
            // 
            cbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGodina.FormattingEnabled = true;
            cbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cbGodina.Location = new Point(12, 42);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(201, 28);
            cbGodina.TabIndex = 1;
            cbGodina.SelectedIndexChanged += cbGodina_SelectedIndexChanged;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(219, 42);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(201, 28);
            cbStipendija.TabIndex = 1;
            cbStipendija.SelectedIndexChanged += cbStipendija_SelectedIndexChanged;
            // 
            // dgvStudentStipendije
            // 
            dgvStudentStipendije.AllowUserToAddRows = false;
            dgvStudentStipendije.AllowUserToDeleteRows = false;
            dgvStudentStipendije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentStipendije.Columns.AddRange(new DataGridViewColumn[] { Student, GodinaInfo, StipendijaInfo, IznosInfo, UkupnoInfo, Ukloni });
            dgvStudentStipendije.Location = new Point(12, 76);
            dgvStudentStipendije.Name = "dgvStudentStipendije";
            dgvStudentStipendije.ReadOnly = true;
            dgvStudentStipendije.RowHeadersWidth = 51;
            dgvStudentStipendije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentStipendije.Size = new Size(1047, 290);
            dgvStudentStipendije.TabIndex = 2;
            dgvStudentStipendije.CellContentClick += dgvStudentStipendije_CellContentClick;
            dgvStudentStipendije.CellDoubleClick += dgvStudentStipendije_CellDoubleClick;
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
            // GodinaInfo
            // 
            GodinaInfo.DataPropertyName = "GodinaInfo";
            GodinaInfo.HeaderText = "Godina";
            GodinaInfo.MinimumWidth = 6;
            GodinaInfo.Name = "GodinaInfo";
            GodinaInfo.ReadOnly = true;
            GodinaInfo.Width = 125;
            // 
            // StipendijaInfo
            // 
            StipendijaInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StipendijaInfo.DataPropertyName = "StipendijaInfo";
            StipendijaInfo.HeaderText = "Stipendija";
            StipendijaInfo.MinimumWidth = 6;
            StipendijaInfo.Name = "StipendijaInfo";
            StipendijaInfo.ReadOnly = true;
            // 
            // IznosInfo
            // 
            IznosInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            IznosInfo.DataPropertyName = "IznosInfo";
            IznosInfo.HeaderText = "Mjesecni iznos";
            IznosInfo.MinimumWidth = 6;
            IznosInfo.Name = "IznosInfo";
            IznosInfo.ReadOnly = true;
            // 
            // UkupnoInfo
            // 
            UkupnoInfo.DataPropertyName = "UkupnoInfo";
            UkupnoInfo.HeaderText = "Ukupno";
            UkupnoInfo.MinimumWidth = 6;
            UkupnoInfo.Name = "UkupnoInfo";
            UkupnoInfo.ReadOnly = true;
            UkupnoInfo.Width = 125;
            // 
            // Ukloni
            // 
            Ukloni.HeaderText = "Ukloni";
            Ukloni.MinimumWidth = 6;
            Ukloni.Name = "Ukloni";
            Ukloni.ReadOnly = true;
            Ukloni.Text = "Ukloni";
            Ukloni.UseColumnTextForButtonValue = true;
            Ukloni.Width = 125;
            // 
            // btnStipendije
            // 
            btnStipendije.Location = new Point(849, 42);
            btnStipendije.Name = "btnStipendije";
            btnStipendije.Size = new Size(204, 29);
            btnStipendije.TabIndex = 3;
            btnStipendije.Text = "Stipendije po godinama";
            btnStipendije.UseVisualStyleBackColor = true;
            btnStipendije.Click += btnStipendije_Click;
            // 
            // btnDodajStipendiju
            // 
            btnDodajStipendiju.Location = new Point(702, 42);
            btnDodajStipendiju.Name = "btnDodajStipendiju";
            btnDodajStipendiju.Size = new Size(141, 29);
            btnDodajStipendiju.TabIndex = 3;
            btnDodajStipendiju.Text = "Dodaj stipendiju";
            btnDodajStipendiju.UseVisualStyleBackColor = true;
            btnDodajStipendiju.Click += btnDodajStipendiju_Click;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 373);
            Controls.Add(btnDodajStipendiju);
            Controls.Add(btnStipendije);
            Controls.Add(dgvStudentStipendije);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "frmPretragaIB180079";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbGodina;
        private ComboBox cbStipendija;
        private DataGridView dgvStudentStipendije;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn GodinaInfo;
        private DataGridViewTextBoxColumn StipendijaInfo;
        private DataGridViewTextBoxColumn IznosInfo;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewButtonColumn Ukloni;
        private Button btnStipendije;
        private Button btnDodajStipendiju;
    }
}