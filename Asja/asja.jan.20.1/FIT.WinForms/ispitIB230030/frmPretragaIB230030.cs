using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data;
using FIT.Data.IspitIB230030;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmPretragaIB230030 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<Student> studenti;
        public frmPretragaIB230030()
        {
            InitializeComponent();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPretragaIB230030_Load(object sender, EventArgs e)
        {
            dgvPretraga.AutoGenerateColumns = false;
            cbDrzava.DataSource = db.DrzaveIB230030.ToList();
        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            var odabranaDrzava = cbDrzava.SelectedItem as DrzaveIB230030;
            cbGrad.DataSource = db.GradoviIB230030
                .Where(x => x.DrzavaID == odabranaDrzava.Id).ToList();
        }

        private void cbGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucitajStudente();
        }

        private void ucitajStudente()
        {
            var odabraniGrad = cbGrad.SelectedItem as GradoviIB230030;

            studenti = db.Studenti
                //.Include(x => x.Grad.Drzava)
                .Where(x => x.GradID==odabraniGrad.Id)
                .ToList();

            for (int i = 0; i < studenti.Count(); i++)
            {
                studenti[i].Prosjek = db.PolozeniPredmeti.Where(x => x.StudentID == studenti[i].Id).Count() == 0 ? 5 :
                   db.PolozeniPredmeti.Where(x => x.StudentID == studenti[i].Id).Average(x => x.Ocjena);
            }

            if (studenti != null)
            {
                dgvPretraga.DataSource = null;
                dgvPretraga.DataSource = studenti;
            }
            if (studenti.Count == 0)
            {
                MessageBox.Show($"u bazi nije evidentiran niti jedan student rodjen u gradu {odabraniGrad.Naziv}", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
