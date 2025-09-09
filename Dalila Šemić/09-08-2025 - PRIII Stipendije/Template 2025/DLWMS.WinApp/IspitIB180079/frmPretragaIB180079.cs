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

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }

        private void UcitajStudentiStipendije()
        {

            var godina = cbGodina?.SelectedItem?.ToString() ?? ""; // "2025" , "2024"

            // Id = 0 , Naziv = "" .. 
            var stipendija = cbStipendija?.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079();

            var studentStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodina.Godina == godina)
                .Where(x => x.StipendijaGodina.StipendijaId == stipendija.Id)
                .ToList();

            if (studentStipendije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentStipendije;

            }

            Text = $"Broj prikazanih studenata: {studentStipendije.Count()}";

            if (studentStipendije.Count() == 0 && stipendija.Id != 0)
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {godina}. godini dodijeljena {stipendija} stipendija.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiStipendije.AutoGenerateColumns = false;

            UcitajComboBox();
        }

        private void UcitajComboBox()
        {
            cbGodina.SelectedIndex = 0;

            cbStipendija.DataSource = db.StipendijeIB180079.ToList();
        }

        private void cbStipendija_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {



                if (MessageBox.Show("Da li ste sigurni da želite izbrisati odabranu stipendiju ? ", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    var odabranaStudentStipendija = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

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
    }
}
