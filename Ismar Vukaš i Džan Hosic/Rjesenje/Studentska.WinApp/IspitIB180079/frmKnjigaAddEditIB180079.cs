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
    public partial class frmKnjigaAddEditIB180079 : Form
    {

        KnjigaServis knjigaServis = new KnjigaServis();

        public frmKnjigaAddEditIB180079()
        {
            InitializeComponent();
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {

            if (ofdSlika.ShowDialog() == DialogResult.OK)
            {
                //              C:\Users\Administrator\Desktop\C# Repos\Slike helpers\book4.jpg
                pbSlika.Image = Image.FromFile(ofdSlika.FileName);
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


                //var novaKnjiga = new KnjigeIB180079();

                //novaKnjiga.Naziv = naziv;
                //novaKnjiga.Autor = autor;
                //novaKnjiga.BrojPrimjeraka = brojPrimjeraka;
                //novaKnjiga.Slika = slika;

                if(brojPrimjeraka <= 0)
                {

                    MessageBox.Show("Broj primjeraka ne smije biti 0 ili negativna vrijednost","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
                else if (knjigaServis.GetAll().Exists(x => x.Naziv.ToLower() == naziv.ToLower() && x.Autor.ToLower() == autor.ToLower()))
                {

                    MessageBox.Show("Knjiga istog naziva i istog autora već postoji", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    var novaKnjiga = new KnjigeIB180079()
                    {

                        Naziv = naziv,
                        Autor = autor,
                        BrojPrimjeraka = brojPrimjeraka,
                        Slika = slika

                    };

                    knjigaServis.Add(novaKnjiga);

                    DialogResult = DialogResult.OK;


                }




            }


        }

        private bool ValidirajUnos()
        {
            return Helpers.Validator.ValidanUnos(pbSlika, err, "Ovo polje je obavezno") &&
                Helpers.Validator.ValidanUnos(txtNaziv, err, "Ovo polje je obavezno") &&
                Helpers.Validator.ValidanUnos(txtAutor, err, "Ovo polje je obavezno") &&
                Helpers.Validator.ValidanUnos(txtBrojPrimjeraka, err, "Ovo polje je obavezno");
        }
    }
}
