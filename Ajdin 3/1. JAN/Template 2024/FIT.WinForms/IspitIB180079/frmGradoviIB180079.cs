using FIT.Data;
using FIT.Data.IspitIB1800079;
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
    public partial class frmGradoviIB180079 : Form
    {
        private DrzaveIB180079 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();
        List<GradoviIB180079> gradovi;

        public frmGradoviIB180079(DrzaveIB180079 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmGradoviIB180079_Load(object sender, EventArgs e)
        {
            dgvGradovi.AutoGenerateColumns = false;
            UcitajInfo();
            UcitajGradove();
        }

        private void UcitajGradove()
        {
            gradovi = db.GradoviIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();



            if (gradovi != null)
            {
                dgvGradovi.DataSource = null;
                dgvGradovi.DataSource = gradovi;
            }

        }

        private void UcitajInfo()
        {
            pbZastava.Image = odabranaDrzava.Zastava.ToImage();
            lblNazivDrzave.Text = odabranaDrzava.Naziv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var naziv = txtNaziv.Text; // Vedad -> vedad  , KESKIN -> keskin


                if (gradovi.Exists(x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show("Grad postoji");
                }
                else
                {

                    var noviGrad = new GradoviIB180079()
                    {
                        Naziv = naziv,
                        DrzavaId = odabranaDrzava.Id,
                        Status = true

                    };

                    db.GradoviIB180079.Add(noviGrad);
                    db.SaveChanges();
                }

                UcitajGradove();

                txtNaziv.Clear();



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void dgvGradovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniGrad = gradovi[e.RowIndex];

            if (e.ColumnIndex == 2)
            {
                if (odabraniGrad.Status == true)
                {
                    odabraniGrad.Status = false;

                }
                else
                {
                    odabraniGrad.Status = true;
                }

                db.Entry(odabraniGrad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                UcitajGradove();

            }
        }

        private void frmGradoviIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {

                DialogResult = DialogResult.OK;
        }
    }
}
