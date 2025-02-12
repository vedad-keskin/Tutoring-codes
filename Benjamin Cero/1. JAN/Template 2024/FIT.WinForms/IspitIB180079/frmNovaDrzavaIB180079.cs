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
        private DrzaveIB180079 odbranaDrzava; // null ako radimo dodavanje

        public frmNovaDrzavaIB180079() // dft kontr. za dodvanje nove drzave
        {
            InitializeComponent();
        }

        // prima paramtear i koristi se za editovanje 
        public frmNovaDrzavaIB180079(DrzaveIB180079 odbranaDrzava)
        {
            InitializeComponent();
            this.odbranaDrzava = odbranaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // C:\Users\ASUS\Desktop\C# Repos\Slike helpers\jpn.jpg
                pbZastava.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {

            if (Validiraj())
            {

                // ToByteArray  IMAGE -> BYTE[]
                // ToImage      BYTE[] -> IMAGE

                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var naziv = txtNaziv.Text;
                var status = chbStatus.Checked;  // false true


                if(odbranaDrzava == null) // dodavanje
                {
                    var novaDrzava = new DrzaveIB180079()
                    {
                        // Id = 4, ne smije biti dodan jer je autoincrement
                        // Broj = 5, nije mapiran na bazi pa se ne smije slat

                        Naziv = naziv,
                        Status = status,
                        Zastava = zastava


                    };

                    db.DrzaveIB180079.Add(novaDrzava);

                }
                else // ako radimo modifikaciju
                {
                    odbranaDrzava.Naziv = naziv;
                    odbranaDrzava.Zastava = zastava;
                    odbranaDrzava.Status = status;

                    db.DrzaveIB180079.Update(odbranaDrzava);

                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }

        }

        private bool Validiraj()
        {
            return Helpers.Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) &&
                Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaDrzavaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {
            if(odbranaDrzava != null) // ako radimo modifikovanje
            {
                txtNaziv.Text = odbranaDrzava.Naziv;
                chbStatus.Checked = odbranaDrzava.Status;

                pbZastava.Image = Ekstenzije.ToImage(odbranaDrzava.Zastava);
                //pbZastava.Image = odbranaDrzava.Zastava.ToImage();

            }

        }
    }
}
