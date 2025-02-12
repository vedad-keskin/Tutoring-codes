using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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
    public partial class frmNovaProstorijaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private ProstorijeIB180079 odabranaProstorija;



        public frmNovaProstorijaIB180079(ProstorijeIB180079 odabranaProstorija = null)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {
                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;
                var kapacitet = int.Parse(txtKapacitet.Text);

                // SLATI ZA BAZU
                // IMAGE -> BYTE[]
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);

                // PRIKAZES SLIKU IZ BAZE
                // BYTE[] -> IMAGE
                // ToImage()

                if(odabranaProstorija == null)
                {
                    var novaProstorija = new ProstorijeIB180079()
                    {
                        // Id = 4   baza puca
                        // Broj = 3, baza puca

                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet,
                        Logo = logo

                    };

                    db.ProstorijeIB180079.Add(novaProstorija);

                }
                else // za edit
                {
                    odabranaProstorija.Naziv = naziv;
                    odabranaProstorija.Oznaka = oznaka;
                    odabranaProstorija.Kapacitet = kapacitet;
                    odabranaProstorija.Logo = logo;

                    db.ProstorijeIB180079.Update(odabranaProstorija);
                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;


            }

        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.ReqiredValue);
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // C:\Users\ASUS\Desktop\C# Repos\Slike helpers\Google_Classroom_Logo.jpg
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void frmNovaProstorijaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odabranaProstorija != null)
            {
                // BYTE[] -> IMAGE
                pbLogo.Image = Ekstenzije.ToImage(odabranaProstorija.Logo);
                txtNaziv.Text = odabranaProstorija.Naziv;
                txtOznaka.Text = odabranaProstorija.Oznaka;

                // INT -> STRING
                txtKapacitet.Text = odabranaProstorija.Kapacitet.ToString();

            }
        }
    }
}
