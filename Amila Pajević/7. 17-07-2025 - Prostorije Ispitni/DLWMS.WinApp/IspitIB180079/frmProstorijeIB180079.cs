using DLWMS.Infrastructure;
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
    public partial class frmProstorijeIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        public frmProstorijeIB180079()
        {
            InitializeComponent();
        }

        private void frmProstorijeIB180079_Load(object sender, EventArgs e)
        {
            dgvProstorije.AutoGenerateColumns = false;

            UcitajProstorije();
        }

        private void UcitajProstorije()
        {
            // prostorije[0] = AMF1
            // prostorije[1] = AMF3
            // prostorije[2] = UC1

            var prostorije = db.ProstorijeIB180079.ToList();

            dgvProstorije.DataSource = prostorije;

        }
    }
}
