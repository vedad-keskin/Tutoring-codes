namespace FIT.WinForms.IspitIB180079
{
    partial class frmDrzaveIB180079
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
            btnPrintaj = new Button();
            btnNova = new Button();
            dgvDrzave = new DataGridView();
            Zastava = new DataGridViewImageColumn();
            Naziv = new DataGridViewTextBoxColumn();
            Broj = new DataGridViewTextBoxColumn();
            Status = new DataGridViewCheckBoxColumn();
            Gradovi = new DataGridViewButtonColumn();
            statusStrip1 = new StatusStrip();
            tsslVrijeme = new ToolStripStatusLabel();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvDrzave).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrintaj
            // 
            btnPrintaj.Location = new Point(805, 354);
            btnPrintaj.Name = "btnPrintaj";
            btnPrintaj.Size = new Size(157, 29);
            btnPrintaj.TabIndex = 0;
            btnPrintaj.Text = "Printaj";
            btnPrintaj.UseVisualStyleBackColor = true;
            btnPrintaj.Click += btnPrintaj_Click;
            // 
            // btnNova
            // 
            btnNova.Location = new Point(805, 27);
            btnNova.Name = "btnNova";
            btnNova.Size = new Size(157, 29);
            btnNova.TabIndex = 0;
            btnNova.Text = "Nova država";
            btnNova.UseVisualStyleBackColor = true;
            btnNova.Click += btnNova_Click;
            // 
            // dgvDrzave
            // 
            dgvDrzave.AllowUserToAddRows = false;
            dgvDrzave.AllowUserToDeleteRows = false;
            dgvDrzave.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrzave.Columns.AddRange(new DataGridViewColumn[] { Zastava, Naziv, Broj, Status, Gradovi });
            dgvDrzave.Location = new Point(12, 62);
            dgvDrzave.Name = "dgvDrzave";
            dgvDrzave.ReadOnly = true;
            dgvDrzave.RowHeadersWidth = 51;
            dgvDrzave.RowTemplate.Height = 29;
            dgvDrzave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrzave.Size = new Size(950, 286);
            dgvDrzave.TabIndex = 1;
            dgvDrzave.CellContentClick += dgvDrzave_CellContentClick;
            dgvDrzave.CellDoubleClick += dgvDrzave_CellDoubleClick;
            // 
            // Zastava
            // 
            Zastava.DataPropertyName = "Zastava";
            Zastava.HeaderText = "Zastava";
            Zastava.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Zastava.MinimumWidth = 6;
            Zastava.Name = "Zastava";
            Zastava.ReadOnly = true;
            Zastava.Width = 80;
            // 
            // Naziv
            // 
            Naziv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Naziv.DataPropertyName = "Naziv";
            Naziv.HeaderText = "Država";
            Naziv.MinimumWidth = 6;
            Naziv.Name = "Naziv";
            Naziv.ReadOnly = true;
            // 
            // Broj
            // 
            Broj.DataPropertyName = "Broj";
            Broj.HeaderText = "Broj gradova";
            Broj.MinimumWidth = 6;
            Broj.Name = "Broj";
            Broj.ReadOnly = true;
            Broj.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Aktivna";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // Gradovi
            // 
            Gradovi.HeaderText = "";
            Gradovi.MinimumWidth = 6;
            Gradovi.Name = "Gradovi";
            Gradovi.ReadOnly = true;
            Gradovi.Text = "Gradovi";
            Gradovi.UseColumnTextForButtonValue = true;
            Gradovi.Width = 125;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslVrijeme });
            statusStrip1.Location = new Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(974, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslVrijeme
            // 
            tsslVrijeme.Name = "tsslVrijeme";
            tsslVrijeme.Size = new Size(151, 20);
            tsslVrijeme.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // frmDrzaveIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 415);
            Controls.Add(statusStrip1);
            Controls.Add(dgvDrzave);
            Controls.Add(btnNova);
            Controls.Add(btnPrintaj);
            Name = "frmDrzaveIB180079";
            Text = "Države";
            Load += frmDrzaveIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrzave).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrintaj;
        private Button btnNova;
        private DataGridView dgvDrzave;
        private DataGridViewImageColumn Zastava;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewTextBoxColumn Broj;
        private DataGridViewCheckBoxColumn Status;
        private DataGridViewButtonColumn Gradovi;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslVrijeme;
        private System.Windows.Forms.Timer timer;
    }
}