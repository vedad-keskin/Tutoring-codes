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
        StudentServis studentServis = new StudentServis();
        KnjigeServis knjigeServis = new KnjigeServis();

        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajStudentKnjige();

            UcitajComboBox();

        }

        private void UcitajComboBox()
        {

            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigeServis.GetAll();

        }

        private void UcitajStudentKnjige()
        {

            var studentiKnjige = studentiKnjigeServis
                .GetAllIncluded()
                .ToList();

            if (studentiKnjige != null)
            {

                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentiKnjige;

            }


        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;
            var student = cbStudent.SelectedItem as Student;

            // 1. NACIN

            if (studentiKnjigeServis.GetAll() // SVE IZNAJMLJIVNAJA
                .Where(x => x.KnjigaId == knjiga.Id // SVE IZNAJMLJIVNAJA ODABRANE KNJ
                && x.Vracena == false) // KOJA NIJE VRACNEA
                .ToList() // PRETVORI U NIZ
                .Count() // COUNT -> PREBROJI --> 
                >= knjiga.BrojPrimjeraka) // 1 >= 2
            {
                MessageBox.Show("Prekoračen broj primjeraka u biblioteci", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (studentiKnjigeServis.GetAll().Exists(
                x => x.StudentId == student.Id &&
                x.KnjigaId == knjiga.Id &&
                x.Vracena == false))
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {


                var novaStudentKnjiga = new StudentiKnjigeIB180079()
                {

                    //Id = 6, <-- autoincrement je pa se ne dodaje
                    //Student = student, klase se nikada ne salju na bazu (FK) -> salje se samo id tog kljuca
                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false

                };

                // 2. NACIN

                //var novaStudentKnjiga = new StudentiKnjigeIB180079();

                //novaStudentKnjiga.DatumIznajmljivanja = DateTime.Now;

                studentiKnjigeServis.Add(novaStudentKnjiga);

                UcitajStudentKnjige();


            }



        }

        private void frmIznajmljivanjaIB180079_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. PRVI DIO
            // -- postavljanje threada
            // -- validacije
            // -- ako imamo neki combo box, on se mora pohranit u prvom dijelu i proslijediti drugom dijelu 

            var student = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiIznajmljivanja(student)  );

        }

        private void GenerisiIznajmljivanja(Student? student)
        {

            // 2. DRUGI DIO
            // -- pohrane
            // -- kalkulacije
            // -- sleep


            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 1;

            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                if (!studentiKnjigeServis.GetAll().Exists(x => x.StudentId == student.Id && x.KnjigaId == sveKnjige[i].Id) )
                {

                    Thread.Sleep(1000);

                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false
                    };



                    info += $"{redniBroj}. {student} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                    redniBroj++;


                    studentiKnjigeServis.Add(novoIznajmljivanje);
                }
             

            }

         

            Action action = () =>
            {
                // 3. TRECI DIO
                // -- mbox
                // -- ispis
                // -- ucitavanje

                UcitajStudentKnjige();
                MessageBox.Show($"Generisanje je uspješno završeno", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInfo.Text = info;

            };
            BeginInvoke(action);


        }
    }
}
