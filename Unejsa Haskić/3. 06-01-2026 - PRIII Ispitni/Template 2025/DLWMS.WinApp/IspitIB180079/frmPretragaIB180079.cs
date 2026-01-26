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

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            // •	Microsoft.Data.Sqlite.SqliteException: 'SQLite Error 1: 'no such column: s.StipenijId'.'
            // NullReferenceException

            var odabranaGodina = cbGodina?.SelectedItem?.ToString() ?? "N/A"; // "2025" , "2026"


            // 1	1	2026	230	1
            // 1	Umjetnička

            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == odabranaGodina)
                .ToList();

            if (stipendijeGodine.Count() == 0)
            {

                dgvStudentiStipendije.DataSource = null;

                MessageBox.Show($"Ne postoji niti jedna stipendiju u {odabranaGodina} godini.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Text = $"Broj prikazanih studenata: 0";

            }

            cbStipendijaGodina.DataSource = stipendijeGodine;

        }

        private void cbStipendijaGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentStipendije();
        }

        private void UcitajStudentStipendije()
        {

            // 1	1	2026	230	1

            var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;


            // 1	1	1


            var studentStipedije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();


            if (studentStipedije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentStipedije;

            }

            if (studentStipedije.Count() == 0)
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {odabranaStipendijaGodina.Godina}. godini dodijeljena {odabranaStipendijaGodina} stipendija", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Text = $"Broj prikazanih studenata: {studentStipedije.Count()}";


        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {

                var odabranaStudentStipendija = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;


                if (MessageBox.Show("Da li ste sigurni da želite obrisati odabrani podatak ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipendija);

                    db.SaveChanges();

                    UcitajStudentStipendije();

                }




            }

        }

        private void btnStipendijePoGodinama_Click(object sender, EventArgs e)
        {

            var frmStipendije = new frmStipendijeIB180079();

            if(frmStipendije.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentStipendije();

            }

        }
    }
}
