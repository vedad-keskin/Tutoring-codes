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
        DrzaveIB180079 odabranaDrzava;
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            cbDrzave.DataSource = db.DrzaveIB180079.ToList();

            odabranaDrzava = cbDrzave.SelectedItem as DrzaveIB180079;

            cbGradovi.DataSource = db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).ToList();

        }
        private void UcitajStudente()
        {
            odabranaDrzava = cbDrzave.SelectedItem as DrzaveIB180079;

            //                   ako je null neka pise "Svi" a ako nije null pisat ce ime tog grada
            var odabraniGrad = cbGradovi.SelectedItem == null ? "Svi" : cbGradovi.SelectedItem.ToString();


            var studenti = db.Studenti.Include(x=> x.Grad).ThenInclude(x=> x.Drzava)
                .Where(x=> x.Grad.DrzavaId == odabranaDrzava.Id && 
                ( odabraniGrad == "Svi" || x.Grad.Naziv == odabraniGrad   )
                )
                .ToList();


            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].Drzava = studenti[i].Grad.Drzava.Naziv;

                studenti[i].Prosjek = db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 :
                    db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);

            }

            if(studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }


        }

        private void cbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();

            cbGradovi.DataSource = db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).ToList();
        }

        private void cbGradovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

    }
}
