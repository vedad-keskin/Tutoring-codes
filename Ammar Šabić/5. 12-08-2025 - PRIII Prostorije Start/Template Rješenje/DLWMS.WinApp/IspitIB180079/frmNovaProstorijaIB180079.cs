using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmNovaProstorijaIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        private ProstorijeIB180079? odabranaProstorija; // null -> dodavanje , nije null -> editovanje

        // dft. constr. --> za dodavanje nove prostorije 
        public frmNovaProstorijaIB180079()
        {
            InitializeComponent();
        }


        // user-def. --> za editovanje postojece prostorije
        public frmNovaProstorijaIB180079(ProstorijeIB180079? odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //C:\Users\ASUS\Desktop\C# Repos\Slike helpers\Classroom Logo.jpg
                pbLogo.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {
                // IMAGE -> BYTE[]

                var logo = pbLogo.Image.ToByteArray();
                //var logo = Ekstenzije.ToByteArray(pbLogo.Image);

                var naziv = txtNaziv.Text;
                var oznaka = txtOznaka.Text;

                // STRING -> INT 

                var kapacitet = int.Parse(txtKapacitet.Text); // 54

                if(odabranaProstorija == null) // add
                {

                    var novaProstorija = new ProstorijeIB180079()
                    {
                        //Id = 4, PROGRAM PUCA 
                        //Broj = 0, PROGRAM PUCA 

                        Naziv = naziv,
                        Oznaka = oznaka,
                        Kapacitet = kapacitet,
                        Logo = logo

                    };

                    db.ProstorijeIB180079.Add(novaProstorija);

                }
                else
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
            return Helpers.Validator.ProvjeriUnos(pbLogo, err, Kljucevi.RequiredField)
                &&
                Helpers.Validator.ProvjeriUnos(txtKapacitet, err, Kljucevi.RequiredField)
                &&
                Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.RequiredField)
                &&
                Helpers.Validator.ProvjeriUnos(txtOznaka, err, Kljucevi.RequiredField);
        }

        private void frmNovaProstorijaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odabranaProstorija != null)
            {

                txtNaziv.Text = odabranaProstorija.Naziv;
                txtOznaka.Text = odabranaProstorija.Oznaka;

                // INT -> STRING 
                txtKapacitet.Text = odabranaProstorija.Kapacitet.ToString();

                // BYTE[] -> IMAGE
                pbLogo.Image = odabranaProstorija.Logo.ToImage();

            }

        }
    }
}
