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
            cbDrzava.DataSource = db.DrzaveIB180079.ToList();
        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ako vadis iz combo boxa 
            odabranaDrzava = cbDrzava.SelectedItem as DrzaveIB180079;

            // kada vadis iz dgv
            // var odabranaDrzava = drzave[e.rowIndex]


            cbGrad.DataSource = db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).ToList();


            // ako postoji drzava bez grada da ne ostanu prethodni studenti

            if(db.GradoviIB180079.Where(x=> x.DrzavaId == odabranaDrzava.Id).Count() == 0)
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


            // sve o gradovima, sve o drzavama

            studenti = db.Studenti
                .Include(x=> x.Grad).ThenInclude(x=> x.Drzava)
                .Where(x=> x.GradId == odabraniGrad.Id)
                .ToList();

            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].NazivDrzava = studenti[i].Grad.Drzava.Naziv;

                // pohrana = izraz ? ako je izraz true : ako je izraz false;

                studenti[i].Prosjek = db.PolozeniPredmeti.Where(x=> x.StudentId == studenti[i].Id).Count() == 0 ? 5 : db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena); 

            }

            
            if(studenti != null)
            {
                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;

            }
            if(studenti.Count() == 0)
            {
                MessageBox.Show($"U bazi nije evidentiran niti jedan student rođen u gradu {odabraniGrad}, {odabranaDrzava}","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }



        }
    }
}
