using FIT.Data;
using FIT.Data.IspitIB210166;
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

namespace FIT.WinForms.IspitIB210166
{
    public partial class frmNovaProstorijaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private ProstorijeIB210166 odabranaProstorija; // null


        // dft. constr. za dodavanje nove prostorije
        public frmNovaProstorijaIB180079()
        {
            InitializeComponent();
        }

        // user-df constr. za dodavanje modifikaciju postojece prostorije
        public frmNovaProstorijaIB180079(ProstorijeIB210166 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // C:\Users\ASUS\Desktop\C# Repos\Slike helpers\Google_Classroom_Logo.jpg
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {
                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;

                // STRING -> INT
                var kapacitet = int.Parse(txtKapacitet.Text);

                // IMAGE -> BYTE[] -> ToByteArray()
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);
                // BYTE[] -> IMAGE -> ToImage()


                if(odabranaProstorija == null)
                {
                    var novaProstorija = new ProstorijeIB210166()
                    {
                        // Id = 1 <-- autoincrement i ne moze se slati
                        // BrojPredmeta = 3, baza puca jer brpr nema u bazi

                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet,
                        Logo = logo

                    };

                    db.ProstorijeIB210166.Add(novaProstorija);

                }
                else
                {

                    odabranaProstorija.Naziv = naziv;
                    odabranaProstorija.Oznaka = oznaka;
                    odabranaProstorija.Kapacitet = kapacitet;
                    odabranaProstorija.Logo = logo;

                    db.ProstorijeIB210166.Update(odabranaProstorija);
                }

                db.SaveChanges();


                DialogResult = DialogResult.OK;


            }

        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.ReqiredValue)
                && Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue)
                && Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaProstorijaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odabranaProstorija != null) // ako radimo edit
            {
                txtNaziv.Text = odabranaProstorija.Naziv;
                txtOznaka.Text = odabranaProstorija.Oznaka;

                //  INT -> STRING
                txtKapacitet.Text = odabranaProstorija.Kapacitet.ToString();

                // BYTE[] -> IMAGE -> ToImage()
                pbLogo.Image = Ekstenzije.ToImage(odabranaProstorija.Logo);

            }
        }
    }
}
