using DLWMS.Data;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void chbAktivan_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {

            var aktivan = chbAktivan.Checked;

            var drzava = cbDrzava.SelectedItem as Drzava;

            var spol = cbSpol.SelectedItem as Spol;

            var imePrezime = txtImePrezime.Text.ToLower(); // emina

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;


            var studenti = db.Studenti
                .Include(x => x.Grad.Drzava)
                .Include(x => x.Spol)
                .Where(x => x.Aktivan == aktivan)
                .Where(x => x.Grad.DrzavaId == drzava.Id)
                .Where(x => x.SpolId == spol.Id)
                .Where(x => x.Ime.ToLower().Contains(imePrezime)
                || x.Prezime.ToLower().Contains(imePrezime))
                .Where(x => x.DatumRodjenja >= datumOd 
                && x.DatumRodjenja <= datumDo)
                .ToList();

            if (studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;

            }
            
            if(studenti.Count() == 0)
            {
                MessageBox.Show($"U bazi nisu evidentirani studenti spola {spol}, koji u imenu i prezimenu posjeduju sadržaj {imePrezime}, a koji su državljani {drzava}.","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }


            this.Text = $"Broj prikazanih studenata: {studenti.Count()}";


        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            cbDrzava.DataSource = db.Drzave.ToList();

            cbSpol.DataSource = db.Spolovi.ToList();

        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void cbSpol_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }
    }
}
