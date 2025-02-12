using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
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
    public partial class frmNovaDrzavaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private DrzaveIB180079 odabranaDrzava; // biti null ako radimo dodavanje

        // dft. constr. ---> za dodavanje nove drzave
        public frmNovaDrzavaIB180079()
        {
            InitializeComponent();
        }

        // user-def constr. ----> za editovanje postojece drzave
        public frmNovaDrzavaIB180079(DrzaveIB180079 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                var naziv = txtNaziv.Text;

                // IMAGE -> BYTE[]
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var status = chbStatus.Checked;


                if(odabranaDrzava == null) // radimo dodavanje
                {
                    var novaDrzava = new DrzaveIB180079()
                    {
                        Naziv = naziv,
                        Status = status,
                        Zastava = zastava
                    };

                    db.DrzaveIB180079.Add(novaDrzava);

                }
                else // radimo edit/modifikacija
                {

                    odabranaDrzava.Zastava = zastava;
                    odabranaDrzava.Naziv = naziv;
                    odabranaDrzava.Status = status;


                    db.DrzaveIB180079.Update(odabranaDrzava);

                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;


            }

        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) && Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaDrzavaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {

            if(odabranaDrzava != null) // edit
            {

                // BYTE[] -> IMAGE
                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);

                txtNaziv.Text = odabranaDrzava.Naziv;
                chbStatus.Checked = odabranaDrzava.Status;
            }


        }
    }
}
