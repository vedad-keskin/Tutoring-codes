using Studentska.Data.Entiteti;
using Studentska.Data.IspitIB180079;
using Studentska.Servis.Servisi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
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

            UcitajStudentiKnjige();

            UcitajComboBox();
        }

        private void UcitajComboBox()
        {
            cbStudent.DataSource = studentServis.GetAll();

            cbKnjiga.DataSource = knjigeServis.GetAll();

            cbKnjiga.DisplayMember = "Naziv";

        }

        private void UcitajStudentiKnjige()
        {

            var studentiKnjige = studentiKnjigeServis
                                .GetAllIncluded();



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
            x.KnjigaId == knjiga.Id &&
            x.Vracena == false)
                .ToList()
                .Count() >= knjiga.BrojPrimjeraka)
            {

                MessageBox.Show($"Knjiga {knjiga} nema dostupnih primjeraka na stanju", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (studentiKnjigeServis.GetAll().Exists(x =>
            x.StudentId == student.Id &&
            x.KnjigaId == knjiga.Id &&
            x.Vracena == false))
            {


                MessageBox.Show($"Knjiga {knjiga} je već podignuta od strane {student} a nije pritom vraćena", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // -- postavljanje threada
            // -- validacija
            // -- ako imamo combo box moramo ga pohraniti u prvom dijelu 

            var odabraniStudent = cbStudent.SelectedItem as Student;

            await Task.Run(() => GenerisiStudentiKnjige(odabraniStudent));


        }

        private void GenerisiStudentiKnjige(Student? odabraniStudent)
        {
            // 2. dio
            // -- kalkulacije
            // -- pohrane
            // -- sleep

            var sveKnjige = knjigeServis.GetAll();

            var info = "";

            var redniBroj = 1;

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

                if (!studentiKnjigeServis.GetAll().Exists(x => x.StudentId == odabraniStudent.Id && x.KnjigaId == sveKnjige[i].Id))
                {


                    Thread.Sleep(300);

                    var novaStudentKnjiga = new StudentiKnjigeIB180079()
                    {

                        StudentId = odabraniStudent.Id,
                        KnjigaId = sveKnjige[i].Id,
                        DatumIznajmljivanja = DateTime.Now,
                        Vracena = false

                    };

                    info += $"{redniBroj}. {odabraniStudent} dodato zaduzenje {sveKnjige[i]}{Environment.NewLine}";

                    redniBroj++;

                    studentiKnjigeServis.Add(novaStudentKnjiga);

                }


            }



            Action action = () =>
            {
                // 3. dio
                // -- mbox
                // -- ispisi
                // -- ucitavanje

                MessageBox.Show($"Generisanje iznajmljivanja studentu {odabraniStudent} je završeno", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajStudentiKnjige();

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
