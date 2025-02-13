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
        }

        private void cbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {
            var odabraniGrad = cbGrad.SelectedItem as GradoviIB180079;


            // studenti

            // ucita grad ako radis where prema gradu

            var studenti = db.Studenti
                .Where(x=> x.GradId == odabraniGrad.Id)
                //.Include(x=> x.Grad.Drzava)
                .ToList();


            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].Prosjek = db.PolozeniPredmeti
                    .Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 : db.PolozeniPredmeti
                    .Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);

                //    izraz ? sta ako je ovaj izraz true : sta ako je izraz false;

            }


            if(studenti != null)
            {
                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;

            }

            if(studenti.Count() == 0)
            {
                MessageBox.Show("Ne postoje studenti koji zadovoljavaju uslove pretrage","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }


        }
    }
}
