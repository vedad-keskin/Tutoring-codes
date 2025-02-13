namespace FIT.WinForms.ispitIB230030
{
    partial class frmProstorijeIB230030
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
            btnnovaprostorija = new Button();
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
            btnPrintaj.Location = new Point(797, 277);
            btnPrintaj.Name = "btnPrintaj";
            btnPrintaj.Size = new Size(153, 29);
            btnPrintaj.TabIndex = 0;
            btnPrintaj.Text = "Printaj";
            btnPrintaj.UseVisualStyleBackColor = true;
            // 
            // btnnovaprostorija
            // 
            btnnovaprostorija.Location = new Point(797, 12);
            btnnovaprostorija.Name = "btnnovaprostorija";
            btnnovaprostorija.Size = new Size(153, 29);
            btnnovaprostorija.TabIndex = 0;
            btnnovaprostorija.Text = "Nova prostorija";
            btnnovaprostorija.UseVisualStyleBackColor = true;
            btnnovaprostorija.Click += btnnovaprostorija_Click;
            // 
            // dgvProstorije
            // 
            dgvProstorije.AllowUserToAddRows = false;
            dgvProstorije.AllowUserToDeleteRows = false;
            dgvProstorije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProstorije.Columns.AddRange(new DataGridViewColumn[] { Logo, Naziv, Oznaka, Kapacitet, Broj, Nastava, Prisustvo });
            dgvProstorije.Location = new Point(52, 47);
            dgvProstorije.Name = "dgvProstorije";
            dgvProstorije.ReadOnly = true;
            dgvProstorije.RowHeadersWidth = 51;
            dgvProstorije.RowTemplate.Height = 29;
            dgvProstorije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProstorije.Size = new Size(898, 224);
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
            Logo.Resizable = DataGridViewTriState.True;
            Logo.SortMode = DataGridViewColumnSortMode.Automatic;
            Logo.Width = 50;
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
            // frmProstorijeIB230030
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 331);
            Controls.Add(dgvProstorije);
            Controls.Add(btnnovaprostorija);
            Controls.Add(btnPrintaj);
            Name = "frmProstorijeIB230030";
            Text = "Prostorije";
            Load += frmProstorijeIB230030_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProstorije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrintaj;
        private Button btnnovaprostorija;
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