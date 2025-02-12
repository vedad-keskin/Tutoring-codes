using FIT.Data;
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
        List<Student> studenti;
        DrzaveIB180079 odabranaDrzava;
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;
            cbDrzave.DataSource = db.DrzaveIB180079.ToList();
        }

        private void cbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            odabranaDrzava = cbDrzave.SelectedItem as DrzaveIB180079;


            cbGradovi.DataSource = db.GradoviIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();

        }

        private void cbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {

            var odabraniGrad = cbGradovi.SelectedItem as GradoviIB180079;

            // GradId
            // Jablanica
            // true
            // 1
            // BiH 
            // [Zastava]
            // true

            studenti = db.Studenti
                .Where(x => x.GradId == odabraniGrad.Id)
                .Include(x=> x.Grad).ThenInclude(x=> x.Drzava)
                .ToList();

            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].DrzavaNaziv = studenti[i].Grad.Drzava.Naziv;


                // projek = izraz ? ako je true : ako je false; 

                studenti[i].Prosjek = db.PolozeniPredmeti.Where(x=> x.StudentId == studenti[i].Id).Count() == 0 ? 5 :     db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);
            }


            if(studenti != null)
            {
                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }
            if(studenti.Count() == 0)
            {
                MessageBox.Show($"U bazi nije evidentiran niti jedan student rođen u gradu {odabraniGrad.Naziv}, {odabranaDrzava.Naziv} ");
            }


        }
    }
}
