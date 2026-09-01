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
    public partial class frmProjekatAddIB180079 : Form
    {
        ProjektiServis projektiServis = new ProjektiServis();
        public frmProjekatAddIB180079()
        {
            InitializeComponent();
        }

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {

                var logo = ImageHelper.ImageToByte(pbLogo.Image);

                var naziv = txtNaziv.Text;
                var napomena = txtNapomena.Text;

                var max = int.Parse(txtMaxBrojStudenata.Text);

                var aktivan = chbAktivan.Checked;

                var rok = dtpRokZavrsetka.Value;


                if (projektiServis.GetAll().Exists(x => x.Naziv.ToLower().Trim() == naziv.ToLower().Trim()))
                {

                    MessageBox.Show($"Projekat sa nazivom {naziv} već postoji", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }else if ( rok < DateTime.Now)
                {
                    MessageBox.Show($"Rok završetka je manji od trenutnog datuma", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }else if (max < 1)
                {
                    MessageBox.Show($"Maksimalan broj studenata mora biti veci od 0", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    var noviProjekat = new ProjektiIB180079()
                    {
                        Naziv = naziv,
                        Napomena = napomena,
                        Logo = logo,
                        MaxBrojStudenata = max,
                        Aktivan = aktivan,
                        RokZavrsetka = rok
                    };

                    projektiServis.Add(noviProjekat);

                    DialogResult = DialogResult.OK;

                }






            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ValidanUnos(pbLogo, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtNaziv, err, "Obavezan unos") &&
                Validator.ValidanUnos(txtMaxBrojStudenata, err, "Obavezan unos");
        }
    }
}
