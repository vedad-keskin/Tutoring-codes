﻿using DLWMS.Data;
using DLWMS.Infrastructure;
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

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmPretragaIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
        List<Student> studenti;
        public frmPretragaIB180079()
        {
            InitializeComponent();
        }

        private void frmPretragaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudenti.AutoGenerateColumns = false;

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {
            cbSpol.DataSource = db.Spolovi.ToList();

            cbDrzava.DataSource = db.Drzave.ToList();
        }

        private void cbSpol_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void UcitajStudente()
        {

            var spol = cbSpol.SelectedItem as Spol ?? new Spol();

            var drzava = cbDrzava.SelectedItem as Drzava ?? new Drzava();

            var imePrezime = txtImePrezime.Text.ToLower();


            studenti = db.Studenti
                .Include(x => x.Grad.Drzava)
                .Include(x => x.Spol)
                .Where(x => x.SpolId == spol.Id)
                .Where(x => x.Grad.DrzavaId == drzava.Id)
                .Where(x => x.Ime.ToLower().Contains(imePrezime) ||
                x.Prezime.ToLower().Contains(imePrezime))
                .ToList();


            if (studenti != null)
            {
                dgvStudenti.DataSource = null;
                dgvStudenti.DataSource = studenti;
            }

            this.Text = $"Broj prikazanih studenata: {studenti.Count()}";


            //if (studenti.Count() == 0)
            //{
            //    MessageBox.Show($"U bazi nisu evidentirani studenti spola {spol}, koji u imenu i prezimenu posjeduju sadržaj {imePrezime}, a koji su državljani {drzava}.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {
            UcitajStudente();
        }

        private void dgvStudenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabraniStudent = studenti[e.RowIndex];


            if (e.ColumnIndex == 4)
            {

                odabraniStudent.Aktivan = !odabraniStudent.Aktivan;

                //odabraniStudent.Aktivan = odabraniStudent.Aktivan ? false : true;

                db.Studenti.Update(odabraniStudent);
                db.SaveChanges();

                UcitajStudente();


            }


        }

        private void dgvStudenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabraniStudent = studenti[e.RowIndex];


            if(e.ColumnIndex < 4)
            {
                var frmEditStudent = new frmStudentEditIB180079(odabraniStudent);

                if(frmEditStudent.ShowDialog() == DialogResult.OK)
                {
                    UcitajStudente();
                }
            }

        }
    }
}
