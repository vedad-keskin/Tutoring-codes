using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data;
using FIT.Data.ispitIB230030;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmNovaProstorijaIB230030 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private ProstorijeIB230030 odabranaProstorija; // ako je otvorena preko dft constr. ona ne postoji (null)

        // dft. za dodvanje nove prostorije
        public frmNovaProstorijaIB230030()
        {
            InitializeComponent();
        }


        // za editovanje postojece prostorije 
        public frmNovaProstorijaIB230030(ProstorijeIB230030 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validacija())
            {
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);

                //var logo = pbLogo.Image.ToByteArray();

                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;

                var kapacitet = int.Parse(txtKapacitet.Text);


                if(odabranaProstorija == null) // dodavanje nove pr.
                {

                    var novaProstorija = new ProstorijeIB230030()
                    {
                        Logo = logo,
                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet
                    };

                    db.ProstorijeIB230030.Add(novaProstorija);
                }
                else // editovanje postojece pr.
                {

                    odabranaProstorija.Logo = logo;
                    odabranaProstorija.Naziv = naziv;
                    odabranaProstorija.Oznaka = oznaka;
                    odabranaProstorija.Kapacitet = kapacitet;


                    db.ProstorijeIB230030.Update(odabranaProstorija);

                }




                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validacija()
        {
            return Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaProstorijaIB230030_Load(object sender, EventArgs e)
        {

            UcitajInfo();

        }

        private void UcitajInfo()
        {

            if(odabranaProstorija != null)
            {

                // BYTE[] -> IMAGE
                pbLogo.Image = Ekstenzije.ToImage(odabranaProstorija.Logo);
                //pbLogo.Image = odabranaProstorija.Logo.ToImage();

                // INT -> STRING
                txtKapacitet.Text = odabranaProstorija.Kapacitet.ToString();

                txtNaziv.Text = odabranaProstorija.Naziv;

                txtOznaka.Text = odabranaProstorija.Oznaka;

            }

        }
    }
}
