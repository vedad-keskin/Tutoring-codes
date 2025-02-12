using FIT.Data;
using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Helpers;
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
            UcitajFiltiraneStudente();
        }

        private void UcitajFiltiraneStudente()
        {
            if (Validiraj())
            {
                var odabraniGrad = cbGrad.SelectedItem as GradoviIB180079;

                studenti = db.Studenti
               .Include(x => x.Grad).ThenInclude(x => x.Drzava)
               .Where(x => x.GradId == odabraniGrad.Id)
               .ToList();

                for (int i = 0; i < studenti.Count(); i++)
                {
                    studenti[i].Drzava = studenti[i].Grad.Drzava.Naziv;

                    // pohrana = izraz ? ako je taj izraz true : ako je taj izraz false;

                    studenti[i].Prosjek = db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 :
                        db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);

                }




                if (studenti != null)
                {

                    dgvStudenti.DataSource = null;
                    dgvStudenti.DataSource = studenti;
                }
                if (studenti.Count() == 0)
                {
                    MessageBox.Show($"U bazi nije evidentiran niti jedan student rođen u gradu {odabraniGrad}, {odabranaDrzava}");
                }

            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(cbDrzava, err, Kljucevi.ReqiredValue) && Validator.ProvjeriUnos(cbGrad, err, Kljucevi.ReqiredValue);
        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            odabranaDrzava = cbDrzava.SelectedItem as DrzaveIB180079;


            cbGrad.DataSource = db.GradoviIB180079
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();

            if(db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).Count() == 0)
            {
                dgvStudenti.DataSource = null;
            }

            UcitajFiltiraneStudente();

        }

        private void cbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UcitajStudente();
            UcitajFiltiraneStudente();
        }

        private void UcitajStudente()
        {
            var odabraniGrad = cbGrad.SelectedItem as GradoviIB180079;

            // GradId
            // Naziv 
            // Status 
            // Drzava naziv
            // Status drzave
            // zastavu 

            studenti = db.Studenti
                .Include(x=> x.Grad).ThenInclude(x=> x.Drzava)
                .Where(x=> x.GradId == odabraniGrad.Id)
                .ToList();

            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].Drzava = studenti[i].Grad.Drzava.Naziv;

                // pohrana = izraz ? ako je taj izraz true : ako je taj izraz false;

                studenti[i].Prosjek = db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 :
                    db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);

            }




            if(studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }
            if (studenti.Count() == 0)
            {
                MessageBox.Show($"U bazi nije evidentiran niti jedan student rođen u gradu {odabraniGrad}, {odabranaDrzava}");
            }

        }
    }
}
