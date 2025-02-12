using FIT.Data;
using FIT.Data.IspitIB1800079;
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
        List<Student> studenti;
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

             UcitajStudente();

             cbGrad.DataSource = db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).ToList();

            

            
        }

        private void UcitajStudente()
        {

            odabranaDrzava = cbDrzava.SelectedItem as DrzaveIB180079;

            if (db.GradoviIB180079.Where(x => x.DrzavaId == odabranaDrzava.Id).Count() == 0)
            {
                studenti = null;
            }
            else
            {
                
                var odabraniGrad = cbGrad.SelectedItem == null ? "Nema grada" : cbGrad.SelectedItem.ToString();


                studenti = db.Studenti.Include(x => x.Grad).ThenInclude(x => x.Drzava)
                    .Where(x => x.Grad.Naziv == odabraniGrad )
                    .ToList();

                for (int i = 0; i < studenti.Count(); i++)
                {
                    studenti[i].DrzavaInfo = studenti[i].Grad.Drzava.ToString();

                    studenti[i].Prosjek =
                        db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Count() == 0 ? 5 : db.PolozeniPredmeti.Where(x => x.StudentId == studenti[i].Id).Average(x => x.Ocjena);

                    // prosjek = uslov ? ako je uslov true : ako je uslov false;

                }

            }




            if(studenti != null)
            {

                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }
            else
            {
                dgvStudenti.DataSource = null;

            }

            


        }

        private void cbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {

            UcitajStudente();


        }
    }
}
