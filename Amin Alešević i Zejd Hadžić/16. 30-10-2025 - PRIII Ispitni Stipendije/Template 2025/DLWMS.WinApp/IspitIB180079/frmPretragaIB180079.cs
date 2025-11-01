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

            UcitajStudentStipendije();
        }

        private void UcitajStudentStipendije()
        {
            //studentStipendije[0] = 1	1	1 1	Denis	Mušić	IB2400001	2024-12-11 13:02:21.1642863	denis.music@fit.ba	tpRYHTp/ep&fQ)i	2	3	BLOB 1	1	2025	200	11	Umjetnička




            //studentStipendije[1] = 2	2	2

            //studentStipendije[2] = 3	3	3



            var studentStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina.Stipendija)
                .ToList();


            dgvStudentiStipendije.DataSource = studentStipendije;


        }
    }
}
