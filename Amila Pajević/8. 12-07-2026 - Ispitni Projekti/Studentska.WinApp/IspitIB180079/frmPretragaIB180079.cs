using Microsoft.EntityFrameworkCore;
using Studentska.Data.IspitIB180079;
using Studentska.Servis;
using Studentska.Servis.Servisi;
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
        //StudentskaDbContext db = new StudentskaDbContext();
        StudentiProjektiServis studentiProjektiServis = new StudentiProjektiServis();
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiProjekti.AutoGenerateColumns = false;

            cmbStatus.SelectedIndex = 0;

            cmbStanje.SelectedIndex = 0;

            UcitajStudentProjekte();
        }

        private void UcitajStudentProjekte()
        {
            //var studentProjekti = db.StudentiProjektiIB180079
            //    .Include(x => x.Student)
            //    .Include(x => x.Projekat)
            //    .ToList();

            var pretrega = txtPretraga.Text.ToLower();

            var status = cmbStatus.SelectedItem as string;

            var stanje = cmbStanje.SelectedItem as string;

            var studentProjekti = studentiProjektiServis
                .GetAllIncluded()
                .Where(x => x.Projekat.Naziv.ToLower().Contains(pretrega) ||
                $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretrega))
                .Where(x => status == "Sve" || x.Status == status)
                .Where(x => stanje == "Sve" || x.Stanje == stanje)
                .ToList();


            if (studentProjekti != null)
            {

                dgvStudentiProjekti.DataSource = null;
                dgvStudentiProjekti.DataSource = studentProjekti;

            }

        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {

            UcitajStudentProjekte();

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentProjekte();

        }

        private void cmbStanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentProjekte();

        }

        private void dgvStudentiProjekti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {

                var odabraniStudentProjekat = dgvStudentiProjekti.SelectedRows[0].DataBoundItem as StudentiProjektiIB180079;

                if(odabraniStudentProjekat.Stanje == "Arhivirana")
                {
                    MessageBox.Show("Stanje odabranog projekta je već arhivirano","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    odabraniStudentProjekat.Stanje = "Arhivirana";
                }


                studentiProjektiServis.Update(odabraniStudentProjekat);

                UcitajStudentProjekte();

            }
        }
    }
}
