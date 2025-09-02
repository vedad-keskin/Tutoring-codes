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

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }


        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiStipendije.AutoGenerateColumns = false;

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbStipendija.DataSource = db.StipendijeIB180079.ToList();

            cbGodina.SelectedIndex = 0;
        }
        private void UcitajStudentiStipendije()
        {
            var odabranaGodina = cbGodina.SelectedItem?.ToString() ?? ""; // 2025

            var odabranaStipendija = cbStipendija.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079(); // null 

            studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodina.Godina == odabranaGodina)
                .Where(x => x.StipendijaGodina.StipendijaId == odabranaStipendija!.Id)
                .ToList();


            if (studentiStipendije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentiStipendije;

            }

            Text = $"Broj prikazanih studenata: {studentiStipendije.Count()}";

            //if(studentiStipendije.Count() == 0)
            //{

            //    MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {odabranaGodina}. godini dodijeljena {odabranaStipendija} stipendija", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}



        }

        private void cbStipendija_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();

        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                //var odabranaStudentStipendija1 = studentiStipendije[e.RowIndex];
                var odabranaStudentStipendija2 = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

                if (MessageBox.Show("Da li ste sigurni da želite pobrisati odabranu stipendiju ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipendija2);
                    db.SaveChanges();

                    UcitajStudentiStipendije();

                }


            }

        }

        private void btnDodajStipendiju_Click(object sender, EventArgs e)
        {

            var frmAddStipendija = new frmStipendijaAddEditIB180079();

            if (frmAddStipendija.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiStipendije();

            }

        }

        private void btnStipendijePoGodinama_Click(object sender, EventArgs e)
        {

            var frmStipendije = new frmStipendijeIB180079();

            if (frmStipendije.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentiStipendije();
            }


        }

        private void dgvStudentiStipendije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex < 5)
            {
                //var odabranaStudentStipendija1 = studentiStipendije[e.RowIndex];
                var odabranaStudentStipendija = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

                var frmEditStipendija = new frmStipendijaAddEditIB180079(odabranaStudentStipendija);

                if (frmEditStipendija.ShowDialog() == DialogResult.OK)
                {

                    UcitajStudentiStipendije();

                }

            }

        }
    }
}
