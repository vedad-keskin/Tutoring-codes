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

            //var studentiKnjige = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .ToList();

            //                             db.StudentiKnjigeIB180079  .ToList(); -> inc

            var vracena = chbVracena.Checked;

            var pretraga = txtPretraga.Text.ToLower();


            var studentiKnjige = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Contains(pretraga) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga))
                .ToList();


            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }

            Text = $"Broj prikazanih podataka: {studentiKnjige.Count()}";


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudentiKnjige();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
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

                
            }

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            


        }
    }
}
