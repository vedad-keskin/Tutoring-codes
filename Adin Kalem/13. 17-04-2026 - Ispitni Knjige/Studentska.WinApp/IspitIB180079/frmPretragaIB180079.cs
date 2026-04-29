using Microsoft.EntityFrameworkCore;
using Studentska.Servis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {

        StudentskaDbContext db = new StudentskaDbContext();

        // dft. constr.
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentKnjige();

            //txtPretraga.Text = "VEDAD KESKIN";
        }

        private void UcitajStudentKnjige()
        {
            //                Id StudentId KnjigaId DatumIzajmljivanja DatumVracanja Vracena
            // studentiKnjige[0] = 1	1	1	2025-12-23 14:12:05.858335	NULL	0
            // studentiKnjige[1] = 2	2	2	2025-12-23 14:12:05.858335	NULL	0
            // studentiKnjige[2] = 3	3	3	2025-12-23 14:12:05.858335	NULL	0

            // + .Include(x => x.Student)
            // 2	IB250002	!CrELt4bg^	Zanin	Vejzović	0	2025-12-23 14:46:08.7275101	1	1	BLOB	1

            // + .Include(x => x.Knjiga)
            // 2	Baze Podataka	Kenan Sarčević	2	BLOB


            var studentiKnjige = db.StudentiKnjigeIB180079
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                .ToList();


            dgvStudentiKnjige.DataSource = studentiKnjige;


            Text = $"Broj prikazanih podataka: {studentiKnjige.Count()}";


        }

        private void btnDodajKnjigu_Click(object sender, EventArgs e)
        {
            //chbVracena.Checked = true;
        }

        private void btnIznajmljivanja_Click(object sender, EventArgs e)
        {
            //chbVracena.Checked = false;
        }
    }
}
