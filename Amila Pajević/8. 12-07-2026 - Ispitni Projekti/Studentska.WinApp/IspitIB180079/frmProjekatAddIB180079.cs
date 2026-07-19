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

                var rok = dtpRokZavrsetka.Value;

                var aktivan = chbAktivan.Checked;


                //  Projekat 1
                if (projektiServis.GetAll().Exists(x => x.Naziv.ToLower().Trim() == naziv.ToLower().Trim())) 
                {

                    MessageBox.Show("Već postoji projekat sa istim nazivom", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }else if (rok < DateTime.Now)
                {

                    MessageBox.Show("Rok završetka projekta ne smije biti manji od trenutnog datuma", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }else if(max < 1)
                {

                    MessageBox.Show("Maksimalan broj studenta na projektu ne smije biti manji od 1", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    var noviProjekat = new ProjektiIB180079()
                    {

                        Naziv = naziv,
                        Napomena = napomena,
                        Logo = logo,
                        RokZavrsetka = rok,
                        MaxBrojStudenata = max,
                        Aktivan = aktivan,

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
