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
            btnDodaj = new Button();
            btnStipendije = new Button();
            dgvStudentiStipendije = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            GodinaInfo = new DataGridViewTextBoxColumn();
            StipendijaInfo = new DataGridViewTextBoxColumn();
            IznosInfo = new DataGridViewTextBoxColumn();
            UkupnoInfo = new DataGridViewTextBoxColumn();
            Ukloni = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(228, 7);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // cbGodina
            // 
            cbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGodina.FormattingEnabled = true;
            cbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cbGodina.Location = new Point(10, 24);
            cbGodina.Margin = new Padding(3, 2, 3, 2);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(214, 23);
            cbGodina.TabIndex = 1;
            cbGodina.SelectedIndexChanged += cbGodina_SelectedIndexChanged;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(229, 24);
            cbStipendija.Margin = new Padding(3, 2, 3, 2);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(214, 23);
            cbStipendija.TabIndex = 1;
            cbStipendija.SelectedIndexChanged += cbStipendija_SelectedIndexChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(598, 23);
            btnDodaj.Margin = new Padding(3, 2, 3, 2);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(150, 22);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj stipendiju";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnStipendije
            // 
            btnStipendije.Location = new Point(752, 23);
            btnStipendije.Margin = new Padding(3, 2, 3, 2);
            btnStipendije.Name = "btnStipendije";
            btnStipendije.Size = new Size(182, 22);
            btnStipendije.TabIndex = 2;
            btnStipendije.Text = "Stipendije po godinama";
            btnStipendije.UseVisualStyleBackColor = true;
            btnStipendije.Click += btnStipendije_Click;
            // 
            // dgvStudentiStipendije
            // 
            dgvStudentiStipendije.AllowUserToAddRows = false;
            dgvStudentiStipendije.AllowUserToDeleteRows = false;
            dgvStudentiStipendije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiStipendije.Columns.AddRange(new DataGridViewColumn[] { Student, GodinaInfo, StipendijaInfo, IznosInfo, UkupnoInfo, Ukloni });
            dgvStudentiStipendije.Location = new Point(10, 50);
            dgvStudentiStipendije.Margin = new Padding(3, 2, 3, 2);
            dgvStudentiStipendije.Name = "dgvStudentiStipendije";
            dgvStudentiStipendije.ReadOnly = true;
            dgvStudentiStipendije.RowHeadersWidth = 51;
            dgvStudentiStipendije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiStipendije.Size = new Size(924, 259);
            dgvStudentiStipendije.TabIndex = 3;
            dgvStudentiStipendije.CellContentClick += dgvStudentiStipendije_CellContentClick;
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
            GodinaInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GodinaInfo.DataPropertyName = "GodinaInfo";
            GodinaInfo.HeaderText = "Godina";
            GodinaInfo.MinimumWidth = 6;
            GodinaInfo.Name = "GodinaInfo";
            GodinaInfo.ReadOnly = true;
            // 
            // StipendijaInfo
            // 
            StipendijaInfo.DataPropertyName = "StipendijaInfo";
            StipendijaInfo.HeaderText = "Stipendija";
            StipendijaInfo.MinimumWidth = 6;
            StipendijaInfo.Name = "StipendijaInfo";
            StipendijaInfo.ReadOnly = true;
            StipendijaInfo.Width = 125;
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
            Ukloni.HeaderText = "";
            Ukloni.MinimumWidth = 6;
            Ukloni.Name = "Ukloni";
            Ukloni.ReadOnly = true;
            Ukloni.Text = "Ukloni";
            Ukloni.UseColumnTextForButtonValue = true;
            Ukloni.Width = 125;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 317);
            Controls.Add(dgvStudentiStipendije);
            Controls.Add(btnStipendije);
            Controls.Add(btnDodaj);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanin studenata: placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbGodina;
        private ComboBox cbStipendija;
        private Button btnDodaj;
        private Button btnStipendije;
        private DataGridView dgvStudentiStipendije;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn GodinaInfo;
        private DataGridViewTextBoxColumn StipendijaInfo;
        private DataGridViewTextBoxColumn IznosInfo;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewButtonColumn Ukloni;
    }
}