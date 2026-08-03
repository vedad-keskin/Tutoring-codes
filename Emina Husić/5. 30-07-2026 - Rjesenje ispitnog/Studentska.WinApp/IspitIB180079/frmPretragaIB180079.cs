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

        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {

            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentiKnjige();

        }

        private void UcitajStudentiKnjige()
        {
            //           Id  StudentId KnjigaId DatumIznajm.                DatuV Vracena
            // studentiKnjige[0] = 1	1	1	2025-12-23 14:12:05.858335		      0
            // studentiKnjige[1] = 2	2	2	2025-12-23 14:12:05.858335		      0
            // studentiKnjige[2] = 3	3	3	2025-12-23 14:12:05.858335		      0

            var vracena = chbVracena.Checked;

            var pretraga = txtPretraga.Text.ToLower().Trim();


            var studentiKnjige = db.StudentiKnjigeIB180079
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                //.ToList() -> objasniti servise
                .Where(x => x.Vracena == vracena)
                .Where(x => $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga) ||
                x.Knjiga.Naziv.ToLower().Contains(pretraga))
                .ToList();


            dgvStudentiKnjige.DataSource = studentiKnjige;


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();

        }
    }
}
