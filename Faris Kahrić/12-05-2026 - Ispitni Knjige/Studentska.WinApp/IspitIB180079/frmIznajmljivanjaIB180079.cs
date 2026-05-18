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
        KnjigaServis knjigaServis = new KnjigaServis();
        public frmIznajmljivanjaIB180079()
        {
            InitializeComponent();
        }

        private void frmIznajmljivanjaIB180079_Load(object sender, EventArgs e)
        {
            dgvStudentiKnjige.AutoGenerateColumns = false;

            UcitajComboBox();

            UcitajStudentKnjige();
        }

        private void UcitajComboBox()
        {

            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigaServis.GetAll();

        }

        private void UcitajStudentKnjige()
        {
            var studentKnjige = studentiKnjigeServis.GetAllIncluded();


            if (studentKnjige != null)
            {
                dgvStudentiKnjige.DataSource = null;
                dgvStudentiKnjige.DataSource = studentKnjige;
            }

        }

        private void btnIznajmi_Click(object sender, EventArgs e)
        {

            var knjiga = cbKnjiga.SelectedItem as KnjigeIB180079;

            var student = cbStudent.SelectedItem as Student;

            if (studentiKnjigeServis.GetAll()
                .Where(x => x.KnjigaId == knjiga.Id && x.Vracena == false)
                .Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show("Prekoračen je broj dostupnih knjiga", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentiKnjigeServis.GetAll()
                .Exists(x => x.StudentId == student.Id && x.KnjigaId == knjiga.Id && x.Vracena == false))
            {

                MessageBox.Show($"Student {student} je već iznajmio knjigu {knjiga} a prethodno je nije vratio", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                // 1. NACIN 

                var novaStudentKnjiga = new StudentiKnjigeIB180079()
                {

                    //Id = 4, Id se nikada ne smije slati
                    //Student = student, objekat klase (strani kljuc) se nikada ne smije slati
                    StudentId = student.Id,
                    KnjigaId = knjiga.Id,
                    DatumIznajmljivanja = DateTime.Now,
                    Vracena = false,

                };

                // 2. NACIN

                //var novaStudentKnjiga = new StudentiKnjigeIB180079();

                //novaStudentKnjiga.Vracena = false;

                studentiKnjigeServis.Add(novaStudentKnjiga);

                UcitajStudentKnjige();


            }



        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {

            // 1. PRVI DIO
            // -- postavljanje threada
            // -- validacije
            // -- ako imamo combo box moramo ga izvaditi ranije 

            var student = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiIznajmljivanja(student));


        }

        private void GenerisiIznajmljivanja(Student? student)
        {

            // 2. DRUGI DIO
            // -- kalkulacije
            // -- sleep
            // -- pohrane

            var info = "";

            var sveKnjige = knjigaServis.GetAll();



            for (int i = 0; i < sveKnjige.Count(); i++)
            {

                if (!studentiKnjigeServis.GetAll()
                    .Exists(x => x.StudentId == student.Id && x.KnjigaId == sveKnjige[i].Id))
                {

                    Thread.Sleep(300);

                    var novoIznajmljivanje = new StudentiKnjigeIB180079()
                    {
                        StudentId = student.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false,

                    };

                    info += $"{i + 1}. {student} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                    studentiKnjigeServis.Add(novoIznajmljivanje);
                }

            }


            Action action = () =>
            {
                // 3. TRECI DIO
                // -- mbox
                // -- ispis
                // -- ucitavanje

                MessageBox.Show($"Uspješno su generisana iznajmljivanja za studenta {student}", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UcitajStudentKnjige();

                txtInfo.Text = info;


            };
            BeginInvoke(action);

        }

        private void frmIznajmljivanjaIB180079_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
