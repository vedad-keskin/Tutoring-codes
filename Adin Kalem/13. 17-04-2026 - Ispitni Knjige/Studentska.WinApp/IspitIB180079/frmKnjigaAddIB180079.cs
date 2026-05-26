using Microsoft.ReportingServices.Interfaces;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using Studentska.WinApp.Helpers;
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

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmKnjigaAddIB180079 : Form
    {
        KnjigeServis knjigeServis = new KnjigeServis();
        public frmKnjigaAddIB180079()
        {
            InitializeComponent();
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // C:\Users\Administrator\Desktop\C# Repos\Slike helpers\book4.jpg
                pbSlika.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                // IMAGE -> BYTE[]
                var slika = ImageHelper.ImageToByte(pbSlika.Image);

                var naziv = txtNaziv.Text;
                var autor = txtAutor.Text;

                // STRING -> INT
                var broj = int.Parse(txtBrojPrimjeraka.Text);


                if (knjigeServis.GetAll().Exists(x => x.Naziv.ToLower() == naziv.ToLower() && x.Autor.ToLower() == autor.ToLower()))
                {
                    MessageBox.Show($"Postoji knjiga {naziv} autora {autor}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (broj == 0 || broj < 0 )
                {
                    MessageBox.Show($"Broj je nula ili negativna vrijednost", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    var novaKnjiga = new KnjigeIB180079()
                    {

                        Slika = slika,
                        Naziv = naziv,
                        Autor = autor,
                        BrojPrimjeraka = broj

                    };

                    knjigeServis.Add(novaKnjiga);

                    DialogResult = DialogResult.OK;

                }

        
            }

        }

        private bool ValidirajUnos()
        {

            return Helpers.Validator.ValidanUnos(pbSlika, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtNaziv, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtAutor, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtBrojPrimjeraka, err, "Obavezan unos");

        }
    }
}
