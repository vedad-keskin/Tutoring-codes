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


        public frmPretragaIB180079() // dft. constr.
        {
            InitializeComponent(); // inic. komponenete koje dodate u formu

            //lblImePrezime.Text = "Vedad";
            //txtPretraga.Text = "Keskin";

        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;


            cmbKnjige.DataSource = knjigaServis.GetAll();


            cmbVracena.SelectedIndex = 0;


            UcitajPodatke();

        }

        private void UcitajPodatke()
        {

            // 1. CHECKBOX

            var vracena = chbVracena.Checked; // "true" "false" -> true ili false

            // 2. TEXTBOX

            var filter = txtPretraga.Text.ToLower().Trim(); // " BAZE " -> "baze"

            // 3. COMBOBOX -> DROPDOWN -> OPADAJUCI MENI 

            // - KOJI SE POPUNJAVA IZ BAZE

            //                    object -> Knjiga

            var knjiga = cmbKnjige.SelectedItem as KnjigeIB180079;


            // - KOJI SE NE POPUNJAVA IZ BAZE -> string

            var vracena2 = cmbVracena.SelectedItem as string;


            // 4. DATE TIME PICKER

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;



            // studentiKnjige[0] = 1	1	1	2025-12-23 14:12:05.858335	
            // StudentId = 1 -> 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB

            // studentiKnjige[1] = 2	2	2	2025-12-23 14:12:05.858335	
            // studentiKnjige[2] = 3	3	3	2025-12-23 14:12:05.858335	

            //var podaci = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .Where(x => x.Vracena == vracena) // false 
            //    .ToList();

            var podaci = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena) // false 
                .Where(x => x.Knjiga.Naziv.ToLower().Trim().Contains(filter) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Trim().Contains(filter))
                //.Where(x => x.Knjiga.Id == knjiga.Id)
                //.Where( x => (x.Vracena == true && vracena2 == "VRACENE") || 
                //(x.Vracena == false && vracena2 == "NISU VRACENE"))
                //.Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)
                .ToList();



            //List<Data.IspitIB180079.StudentiKnjigeIB180079> podaciFiltirani;

            //for (int i = 0; i < podaci.Count; i++)
            //{

            //    if (podaci[i].Vracena == vracena)
            //    {
            //        podaciFiltirani.Add(podaci[i]);
            //    }


            //}


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

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajPodatke();

        }

        private void cmbKnjige_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dgvPodaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if(e.ColumnIndex == 5)
            {

                var odabranaStudentKnjiga = dgvPodaci.SelectedRows[0].DataBoundItem as StudentiKnjigeIB180079;


                //MessageBox.Show($"{odabranaStudentKnjiga.Student} - {odabranaStudentKnjiga.Knjiga}");


                odabranaStudentKnjiga.Vracena = true;
                odabranaStudentKnjiga.DatumVracanja = DateTime.Now;

                studentiKnjigeServis.Update(odabranaStudentKnjiga);


                UcitajPodatke();


            }



        }
    }
}
