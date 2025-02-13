﻿using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
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
    public partial class frmDrzaveIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<DrzaveIB180079> drzave;
        public frmDrzaveIB180079()
        {
            InitializeComponent();
        }

        private void frmDrzaveIB180079_Load(object sender, EventArgs e)
        {
            dgvDrzave.AutoGenerateColumns = false;
            UcitajVrijeme();
            UcitajDrzave();
        }

        private void UcitajDrzave()
        {
            drzave = db.DrzaveIB180079.ToList();

            // drz[0] = BiH -> broj -> 2
            // drz[1] = Egp -> broj -> 1
            // drz[2] = Jpn -> broj -> 1

            for (int i = 0; i < drzave.Count(); i++)
            {
                drzave[i].Broj = db.GradoviIB180079
                    .Where(x => x.DrzavaId == drzave[i].Id)
                    .Count();
            }


            if (drzave != null)
            {
                dgvDrzave.DataSource = null;
                dgvDrzave.DataSource = drzave;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UcitajVrijeme();
        }

        private void UcitajVrijeme()
        {
            tsslVrijeme.Text = $"Trenutno vrijeme: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void btnNovaDrzava_Click(object sender, EventArgs e)
        {
            frmNovaDrzavaIB180079 frmNovaDrzava = new frmNovaDrzavaIB180079();

            if (frmNovaDrzava.ShowDialog() == DialogResult.OK)
            {
                UcitajDrzave();
            }
        }

        private void dgvDrzave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.ColumnIndex = 1 
            // e.RowIndex = 0

            // drz[0] = BiH -> broj -> 2
            // drz[1] = Egp -> broj -> 1
            // drz[2] = Jpn -> broj -> 1

            var odabranaDrzava = drzave[e.RowIndex];

            if (e.ColumnIndex < 4)
            {

                var frmEditDrzava = new frmNovaDrzavaIB180079(odabranaDrzava);

                if (frmEditDrzava.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
                }

            }

        }

        private void dgvDrzave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaDrzava = drzave[e.RowIndex];

            if (e.ColumnIndex == 4)
            {

                var frmGradovi = new frmGradoviIB180079(odabranaDrzava);

                if (frmGradovi.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
                }


            }

        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var odabranaDrzava = dgvDrzave.SelectedRows[0].DataBoundItem as DrzaveIB180079;

            var frmIzvjestaj = new frmIzvjestaji(odabranaDrzava);

            frmIzvjestaj.ShowDialog();

        }
    }
}
