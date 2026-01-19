namespace DLWMS.WinApp.IspitIB180079
{
    partial class frmStipendijeIB180079
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbGodina = new ComboBox();
            cbStipendija = new ComboBox();
            txtIznos = new TextBox();
            btnDodaj = new Button();
            dgvStipendijeGodine = new DataGridView();
            Godina = new DataGridViewTextBoxColumn();
            Stipendija = new DataGridViewTextBoxColumn();
            Iznos = new DataGridViewTextBoxColumn();
            UkupnoInfo = new DataGridViewTextBoxColumn();
            Aktivna = new DataGridViewCheckBoxColumn();
            btnGenerisi = new Button();
            btnPotvrda = new Button();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
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
            label2.Location = new Point(230, 9);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(453, 9);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 0;
            label3.Text = "Mjesečni iznos (BAM):";
            // 
            // cbGodina
            // 
            cbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGodina.FormattingEnabled = true;
            cbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2023" });
            cbGodina.Location = new Point(12, 32);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(212, 28);
            cbGodina.TabIndex = 1;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(230, 32);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(212, 28);
            cbStipendija.TabIndex = 1;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(453, 32);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(193, 27);
            txtIznos.TabIndex = 2;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(652, 31);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(167, 29);
            btnDodaj.TabIndex = 3;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // dgvStipendijeGodine
            // 
            dgvStipendijeGodine.AllowUserToAddRows = false;
            dgvStipendijeGodine.AllowUserToDeleteRows = false;
            dgvStipendijeGodine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStipendijeGodine.Columns.AddRange(new DataGridViewColumn[] { Godina, Stipendija, Iznos, UkupnoInfo, Aktivna });
            dgvStipendijeGodine.Location = new Point(12, 66);
            dgvStipendijeGodine.Name = "dgvStipendijeGodine";
            dgvStipendijeGodine.ReadOnly = true;
            dgvStipendijeGodine.RowHeadersWidth = 51;
            dgvStipendijeGodine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStipendijeGodine.Size = new Size(938, 269);
            dgvStipendijeGodine.TabIndex = 4;
            dgvStipendijeGodine.CellDoubleClick += dgvStipendijeGodine_CellDoubleClick;
            // 
            // Godina
            // 
            Godina.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Godina.DataPropertyName = "Godina";
            Godina.HeaderText = "Godina";
            Godina.MinimumWidth = 6;
            Godina.Name = "Godina";
            Godina.ReadOnly = true;
            // 
            // Stipendija
            // 
            Stipendija.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stipendija.DataPropertyName = "Stipendija";
            Stipendija.HeaderText = "Stipendija";
            Stipendija.MinimumWidth = 6;
            Stipendija.Name = "Stipendija";
            Stipendija.ReadOnly = true;
            // 
            // Iznos
            // 
            Iznos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Iznos.DataPropertyName = "Iznos";
            Iznos.HeaderText = "Mjesečni iznos";
            Iznos.MinimumWidth = 6;
            Iznos.Name = "Iznos";
            Iznos.ReadOnly = true;
            // 
            // UkupnoInfo
            // 
            UkupnoInfo.DataPropertyName = "UkupnoInfo";
            UkupnoInfo.HeaderText = "Ukupni iznos";
            UkupnoInfo.MinimumWidth = 6;
            UkupnoInfo.Name = "UkupnoInfo";
            UkupnoInfo.ReadOnly = true;
            UkupnoInfo.Width = 125;
            // 
            // Aktivna
            // 
            Aktivna.DataPropertyName = "Aktivna";
            Aktivna.HeaderText = "Aktivna";
            Aktivna.MinimumWidth = 6;
            Aktivna.Name = "Aktivna";
            Aktivna.ReadOnly = true;
            Aktivna.Width = 125;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(12, 341);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(264, 29);
            btnGenerisi.TabIndex = 5;
            btnGenerisi.Text = "Generiši stipendije >>>>>";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(773, 341);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(177, 29);
            btnPotvrda.TabIndex = 5;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            btnPotvrda.Click += btnPotvrda_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 376);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(938, 231);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator info";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 26);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(926, 199);
            txtInfo.TabIndex = 0;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmStipendijeIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 619);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrda);
            Controls.Add(btnGenerisi);
            Controls.Add(dgvStipendijeGodine);
            Controls.Add(btnDodaj);
            Controls.Add(txtIznos);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmStipendijeIB180079";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Upravljanje stipendijama";
            Load += frmStipendijeIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbGodina;
        private ComboBox cbStipendija;
        private TextBox txtIznos;
        private Button btnDodaj;
        private DataGridView dgvStipendijeGodine;
        private DataGridViewTextBoxColumn Godina;
        private DataGridViewTextBoxColumn Stipendija;
        private DataGridViewTextBoxColumn Iznos;
        private DataGridViewTextBoxColumn UkupnoInfo;
        private DataGridViewCheckBoxColumn Aktivna;
        private Button btnGenerisi;
        private Button btnPotvrda;
        private GroupBox groupBox1;
        private TextBox txtInfo;
        private ErrorProvider err;
    }
}