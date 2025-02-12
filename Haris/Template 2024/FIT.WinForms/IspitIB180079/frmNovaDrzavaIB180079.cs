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

        public frmNovaDrzavaIB180079() // koji se koristi za dodavanje drzave
        {
            InitializeComponent();
        }

        public frmNovaDrzavaIB180079(DrzaveIB180079 odabranaDrzava) // kada radimo modifikaciju
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //                C:\Users\ASUS\Desktop\C# Repos\Slike helpers\egy.jpg
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var naziv = txtNaziv.Text;
                var status = chbStatus.Checked;

                if(odabranaDrzava == null) // dodavanje
                {

                    var novaDrzava = new DrzaveIB180079()
                    {
                        Naziv = naziv,
                        Zastava = zastava,
                        Status = status,

                    };

                    db.DrzaveIB180079.Add(novaDrzava);
                }
                else
                {

                    odabranaDrzava.Zastava = zastava;
                    odabranaDrzava.Naziv = naziv;
                    odabranaDrzava.Status = status;

                    db.DrzaveIB180079.Update(odabranaDrzava);

                    //db.Entry(odabranaDrzava).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
            if (odabranaDrzava != null) // modifkiacija
            {

                txtNaziv.Text = odabranaDrzava.Naziv;
                chbStatus.Checked = odabranaDrzava.Status;
                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
                //pbZastava.Image = odabranaDrzava.Zastava.ToImage();
            }

        }
    }
}
