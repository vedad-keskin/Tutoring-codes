using Studentska.Data.IspitIB180079;
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

            var vracena = chbVracena.Checked;

            var naziv = txtNaziv.Text.ToLower();


            var studentiKnjige = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Contains(naziv) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(naziv))
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

        private void txtNaziv_TextChanged(object sender, EventArgs e)
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

            var frmKnjigaAdd = new frmKnjigaAddIB180079();

            if (frmKnjigaAdd.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiKnjige();

            }


        }

        private void dgvStudentiKnjige_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex < 5)
            {

                var odabranaStudentKnjiga = dgvStudentiKnjige.SelectedRows[0].DataBoundItem as StudentiKnjigeIB180079;

                var frmKnjigaEdit = new frmKnjigaAddIB180079(odabranaStudentKnjiga.Knjiga);

                if (frmKnjigaEdit.ShowDialog() == DialogResult.OK)
                {

                    UcitajStudentiKnjige();

                }


            }

        }

        private void btnIznajmljivanja_Click(object sender, EventArgs e)
        {


            var frmIznajmljivanja = new frmIznajmljivanjaIB180079();

            if (frmIznajmljivanja.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiKnjige();

            }

        }
    }
}
