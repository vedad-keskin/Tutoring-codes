using DLWMS.Data.IspitIB180079;
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
        List<StudentiStipendijeIB180079> studentiStipendije;
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiStipendija.AutoGenerateColumns = false;

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbGodina.SelectedIndex = 0;

            cbStipendija.DataSource = db.StipendijeIB180079.ToList();

        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }


        private void cbStipendija_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();

        }
        private void UcitajStudentiStipendije()
        {

            var odabranaGodina = cbGodina.SelectedItem.ToString() ?? "";

            var odabranaStipendija = cbStipendija.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079();

            var imePrezime = txtImePrezime.Text.ToLower();

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;

            studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodina.Godina == odabranaGodina)
                .Where(x => x.StipendijaGodina.StipendijaId == odabranaStipendija.Id)
                .Where(x => x.Student.Ime.ToLower().Contains(imePrezime) || x.Student.Prezime.ToLower().Contains(imePrezime))
                .Where(x=> x.Student.DatumRodjenja >= datumOd && x.Student.DatumRodjenja <= datumDo )
                .ToList();


            this.Text = $"Broj prikazanih studenata: {studentiStipendije.Count()}";

            //if (studentiStipendije.Count() == 0)
            //{
            //    MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {odabranaGodina}. godini dodijeljena {odabranaStipendija} stipendija", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}

            if (studentiStipendije != null)
            {

                dgvStudentiStipendija.DataSource = null;
                dgvStudentiStipendija.DataSource = studentiStipendije;

            }


        }

        private void dgvStudentiStipendija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {

                var odabranaStudentStipendija = studentiStipendije[e.RowIndex];
                //var odabranaStudentStipendija2 = dgvStudentiStipendija.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

                if (MessageBox.Show("Da li ste sigurni da želite ukloniti odabranu stipendiju ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipendija);
                    db.SaveChanges();

                    UcitajStudentiStipendije();


                }



            }

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            var frmAddStipendija = new frmStipendijaAddEditIB180079();

            if (frmAddStipendija.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentiStipendije();
            }

        }

        private void btnStipendije_Click(object sender, EventArgs e)
        {
            var frmStipendije = new frmStipendijeIB180079();

            if (frmStipendije.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentiStipendije();
            }
        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();

        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }
    }
}
