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


        // dft. constr.
        public frmPretragaIB180079()
        {
            InitializeComponent();

            //lblPretraga.Text = "VEDAD";
            //txtPretraga.Text = "KESKIN";

        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            //lblPretraga.Text = "VEDAD";
            //txtPretraga.Text = "KESKIN";
            //chbVracena.Checked = false;

            dgvPodaci.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajPodatke();

        }

        private void UcitajComboBox()
        {

            // unos preko baze

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

            // unos rucno preko edit items

            cbAktivan.SelectedIndex = 0;


        }

        private void UcitajPodatke()
        {

            // FILTERI 

            // 1/4 CHECK BOX -> bool

            var vracena = chbVracena.Checked;

            // 2/4 TEXT BOX -> string

            var pretraga = txtPretraga.Text.ToLower().Trim();

            // 3/4 COMBO BOX/DROPDOWN 

            // 3.1 COMBO BOX KOJI JE POPUNJEN IZ BAZE -> object -> objekat klase (Knjiga)

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;

            // 3.2 COMBO BOX KOJI JE POPUNJEN RUCNO -> string/int

            var aktivan = cbAktivan.SelectedItem as string; // "Svi" "Aktivni" "Neaktivni"

            // 4/4 DATE TIME PICKERI -> DateTime

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;



            //             Id StuId KnjId DatIzn      DatVrc
            // podaci[0] = 1	1	1	2025-12-23 14:12:05.858335	
            // +++ 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB	1
            // +++ 1	C# 10 i .NET 6 Programiranje	Mark J. Price	3	BLOB



            // podaci[1] = 2	2	2	2025-12-23 14:12:05.858335	
            // podaci[2] = 3	3	3	2025-12-23 14:12:05.858335	

            //var podaci = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .Where(x => x.Vracena == vracena)
            //    .ToList();

            var podaci = studentiKnjigeServis
                .GetAllIncluded() // _dbContext.StudentiKnjigeIB180079 ------ ToList();
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Trim().Contains(pretraga) ||
                 $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Trim().Contains(pretraga))
                //.Where(x => x.KnjigaId == knjiga.Id)
                //                          OP I 
                //.Where(x =>  (x.Student.Aktivan == true && aktivan == "Aktivni") ||
                ////                          OP II 
                //(x.Student.Aktivan == false && aktivan == "Neaktivni") ||
                ////                          OP III
                //aktivan == "Svi")
                //.Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)
                .ToList(); // ToList();







            //List<StudentiKnjigeIB180079> filtriranaLista = new List<StudentiKnjigeIB180079>();

            //for (int i = 0; i < podaci.Count(); i++)
            //{
            //    if (podaci[i].Vracena == vracena)
            //    {

            //        filtriranaLista.Add(podaci[i]);

            //    }
            //}



            dgvPodaci.DataSource = podaci;


            Text = $"Broj prikazanih podataka {podaci.Count()}";


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {

            UcitajPodatke();

        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {

            UcitajPodatke();

        }

        private void cbKnjiga_SelectedIndexChanged(object sender, EventArgs e)
        {

            UcitajPodatke();

        }

        private void cbAktivan_SelectedIndexChanged(object sender, EventArgs e)
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
