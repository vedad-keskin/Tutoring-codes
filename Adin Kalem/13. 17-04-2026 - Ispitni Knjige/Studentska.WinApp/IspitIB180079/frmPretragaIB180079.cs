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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {

        //StudentskaDbContext db = new StudentskaDbContext();
        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();
        KnjigeServis knjigeServis = new KnjigeServis();



        // dft. constr.
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            cbKnjige.DataSource = knjigeServis.GetAll();


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


            //var studentiKnjige = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .ToList();





            // 1. CHECKBOX

            var vracena = chbVracena.Checked; // "true" "false"


            // 2. TEXTBOX

            var pretraga = txtPretraga.Text.ToLower().Trim(); // BAZE , Baze , baze --> baze


            // 3. COMBO BOX

            //var knjiga = cbKnjige.SelectedItem.ToString().ToLower();

            //                          object -> Knjiga
            var knjiga = cbKnjige.SelectedItem as KnjigeIB180079;


            // 4. DATE TIME PICKER

            var datumOd = dtpDatumOd.Value; // DateTime
            var datumDo = dtpDatumDo.Value;




            var studentiKnjige = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                // Baze Podataka --> baze podataka
                .Where(x => x.Knjiga.Naziv.ToLower().Contains(pretraga) ||
                 $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga))
                //.Where(x => x.Knjiga.ToString().ToLower().Contains(knjiga))
                .Where(x => x.KnjigaId == knjiga.Id)
                .Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)
                .ToList();



            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }




            Text = $"Broj prikazanih podataka: {studentiKnjige.Count()}";


        }

        private void btnDodajKnjigu_Click(object sender, EventArgs e)
        {
            //chbVracena.Checked = true;
        }

        private void btnIznajmljivanja_Click(object sender, EventArgs e)
        {

            var frmIznajmljivanja = new frmIznajmljivanjaIB180079();

            if (frmIznajmljivanja.ShowDialog() == DialogResult.OK)
            {
                UcitajStudentKnjige();
            }


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajStudentKnjige();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajStudentKnjige();
        }

        private void cbKnjige_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentKnjige();
        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentKnjige();
        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajStudentKnjige();
        }

        private void dgvStudentiKnjige_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == 5)
            {
                //                                                            obj -> StudentKnjig
                var odabraniStudentKnjiga = dgvStudentiKnjige.SelectedRows[0].DataBoundItem as StudentiKnjigeIB180079;


                odabraniStudentKnjiga.DatumVracanja = DateTime.Now;
                odabraniStudentKnjiga.Vracena = true;

                studentiKnjigeServis.Update(odabraniStudentKnjiga);

                UcitajStudentKnjige();

            }

        }
    }
}
