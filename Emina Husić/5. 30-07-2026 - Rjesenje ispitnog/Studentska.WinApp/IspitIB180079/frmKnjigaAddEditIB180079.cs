using DocumentFormat.OpenXml.Spreadsheet;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using Studentska.WinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmKnjigaAddEditIB180079 : Form
    {
        KnjigaServis knjigaServis = new KnjigaServis();
        public frmKnjigaAddEditIB180079()
        {
            InitializeComponent();
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // C:\Users\Administrator\Desktop\C# Repos\Slike helpers\book3.jpg
                pbSlika.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {


                var naziv = txtNaziv.Text;

                var autor = txtAutor.Text;

                // STRING -> INT 
                var brojPrimjeraka = int.Parse(txtBrojPrimjeraka.Text);

                // IMAGE -> BYTE[] 
                var slika = ImageHelper.ImageToByte(pbSlika.Image);


                // Lista svih knjiga -> 


                if (knjigaServis.GetAll().Exists( x => x.Naziv.ToLower() == naziv.ToLower() && x.Autor.ToLower() == autor.ToLower()) )
                {

                    MessageBox.Show($"Knjiga sa nazivom {naziv} i autorom {autor} već postoji","Upozorenje",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }else if (brojPrimjeraka <= 0)
                {

                    MessageBox.Show($"Broj primjeraka mora biti veći od 0", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {



                    var novaKnjiga = new KnjigeIB180079()
                    {
                        //Id = 4, autoinc. ne smije se pohranjivati
                        Naziv = naziv,
                        Autor = autor,
                        BrojPrimjeraka = brojPrimjeraka,
                        Slika = slika
                    };

                    knjigaServis.Add(novaKnjiga);

                    DialogResult = DialogResult.OK;

                    //var novaKnjiga1 = new KnjigeIB180079();

                    //novaKnjiga1.Naziv = naziv;


                }




            }




        }

        private bool ValidirajUnos()
        {
            return Validator.ValidanUnos(pbSlika, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtNaziv, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtAutor, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtBrojPrimjeraka, err, "Obavezan unos");

        }
    }
}
