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


        public frmPretragaIB180079() // dft. constr.
        {
            InitializeComponent(); // inic. komponenete koje dodate u formu

            //lblImePrezime.Text = "Vedad";
            //txtPretraga.Text = "Keskin";

        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;


            UcitajPodatke();

        }

        private void UcitajPodatke()
        {

            var vracena = chbVracena.Checked; // "true" "false" -> true ili false


            // studentiKnjige[0] = 1	1	1	2025-12-23 14:12:05.858335	
            // StudentId = 1 -> 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB

            // studentiKnjige[1] = 2	2	2	2025-12-23 14:12:05.858335	
            // studentiKnjige[2] = 3	3	3	2025-12-23 14:12:05.858335	

            var podaci = db.StudentiKnjigeIB180079
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                .Where(x => x.Vracena == vracena) // false 
                .ToList();

            //List<Data.IspitIB180079.StudentiKnjigeIB180079> podaciFiltirani;

            //for (int i = 0; i < podaci.Count; i++)
            //{

            //    if (podaci[i].Vracena == vracena)
            //    {
            //        podaciFiltirani.Add(podaci[i]);
            //    }


            //}


            dgvPodaci.DataSource = podaci;




        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }





    }
}
