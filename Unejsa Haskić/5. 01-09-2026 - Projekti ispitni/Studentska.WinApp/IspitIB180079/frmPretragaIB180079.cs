using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using Studentska.WinApp.IspitIB180079;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentska.WinApp
{
    public partial class frmPretragaIB180079 : Form
    {
        StudentiProjektiServis studentiProjektiServis = new StudentiProjektiServis();
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiProjekti.AutoGenerateColumns = false;

            cmbStanje.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            UcitajStudentiProjekte();

        }

        private void UcitajStudentiProjekte()
        {
            var pretraga = txtPretraga.Text.ToLower().Trim();

            var status = cmbStatus.SelectedItem as string;

            var stanje = cmbStanje.SelectedItem as string;

            var studentiProjekti = studentiProjektiServis
                .GetAllIncluded()
                .Where(x => $"{x.Student.Ime} {x.Student.Prezime}".ToLower().Contains(pretraga) || x.Projekat.Naziv.ToLower().Contains(pretraga))
                .Where(x => status == "Sve" || x.Status == status)
                .Where(x => stanje == "Sve" ||
                (x.Arhivirana == true && stanje == "Arhivirane") ||
                (x.Arhivirana == false && stanje == "Aktivne"))
                .ToList();



            if (studentiProjekti != null)
            {
                dgvStudentiProjekti.DataSource = null;
                dgvStudentiProjekti.DataSource = studentiProjekti;
            }


        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            UcitajStudentiProjekte();

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiProjekte();

        }

        private void cmbStanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudentiProjekte();

        }

        private void dgvStudentiProjekti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {

                var odabraniStudentProjekat = dgvStudentiProjekti.SelectedRows[0].DataBoundItem as StudentiProjektiIB180079;

                if (odabraniStudentProjekat.Arhivirana)
                {

                    MessageBox.Show("Prijava je vec arhivirana", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    odabraniStudentProjekat.Arhivirana = true;

                    studentiProjektiServis.Update(odabraniStudentProjekat);

                    UcitajStudentiProjekte();

                }


            }

        }

        private void btnNoviProjekat_Click(object sender, EventArgs e)
        {

            var frmAddProjekat = new frmProjekatAddIB180079();

            if (frmAddProjekat.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiProjekte();

            }


        }

        private void btnNovaPrijava_Click(object sender, EventArgs e)
        {
            var frmAddEditPrijava = new frmPrijavaAddEditIB180079();

            if (frmAddEditPrijava.ShowDialog() == DialogResult.OK)
            {

                UcitajStudentiProjekte();

            }
        }
    }
}
