using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data;
using FIT.Data.IspitIB230030;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmNovaDrzavaIB230030 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private DrzaveIB230030 odabranaDrzava;

        public frmNovaDrzavaIB230030()
        {
            InitializeComponent();
        }

        public frmNovaDrzavaIB230030(DrzaveIB230030 odabranaDrzava)
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
            if (Validacija())
            {
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image);
                var naziv = txtNaziv.Text;
                var status = chbStatus.Checked;

                if (odabranaDrzava == null)
                {
                    var NovaDrzava = new DrzaveIB230030()
                    {
                        Naziv = naziv,
                        Zastava = zastava,
                        Status = status
                    };

                    db.DrzaveIB230030.Add(NovaDrzava);
                }
                else {
                    odabranaDrzava.Zastava = zastava;
                    odabranaDrzava.Naziv = naziv;
                    odabranaDrzava.Status = status;

                    db.DrzaveIB230030.Update(odabranaDrzava);
                }
                
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validacija()
        {
            return Helpers.Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue)
                && Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);

        }

        private void frmNovaDrzavaIB230030_Load(object sender, EventArgs e)
        {
            ucitajInfo();
        }

        private void ucitajInfo()
        {
            if (odabranaDrzava != null)
            {
                pbZastava.Image = Ekstenzije.ToImage(odabranaDrzava.Zastava);
                txtNaziv.Text = odabranaDrzava.Naziv;
                chbStatus.Checked = odabranaDrzava.Status;
            }
        }
    }
}
