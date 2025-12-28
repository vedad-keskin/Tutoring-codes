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
    public partial class frmStipendijeIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmStipendijeIB180079()
        {
            InitializeComponent();
        }

        private void frmStipendijeIB180079_Load(object sender, EventArgs e)
        {
            dgvStipendijeGodine.AutoGenerateColumns = false;

            UcitajStipendijeGodine();

        }

        private void UcitajStipendijeGodine()
        {
            var stipendijeGodine = db.StipendijeGodineIB180079
                .Include(x => x.Stipendija)
                .ToList();


            if (stipendijeGodine != null)
            {
                dgvStipendijeGodine.DataSource = null;
                dgvStipendijeGodine.DataSource = stipendijeGodine;
            }


        }

        private void dgvStipendijeGodine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaStipendijaGodina = dgvStipendijeGodine.SelectedRows[0].DataBoundItem as StipendijeGodineIB180079;


            //if(odabranaStipendijaGodina.Aktivna)
            //{
            //    odabranaStipendijaGodina.Aktivna = false;
            //}
            //else
            //{
            //    odabranaStipendijaGodina.Aktivna = true;
            //}

            //odabranaStipendijaGodina.Aktivna = odabranaStipendijaGodina.Aktivna ? false : true;


            odabranaStipendijaGodina.Aktivna = !odabranaStipendijaGodina.Aktivna;

            db.StipendijeGodineIB180079.Update(odabranaStipendijaGodina);

            db.SaveChanges();

            UcitajStipendijeGodine();

        }
    }
}
