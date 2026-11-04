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

            UcitajPodatke();

        }

        private void UcitajPodatke()
        {

            // 1/4 CHECK BOX

            var vracena = chbVracena.Checked; // true false



            //            Id StudentId KnjigaId DatumIzn                      DatumVrac
            // podaci[0] = 1	 1	      1	     2025-12-23 14:12:05.858335	
            // 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB	1

            // podaci[1] = 2	 2	      2	     2025-12-23 14:12:05.858335	
            // podaci[2] = 3	 3	      3	     2025-12-23 14:12:05.858335	 2025-12-26 14:12:05.858335

            var podaci = db.StudentiKnjigeIB180079
                .Include(x => x.Student)
                .Include(x => x.Knjiga)
                .Where(x => x.Vracena == vracena)
                .ToList();


            //var filtriraniPodaci = new List<Data.IspitIB180079.StudentiKnjigeIB180079>();

            //for (int i = 0; i < podaci.Count; i++)
            //{

            //    if (podaci[i].Vracena == vracena)
            //    {

            //        filtriraniPodaci.Add(podaci[i]);

            //    }

            //}


            dgvPodaci.DataSource = podaci;


            Text = $"Broj prikazanih podataka: {podaci.Count}";


        }

        private void chbVracena_CheckedChanged(object sender, EventArgs e)
        {
            UcitajPodatke();
        }



    }
}
