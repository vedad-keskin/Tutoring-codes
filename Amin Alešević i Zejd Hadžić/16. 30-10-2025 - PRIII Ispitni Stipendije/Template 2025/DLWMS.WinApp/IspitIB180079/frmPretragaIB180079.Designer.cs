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
            btnStipendije = new Button();
            btnDodajStipendiju = new Button();
            cbGodina = new ComboBox();
            cbStipendija = new ComboBox();
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
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(260, 9);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // btnStipendije
            // 
            btnStipendije.Location = new Point(973, 31);
            btnStipendije.Name = "btnStipendije";
            btnStipendije.Size = new Size(190, 29);
            btnStipendije.TabIndex = 1;
            btnStipendije.Text = "Stipendije po godinama";
            btnStipendije.UseVisualStyleBackColor = true;
            // 
            // btnDodajStipendiju
            // 
            btnDodajStipendiju.Location = new Point(810, 31);
            btnDodajStipendiju.Name = "btnDodajStipendiju";
            btnDodajStipendiju.Size = new Size(157, 29);
            btnDodajStipendiju.TabIndex = 1;
            btnDodajStipendiju.Text = "Dodaj stipendiju";
            btnDodajStipendiju.UseVisualStyleBackColor = true;
            // 
            // cbGodina
            // 
            cbGodina.FormattingEnabled = true;
            cbGodina.Location = new Point(12, 32);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(242, 28);
            cbGodina.TabIndex = 2;
            // 
            // cbStipendija
            // 
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(260, 32);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(245, 28);
            cbStipendija.TabIndex = 2;
            // 
            // dgvStudentiStipendije
            // 
            dgvStudentiStipendije.AllowUserToAddRows = false;
            dgvStudentiStipendije.AllowUserToDeleteRows = false;
            dgvStudentiStipendije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentiStipendije.Columns.AddRange(new DataGridViewColumn[] { Student, GodinaInfo, StipendijaInfo, IznosInfo, UkupnoInfo, Ukloni });
            dgvStudentiStipendije.Location = new Point(12, 66);
            dgvStudentiStipendije.Name = "dgvStudentiStipendije";
            dgvStudentiStipendije.ReadOnly = true;
            dgvStudentiStipendije.RowHeadersWidth = 51;
            dgvStudentiStipendije.Size = new Size(1151, 362);
            dgvStudentiStipendije.TabIndex = 3;
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
            IznosInfo.DataPropertyName = "IznosInfo";
            IznosInfo.HeaderText = "Iznos";
            IznosInfo.MinimumWidth = 6;
            IznosInfo.Name = "IznosInfo";
            IznosInfo.ReadOnly = true;
            IznosInfo.Width = 125;
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
            Ukloni.Width = 125;
            // 
            // frmPretragaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 440);
            Controls.Add(dgvStudentiStipendije);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(btnDodajStipendiju);
            Controls.Add(btnStipendije);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPretragaIB180079";
            Text = "frmPretragaIB180079";
            Load += frmPretragaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentiStipendije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnStipendije;
        private Button btnDodajStipendiju;
        private ComboBox cbGodina;
        private ComboBox cbStipendija;
        private DataGridView dgvStudentiStipendije;
        private DataGridViewTextBoxColumn Student;
        private DataGridViewTextBoxColumn GodinaInfo;
        private DataGridViewTextBoxColumn StipendijaInfo;
        private DataGridViewTextBoxColumn IznosInfo;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewButtonColumn Ukloni;
    }
}