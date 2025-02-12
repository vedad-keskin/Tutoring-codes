namespace FIT.WinForms.ispitIB230030
{
    partial class frmGradoviIB230030
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
            pbZastava = new PictureBox();
            txtNaziv = new TextBox();
            lblNazivDrzave = new Label();
            label2 = new Label();
            btnDodaj = new Button();
            dgvGradovi = new DataGridView();
            Naziv = new DataGridViewTextBoxColumn();
            Status = new DataGridViewCheckBoxColumn();
            PromjeniStatus = new DataGridViewButtonColumn();
            err = new ErrorProvider(components);
            gbGenerator = new GroupBox();
            chbStatus = new CheckBox();
            btnGenerisi = new Button();
            label3 = new Label();
            label1 = new Label();
            txtInfo = new TextBox();
            txtBroj = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbZastava).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGradovi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            gbGenerator.SuspendLayout();
            SuspendLayout();
            // 
            // pbZastava
            // 
            pbZastava.Location = new Point(12, 12);
            pbZastava.Name = "pbZastava";
            pbZastava.Size = new Size(125, 62);
            pbZastava.SizeMode = PictureBoxSizeMode.StretchImage;
            pbZastava.TabIndex = 0;
            pbZastava.TabStop = false;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(205, 92);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(366, 27);
            txtNaziv.TabIndex = 1;
            // 
            // lblNazivDrzave
            // 
            lblNazivDrzave.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNazivDrzave.Location = new Point(143, 26);
            lblNazivDrzave.Name = "lblNazivDrzave";
            lblNazivDrzave.Size = new Size(537, 48);
            lblNazivDrzave.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 99);
            label2.Name = "label2";
            label2.Size = new Size(188, 20);
            label2.TabIndex = 3;
            label2.Text = "Unesite naziv novog grada:";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(577, 92);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(103, 29);
            btnDodaj.TabIndex = 5;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // dgvGradovi
            // 
            dgvGradovi.AllowUserToAddRows = false;
            dgvGradovi.AllowUserToDeleteRows = false;
            dgvGradovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGradovi.Columns.AddRange(new DataGridViewColumn[] { Naziv, Status, PromjeniStatus });
            dgvGradovi.Location = new Point(11, 138);
            dgvGradovi.Name = "dgvGradovi";
            dgvGradovi.ReadOnly = true;
            dgvGradovi.RowHeadersWidth = 51;
            dgvGradovi.RowTemplate.Height = 29;
            dgvGradovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGradovi.Size = new Size(669, 188);
            dgvGradovi.TabIndex = 6;
            dgvGradovi.CellContentClick += dgvGradovi_CellContentClick;
            // 
            // Naziv
            // 
            Naziv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Naziv.DataPropertyName = "Naziv";
            Naziv.HeaderText = "Naziv grada";
            Naziv.MinimumWidth = 6;
            Naziv.Name = "Naziv";
            Naziv.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Aktivan";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // PromjeniStatus
            // 
            PromjeniStatus.HeaderText = "";
            PromjeniStatus.MinimumWidth = 6;
            PromjeniStatus.Name = "PromjeniStatus";
            PromjeniStatus.ReadOnly = true;
            PromjeniStatus.Text = "Promjeni status";
            PromjeniStatus.UseColumnTextForButtonValue = true;
            PromjeniStatus.Width = 125;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // gbGenerator
            // 
            gbGenerator.Controls.Add(chbStatus);
            gbGenerator.Controls.Add(btnGenerisi);
            gbGenerator.Controls.Add(label3);
            gbGenerator.Controls.Add(label1);
            gbGenerator.Controls.Add(txtInfo);
            gbGenerator.Controls.Add(txtBroj);
            gbGenerator.Location = new Point(12, 347);
            gbGenerator.Name = "gbGenerator";
            gbGenerator.Size = new Size(668, 197);
            gbGenerator.TabIndex = 7;
            gbGenerator.TabStop = false;
            gbGenerator.Text = "Generator";
            // 
            // chbStatus
            // 
            chbStatus.AutoSize = true;
            chbStatus.Location = new Point(193, 32);
            chbStatus.Name = "chbStatus";
            chbStatus.Size = new Size(101, 24);
            chbStatus.TabIndex = 3;
            chbStatus.Text = "checkBox1";
            chbStatus.UseVisualStyleBackColor = true;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(300, 29);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(94, 29);
            btnGenerisi.TabIndex = 2;
            btnGenerisi.Text = "Generiši";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 70);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 0;
            label3.Text = "Info:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Broj gradova:";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 93);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(662, 98);
            txtInfo.TabIndex = 1;
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(110, 30);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(68, 27);
            txtBroj.TabIndex = 1;
            // 
            // frmGradoviIB230030
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 565);
            Controls.Add(gbGenerator);
            Controls.Add(dgvGradovi);
            Controls.Add(btnDodaj);
            Controls.Add(label2);
            Controls.Add(lblNazivDrzave);
            Controls.Add(txtNaziv);
            Controls.Add(pbZastava);
            Name = "frmGradoviIB230030";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o gradu";
            FormClosed += frmGradoviIB230030_FormClosed;
            Load += frmGradoviIB230030_Load;
            ((System.ComponentModel.ISupportInitialize)pbZastava).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGradovi).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            gbGenerator.ResumeLayout(false);
            gbGenerator.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbZastava;
        private TextBox txtNaziv;
        private Label lblNazivDrzave;
        private Label label2;
        private Button btnDodaj;
        private DataGridView dgvGradovi;
        private DataGridViewTextBoxColumn Naziv;
        private DataGridViewCheckBoxColumn Status;
        private DataGridViewButtonColumn PromjeniStatus;
        private ErrorProvider err;
        private GroupBox gbGenerator;
        private CheckBox chbStatus;
        private Button btnGenerisi;
        private Label label1;
        private TextBox txtBroj;
        private Label label3;
        private TextBox txtInfo;
    }
}