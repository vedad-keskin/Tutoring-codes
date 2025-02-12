using FIT.Data;
using FIT.Data.IspitIB220152;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB220152
{
    public partial class frmNovaProstorijaIB220152 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private ProstorijeIB220152 odabranaProstorija;

        //ctor za novu prostoriju
        public frmNovaProstorijaIB220152()
        {
            InitializeComponent();
        }

        //ctor za editovanje prostorije
        public frmNovaProstorijaIB220152(ProstorijeIB220152 odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;

        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pbLogo.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {
                var logo = Ekstenzije.ToByteArray(pbLogo.Image);
                var naziv = tbNaziv.Text;
                var oznaka = tbOznaka.Text;
                var kapacitet = int.Parse(tbKapacitet.Text);

                if (odabranaProstorija == null)  //dodavanje
                {
                    var novaProstorija = new ProstorijeIB220152
                    {
                        Logo = logo,
                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet
                    };
                    db.ProstorijeIB220152.Add(novaProstorija);
                }
                else //editovanje
                {
                    odabranaProstorija.Logo = logo;
                    odabranaProstorija.Naziv = naziv;
                    odabranaProstorija.Oznaka = oznaka;
                    odabranaProstorija.Kapacitet = kapacitet;

                    db.ProstorijeIB220152.Update(odabranaProstorija);
                } 

                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(tbNaziv, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(tbOznaka, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(tbKapacitet, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaProstorijaIB220152_Load(object sender, EventArgs e)
        {
            if(odabranaProstorija != null)
            {
                UcitajInfo();
            }

        }

        private void UcitajInfo()
        {
            tbNaziv.Text = odabranaProstorija.Naziv;
            tbOznaka.Text = odabranaProstorija.Oznaka;
            tbKapacitet.Text = odabranaProstorija.Kapacitet.ToString();
            pbLogo.Image = Ekstenzije.ToImage(odabranaProstorija.Logo);
        }
    }
}
