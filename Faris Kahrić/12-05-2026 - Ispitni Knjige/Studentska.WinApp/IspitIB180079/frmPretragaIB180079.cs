using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using Studentska.Servis;
using Studentska.Servis.Servisi;
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
        //StudentskaDbContext db = new StudentskaDbContext();
        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();
        KnjigaServis knjigaServis = new KnjigaServis();

        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            cbKnjiga.DataSource = knjigaServis.GetAll();

            UcitajStudentiKnjige();

        }

        private void UcitajStudentiKnjige()
        {

            // 1	1	1	2025-12-23 14:12:05.858335		0
            // 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB	1
            // 1	C# 10 i .NET 6 Programiranje	Mark J. Price	2	BLOB


            //var studentiKnjige = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .ToList();

            // 1. CHECKBOX

            var vracena = chbVracena.Checked; // true false

            // 2. TEXTBOX

            var pretraga = txtPretraga.Text.ToLower(); // Baze

            // 3. COMBO BOX (DROPDOWN)

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            // 4. DATE TIME PICKER

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;


            var studentiKnjige = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Contains(pretraga) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga))
                .Where(x => x.KnjigaId == knjiga.Id)
                .Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)
                .ToList();

            if (studentiKnjige != null)
            {
                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;
            }


            Text = $"Broj prikazanih studenata: {studentiKnjige.Count()}";

        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();

        }

        private void cbKnjiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();

        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();

        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();
        }

        private void dgvStudentiKnjige_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {

                var odabranaStudentKnjiga = dgvStudentiKnjige.SelectedRows[0].DataBoundItem as StudentiKnjigeIB180079;

                odabranaStudentKnjiga.DatumVracanja = DateTime.Now;
                odabranaStudentKnjiga.Vracena = true;


                studentiKnjigeServis.Update(odabranaStudentKnjiga);

                UcitajStudentiKnjige();

                //MessageBox.Show($"{odabranaStudentKnjiga.Student} {odabranaStudentKnjiga.Knjiga}");

            }
        }

        private void btnIznajmljivanja_Click(object sender, EventArgs e)
        {

            var frmIznajmljivanje = new frmIznajmljivanjaIB180079();

            frmIznajmljivanje.ShowDialog();

        }
    }
}
