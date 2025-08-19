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
            err = new ErrorProvider(components);
            btnPotvrda = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
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
            label2.Location = new Point(248, 20);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(484, 20);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 0;
            label3.Text = "Mjesečni iznos (BAM):";
            // 
            // cbGodina
            // 
            cbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGodina.FormattingEnabled = true;
            cbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cbGodina.Location = new Point(12, 43);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(230, 28);
            cbGodina.TabIndex = 1;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(248, 43);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(230, 28);
            cbStipendija.TabIndex = 1;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(484, 44);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(221, 27);
            txtIznos.TabIndex = 2;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(711, 43);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(142, 28);
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
            dgvStipendijeGodine.Location = new Point(12, 77);
            dgvStipendijeGodine.Name = "dgvStipendijeGodine";
            dgvStipendijeGodine.ReadOnly = true;
            dgvStipendijeGodine.RowHeadersWidth = 51;
            dgvStipendijeGodine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStipendijeGodine.Size = new Size(1041, 268);
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
            // err
            // 
            err.ContainerControl = this;
            // 
            // btnPotvrda
            // 
            btnPotvrda.Location = new Point(899, 351);
            btnPotvrda.Name = "btnPotvrda";
            btnPotvrda.Size = new Size(154, 29);
            btnPotvrda.TabIndex = 5;
            btnPotvrda.Text = "Potvrda";
            btnPotvrda.UseVisualStyleBackColor = true;
            btnPotvrda.Click += btnPotvrda_Click;
            // 
            // frmStipendijeIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 387);
            Controls.Add(btnPotvrda);
            Controls.Add(dgvStipendijeGodine);
            Controls.Add(btnDodaj);
            Controls.Add(txtIznos);
            Controls.Add(cbStipendija);
            Controls.Add(cbGodina);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmStipendijeIB180079";
            Text = "Upravljanje stipendijama";
            Load += frmStipendijeIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).EndInit();
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
        private ErrorProvider err;
        private Button btnPotvrda;
    }
}