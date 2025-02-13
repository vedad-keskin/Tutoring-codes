namespace FIT.WinForms.ispitIB230030
{
    partial class frmNovaDrzavaIB230030
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
            pbZastava = new PictureBox();
            txtNaziv = new TextBox();
            chbStatus = new CheckBox();
            btnSacuvaj = new Button();
            openFileDialog1 = new OpenFileDialog();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbZastava).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 22);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Zastava:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 253);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Naziv:";
            // 
            // pbZastava
            // 
            pbZastava.Location = new Point(23, 45);
            pbZastava.Name = "pbZastava";
            pbZastava.Size = new Size(395, 195);
            pbZastava.SizeMode = PictureBoxSizeMode.StretchImage;
            pbZastava.TabIndex = 1;
            pbZastava.TabStop = false;
            pbZastava.DoubleClick += pbZastava_DoubleClick;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(23, 276);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(395, 27);
            txtNaziv.TabIndex = 2;
            // 
            // chbStatus
            // 
            chbStatus.AccessibleRole = AccessibleRole.None;
            chbStatus.AutoSize = true;
            chbStatus.Location = new Point(23, 322);
            chbStatus.Name = "chbStatus";
            chbStatus.Size = new Size(80, 24);
            chbStatus.TabIndex = 3;
            chbStatus.Text = "Aktivna";
            chbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(324, 336);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(94, 29);
            btnSacuvaj.TabIndex = 4;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmNovaDrzavaIB230030
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 377);
            Controls.Add(btnSacuvaj);
            Controls.Add(chbStatus);
            Controls.Add(txtNaziv);
            Controls.Add(pbZastava);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNovaDrzavaIB230030";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Podaci o državi";
            Load += frmNovaDrzavaIB230030_Load;
            ((System.ComponentModel.ISupportInitialize)pbZastava).EndInit();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pbZastava;
        private TextBox txtNaziv;
        private CheckBox chbStatus;
        private Button btnSacuvaj;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider err;
    }
}