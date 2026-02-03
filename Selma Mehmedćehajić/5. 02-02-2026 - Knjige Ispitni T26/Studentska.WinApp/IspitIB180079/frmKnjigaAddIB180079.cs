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
        private KnjigeIB180079 knjiga;

        public frmKnjigaAddIB180079()
        {
            InitializeComponent();
        }

        public frmKnjigaAddIB180079(KnjigeIB180079 knjiga)
        {
            InitializeComponent();
            this.knjiga = knjiga;
        }

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                pbSlika.Image = Image.FromFile(ofd.FileName);

            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (ValidirajUnos())
            {

                var naziv = txtNaziv.Text;
                var autor = txtAutori.Text;

                var broj = int.Parse(txtBroj.Text);

                var slika = ImageHelper.ImageToByte(pbSlika.Image);


                if (broj <= 0)
                {

                    MessageBox.Show("Broj primjeraka ne može biti 0 ili negativan broj", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (knjigeServis.GetAll().Exists(x =>
                x.Naziv.ToLower() == naziv.ToLower()
                && x.Autor.ToLower() == autor.ToLower()))
                {

                    MessageBox.Show("Dodata knjiga već postoji", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (knjiga != null) // editovanje
                {

                    var odabranaUntrackedKnjiga = knjigeServis.GetById(knjiga.Id);

                    odabranaUntrackedKnjiga.Naziv = naziv;
                    odabranaUntrackedKnjiga.Autor = autor;
                    odabranaUntrackedKnjiga.BrojPrimjeraka = broj;
                    odabranaUntrackedKnjiga.Slika = slika;

                    knjigeServis.Update(odabranaUntrackedKnjiga);

                    DialogResult = DialogResult.OK;

                }

                else
                {

                    var novaKnjiga = new KnjigeIB180079()
                    {
                        Naziv = naziv,
                        Autor = autor,
                        BrojPrimjeraka = broj,
                        Slika = slika


                    };

                    knjigeServis.Add(novaKnjiga);

                    DialogResult = DialogResult.OK;

                }



            }

        }

        private bool ValidirajUnos()
        {
            return Validator.ValidanUnos(pbSlika, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtNaziv, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtAutori, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtBroj, err, "Obavezan unos");
        }

        private void frmKnjigaAddIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(knjiga != null)
            {

                pbSlika.Image = ImageHelper.ByteToImage(knjiga.Slika);

                txtNaziv.Text = knjiga.Naziv;
                txtAutori.Text = knjiga.Autor;
                txtBroj.Text = knjiga.BrojPrimjeraka.ToString();

            }

        }
    }
}
