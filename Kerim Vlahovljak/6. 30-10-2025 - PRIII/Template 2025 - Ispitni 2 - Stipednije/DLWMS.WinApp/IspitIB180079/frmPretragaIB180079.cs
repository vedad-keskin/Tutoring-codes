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
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiStipendije.AutoGenerateColumns = false;

            cbGodina.SelectedIndex = 0;


        }

        private void UcitajStudentStipendije()
        {

            var odabranaStipendijaGodina = cbStipendijaGodina?.SelectedItem as StipendijeGodineIB180079 ?? new StipendijeGodineIB180079();

            var studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();


            if (studentiStipendije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentiStipendije;

            }

            Text = $"Broj prikazanih studenata: {studentiStipendije.Count()}";

            if (studentiStipendije.Count() == 0)
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cbGodina.SelectedItem}. godini dodijeljena {odabranaStipendijaGodina} stipendija", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {

            var odabranaGodina = cbGodina?.SelectedItem?.ToString() ?? "2025"; // "2025"

            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == odabranaGodina)
                .ToList();

            cbStipendijaGodina.DataSource = stipendijeGodine;

            if (stipendijeGodine.Count() == 0)
            {
                dgvStudentiStipendije.DataSource = null;
                Text = $"Broj prikazanih studenata: 0";
                MessageBox.Show($"U bazi nisu evidentirani stipendije za studente u {odabranaGodina} godini", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void cbStipendijaGodina_SelectedIndexChanged(object sender, EventArgs e)
        {

            UcitajStudentStipendije();

        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {

                if (MessageBox.Show("Da li ste sigurni da želite pobrisati odabrani zapis ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    var odabranaStudentStipendija = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipendija);

                    db.SaveChanges();

                    UcitajStudentStipendije();

                }


            }


        }

        private void btnDodajStipendiju_Click(object sender, EventArgs e)
        {

            var frmStipendijaAdd = new frmStipendijaAddEditIB180079();

            if (frmStipendijaAdd.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentStipendije();
            }


        }

        private void btnStipendije_Click(object sender, EventArgs e)
        {
            var frmStipendije = new frmStipendijeIB180079();

            if (frmStipendije.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentStipendije();
            }
        }
    }
}
