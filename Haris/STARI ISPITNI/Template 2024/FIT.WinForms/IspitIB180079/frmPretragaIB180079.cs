using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
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

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<PolozeniPredmetiIB180079> polozeni;
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvPolozeniPredmeti.AutoGenerateColumns = false;

            cbOcjenaOd.SelectedIndex = 0;
            cbOcjenaDo.SelectedIndex = 0;
        }
        private void UcitajPolozenePredmete()
        {

            var aktivan = chbAktivan.Checked;
            var naziv = txtNaziv.Text.ToLower();

            var ocjenaOd = cbOcjenaOd.SelectedItem == null ? 6 : int.Parse(cbOcjenaOd.SelectedItem.ToString());
            var ocjenaDo = cbOcjenaDo.SelectedItem == null ? 10 : int.Parse(cbOcjenaDo.SelectedItem.ToString());

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;


            polozeni = db.PolozeniPredmeti
                .Include(x=> x.Student)
                .Include(x=> x.Predmet)
                .Where(x=> (x.Student.Aktivan == aktivan)
                && (x.Predmet.Naziv.ToLower().Contains(naziv))
                && (x.Ocjena >= ocjenaOd && x.Ocjena <= ocjenaDo)
                && (x.DatumPolaganja >= datumOd && x.DatumPolaganja <= datumDo)
                )
                .ToList();

            if(polozeni != null)
            {

                dgvPolozeniPredmeti.DataSource = null;
                dgvPolozeniPredmeti.DataSource = polozeni;
            }


        }

        private void txtNaziv_TextChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }


        private void chbAktivan_CheckedChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }

        private void cbOcjenaOd_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }

        private void cbOcjenaDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajPolozenePredmete();
        }
    }
}
