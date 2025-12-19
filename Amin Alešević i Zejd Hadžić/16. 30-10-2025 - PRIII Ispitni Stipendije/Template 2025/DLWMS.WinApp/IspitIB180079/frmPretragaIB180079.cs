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
        // Veza sa bazom

        DLWMSContext db = new DLWMSContext();



        // dft. constr.
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
            //studentStipendije[0] = 1	1	1 1	Denis	Mušić	IB2400001	2024-12-11 13:02:21.1642863	denis.music@fit.ba	tpRYHTp/ep&fQ)i	2	3	BLOB 1	1	2025	200	11	Umjetnička
            //studentStipendije[1] = 2	2	2
            //studentStipendije[2] = 3	3	3

            var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;

            var studentStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();

            if (studentStipendije != null)
            {
                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentStipendije;
            }

            Text = $"Broj prikazanih studenata: {studentStipendije.Count()}";

            if (studentStipendije.Count() == 0)
            {

                MessageBox.Show($"U bazi nisu evidentirani studenti kojima je u {cbGodina.SelectedItem}. godini dodijeljena {odabranaStipendijaGodina} stipendija", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {

            var odabranaGodina = cbGodina?.SelectedItem?.ToString() ?? "2025"; // "2025" "2024"


            var odabraneStipendijeGodine = db.StipendijeGodineIB180079
                .Where(x => x.Godina == odabranaGodina)
                .Include(x => x.Stipendija)
                .ToList();

            cbStipendijaGodina.DataSource = odabraneStipendijeGodine;

            if (odabraneStipendijeGodine.Count() == 0)
            {
                dgvStudentiStipendije.DataSource = null;
                Text = "Broj prikazanih studenata: 0";
                MessageBox.Show($"U bazi ne postoje stipendije na {odabranaGodina} godini", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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


                if (MessageBox.Show("Da li ste sigurni da želite izbrisati odabrani zapis ?", "Pitanje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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

            var frmAddStipendija = new frmStipendijaAddEditIB180079();


            if (frmAddStipendija.ShowDialog() == DialogResult.OK)
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
