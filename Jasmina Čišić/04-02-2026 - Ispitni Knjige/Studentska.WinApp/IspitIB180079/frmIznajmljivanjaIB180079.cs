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
using System.Transactions;
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



            //var studentiKnjige = db.StudentiKnjigeIB180079 --- .ToList();
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


            var student = cbStudent.SelectedItem as Student;
            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;

            if (studentiKnjigeServis.GetAll().Where(x =>
            x.KnjigaId == knjiga.Id
            && x.Vracena == false)
                .ToList().Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show($"Knjiga {knjiga} ima {knjiga.BrojPrimjeraka} primjeraka i svi su izdati", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (studentiKnjigeServis.GetAll().Exists(x =>
            x.StudentId == student.Id
            && x.KnjigaId == knjiga.Id &&
            x.Vracena == false
            ))
            {
                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga} ali je pritom nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                var novoIznajmljivanje = new StudentiKnjigeIB180079()
                {

                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false

                };


                studentiKnjigeServis.Add(novoIznajmljivanje);


                UcitajStudentiKnjige();

            }



        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. dio 
            // -- postavljanje threada --> async await Task
            // -- validacije
            // -- ako imamo neki combo box koji koristimo u MT onda taj podataka moramo izvaditi u prvom dijelu i prosliditi ga drugom threadu

            var student = cbStudent.SelectedItem as Student;


            await Task.Run(() => GenerisiIznajmljivanja(student));

        }

        private void GenerisiIznajmljivanja(Student? student)
        {

            // 2. dio
            // -- pohrane
            // -- kalkulacije
            // -- sleep


            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 1;


            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                //Thread.Sleep(3000);

                //var novoIznajmljivanje = new StudentiKnjigeIB180079()
                //{
                //    StudentId = student.Id,
                //    KnjigaId = sveKnjige[i].Id,
                //    DatumIznajmljivanja = DateTime.Now,
                //    Vracena = false

                //};

                //studentiKnjigeServis.Add(novoIznajmljivanje);


                if (!studentiKnjigeServis.GetAll().Exists(x =>
                x.StudentId == student.Id && x.KnjigaId == sveKnjige[i].Id))
                {


                    Thread.Sleep(300);

                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false

                    };

                    studentiKnjigeServis.Add(novoIznajmljivanje);

                    info += $"{redniBroj}. {student} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                    redniBroj++;

                }



            }





            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ispis
                // -- ucitavanja

                UcitajStudentiKnjige();

                MessageBox.Show("Generisanje je uspješno završeno", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
