namespace Studentska.WinApp.IspitIB180079
{
    partial class frmProjekatAddIB180079
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
            label5 = new Label();
            pbLogo = new PictureBox();
            txtNaziv = new TextBox();
            txtNapomena = new TextBox();
            dtpRokZavrsetka = new DateTimePicker();
            txtMaxBrojStudenata = new TextBox();
            chbAktivan = new CheckBox();
            btnSacuvaj = new Button();
            ofd = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Logo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(249, 9);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Naziv:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 78);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 0;
            label3.Text = "Napomena:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 171);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 0;
            label4.Text = "Maksimalno studenata:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(249, 171);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 0;
            label5.Text = "Rok završetka:";
            // 
            // pbLogo
            // 
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.Location = new Point(12, 36);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(231, 230);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            pbLogo.DoubleClick += pbLogo_DoubleClick;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(249, 36);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(589, 27);
            txtNaziv.TabIndex = 2;
            // 
            // txtNapomena
            // 
            txtNapomena.Location = new Point(249, 101);
            txtNapomena.Multiline = true;
            txtNapomena.Name = "txtNapomena";
            txtNapomena.Size = new Size(589, 67);
            txtNapomena.TabIndex = 2;
            // 
            // dtpRokZavrsetka
            // 
            dtpRokZavrsetka.Location = new Point(249, 194);
            dtpRokZavrsetka.Name = "dtpRokZavrsetka";
            dtpRokZavrsetka.Size = new Size(250, 27);
            dtpRokZavrsetka.TabIndex = 3;
            // 
            // txtMaxBrojStudenata
            // 
            txtMaxBrojStudenata.Location = new Point(510, 196);
            txtMaxBrojStudenata.Name = "txtMaxBrojStudenata";
            txtMaxBrojStudenata.Size = new Size(242, 27);
            txtMaxBrojStudenata.TabIndex = 4;
            // 
            // chbAktivan
            // 
            chbAktivan.AutoSize = true;
            chbAktivan.Checked = true;
            chbAktivan.CheckState = CheckState.Checked;
            chbAktivan.Location = new Point(758, 199);
            chbAktivan.Name = "chbAktivan";
            chbAktivan.Size = new Size(80, 24);
            chbAktivan.TabIndex = 5;
            chbAktivan.Text = "Aktivan";
            chbAktivan.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(698, 237);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(140, 29);
            btnSacuvaj.TabIndex = 6;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmProjekatAddIB180079
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 280);
            Controls.Add(btnSacuvaj);
            Controls.Add(chbAktivan);
            Controls.Add(txtMaxBrojStudenata);
            Controls.Add(dtpRokZavrsetka);
            Controls.Add(txtNapomena);
            Controls.Add(txtNaziv);
            Controls.Add(pbLogo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProjekatAddIB180079";
            Text = "Projekat";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pbLogo;
        private TextBox txtNaziv;
        private TextBox txtNapomena;
        private DateTimePicker dtpRokZavrsetka;
        private TextBox txtMaxBrojStudenata;
        private CheckBox chbAktivan;
        private Button btnSacuvaj;
        private OpenFileDialog ofd;
        private ErrorProvider err;
    }
}