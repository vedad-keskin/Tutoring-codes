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
    public partial class frmPretraga2IB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmPretraga2IB180079()
        {
            InitializeComponent();
        }

        private void frmPretraga2IB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbSpol.DataSource = db.Spolovi.ToList();

            cbDrzava.DataSource = db.Drzave.ToList();
        }

        private void cbSpol_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {

            var spol = cbSpol?.SelectedItem as Spol ?? new Spol();

            var drzava = cbDrzava?.SelectedItem as Drzava ?? new Drzava();

            var imePrezime = txtImePrezime.Text.ToLower(); // GORAN -> goran

            var aktivan = chbAktivan.Checked; // true ili false

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;


            var studenti = db.Studenti
                .Include(x => x.Spol)
                .Include(x => x.Grad.Drzava)
                .Where(x => x.SpolId == spol.Id)
                .Where(x => x.Grad.DrzavaId == drzava.Id)
                .Where(x => x.Ime.ToLower().Contains(imePrezime) || x.Prezime.ToLower().Contains(imePrezime))
                .Where(x => x.Aktivan == aktivan)
                .Where(x => x.DatumRodjenja >= datumOd && x.DatumRodjenja <= datumDo)
                .ToList();

            if (studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;

            }



        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void chbAktivan_CheckedChanged(object sender, EventArgs e)
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
