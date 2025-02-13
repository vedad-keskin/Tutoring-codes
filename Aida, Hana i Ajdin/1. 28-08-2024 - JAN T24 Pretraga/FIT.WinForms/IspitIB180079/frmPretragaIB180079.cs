using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            cbDrzava.DataSource = db.DrzaveIB180079.ToList();

        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            var odabranaDrzava = cbDrzava.SelectedItem as DrzaveIB180079;


            cbGrad.DataSource = db.GradoviIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();

            if(db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).Count() == 0)
            {
                dgvStudenti.DataSource = null;
            }

        }

        private void cbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {

            var odabraniGrad = cbGrad.SelectedItem as GradoviIB180079;

            var studenti = db.Studenti
                .Include(x=> x.Grad).ThenInclude(x=> x.Drzava)
                .Where(x=> x.GradId == odabraniGrad.Id)
                .ToList();


            for (int i = 0; i < studenti.Count(); i++)
            {

                // prosjek = izraz ? ako je taj izraz true : ako je taj izraz false;

                //studenti[i].Prosjek = db.PolozeniPredmeti
                //    .Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 :

                //    db.PolozeniPredmeti
                //    .Where(x=> x.StudentId == studenti[i].Id)
                //    .Average(x => x.Ocjena);


                if( db.PolozeniPredmeti
                    .Where(x => x.StudentId == studenti[i].Id).Count() == 0)
                {
                    studenti[i].Prosjek = 5;
                }
                else
                {
                    studenti[i].Prosjek = db.PolozeniPredmeti
                    .Where(x => x.StudentId == studenti[i].Id)
                    .Average(x => x.Ocjena);
                }


            }


            if(studenti != null)
            {


                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }


        }
    }
}
