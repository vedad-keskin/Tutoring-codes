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

            cbOcjenaDo.SelectedIndex = 0;
            cbOcjenaOd.SelectedIndex = 0;
        }
        private void UcitajStudente()
        {
            var ocjenaOd = cbOcjenaOd.SelectedItem == null ? 6 : int.Parse(cbOcjenaOd.SelectedItem.ToString());
            var ocjenaDo = cbOcjenaDo.SelectedItem == null ? 10 : int.Parse(cbOcjenaDo.SelectedItem.ToString());

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;

            var predmet = txtNaziv.Text.ToLower();

            var aktivan = chbAktivan.Checked;


            polozeni = db.PolozeniPredmeti
                .Where(x => (x.Ocjena >= ocjenaOd && x.Ocjena <= ocjenaDo)
                && (x.DatumPolaganja >= datumOd && x.DatumPolaganja <= datumDo)
                && (x.Predmet.Naziv.ToLower().Contains(predmet))
                && (x.Student.Aktivan == aktivan)
                )
                .Include(x => x.Student)
                .Include(x => x.Predmet)
                .ToList();


            if (polozeni != null)
            {
                dgvPolozeniPredmeti.DataSource = null;
                dgvPolozeniPredmeti.DataSource = polozeni;
            }

        }

        private void cbOcjenaOd_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }


        private void cbOcjenaDo_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtNaziv_TextChanged(object sender, EventArgs e)
        {

            UcitajStudente();
        }

        private void chbAktivan_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudente();

        }

        private void dgvPolozeniPredmeti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabraniPolzeniPredmeti = polozeni[e.RowIndex];

            if(e.ColumnIndex == 6)
            {
                frmPorukeIB180079 frmPoruke = new frmPorukeIB180079(odabraniPolzeniPredmeti.Student);
                frmPoruke.ShowDialog();

            }
        }
    }
}
