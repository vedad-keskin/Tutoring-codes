﻿using DLWMS.Data;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Helpers;
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
    public partial class frmStudentEditIB180079 : Form
    {
        private Student odabraniStudent;
        DLWMSContext db = new DLWMSContext();

        public frmStudentEditIB180079(Student odabraniStudent)
        {
            InitializeComponent();
            this.odabraniStudent = odabraniStudent;
        }

        private void frmStudentEditIB180079_Load(object sender, EventArgs e)
        {
            UcitajInfo();

            cbDrzava.DataSource = db.Drzave.ToList();
        }

        private void UcitajInfo()
        {
            pbSlika.Image = odabraniStudent.Slika.ToImage();

            lblBrojIndeksa.Text = odabraniStudent.BrojIndeksa;
            lblImePrezime.Text = $"{odabraniStudent.Ime} {odabraniStudent.Prezime}";

        }

        private void cbDrzava_SelectedIndexChanged(object sender, EventArgs e)
        {

            var odabranaDrzava = cbDrzava.SelectedItem as Drzava;

            cbGrad.DataSource = db.Gradovi
                .Where(x => x.DrzavaId == odabranaDrzava.Id)
                .ToList();


        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (Validiraj())
            {

                // Id, Ime, Prezime GradId = 2 .....

                // Grad -> Id = 2 , Naziv = Mostar
                // Spol -> Id ... 
                // Drzava -> ... 


                var slika = pbSlika.Image.ToByteArray();

                var odabraniGrad = cbGrad.SelectedItem as Grad; 


                odabraniStudent.Slika = slika;
                odabraniStudent.GradId = odabraniGrad.Id;
                odabraniStudent.Grad = odabraniGrad;


                db.Studenti.Update(odabraniStudent);
                db.SaveChanges();

                DialogResult = DialogResult.OK;

           

                



            }
        }

        private bool Validiraj()
        {
            return Validator.ProvjeriUnos(pbSlika, err, Kljucevi.RequiredField)
                &&
                Validator.ProvjeriUnos(cbGrad, err, Kljucevi.RequiredField);
        }
    }
}
