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
            Aktivan = new DataGridViewCheckBoxColumn();
            err = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            btnGenerisi = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Godina:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 9);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Stipendija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 9);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 0;
            label3.Text = "Mjesečni iznos (BAM):";
            // 
            // cbGodina
            // 
            cbGodina.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGodina.FormattingEnabled = true;
            cbGodina.Items.AddRange(new object[] { "2025", "2024", "2023", "2022", "2021" });
            cbGodina.Location = new Point(12, 27);
            cbGodina.Name = "cbGodina";
            cbGodina.Size = new Size(157, 23);
            cbGodina.TabIndex = 1;
            // 
            // cbStipendija
            // 
            cbStipendija.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStipendija.FormattingEnabled = true;
            cbStipendija.Location = new Point(184, 27);
            cbStipendija.Name = "cbStipendija";
            cbStipendija.Size = new Size(157, 23);
            cbStipendija.TabIndex = 1;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(347, 27);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(154, 23);
            txtIznos.TabIndex = 2;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(507, 27);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(125, 23);
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
            dgvStipendijeGodine.Columns.AddRange(new DataGridViewColumn[] { Godina, Stipendija, Iznos, UkupnoInfo, Aktivan });
            dgvStipendijeGodine.Location = new Point(12, 56);
            dgvStipendijeGodine.Name = "dgvStipendijeGodine";
            dgvStipendijeGodine.ReadOnly = true;
            dgvStipendijeGodine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStipendijeGodine.Size = new Size(690, 174);
            dgvStipendijeGodine.TabIndex = 4;
            dgvStipendijeGodine.CellDoubleClick += dgvStipendijeGodine_CellDoubleClick;
            // 
            // Godina
            // 
            Godina.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Godina.DataPropertyName = "Godina";
            Godina.HeaderText = "Godina";
            Godina.Name = "Godina";
            Godina.ReadOnly = true;
            // 
            // Stipendija
            // 
            Stipendija.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stipendija.DataPropertyName = "Stipendija";
            Stipendija.HeaderText = "Stipendija";
            Stipendija.Name = "Stipendija";
            Stipendija.ReadOnly = true;
            // 
            // Iznos
            // 
            Iznos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Iznos.DataPropertyName = "Iznos";
            Iznos.HeaderText = "Mjesečni iznos";
            Iznos.Name = "Iznos";
            Iznos.ReadOnly = true;
            // 
            // UkupnoInfo
            // 
            UkupnoInfo.DataPropertyName = "UkupnoInfo";
            UkupnoInfo.HeaderText = "Ukupni iznos";
            UkupnoInfo.Name = "UkupnoInfo";
            UkupnoInfo.ReadOnly = true;
            // 
            // Aktivan
            // 
            Aktivan.DataPropertyName = "Aktivan";
            Aktivan.HeaderText = "Aktivna";
            Aktivan.Name = "Aktivan";
            Aktivan.ReadOnly = true;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 272);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(690, 151);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator info";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 22);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(678, 123);
            txtInfo.TabIndex = 0;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(12, 236);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(176, 23);
            btnGenerisi.TabIndex = 6;
            btnGenerisi.Text = "Generiši stipendije >>>>>";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // button2
            // 
            button2.Location = new Point(568, 236);
            button2.Name = "button2";
            button2.Size = new Size(134, 23);
            button2.TabIndex = 6;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // frmStipendijeIB180079
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 435);
            Controls.Add(button2);
            Controls.Add(btnGenerisi);
            Controls.Add(groupBox1);
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
            FormClosed += frmStipendijeIB180079_FormClosed;
            Load += frmStipendijeIB180079_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStipendijeGodine).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private DataGridViewCheckBoxColumn Aktivan;
        private ErrorProvider err;
        private Button button2;
        private Button btnGenerisi;
        private GroupBox groupBox1;
        private TextBox txtInfo;
    }
}