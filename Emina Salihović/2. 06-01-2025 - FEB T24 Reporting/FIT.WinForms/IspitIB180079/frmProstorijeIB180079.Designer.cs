namespace FIT.WinForms.IspitIB180079
{
    partial class frmProstorijeIB180079
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
            btnPrintaj = new Button();
            btnNovaProstorija1 = new Button();
            dgvProstorije = new DataGridView();
            Logo = new DataGridViewImageColumn();
            Naziv = new DataGridViewTextBoxColumn();
            Oznaka = new DataGridViewTextBoxColumn();
            Kapacitet = new DataGridViewTextBoxColumn();
            Broj = new DataGridViewTextBoxColumn();
            Nastava = new DataGridViewButtonColumn();
            Prisustvo = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProstorije).BeginInit();
            SuspendLayout();
            // 
            // btnPrintaj
            // 
            btnPrintaj.Location = new Point(708, 313);
            btnPrintaj.Name = "btnPrintaj";
            btnPrintaj.Size = new Size(184, 29);
            btnPrintaj.TabIndex = 0;
            btnPrintaj.Text = "Printaj";
            btnPrintaj.UseVisualStyleBackColor = true;
            btnPrintaj.Click += btnPrintaj_Click;
            // 
            // btnNovaProstorija1
            // 
            btnNovaProstorija1.Location = new Point(708, 18);
            btnNovaProstorija1.Name = "btnNovaProstorija1";
            btnNovaProstorija1.Size = new Size(184, 29);
            btnNovaProstorija1.TabIndex = 0;
            btnNovaProstorija1.Text = "Nova prostorija";
            btnNovaProstorija1.UseVisualStyleBackColor = true;
            btnNovaProstorija1.Click += btnNovaProstorija1_Click;
            // 
            // dgvProstorije
            // 
            dgvProstorije.AllowUserToAddRows = false;
            dgvProstorije.AllowUserToDeleteRows = false;
            dgvProstorije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProstorije.Columns.AddRange(new DataGridViewColumn[] { Logo, Naziv, Oznaka, Kapacitet, Broj, Nastava, Prisustvo });
            dgvProstorije.Location = new Point(12, 58);
            dgvProstorije.Name = "dgvProstorije";
            dgvProstorije.ReadOnly = true;
            dgvProstorije.RowHeadersWidth = 51;
            dgvProstorije.RowTemplate.Height = 29;
            dgvProstorije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProstorije.Size = new Size(880, 249);
            dgvProstorije.TabIndex = 1;
            dgvProstorije.CellContentClick += dgvProstorije_CellContentClick;
            dgvProstorije.CellDoubleClick += dgvProstorije_CellDoubleClick;
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
            Oznaka.DataPropertyName = "Oznaka";
            Oznaka.HeaderText = "Oznaka";
            Oznaka.MinimumWidth = 6;
            Oznaka.Name = "Oznaka";
            Oznaka.ReadOnly = true;
            Oznaka.Width = 125;
            // 
            // Kapacitet
            // 
            Kapacitet.DataPropertyName = "Kapacitet";
            Kapacitet.HeaderText = "Kapacitet";
            Kapacitet.MinimumWidth = 6;
            Kapacitet.Name = "Kapacitet";
            Kapacitet.ReadOnly = true;
            Kapacitet.Width = 125;
            // 
            // Broj
            // 
            Broj.DataPropertyName = "Broj";
            Broj.HeaderText = "Br. predmeta";
            Broj.MinimumWidth = 6;
            Broj.Name = "Broj";
            Broj.ReadOnly = true;
            Broj.Width = 125;
            // 
            // Nastava
            // 
            Nastava.HeaderText = "";
            Nastava.MinimumWidth = 6;
            Nastava.Name = "Nastava";
            Nastava.ReadOnly = true;
            Nastava.Text = "Nastava";
            Nastava.UseColumnTextForButtonValue = true;
            Nastava.Width = 125;
            // 
            // Prisustvo
            // 
            Prisustvo.HeaderText = "";
            Prisustvo.MinimumWidth = 6;
            Prisustvo.Name = "Prisustvo";
            Prisustvo.ReadOnly = true;
            Prisustvo.Text = "Prisustvo";
            Prisustvo.UseColumnTextForButtonValue = true;
            Prisustvo.Width = 125;
            // 
            // frmProstorijeIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 356);
            Controls.Add(dgvProstorije);
            Controls.Add(btnNovaProstorija1);
            Controls.Add(btnPrintaj);
            Name = "frmProstorijeIB180079";
            Text = "Prostorije";
            Load += frmProstorijeIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProstorije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrintaj;
        private Button btnNovaProstorija1;
        private DataGridView dgvProstorije;
        private DataGridViewImageColumn Logo;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Oznaka;
        private DataGridViewTextBoxColumn Kapacitet;
        private DataGridViewTextBoxColumn Broj;
        private DataGridViewButtonColumn Nastava;
        private DataGridViewButtonColumn Prisustvo;
    }
}