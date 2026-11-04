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

        private void btnUcitajSliku_Click(object sender, EventArgs e)
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

                var naziv = txtNaziv.Text;
                var autor = txtAutor.Text;

                // STRING -> INT
                var brojPrimjeraka = int.Parse(txtBrojPrimjeraka.Text);

                // IMAGE -> BYTE[]
                var slika = ImageHelper.ImageToByte(pbSlika.Image);


                //var novaKnjiga = new KnjigeIB180079();

                //novaKnjiga.Autor = autor;
                //novaKnjiga.Naziv = naziv;

                if (brojPrimjeraka <= 0)
                {

                    MessageBox.Show("Broj primjeraka ne smije biti 0 ili negativna vrijednost","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
                else if (knjigeServis.GetAll().Exists(x => x.Naziv.ToLower().Trim() == naziv.ToLower().Trim() && x.Autor.ToLower().Trim() == autor.ToLower().Trim())   )
                {

                    MessageBox.Show("Naziv knjige i autor već postoje", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    var novaKnjiga = new KnjigeIB180079()
                    {
                        //Id = 1, // AI 
                        Naziv = naziv,
                        Autor = autor,
                        BrojPrimjeraka = brojPrimjeraka,
                        Slika = slika
                    };


                    knjigeServis.Add(novaKnjiga);

                    DialogResult = DialogResult.OK;

                }



            }



        }

        private bool ValidirajUnos()
        {
            return Helpers.Validator.ValidanUnos(pbSlika, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtAutor, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtNaziv, err, "Obavezan unos") &&
                Helpers.Validator.ValidanUnos(txtBrojPrimjeraka, err, "Obavezan unos");
        }
    }
}
