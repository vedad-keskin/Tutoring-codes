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
        KnjigeServis knjigeServis = new KnjigeServis();

        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;

            // 3.1 COMBO BOX KOJI SE POPUNJAVA IZ BAZE

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

            // 3.2 COMBO BOX KOJI SE NE POPUNJAVA IZ BAZE

            cbAktivan.SelectedIndex = 0;


            UcitajPodatke();

        }

        private void UcitajPodatke()
        {

            // FILTERI 

            // 1. CHECKBOX -> bool 

            var vracena = chbVracena.Checked;

            // 2. TEXTBOX -> string

            var pretraga = tbPretraga.Text.ToLower().Trim(); // C# 10 -> c# 10

            // 3. COMBO BOX

            // 3.1 COMBO BOX KOJI SE POPUNJAVA IZ BAZE -> klasu

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;

            // 3.2 COMBO BOX KOJI SE NE POPUNJAVA IZ BAZE -> string

            var aktivan = cbAktivan.SelectedItem as string; // "Svi" "Aktivni" "Neaktivni"

            // 4. DATE TIME PICKERI -> DateTime

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;






            //var podaci = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .ToList();

            var podaci = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Contains(pretraga) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga))
                //.Where(x => x.KnjigaId == knjiga.Id)
                //.Where(x => (aktivan == "Svi") ||
                //(x.Student.Aktivan == true && aktivan == "Aktivni") ||
                //(x.Student.Aktivan == false && aktivan == "Neaktivni"))
                //.Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)
                .ToList();



            if (podaci != null)
            {

                dgvPodaci.DataSource = null;
                dgvPodaci.DataSource = podaci;

            }


            Text = $"Broj prikazanih podataka: {podaci.Count()}";


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void tbPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajPodatke();

        }

        private void cbKnjiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPodatke();

        }

        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            UcitajPodatke();

        }

        private void dtpDatumDo_ValueChanged(object sender, EventArgs e)
        {
            UcitajPodatke();

        }

        private void cbAktivan_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void dgvPodaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == 6)
            {

                var odabranaStudentKnjiga = dgvPodaci.SelectedRows[0].DataBoundItem as StudentiKnjigeIB180079;


                odabranaStudentKnjiga.DatumVracanja = DateTime.Now;
                odabranaStudentKnjiga.Vracena = true;

                studentiKnjigeServis.Update(odabranaStudentKnjiga);

                UcitajPodatke();

                //MessageBox.Show($"{odabranaStudentKnjiga.Student} - {odabranaStudentKnjiga.Knjiga}");

            }

        }
    }
}
