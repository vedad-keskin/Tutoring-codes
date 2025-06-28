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
            dgvStudentStipendije.AutoGenerateColumns = false;

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
            var godina = cbGodina.SelectedItem?.ToString() ?? ""; // "2025" , "2024" 

            var stipendija = cbStipendija.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079();


            studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodina.Godina == godina)
                .Where(x => x.StipendijaGodina.StipendijaId == stipendija.Id)
                .ToList();

            this.Text = $"Broj prikazanih studenata {studentiStipendije.Count()}";

            if (studentiStipendije != null)
            {

                dgvStudentStipendije.DataSource = null;
                dgvStudentStipendije.DataSource = studentiStipendije;

            }

            //if(studentiStipendije.Count() == 0)
            //{

            //    MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {godina}. godini dodijeljena {stipendija} stipendija","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            //}

        }

        private void dgvStudentStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                var odabranaStudentStipendija = studentiStipendije[e.RowIndex];
                //var odabranaStudentStipendija2 = dgvStudentStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

                if (MessageBox.Show("Da li ste sigurni da želite ukloniti odabranu stipendiju ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipendija);
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

        private void btnStipendije_Click(object sender, EventArgs e)
        {
            var frmStipendije = new frmStipendijeIB180079();

            if(frmStipendije.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiStipendije();

            }


        }
    }
}
