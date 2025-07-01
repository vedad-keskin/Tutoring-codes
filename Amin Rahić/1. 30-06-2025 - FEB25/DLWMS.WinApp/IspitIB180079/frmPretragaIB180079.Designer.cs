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
            dgvStudentiStipendija = new DataGridView();
            Student = new DataGridViewTextBoxColumn();
            Datum = new DataGridViewTextBoxColumn();
            GodinaInfo = new DataGridViewTextBoxColumn();
            StipendijaInfo = new DataGridViewTextBoxColumn();
            IznosInfo = new DataGridViewTextBoxColumn();
            UkupnoInfo = new DataGridViewTextBoxColumn();
            Ukloni = new DataGridViewButtonColumn();
            btnStipendije = new Button();
            btnDodaj = new Button();
            txtImePrezime = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendija).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 20);
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
            cbGodina.Location = new Point(12, 43);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(210, 28);
            cbGodina.TabIndex = 1;
            cbGodina.SelectedIndexChanged += cbGodina_SelectedIndexChanged;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(230, 43);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(210, 28);
            cbStipendija.TabIndex = 1;
            cbStipendija.SelectedIndexChanged += cbStipendija_SelectedIndexChanged;
            // 
            // dgvStudentiStipendija
            // 
            dgvStudentiStipendija.AllowUserToAddRows = false;
            dgvStudentiStipendija.AllowUserToDeleteRows = false;
            dgvStudentiStipendija.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiStipendija.Columns.AddRange(new DataGridViewColumn[] { Student, Datum, GodinaInfo, StipendijaInfo, IznosInfo, UkupnoInfo, Ukloni });
            dgvStudentiStipendija.Location = new Point(12, 77);
            dgvStudentiStipendija.Name = "dgvStudentiStipendija";
            dgvStudentiStipendija.ReadOnly = true;
            dgvStudentiStipendija.RowHeadersWidth = 51;
            dgvStudentiStipendija.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentiStipendija.Size = new Size(1318, 337);
            dgvStudentiStipendija.TabIndex = 2;
            dgvStudentiStipendija.CellContentClick += dgvStudentiStipendija_CellContentClick;
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
            // Datum
            // 
            Datum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Datum.DataPropertyName = "Datum";
            Datum.HeaderText = "Datum rođenja";
            Datum.MinimumWidth = 6;
            Datum.Name = "Datum";
            Datum.ReadOnly = true;
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
            // btnStipendije
            // 
            btnStipendije.Location = new Point(1129, 43);
            btnStipendije.Name = "btnStipendije";
            btnStipendije.Size = new Size(201, 29);
            btnStipendije.TabIndex = 3;
            btnStipendije.Text = "Stipendije po godinama";
            btnStipendije.UseVisualStyleBackColor = true;
            btnStipendije.Click += btnStipendije_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(922, 43);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(201, 29);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj stipendiju";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(446, 42);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(172, 27);
            txtImePrezime.TabIndex = 4;
            txtImePrezime.TextChanged += txtImePrezime_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(455, 19);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 0;
            label3.Text = "Stipendija:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 19);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 0;
            label4.Text = "Ime ili prezime";
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(666, 15);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 5;
            dtpDatumOd.Value = new DateTime(2000, 7, 1, 19, 1, 0, 0);
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(666, 45);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 5;
            dtpDatumDo.ValueChanged += dtpDatumDo_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(624, 22);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 0;
            label5.Text = "Od:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(624, 49);
            label6.Name = "label6";
            label6.Size = new Size(32, 20);
            label6.TabIndex = 0;
            label6.Text = "Do:";
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 426);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(txtImePrezime);
            Controls.Add(btnDodaj);
            Controls.Add(btnStipendije);
            Controls.Add(dgvStudentiStipendija);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "Broj prikazanih studenata placeholder";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendija).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbGodina;
        private ComboBox cbStipendija;
        private DataGridView dgvStudentiStipendija;
        private Button btnStipendije;
        private Button btnDodaj;
        private TextBox txtImePrezime;
        private Label label3;
        private Label label4;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewTextBoxColumn GodinaInfo;
        private DataGridViewTextBoxColumn StipendijaInfo;
        private DataGridViewTextBoxColumn IznosInfo;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewButtonColumn Ukloni;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private Label label5;
        private Label label6;
    }
}