using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.EntityFrameworkCore.Metadata;
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
        private ProstorijeIB180079 odrabranaProstorija;

        public frmNovaProstorijaIB180079() // za dodavanje
        {
            InitializeComponent();
        }

        public frmNovaProstorijaIB180079(ProstorijeIB180079 odrabranaProstorija) // za editovanje
        {
            InitializeComponent();
            this.odrabranaProstorija = odrabranaProstorija;
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            //otvorio dijalog za dodavanje slike == ako je neko kliknuo ok 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  C:\Users\ASUS\Desktop\C# Repos\Slike helpers\Google_Classroom_Logo.jpg
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);
                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;
                var kapacitet = int.Parse(txtKapacitet.Text);
                
                if(odrabranaProstorija == null) // add
                {
                    var novaProstorija = new ProstorijeIB180079()
                    {
                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet,
                        Logo = logo

                    };

                    db.ProstorijeIB180079.Add(novaProstorija);

                }
                else
                {

                    odrabranaProstorija.Naziv = naziv;
                    odrabranaProstorija.Oznaka = oznaka;
                    odrabranaProstorija.Kapacitet = kapacitet;
                    odrabranaProstorija.Logo = logo;

                    db.ProstorijeIB180079.Update(odrabranaProstorija);

                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;



            }



        }

        private bool Validiraj()
        {
            return
                Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaProstorijaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odrabranaProstorija != null) // editovanje
            {
                pbLogo.Image = Ekstenzije.ToImage(odrabranaProstorija.Logo);
                txtKapacitet.Text = odrabranaProstorija.Kapacitet.ToString();
                txtNaziv.Text = odrabranaProstorija.Naziv;
                txtOznaka.Text = odrabranaProstorija.Oznaka;

            }

        }
    }
}
