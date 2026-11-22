using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using Studentska.Servis;
using Studentska.Servis.Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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

            dgvPodaci.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajPodatke();

        }

        private void UcitajComboBox()
        {

            // 3.1 AKO JE COMBO BOX IZ BAZE

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

            // 3.2 COMBO BOX KOJI SE NE POPUNJAJE IZ BAZE

            cbAktivan.SelectedIndex = 0;


        }

        private void UcitajPodatke()
        {

            // 1/4 CHECK BOX -> true ili false -> bool 

            var vracena = chbVracena.Checked;

            // 2/4 TEXT BOX -> string 

            var filter = txtPretraga.Text.ToLower().Trim();

            // 3/4 COMBO BOX -> DROPDOWN 

            // 3.1 COMBO BOX KOJI SE POPUNJAJE IZ BAZE -> object -> Knjiga

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;

            // 3.2 COMBO BOX KOJI SE NE POPUNJAJE IZ BAZE -> object -> string

            var aktivan = cbAktivan.SelectedItem as string; // "Svi" "Aktivni" "Neaktivni"

            // 4/4 DATE TIME PICKERI -> DateTime

            var datumOd = dtpDatumOd.Value;
            var datumDo = dtpDatumDo.Value;





            // LIST 
            //             Id StudentId KnjigaId          DatumIzn                    DatumVrac
            // podaci[0] = 1     1          1     2025-12-23 14:12:05.858335	
            // podaci[1] = 2     2          2     2025-12-23 14:12:05.858335	
            // podaci[2] = 3     3          3     2025-12-23 14:12:05.858335	2025-12-25 14:12:05.858335


            //var podaci = db.StudentiKnjigeIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Knjiga)
            //    .ToList();
            //    .Where(x => x.Vracena == vracena)   
            //    .ToList();

            var podaci = studentiKnjigeServis
                .GetAllIncluded()
                .Where(x => x.Vracena == vracena)
                .Where(x => x.Knjiga.Naziv.ToLower().Trim().Contains(filter) ||
                  $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Trim().Contains(filter)) // ""
                //.Where(x => x.KnjigaId == knjiga.Id)
                //.Where(x => (x.Student.Aktivan == true && aktivan == "Aktivni") || 
                //(x.Student.Aktivan == false && aktivan == "Neaktivni") || 
                //(aktivan == "Svi"))
                .Where(x => x.DatumIznajmljivanja >= datumOd && x.DatumIznajmljivanja <= datumDo)

                .ToList();










            //List<Data.IspitIB180079.StudentiKnjigeIB180079> lista = new List<Data.IspitIB180079.StudentiKnjigeIB180079>();

            //for (int i = 0; i < podaci.Count; i++)
            //{

            //    if (podaci[i].Vracena == vracena)
            //    {
            //        lista.Add(podaci[i]);
            //    }

            //}


            dgvPodaci.DataSource = podaci;

            Text = $"Broj prikazanih podataka {podaci.Count}";



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
    }
}
