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
            cbStipendijaGodina = new ComboBox();
            btnDodaj = new Button();
            btnStipendijeGodine = new Button();
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
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 9);
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
            cbGodina.Location = new Point(12, 27);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(198, 23);
            cbGodina.TabIndex = 1;
            cbGodina.SelectedIndexChanged += cbGodina_SelectedIndexChanged;
            // 
            // cbStipendijaGodina
            // 
            cbStipendijaGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendijaGodina.FormattingEnabled = true;
            cbStipendijaGodina.Location = new Point(224, 27);
            cbStipendijaGodina.Name = "cbStipendijaGodina";
            cbStipendijaGodina.Size = new Size(198, 23);
            cbStipendijaGodina.TabIndex = 1;
            cbStipendijaGodina.SelectedIndexChanged += cbStipendijaGodina_SelectedIndexChanged;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(560, 27);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(137, 23);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj stipendiju";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnStipendijeGodine
            // 
            btnStipendijeGodine.Location = new Point(703, 27);
            btnStipendijeGodine.Name = "btnStipendijeGodine";
            btnStipendijeGodine.Size = new Size(163, 23);
            btnStipendijeGodine.TabIndex = 2;
            btnStipendijeGodine.Text = "Stipendije po godinama";
            btnStipendijeGodine.UseVisualStyleBackColor = true;
            btnStipendijeGodine.Click += btnStipendijeGodine_Click;
            // 
            // dgvStudentiStipendije
            // 
            dgvStudentiStipendije.AllowUserToAddRows = false;
            dgvStudentiStipendije.AllowUserToDeleteRows = false;
            dgvStudentiStipendije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiStipendije.Columns.AddRange(new DataGridViewColumn[] { Student, GodinaInfo, StipendijaInfo, IznosInfo, UkupnoInfo, Ukloni });
            dgvStudentiStipendije.Location = new Point(12, 56);
            dgvStudentiStipendije.Name = "dgvStudentiStipendije";
            dgvStudentiStipendije.ReadOnly = true;
            dgvStudentiStipendije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiStipendije.Size = new Size(854, 249);
            dgvStudentiStipendije.TabIndex = 3;
            dgvStudentiStipendije.CellContentClick += dgvStudentiStipendije_CellContentClick;
            // 
            // Student
            // 
            Student.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Student.DataPropertyName = "Student";
            Student.HeaderText = "(Indeks) Ime i prezime";
            Student.Name = "Student";
            Student.ReadOnly = true;
            // 
            // GodinaInfo
            // 
            GodinaInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GodinaInfo.DataPropertyName = "GodinaInfo";
            GodinaInfo.HeaderText = "Godina";
            GodinaInfo.Name = "GodinaInfo";
            GodinaInfo.ReadOnly = true;
            // 
            // StipendijaInfo
            // 
            StipendijaInfo.DataPropertyName = "StipendijaInfo";
            StipendijaInfo.HeaderText = "Stipendija";
            StipendijaInfo.Name = "StipendijaInfo";
            StipendijaInfo.ReadOnly = true;
            // 
            // IznosInfo
            // 
            IznosInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            IznosInfo.DataPropertyName = "IznosInfo";
            IznosInfo.HeaderText = "Iznos";
            IznosInfo.Name = "IznosInfo";
            IznosInfo.ReadOnly = true;
            // 
            // UkupnoInfo
            // 
            UkupnoInfo.DataPropertyName = "UkupnoInfo";
            UkupnoInfo.HeaderText = "Ukupno";
            UkupnoInfo.Name = "UkupnoInfo";
            UkupnoInfo.ReadOnly = true;
            // 
            // Ukloni
            // 
            Ukloni.HeaderText = "";
            Ukloni.Name = "Ukloni";
            Ukloni.ReadOnly = true;
            Ukloni.Text = "Ukloni";
            Ukloni.UseColumnTextForButtonValue = true;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 313);
            Controls.Add(dgvStudentiStipendije);
            Controls.Add(btnStipendijeGodine);
            Controls.Add(btnDodaj);
            Controls.Add(cbStipendijaGodina);
            Controls.Add(cbGodina);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih studenata placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbGodina;
        private ComboBox cbStipendijaGodina;
        private Button btnDodaj;
        private Button btnStipendijeGodine;
        private DataGridView dgvStudentiStipendije;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn GodinaInfo;
        private DataGridViewTextBoxColumn StipendijaInfo;
        private DataGridViewTextBoxColumn IznosInfo;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewButtonColumn Ukloni;
    }
}