using FIT.Data;
using FIT.Data.IspitIB230030;
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

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmGradoviIB180079 : Form
    {
        private DrzaveIB230030 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();
        List<GradoviIB230030> gradovi;

        public frmGradoviIB180079(DrzaveIB230030 odabranaDrzava)
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
            gradovi = db.GradoviIB230030
                .Where(x => x.DrzavaID == odabranaDrzava.Id)
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

        private void dgvGradovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniGrad = gradovi[e.RowIndex];

            if (e.ColumnIndex == 2)
            {

                if (odabraniGrad.Status) // ako je false
                {
                    odabraniGrad.Status = false;
                }
                else
                {
                    odabraniGrad.Status = true;
                }

                // pohrana          -> uslov                 ?  ako je true : ako je false;
                // odabraniGrad.Status = odabraniGrad.Status ? false : true;

                // ako je ovo prvo null ?? onda uradi nesto;



                db.GradoviIB230030.Update(odabraniGrad);
                db.SaveChanges();

                UcitajGradove();


            }

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var naziv = txtNaziv.Text;


                //                        mostar == mostar
                if (gradovi.Exists( x => x.Naziv.ToLower() == naziv.ToLower()))
                {
                    MessageBox.Show($"Grad {naziv} već postoji u državi {odabranaDrzava.Naziv}","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {

                    var noviGrad = new GradoviIB230030()
                    {
                        Naziv = naziv,
                        Status = true,
                        DrzavaID = odabranaDrzava.Id

                    };

                    db.GradoviIB230030.Add(noviGrad);
                    db.SaveChanges();

                    txtNaziv.Clear();
                    UcitajGradove();

                    MessageBox.Show($"Dodali ste grad {naziv} u državi {odabranaDrzava.Naziv}", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }





            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmGradoviIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {

             DialogResult = DialogResult.OK;

        }
    }
}
