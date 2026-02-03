using Microsoft.VisualBasic;
using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
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
    public partial class frmIznajmljivanjaIB180079 : Form
    {
        StudentiKnjigeServis studentiKnjigeServis = new StudentiKnjigeServis();
        KnjigeServis knjigeServis = new KnjigeServis();
        StudentServis studentServis = new StudentServis();

        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentiKnjige();

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

            cbStudent.DataSource = studentServis.GetAll();




        }

        private void UcitajStudentiKnjige()
        {

            var studentiKnjige = studentiKnjigeServis.GetAllIncluded();


            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }



        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var student = cbStudent.SelectedItem as Student;
            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;


            if (studentiKnjigeServis.GetAllIncluded()
                .Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false).ToList().Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show("Odabrana knjiga nema dostupnih primjeraka", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentiKnjigeServis.GetAllIncluded().Exists(x =>
            x.StudentId == student.Id &&
            x.KnjigaId == knjiga.Id &&
            x.Vracena == false
            ))
            {
                MessageBox.Show("Student je već iznajmio odabranu knjigu i nije je vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var novaStudentKnjiga = new StudentiKnjigeIB180079()
                {
                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false

                };

                studentiKnjigeServis.Add(novaStudentKnjiga);

                UcitajStudentiKnjige();

            }



        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            // 1. dio
            // -- postavljanje threada -> async await Task
            // -- validacija
            // -- ako se vadi nesto iz combo boxa mora se to vaditi u prvom dijelu 


            var odabraniStudent = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiKnjige(odabraniStudent));


        }

        private void GenerisiKnjige(Student? odabraniStudent)
        {

            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep


            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 0;

            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                //Thread.Sleep(300);

                //var novaStudentKnjiga = new StudentiKnjigeIB180079()
                //{
                //    StudentId = odabraniStudent.Id,
                //    KnjigaId = sveKnjige[i].Id,
                //    DatumIznajmljivanja = DateTime.Now,
                //    Vracena = false

                //};

                //studentiKnjigeServis.Add(novaStudentKnjiga);

                if (!studentiKnjigeServis.GetAllIncluded().Exists(x =>
                x.StudentId == odabraniStudent.Id &&
                x.KnjigaId == sveKnjige[i].Id))
                {

                    Thread.Sleep(300);

                    var novaStudentKnjiga = new StudentiKnjigeIB180079()
                    {
                        StudentId = odabraniStudent.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false

                    };

                    studentiKnjigeServis.Add(novaStudentKnjiga);

                    redniBroj++;

                    info += $"{redniBroj}. {odabraniStudent} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";


                }




            }


            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ucitavanja
                // -- ispisi

                UcitajStudentiKnjige();
                MessageBox.Show("Uspješno su generisana iznajmljivanja", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtInfo.Text = info;

            };
            BeginInvoke(action);




        }

        private void frmIznajmljivanjaIB180079_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
