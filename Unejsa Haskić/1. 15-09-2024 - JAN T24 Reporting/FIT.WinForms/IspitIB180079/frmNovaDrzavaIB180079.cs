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
        private DrzaveIB180079 odabranaDrzava;

        // za dodvanje nove drzave
        public frmNovaDrzavaIB180079()
        {
            InitializeComponent();
        }


        // za editovanje postojece drzave
        public frmNovaDrzavaIB180079(DrzaveIB180079 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //C:\Users\ASUS\Desktop\C# Repos\Slike helpers\jpn.png
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                // IMAGE -> BYTE[] 
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);

                var naziv = txtNaziv.Text;
                var status = chbStatus.Checked; // true false

                if(odabranaDrzava == null)
                {
                    var novaDrzava = new DrzaveIB180079()
                    {
                        // Id = 1, on je autoincrement
                        // Broj = 3, baza puca

                        Naziv = naziv,
                        Status = status,
                        Zastava = zastava

                    };

                    db.DrzaveIB180079.Add(novaDrzava);

                }
                else
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
            return Helpers.Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) &&
                Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaDrzavaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odabranaDrzava != null)
            {
                // BYTE[] -> IMAGE
                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);

                txtNaziv.Text = odabranaDrzava.Naziv;
                chbStatus.Checked = odabranaDrzava.Status;

            }
        }
    }
}
