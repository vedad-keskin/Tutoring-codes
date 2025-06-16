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
            dgvStudentiStipendije.AutoGenerateColumns = false;

            UcitajComboBox();
        }

        private void UcitajComboBox()
        {
            cbGodina.SelectedIndex = 0;

            cbStipendije.DataSource = db.StipendijeIB180079.ToList();

        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }


        private void cbStipendije_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiStipendije();
        }
        private void UcitajStudentiStipendije()
        {
            var godina = cbGodina.SelectedItem?.ToString() ?? string.Empty;

            var stipendija = cbStipendije.SelectedItem as StipendijeIB180079 ?? new StipendijeIB180079();

            var studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodina.Godina == godina)
                .Where(x => x.StipendijaGodina.StipendijaId == stipendija.Id)
                .ToList();

            if (studentiStipendije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentiStipendije;
            }

            //if(studentiStipendije.Count() == 0)
            //{

            //    MessageBox.Show("Ne postoje zapisi koji zadovoljavaju pretragu");
            //}
        }

        private void dgvStudentiStipendije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //var odabranaStudentStipedija1 = studentiStipendije[e.RowIndex];
            var odabranaStudentStipedija2 = dgvStudentiStipendije.SelectedRows[0].DataBoundItem as StudentiStipendijeIB180079;

            if (e.ColumnIndex == 5)
            {

                if (MessageBox.Show("Da li ste sigurni da želite obrisati odabranu stipendiju?","Pitanje",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {

                    db.StudentiStipendijeIB180079.Remove(odabranaStudentStipedija2);
                    db.SaveChanges();
                    UcitajStudentiStipendije();

                }


            }
        }
    }
}
