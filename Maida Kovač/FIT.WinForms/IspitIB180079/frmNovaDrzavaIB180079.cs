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
        private DrzaveIB180079 kliknutaDrzava;

        public frmNovaDrzavaIB180079()
        {
            InitializeComponent();
        }

        public frmNovaDrzavaIB180079(DrzaveIB180079 kliknutaDrzava)
        {
            InitializeComponent();
            this.kliknutaDrzava = kliknutaDrzava;
        }

        private void pbZastava_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //                C:\Users\ASUS\Desktop\C# Repos\Slike helpers\swd.jpg
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


                var novaDrzava = new DrzaveIB180079()
                {
                    Zastava = zastava,
                    Status = status,
                    Naziv = naziv

                };

                db.DrzaveIB180079.Add(novaDrzava);
                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }



        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) &&
                   Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }

        private void frmNovaDrzavaIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();
        }

        private void UcitajInfo()
        {

            if(kliknutaDrzava != null) // modifikacija 
            {

                pbZastava.Image = Ekstenzije.ToImage(kliknutaDrzava.Zastava);
                txtNaziv.Text = kliknutaDrzava.Naziv;
                chbStatus.Checked = kliknutaDrzava.Status;
            }

        }
    }
}
