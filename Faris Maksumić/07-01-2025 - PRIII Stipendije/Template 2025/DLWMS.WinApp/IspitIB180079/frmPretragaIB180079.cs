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

            // 1	1	5
            // 1	Denis	Mušić	IB2400001	2024-12-11 13:02:21.1642863	denis.music@fit.ba
            // 1	1	2025	230	0
            // 1	Umjetnička

            var odabranaStipendijaGodina = cbStipendijaGodina.SelectedItem as StipendijeGodineIB180079;



            var studentStipednije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .Where(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();



            if (studentStipednije != null)
            {

                dgvStudentiStipendije.DataSource = null;
                dgvStudentiStipendije.DataSource = studentStipednije;

            }

            Text = $"Broj prikazanih studenata {studentStipednije.Count()}";


        }

        private void cbGodina_SelectedIndexChanged(object sender, EventArgs e)
        {

            var odabranaGodina = cbGodina?.SelectedItem?.ToString() ?? "2026"; // "2025" , "2024" .. 


            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .Where(x => x.Godina == odabranaGodina)
                .ToList();

            if(stipendijeGodine.Count() == 0)
            {

                dgvStudentiStipendije.DataSource = null;
                Text = $"Broj prikazanih studenata 0";

            }

            cbStipendijaGodina.DataSource = stipendijeGodine;



        }

        private void cbStipendijaGodina_SelectedIndexChanged(object sender, EventArgs e)
        {

            UcitajStudentStipendije();

        }
    }
}
