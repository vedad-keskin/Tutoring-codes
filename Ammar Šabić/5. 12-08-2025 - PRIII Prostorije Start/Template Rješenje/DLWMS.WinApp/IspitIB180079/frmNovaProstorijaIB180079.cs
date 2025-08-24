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
        public frmNovaProstorijaIB180079()
        {
            InitializeComponent();
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
    }
}
