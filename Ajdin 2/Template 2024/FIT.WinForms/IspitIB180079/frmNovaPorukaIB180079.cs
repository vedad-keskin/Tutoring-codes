using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmNovaPorukaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private Student student;

        
        public frmNovaPorukaIB180079(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void frmNovaPorukaIB180079_Load(object sender, EventArgs e)
        {
            cbPredmet.DataSource = db.Predmeti.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var predmet = cbPredmet.SelectedItem as PredmetiIB180079;
                var validnost = dtpValidnost.Value;
                var sadrzaj = txtSadrzaj.Text;
                var slika = Ekstenzije.ToByteArray(pbSlika.Image);


                var novaPoruka = new StudentiPorukeIB180079()
                {
                    // Id je autoinc
                    // Predmet je klasa
                    // Student je klasa

                    StudentId = student.Id,
                    PredmetId = predmet.Id,
                    Sadrzaj = sadrzaj,
                    Validnost = validnost,
                    Slika = slika,

                };

                db.StudentiPorukeIB180079.Add(novaPoruka);
                db.SaveChanges();

                DialogResult = DialogResult.OK;



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtSadrzaj, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(pbSlika, err, Kljucevi.ReqiredValue);
        }
    }
}
