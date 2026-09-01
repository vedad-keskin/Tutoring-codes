namespace Studentska.WinApp.IspitIB180079
{
    partial class frmPrijavaAddEditIB180079
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
            label4 = new Label();
            cmbStudent = new ComboBox();
            cmbProjekat = new ComboBox();
            dtpDatumPrijave = new DateTimePicker();
            cmbStatus = new ComboBox();
            btnGenerisi = new Button();
            btnSacuvaj = new Button();
            err = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Student:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 9);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 0;
            label2.Text = "Projekat:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 68);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 0;
            label3.Text = "Datum prijave:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(468, 68);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 0;
            label4.Text = "Status prijave:";
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(12, 32);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(449, 28);
            cmbStudent.TabIndex = 1;
            // 
            // cmbProjekat
            // 
            cmbProjekat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjekat.FormattingEnabled = true;
            cmbProjekat.Location = new Point(468, 32);
            cmbProjekat.Name = "cmbProjekat";
            cmbProjekat.Size = new Size(449, 28);
            cmbProjekat.TabIndex = 1;
            // 
            // dtpDatumPrijave
            // 
            dtpDatumPrijave.Location = new Point(12, 91);
            dtpDatumPrijave.Name = "dtpDatumPrijave";
            dtpDatumPrijave.Size = new Size(449, 27);
            dtpDatumPrijave.TabIndex = 2;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "PODNESENA", "PRIHVACENA", "ODBIJENA", "ZAVRSENA" });
            cmbStatus.Location = new Point(468, 93);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(449, 28);
            cmbStatus.TabIndex = 1;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(12, 136);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(241, 29);
            btnGenerisi.TabIndex = 3;
            btnGenerisi.Text = "Generiši prijave";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(676, 136);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(241, 29);
            btnSacuvaj.TabIndex = 3;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Location = new Point(12, 171);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(905, 303);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(19, 26);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(868, 271);
            txtInfo.TabIndex = 0;
            // 
            // frmPrijavaAddEditIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 486);
            Controls.Add(groupBox1);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnGenerisi);
            Controls.Add(dtpDatumPrijave);
            Controls.Add(cmbProjekat);
            Controls.Add(cmbStatus);
            Controls.Add(cmbStudent);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "frmPrijavaAddEditIB180079";
            Text = "Nova prijava na projekat";
            FormClosed += frmPrijavaAddEditIB180079_FormClosed;
            Load += frmPrijavaAddEditIB180079_Load;
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
        private Label label4;
        private ComboBox cmbStudent;
        private ComboBox cmbProjekat;
        private DateTimePicker dtpDatumPrijave;
        private ComboBox cmbStatus;
        private Button btnGenerisi;
        private Button btnSacuvaj;
        private ErrorProvider err;
        private GroupBox groupBox1;
        private TextBox txtInfo;
    }
}