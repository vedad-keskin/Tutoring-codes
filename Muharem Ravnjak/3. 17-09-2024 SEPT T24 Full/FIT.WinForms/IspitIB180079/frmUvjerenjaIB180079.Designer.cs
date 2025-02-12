namespace FIT.WinForms.IspitIB180079
{
    partial class frmUvjerenjaIB180079
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
            dgvUvjerenja = new DataGridView();
            Vrijeme = new DataGridViewTextBoxColumn();
            Vrsta = new DataGridViewTextBoxColumn();
            Svrha = new DataGridViewTextBoxColumn();
            Uplatnica = new DataGridViewImageColumn();
            Printano = new DataGridViewCheckBoxColumn();
            Brisi = new DataGridViewButtonColumn();
            Printaj = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvUvjerenja).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(814, 12);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 0;
            button1.Text = "Novi zahtjev";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvUvjerenja
            // 
            dgvUvjerenja.AllowUserToAddRows = false;
            dgvUvjerenja.AllowUserToDeleteRows = false;
            dgvUvjerenja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUvjerenja.Columns.AddRange(new DataGridViewColumn[] { Vrijeme, Vrsta, Svrha, Uplatnica, Printano, Brisi, Printaj });
            dgvUvjerenja.Location = new Point(12, 54);
            dgvUvjerenja.Name = "dgvUvjerenja";
            dgvUvjerenja.ReadOnly = true;
            dgvUvjerenja.RowHeadersWidth = 51;
            dgvUvjerenja.RowTemplate.Height = 29;
            dgvUvjerenja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUvjerenja.Size = new Size(953, 235);
            dgvUvjerenja.TabIndex = 1;
            dgvUvjerenja.CellContentClick += dgvUvjerenja_CellContentClick;
            // 
            // Vrijeme
            // 
            Vrijeme.DataPropertyName = "Vrijeme";
            Vrijeme.HeaderText = "Datum";
            Vrijeme.MinimumWidth = 6;
            Vrijeme.Name = "Vrijeme";
            Vrijeme.ReadOnly = true;
            Vrijeme.Width = 125;
            // 
            // Vrsta
            // 
            Vrsta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Vrsta.DataPropertyName = "Vrsta";
            Vrsta.HeaderText = "Vrsta";
            Vrsta.MinimumWidth = 6;
            Vrsta.Name = "Vrsta";
            Vrsta.ReadOnly = true;
            // 
            // Svrha
            // 
            Svrha.DataPropertyName = "Svrha";
            Svrha.HeaderText = "Svrha";
            Svrha.MinimumWidth = 6;
            Svrha.Name = "Svrha";
            Svrha.ReadOnly = true;
            Svrha.Width = 125;
            // 
            // Uplatnica
            // 
            Uplatnica.DataPropertyName = "Uplatnica";
            Uplatnica.HeaderText = "Uplatnica";
            Uplatnica.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Uplatnica.MinimumWidth = 6;
            Uplatnica.Name = "Uplatnica";
            Uplatnica.ReadOnly = true;
            Uplatnica.Width = 125;
            // 
            // Printano
            // 
            Printano.DataPropertyName = "Printano";
            Printano.HeaderText = "Printano";
            Printano.MinimumWidth = 6;
            Printano.Name = "Printano";
            Printano.ReadOnly = true;
            Printano.Width = 125;
            // 
            // Brisi
            // 
            Brisi.HeaderText = "";
            Brisi.MinimumWidth = 6;
            Brisi.Name = "Brisi";
            Brisi.ReadOnly = true;
            Brisi.Text = "Briši";
            Brisi.UseColumnTextForButtonValue = true;
            Brisi.Width = 125;
            // 
            // Printaj
            // 
            Printaj.HeaderText = "";
            Printaj.MinimumWidth = 6;
            Printaj.Name = "Printaj";
            Printaj.ReadOnly = true;
            Printaj.Text = "Printaj";
            Printaj.UseColumnTextForButtonValue = true;
            Printaj.Width = 125;
            // 
            // frmUvjerenjaIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 303);
            Controls.Add(dgvUvjerenja);
            Controls.Add(button1);
            Name = "frmUvjerenjaIB180079";
            Text = "frmUvjerenjaIB180079";
            Load += frmUvjerenjaIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUvjerenja).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dgvUvjerenja;
        private DataGridViewTextBoxColumn Vrijeme;
        private DataGridViewTextBoxColumn Vrsta;
        private DataGridViewTextBoxColumn Svrha;
        private DataGridViewImageColumn Uplatnica;
        private DataGridViewCheckBoxColumn Printano;
        private DataGridViewButtonColumn Brisi;
        private DataGridViewButtonColumn Printaj;
    }
}