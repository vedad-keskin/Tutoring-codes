namespace FIT.WinForms.IspitIB210166
{
    partial class frmProstorijeIB210166
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
            button1 = new Button();
            dgvProstorijeIB210166 = new DataGridView();
            Logo = new DataGridViewImageColumn();
            Naziv = new DataGridViewTextBoxColumn();
            Oznaka = new DataGridViewTextBoxColumn();
            Kapacitet = new DataGridViewTextBoxColumn();
            BrojPredmeta = new DataGridViewTextBoxColumn();
            Nastava = new DataGridViewButtonColumn();
            Prisustvo = new DataGridViewButtonColumn();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProstorijeIB210166).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(864, 38);
            button1.Name = "button1";
            button1.Size = new Size(172, 36);
            button1.TabIndex = 0;
            button1.Text = "Nova prostorija";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvProstorijeIB210166
            // 
            dgvProstorijeIB210166.AllowUserToAddRows = false;
            dgvProstorijeIB210166.AllowUserToDeleteRows = false;
            dgvProstorijeIB210166.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProstorijeIB210166.Columns.AddRange(new DataGridViewColumn[] { Logo, Naziv, Oznaka, Kapacitet, BrojPredmeta, Nastava, Prisustvo });
            dgvProstorijeIB210166.Location = new Point(2, 80);
            dgvProstorijeIB210166.Name = "dgvProstorijeIB210166";
            dgvProstorijeIB210166.ReadOnly = true;
            dgvProstorijeIB210166.RowHeadersWidth = 51;
            dgvProstorijeIB210166.RowTemplate.Height = 29;
            dgvProstorijeIB210166.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProstorijeIB210166.Size = new Size(1034, 311);
            dgvProstorijeIB210166.TabIndex = 1;
            dgvProstorijeIB210166.CellContentClick += dgvProstorijeIB210166_CellContentClick;
            dgvProstorijeIB210166.CellDoubleClick += dgvProstorijeIB210166_CellDoubleClick;
            // 
            // Logo
            // 
            Logo.DataPropertyName = "Logo";
            Logo.HeaderText = "Logo";
            Logo.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Logo.MinimumWidth = 6;
            Logo.Name = "Logo";
            Logo.ReadOnly = true;
            Logo.Width = 70;
            // 
            // Naziv
            // 
            Naziv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Naziv.DataPropertyName = "Naziv";
            Naziv.HeaderText = "Naziv";
            Naziv.MinimumWidth = 6;
            Naziv.Name = "Naziv";
            Naziv.ReadOnly = true;
            // 
            // Oznaka
            // 
            Oznaka.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Oznaka.DataPropertyName = "Oznaka";
            Oznaka.HeaderText = "Oznaka";
            Oznaka.MinimumWidth = 6;
            Oznaka.Name = "Oznaka";
            Oznaka.ReadOnly = true;
            // 
            // Kapacitet
            // 
            Kapacitet.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Kapacitet.DataPropertyName = "Kapacitet";
            Kapacitet.HeaderText = "Kapacitet";
            Kapacitet.MinimumWidth = 6;
            Kapacitet.Name = "Kapacitet";
            Kapacitet.ReadOnly = true;
            // 
            // BrojPredmeta
            // 
            BrojPredmeta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BrojPredmeta.DataPropertyName = "BrojPredmeta";
            BrojPredmeta.HeaderText = "Br. predmeta";
            BrojPredmeta.MinimumWidth = 6;
            BrojPredmeta.Name = "BrojPredmeta";
            BrojPredmeta.ReadOnly = true;
            // 
            // Nastava
            // 
            Nastava.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nastava.DataPropertyName = "Nastava";
            Nastava.HeaderText = "";
            Nastava.MinimumWidth = 6;
            Nastava.Name = "Nastava";
            Nastava.ReadOnly = true;
            Nastava.Text = "Nastava";
            Nastava.UseColumnTextForButtonValue = true;
            // 
            // Prisustvo
            // 
            Prisustvo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Prisustvo.DataPropertyName = "Prisustvo";
            Prisustvo.HeaderText = "";
            Prisustvo.MinimumWidth = 6;
            Prisustvo.Name = "Prisustvo";
            Prisustvo.ReadOnly = true;
            Prisustvo.Text = "Prisustvo";
            Prisustvo.UseColumnTextForButtonValue = true;
            // 
            // button2
            // 
            button2.Location = new Point(864, 397);
            button2.Name = "button2";
            button2.Size = new Size(172, 36);
            button2.TabIndex = 2;
            button2.Text = "Printaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // frmProstorijeIB210166
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 439);
            Controls.Add(button2);
            Controls.Add(dgvProstorijeIB210166);
            Controls.Add(button1);
            Name = "frmProstorijeIB210166";
            Text = "Prostorije";
            Load += frmProstorijeIB210166_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProstorijeIB210166).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dgvProstorijeIB210166;
        private Button button2;
        private DataGridViewImageColumn Logo;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Oznaka;
        private DataGridViewTextBoxColumn Kapacitet;
        private DataGridViewTextBoxColumn BrojPredmeta;
        private DataGridViewButtonColumn Nastava;
        private DataGridViewButtonColumn Prisustvo;
    }
}