using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
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

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmNovaDrzavaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmNovaDrzavaIB180079()
        {
            InitializeComponent();
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
                
                var naziv = txtNaziv.Text;

                var status = chbStatus.Checked; // true false

                // IMAGE -> BYTE[]
                var zastava = Ekstenzije.ToByteArray(pbZastava.Image); // IMAGE


                var novaDrzava = new DrzaveIB180079()
                {
                    // Id = 4, // BAZA PUCA 
                    // Broj = 0, // BAZA PUCA

                    Naziv = naziv,
                    Status = status,
                    Zastava = zastava

                };

                db.DrzaveIB180079.Add(novaDrzava);
                db.SaveChanges();

                DialogResult = DialogResult.OK;




            }
            
        }

        private bool Validiraj()
        {
            return 
                Helpers.Validator.ProvjeriUnos(pbZastava, err, Kljucevi.ReqiredValue) && 
                Helpers.Validator.ProvjeriUnos(txtNaziv, err, Kljucevi.ReqiredValue);
        }
    }
}
